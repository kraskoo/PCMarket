namespace PCMarket.Services.Managers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Data;
    using Data.Interfaces;
    using Models.Entities.Users;

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class UserManager : UserManager<User>, IRepository<User>
    {
        public UserManager(IUserStore<User> store) : base(store)
        {
        }

        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            var manager = new UserManager(new UserStore<User>(context.Get<PcMarketContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<User>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<User>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }

        public User Find(Expression<Func<User, bool>>[] wheres)
        {
            var set = this.Users.Where(wheres[0]);
            if (wheres.Length == 1)
            {
                return set.FirstOrDefault();
            }

            for (var i = 1; i < wheres.Length; i++)
            {
                set = set.Where(wheres[i]);
            }

            return set.FirstOrDefault();
        }

        public async Task<User> FindAsync(Expression<Func<User, bool>>[] wheres)
        {
            var set = this.Users.Where(wheres[0]);
            if (wheres.Length == 1)
            {
                return await set.FirstOrDefaultAsync();
            }

            for (var i = 1; i < wheres.Length; i++)
            {
                set = set.Where(wheres[1]);
            }

            return await set.FirstOrDefaultAsync();
        }

        public IQueryable<User> FindAll(params Expression<Func<User, bool>>[] wheres)
        {
            if (wheres.Length == 0)
            {
                return this.Users;
            }

            var set = this.Users;
            var query = set.Where(wheres[0]);
            if (wheres.Length == 1)
            {
                return query;
            }

            for (var i = 1; i < wheres.Length; i++)
            {
                query = query.Where(wheres[i]);
            }

            return query;
        }
    }
}