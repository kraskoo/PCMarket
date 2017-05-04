namespace PCMarket.WebApplication.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;
    using ApplicationModels;
    using Data;
    using Data.DataModels;
    using Services.UserServices;
    using Enums;
    using Models.ViewModels.Identity;

    [Authorize]
    public class ManageController : Controller
    {
        private UserService userService;

        public ManageController()
        {
        }

        public ManageController(UserService service)
        {
            this.UserService = service;
        }

        public UserService UserService
        {
            get
            {
                return this.userService ?? (this.userService = new UserService(
                    new PcMarketContextFactory(PcMarketContext.Create()),
                    this.HttpContext.GetOwinContext()));
            }

            private set
            {
                this.userService = value;
            }
        }

        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            this.ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";

            var userId = this.User.Identity.GetUserId();
            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = await this.UserService.IdentityService.GetPhoneNumberAsync(userId),
                TwoFactor = await this.UserService.IdentityService.GetTwoFactorEnabledAsync(userId),
                Logins = await this.UserService.IdentityService.GetLoginsAsync(userId),
                BrowserRemembered = await this.AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
            };

            return this.View(model);
        }

        //
        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ManageMessageId? message;
            var result = await this.UserService.IdentityService.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await this.UserService.IdentityService.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await this.UserService.IdentityService.SignInAsync(user, false, false);
                }

                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }

            return this.RedirectToAction("ManageLogins", new { Message = message });
        }

        //
        // GET: /Manage/AddPhoneNumber
        public ActionResult AddPhoneNumber()
        {
            return this.View();
        }

        //
        // POST: /Manage/AddPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            // Generate the token and send it
            var code = await this.UserService.IdentityService.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.Number);
            if (this.UserService.IdentityService.SmsService() != null)
            {
                var message = new IdentityMessage
                {
                    Destination = model.Number,
                    Body = "Your security code is: " + code
                };

                await this.UserService.IdentityService.SmsService().SendAsync(message);
            }

            return this.RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
        }

        //
        // POST: /Manage/EnableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EnableTwoFactorAuthentication()
        {
            await this.UserService.IdentityService.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), true);
            var user = await this.UserService.IdentityService.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await this.UserService.IdentityService.SignInAsync(user, false, false);
            }

            return this.RedirectToAction("Index", "Manage");
        }

        //
        // POST: /Manage/DisableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DisableTwoFactorAuthentication()
        {
            await this.UserService.IdentityService.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), false);
            var user = await this.UserService.IdentityService.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await this.UserService.IdentityService.SignInAsync(user, false, false);
            }

            return this.RedirectToAction("Index", "Manage");
        }

        //
        // GET: /Manage/VerifyPhoneNumber
        public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            var code = await this.UserService.IdentityService.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), phoneNumber);
            // Send an SMS through the SMS provider to verify the phone number
            return phoneNumber == null ? this.View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        }

        //
        // POST: /Manage/VerifyPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = await this.UserService.IdentityService.ChangePhoneNumberAsync(User.Identity.GetUserId(), model.PhoneNumber, model.Code);
            if (result.Succeeded)
            {
                var user = await this.UserService.IdentityService.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await this.UserService.IdentityService.SignInAsync(user, false, false);
                }
                return this.RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
            }
            // If we got this far, something failed, redisplay form
            this.ModelState.AddModelError("", "Failed to verify phone");
            return this.View(model);
        }

        //
        // POST: /Manage/RemovePhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemovePhoneNumber()
        {
            var result = await this.UserService.IdentityService.SetPhoneNumberAsync(this.User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return this.RedirectToAction("Index", new { Message = ManageMessageId.Error });
            }

            var user = await this.UserService.IdentityService.FindByIdAsync(this.User.Identity.GetUserId());
            if (user != null)
            {
                await this.UserService.IdentityService.SignInAsync(user, false, false);
            }

            return this.RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = await this.UserService.IdentityService.ChangePasswordAsync(this.User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await this.UserService.IdentityService.FindByIdAsync(this.User.Identity.GetUserId());
                if (user != null)
                {
                    await this.UserService.IdentityService.SignInAsync(user, false, false);
                }

                return this.RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }

            this.AddErrors(result);
            return this.View(model);
        }

        //
        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
        {
            return this.View();
        }

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var result = await this.UserService.IdentityService.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                if (result.Succeeded)
                {
                    var user = await this.UserService.IdentityService.FindByIdAsync(User.Identity.GetUserId());
                    if (user != null)
                    {
                        await this.UserService.IdentityService.SignInAsync(user, false, false);
                    }

                    return this.RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }

                this.AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }

        //
        // GET: /Manage/ManageLogins
        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            this.ViewBag.StatusMessage =
                message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            var user = await this.UserService.IdentityService.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return this.View("Error");
            }

            var userLogins = await this.UserService.IdentityService.GetLoginsAsync(this.User.Identity.GetUserId());
            var otherLogins = this.AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
            this.ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            return this.View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins
            });
        }

        //
        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new ChallengeResult(provider, this.Url.Action("LinkLoginCallback", "Manage"), this.User.Identity.GetUserId());
        }

        //
        // GET: /Manage/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await this.AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, this.User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return this.RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }

            var result = await this.UserService.IdentityService.AddLoginAsync(this.User.Identity.GetUserId(), loginInfo.Login);
            return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }

#region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager =>
            HttpContext.GetOwinContext().Authentication;

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = this.UserService.IdentityService.FindById(User.Identity.GetUserId());
            return user?.PasswordHash != null;
        }

        private bool HasPhoneNumber()
        {
            var user = this.UserService.IdentityService.FindById(User.Identity.GetUserId());
            return user?.PhoneNumber != null;
        }

#endregion
    }
}