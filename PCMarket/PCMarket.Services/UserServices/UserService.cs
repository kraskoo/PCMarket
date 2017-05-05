using System.Data.Entity;
using System.Text.RegularExpressions;

namespace PCMarket.Services.UserServices
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin;
    using Common.Enums;
    using Data.DataModels;
    using Data.Interfaces;
    using Data.Repositories;
    using Models.Entities.Users;

    public class UserService : Service<IUserUnitOfWork>
    {
        public UserService(
            PcMarketContextFactory contextFactory,
            IUserUnitOfWork userUnitOfWork,
            IOwinContext context,
            IdentityService identityService) : base(contextFactory, userUnitOfWork, context)
        {
            this.IdentityService = identityService;
        }

        public UserService(PcMarketContextFactory contextFactory,
            IOwinContext context) : this(
                contextFactory,
                new UserUnitOfWork(
                    contextFactory.DataWorker,
                    new AdminUserRepository(contextFactory),
                    new RegularUserRepository(contextFactory),
                    new ClientUserRepository(contextFactory)),
                context,
                IdentityService.Create(contextFactory, context))
        {
        }

        public string Layout(string id)
        {
            var role = this.GetUserRole(id);
            var layout = "~/Views/Shared/_Layout.cshtml";
            if (role == "Admin")
            {
                layout = "~/Views/Shared/_AdminLayout.cshtml";
            }

            return layout;
        }

        public IdentityService IdentityService { get; }

        public AdminUser FindAdminUserByIdentityId(string identityId)
        {
            return this.UnitOfWork.AdminUsers.Find(
                new Expression<Func<AdminUser, bool>>[]
                {
                    au => au.UserId == identityId
                });
        }

        public User CreateUser(string email, string firstname, string lastname)
        {
            var role = this.IdentityService.UserOperator.FindAll().Any() ? RoleType.Regular : RoleType.Admin;
            var user = this.IdentityService.CreateUser(email, firstname, lastname);
            if (role == RoleType.Admin)
            {
                this.UnitOfWork.AdminUsers.Create(new AdminUser
                {
                    User = user,
                    Firstname = firstname,
                    Lastname = lastname
                });

                var adminRole = this.IdentityService.RoleManager.Roles.FirstOrDefault(ir => ir.Name == RoleType.Admin.ToString());
                    adminRole?.Users.Add(new IdentityUserRole
                    {
                        RoleId = adminRole.Id,
                        UserId = user.Id
                    });
            }
            else
            {
                this.UnitOfWork.RegularUsers.Create(new RegularUser
                {
                    User = user,
                    Firstname = firstname,
                    Lastname = lastname
                });
                var regularRole = this.IdentityService.RoleManager.Roles.FirstOrDefault(ir => ir.Name == RoleType.Regular.ToString());
                regularRole?.Users.Add(new IdentityUserRole
                {
                    RoleId = regularRole.Id,
                    UserId = user.Id
                });
            }

            this.SaveChanges();
            return user;
        }

        public string GetUserRole(string id)
        {
            return this.IdentityService
                .RoleManager
                .Roles
                .FirstAsync(r => r.Users.Any(u => u.UserId == id)).Result.Name;
        }
    }
}