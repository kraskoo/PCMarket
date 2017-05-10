namespace PCMarket.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Common.Enums;

    internal sealed class Configuration : DbMigrationsConfiguration<PcMarketContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PcMarketContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.Add(new IdentityRole(RoleType.Admin.ToString()));
                context.Roles.Add(new IdentityRole(RoleType.Client.ToString()));
                context.Roles.Add(new IdentityRole(RoleType.Regular.ToString()));
            }
        }
    }
}