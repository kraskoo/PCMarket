namespace PCMarket.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;
    using Data.DataModels;
    using Data.Interfaces;
    using Data.Repositories;
    using Managers;
    using Models.Entities.Users;
    using Models.ViewModels.Identity;
    using IdentityOperators;

    public class IdentityService : Service<IIdentityUnitOfWork>, IDisposable
    {
        private readonly AuthenticationManager authentication;

        public IdentityService(
            PcMarketContextFactory contextFactory,
            IIdentityUnitOfWork unitOfWork,
            IOwinContext context,
            IdentityUserOperator userManagar,
            RoleManager roleManager,
            IdentitySignInOperator signInManager) : base(contextFactory, unitOfWork, context)
        {
            this.UserOperator = userManagar;
            this.RoleManager = roleManager;
            this.SignInOperator = signInManager;
            this.authentication = new AuthenticationManager(this.OwinContext);
        }

        public IAuthenticationManager AuthenticationManager => this.authentication.Manager;

        public IdentityUserOperator UserOperator { get; private set; }

        public RoleManager RoleManager { get; private set; }

        public IdentitySignInOperator SignInOperator { get; private set; }

        public Task<IdentityResult> CreateAsync(User user)
        {
            return this.UserOperator.CreateAsync(user);
        }

        public User CreateUser(string email, string firstname, string lastname)
        {
            var user = new User
            {
                Email = email,
                UserName = $"{firstname} {lastname}"
            };

            return user;
        }

        public Task<IdentityResult> AddPasswordAsync(string id, string password)
        {
            return this.UserOperator.AddPasswordAsync(id, password);
        }

        public Task<IdentityResult> ChangePasswordAsync(string id, string oldPassword, string newPassword)
        {
            return this.UserOperator.ChangePasswordAsync(id, oldPassword, newPassword);
        }

        public Task<IdentityResult> ChangePhoneNumberAsync(string id, string number, string token)
        {
            return this.UserOperator.ChangePhoneNumberAsync(id, number, token);
        }

        public User FindById(string id)
        {
            return this.UserOperator.FindById(id);
        }

        public Task<User> FindByIdAsync(string id)
        {
            return this.UserOperator.FindByIdAsync(id);
        }

        public Task<string> GenerateChangePhoneNumberTokenAsync(string id, string number)
        {
            return this.UserOperator.GenerateChangePhoneNumberTokenAsync(id, number);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(string id)
        {
            return this.UserOperator.GetLoginsAsync(id);
        }

        public Task<string> GetPhoneNumberAsync(string id)
        {
            return this.UserOperator.GetPhoneNumberAsync(id);
        }

        public Task<bool> GetTwoFactorEnabledAsync(string id)
        {
            return this.UserOperator.GetTwoFactorEnabledAsync(id);
        }

        public Task<IdentityResult> RemoveLoginAsync(string id, UserLoginInfo userLoginInfo)
        {
            return this.UserOperator.RemoveLoginAsync(id, userLoginInfo);
        }

        public Task<IdentityResult> SetPhoneNumberAsync(string id, string phoneNumber)
        {
            return this.UserOperator.SetPhoneNumberAsync(id, phoneNumber);
        }

        public Task<IdentityResult> SetTwoFactorEnabledAsync(string id, bool enabled)
        {
            return this.UserOperator.SetTwoFactorEnabledAsync(id, enabled);
        }

        public IIdentityMessageService SmsService()
        {
            return this.UserOperator.SmsService();
        }

        public Task<IdentityResult> AddLoginAsync(string id, UserLoginInfo login)
        {
            return this.UserOperator.AddLoginAsync(id, login);
        }

        public Task<IdentityResult> ConfirmEmailAsync(string userId, string code)
        {
            return this.UserOperator.ConfirmEmailAsync(userId, code);
        }

        public Task<IdentityResult> CreateAsync(User user, string password)
        {
            return this.UserOperator.FindByEmailAsync(user.Email).Result != null ?
                this.UserOperator.AddPasswordAsync(user.Id, password) :
                this.UserOperator.CreateAsync(user, password);
        }

        public Task SignInAsync(User user, bool isPersistent, bool rememberBrowser)
        {
            return this.SignInOperator.SignInAsyncExt(user, isPersistent, rememberBrowser);
        }

        public Task<SignInStatus> PasswordSignInAsync(string email, string password, bool rememberMe, bool shouldLockout)
        {
            var userByEmail = this.UserOperator.FindByEmailAsync(email).Result;
            return this.SignInOperator.PasswordSignInAsync(userByEmail.UserName, password, rememberMe, shouldLockout);
        }

        public Task<IdentityResult> ResetPasswordAsync(string id, string code, string password)
        {
            return this.UserOperator.ResetPasswordAsync(id, code, password);
        }

        public Task<string> GetVerifiedUserIdAsync()
        {
            return this.SignInOperator.GetVerifiedUserIdAsync();
        }

        public Task<bool> SendTwoFactorCodeAsync(string selectedProvider)
        {
            return this.SignInOperator.SendTwoFactorCodeAsync(selectedProvider);
        }

        public Task<SignInStatus> ExternalSignInAsync(ExternalLoginInfo loginInfo, bool isPersist)
        {
            return this.SignInOperator.ExternalSignInAsync(loginInfo, isPersist);
        }

        public Task<IList<string>> GetValidTwoFactorProvidersAsync(string userId)
        {
            return this.UserOperator.GetValidTwoFactorProvidersAsync(userId);
        }

        public Task<bool> IsEmailConfirmedAsync(string id)
        {
            return this.UserOperator.IsEmailConfirmedAsyncExt(id);
        }

        public Task<User> FindByNameAsync(string email)
        {
            return this.UserOperator.FindByNameAsyncExt(email);
        }

        public User CreateUser(User user)
        {
            if (this.UnitOfWork.Identity.FindAll().Any())
            {
                this.UserOperator.Create(user);
                var regularRole = RoleManager.FindByName("Regular");
                var userRole = new IdentityUserRole
                {
                    RoleId = regularRole.Name,
                    UserId = user.Id
                };

                user.Roles.Add(userRole);
            }
            else
            {
                this.UserOperator.Create(user);
                var regularRole = RoleManager.FindByName("Admin");
                var userRole = new IdentityUserRole
                {
                    RoleId = regularRole.Name,
                    UserId = user.Id
                };

                user.Roles.Add(userRole);
            }

            return user;
        }

        public Task<SignInStatus> TwoFactorSignInAsync(VerifyCodeViewModel model)
        {
            return this.SignInOperator.TwoFactorSignInAsync(model);
        }

        public Task<bool> HasBeenVerifiedAsync()
        {
            return this.SignInOperator.HasBeenVerifiedAsync();
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return this.UserOperator.FindByEmailAsync(email);
        }

        public static IdentityService Create(PcMarketContextFactory contextFactory, IOwinContext owinContext)
        {
            return new IdentityService(
                contextFactory,
                new IdentityUnitOfWork(
                    contextFactory.DataWorker,
                    new IdentityRepository(contextFactory)),
                owinContext,
                IdentityUserOperator.Create(
                    UserManager.Create(
                        new IdentityFactoryOptions<UserManager>(),
                        owinContext)),
                RoleManager.Create(
                    new IdentityFactoryOptions<RoleManager>(),
                    owinContext),
                IdentitySignInOperator.Create(
                    ApplicationSignInManager.Create(
                        new IdentityFactoryOptions<ApplicationSignInManager>(),
                        owinContext)));
        }

        public void Dispose()
        {
            if (this.UserOperator != null || this.RoleManager != null || this.SignInOperator != null)
            {
                this.UserOperator?.Dispose();
                this.UserOperator = null;
                this.RoleManager?.Dispose();
                this.RoleManager = null;
                this.SignInOperator?.Dispose();
                this.SignInOperator = null;
            }
        }
    }
}