namespace PCMarket.Services.IdentityOperators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Managers;
    using Models.Entities.Users;

    public class IdentityUserOperator : IDisposable
    {
        private UserManager userManager;

        public IdentityUserOperator(UserManager userManager)
        {
            this.userManager = userManager;
        }

        public void Create(User user)
        {
            this.userManager.Create(user);
        }

        public Task<IdentityResult> CreateAsync(User user)
        {
            return this.userManager.CreateAsync(user);
        }

        public Task<IdentityResult> CreateAsync(User user, string password)
        {
            return this.userManager.CreateAsync(user, password);
        }

        public Task<IdentityResult> AddPasswordAsync(string id, string password)
        {
            return this.userManager.AddPasswordAsync(id, password);
        }

        public Task<IdentityResult> AddLoginAsync(string id, UserLoginInfo login)
        {
            return this.userManager.AddLoginAsync(id, login);
        }

        public Task<IdentityResult> ChangePasswordAsync(string id, string oldPassword, string newPassword)
        {
            return this.userManager.ChangePasswordAsync(id, oldPassword, newPassword);
        }

        public Task<IdentityResult> ChangePhoneNumberAsync(string id, string number, string token)
        {
            return this.userManager.ChangePhoneNumberAsync(id, number, token);
        }

        public User FindById(string id)
        {
            return this.userManager.FindById(id);
        }

        public Task<User> FindByIdAsync(string id)
        {
            return this.userManager.FindByIdAsync(id);
        }

        public Task<string> GenerateChangePhoneNumberTokenAsync(string id, string number)
        {
            return this.userManager.GenerateChangePhoneNumberTokenAsync(id, number);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(string id)
        {
            return this.userManager.GetLoginsAsync(id);
        }

        public Task<bool> GetTwoFactorEnabledAsync(string id)
        {
            return this.userManager.GetTwoFactorEnabledAsync(id);
        }

        public Task<string> GetPhoneNumberAsync(string id)
        {
            return this.userManager.GetPhoneNumberAsync(id);
        }

        public Task<IList<string>> GetValidTwoFactorProvidersAsync(string userId)
        {
            return this.userManager.GetValidTwoFactorProvidersAsync(userId);
        }

        public Task<IdentityResult> RemoveLoginAsync(string id, UserLoginInfo userLoginInfo)
        {
            return this.userManager.RemoveLoginAsync(id, userLoginInfo);
        }

        public Task<IdentityResult> SetPhoneNumberAsync(string id, string phoneNumber)
        {
            return this.userManager.SetPhoneNumberAsync(id, phoneNumber);
        }

        public Task<IdentityResult> SetTwoFactorEnabledAsync(string id, bool enabled)
        {
            return this.userManager.SetTwoFactorEnabledAsync(id, enabled);
        }

        public IIdentityMessageService SmsService()
        {
            return this.userManager.SmsService;
        }

        public Task<bool> IsEmailConfirmedAsyncExt(string id)
        {
            return this.userManager.IsEmailConfirmedAsync(id);
        }

        public Task<User> FindByNameAsyncExt(string email)
        {
            return this.userManager.FindByNameAsync(email);
        }

        public IQueryable<User> FindAll()
        {
            return this.userManager.FindAll();
        }

        public Task<IdentityResult> ResetPasswordAsync(string id, string code, string password)
        {
            return this.userManager.ResetPasswordAsync(id, code, password);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return this.userManager.FindByEmailAsync(email);
        }

        public Task<IdentityResult> ConfirmEmailAsync(string userId, string code)
        {
            return this.userManager.ConfirmEmailAsync(userId, code);
        }

        public static IdentityUserOperator Create(UserManager manager)
        {
            return new IdentityUserOperator(manager);
        }

        public void Dispose()
        {
            if (this.userManager != null)
            {
                this.userManager.Dispose();
                this.userManager = null;
            }
        }
    }
}