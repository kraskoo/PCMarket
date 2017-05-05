namespace PCMarket.Services.Managers
{
    using Microsoft.Owin;
    using Microsoft.Owin.Security;

    public class AuthenticationManager
    {
        public AuthenticationManager(IAuthenticationManager authenticationManager)
        {
            this.Manager = authenticationManager;
        }

        public AuthenticationManager(IOwinContext owinContext)
        {
            this.Manager = owinContext.Authentication;
        }

        public IAuthenticationManager Manager { get; }
    }
}