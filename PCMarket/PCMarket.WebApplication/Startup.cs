[assembly: Microsoft.Owin.OwinStartup(typeof(PCMarket.WebApplication.Startup))]
namespace PCMarket.WebApplication
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}