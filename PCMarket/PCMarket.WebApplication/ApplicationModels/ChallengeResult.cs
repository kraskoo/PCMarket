namespace PCMarket.WebApplication.ApplicationModels
{
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.Owin.Security;

    internal class ChallengeResult : HttpUnauthorizedResult
    {
        private const string XsrfKey = "XsrfId";

        public ChallengeResult(string provider, string redirectUri)
            : this(provider, redirectUri, null)
        {
        }

        public ChallengeResult(string provider, string redirectUri, string userId)
        {
            this.LoginProvider = provider;
            this.RedirectUri = redirectUri;
            this.UserId = userId;
        }

        public string LoginProvider { get; set; }

        public string RedirectUri { get; set; }

        public string UserId { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
            if (this.UserId != null)
            {
                properties.Dictionary[XsrfKey] = UserId;
            }

            context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
        }
    }
}