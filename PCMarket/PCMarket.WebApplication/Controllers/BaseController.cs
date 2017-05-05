namespace PCMarket.WebApplication.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using Common.Enums;
    using Data;
    using Data.DataModels;
    using Services.UserServices;

    public abstract class BaseController : Controller
    {
        private UserService userService;

        protected BaseController(UserService service)
        {
            this.UserService = service;
        }

        protected BaseController()
        {
            this.Context = new PcMarketContextFactory(PcMarketContext.Create());
        }

        protected bool IsInAdminRole()
        {
            return this.User.IsInRole(RoleType.Admin.ToString());
        }

        protected PcMarketContextFactory Context { get; }

        protected UserService UserService
        {
            get
            {
                return this.userService ?? (this.userService =
                           new UserService(Context, this.HttpContext.GetOwinContext()));
            }

            private set
            {
                this.userService = value;
            }
        }
    }
}