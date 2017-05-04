namespace PCMarket.Services.UserServices
{
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin;
    using Data.DataModels;
    using Data.Repositories;
    using Data.Interfaces;
    using Models.Entities;
    using Common.Enums;

    public class UserService : Service
    {
        private readonly IAdminUserRepository adminRepository;
        private readonly IRegularUserRepository regularRepository;

        public UserService(
            PcMarketContextFactory contextFactory,
            IOwinContext context,
            IdentityService identityService) : base(contextFactory, context)
        {
            this.IdentityService = identityService;
            this.adminRepository = new AdminUserRepository(this.ContextFactory);
            this.regularRepository = new RegularUserRepository(this.ContextFactory);
        }

        public UserService(
            PcMarketContextFactory contextFactory,
            IOwinContext context) : this(
                contextFactory,
                context,
                IdentityService.Create(contextFactory, context))
        {
        }

        public IdentityService IdentityService { get; }

        public User CreateUser(string email, string firstname, string lastname)
        {
            var user = this.IdentityService.CreateUser(email, firstname, lastname);
            var role = UserServiceFactory.GetCurrentRole();
            var identityRoleSet = this.ContextFactory.Set<IdentityRole>();
            if (role == Role.Admin)
            {
                this.adminRepository.Create(new AdminUser
                {
                    User = user,
                    Firstname = firstname,
                    Lastname = lastname
                });

                var adminRole = identityRoleSet.FirstOrDefault(ir => ir.Name == Role.Admin.ToString());
                    adminRole?.Users.Add(new IdentityUserRole
                    {
                        RoleId = adminRole.Id,
                        UserId = user.Id
                    });
            }
            else
            {
                this.regularRepository.Create(new RegularUser
                {
                    User = user,
                    Firstname = firstname,
                    Lastname = lastname
                });
                var regularRole = identityRoleSet.FirstOrDefault(ir => ir.Name == Role.Regular.ToString());
                regularRole?.Users.Add(new IdentityUserRole
                {
                    RoleId = regularRole.Id,
                    UserId = user.Id
                });
            }

            this.SaveChanges();
            return user;
        }
    }
}