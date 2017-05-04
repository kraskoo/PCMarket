namespace PCMarket.Services.IdentityOperators
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity.Owin;
    using Managers;
    using Models.Entities;
    using Models.ViewModels.Identity;

    public class IdentitySignInOperator : IDisposable
    {
        private ApplicationSignInManager signInManager;

        public IdentitySignInOperator(ApplicationSignInManager signInManager)
        {
            this.signInManager = signInManager;
        }

        public Task<SignInStatus> ExternalSignInAsync(ExternalLoginInfo loginInfo, bool isPersist)
        {
            return this.signInManager.ExternalSignInAsync(loginInfo, isPersist);
        }

        public Task<string> GetVerifiedUserIdAsync()
        {
            return this.signInManager.GetVerifiedUserIdAsync();
        }

        public Task<bool> HasBeenVerifiedAsync()
        {
            return this.signInManager.HasBeenVerifiedAsync();
        }

        public Task<SignInStatus> PasswordSignInAsync(string email, string password, bool rememberMe, bool shouldLock)
        {
            return this.signInManager.PasswordSignInAsync(email, password, rememberMe, shouldLock);
        }

        public Task<bool> SendTwoFactorCodeAsync(string selectedProvider)
        {
            return this.signInManager.SendTwoFactorCodeAsync(selectedProvider);
        }

        public Task SignInAsyncExt(User user, bool isPersistent, bool rememberBrowser)
        {
            return this.signInManager.SignInAsync(user, isPersistent, rememberBrowser);
        }

        public Task<SignInStatus> TwoFactorSignInAsync(VerifyCodeViewModel model)
        {
            return this.signInManager.TwoFactorSignInAsync(model.Provider, model.Code, model.RememberMe, model.RememberBrowser);
        }

        public static IdentitySignInOperator Create(ApplicationSignInManager signInManager)
        {
            return new IdentitySignInOperator(signInManager);
        }

        public void Dispose()
        {
            if (this.signInManager != null)
            {
                this.signInManager.Dispose();
                this.signInManager = null;
            }
        }
    }
}