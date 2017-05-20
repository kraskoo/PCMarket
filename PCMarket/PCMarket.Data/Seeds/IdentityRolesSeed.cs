namespace PCMarket.Data.Seeds
{
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Common.Enums;
    using Interfaces;

    public class IdentityRolesSeed : IPcMarketContextSeed
    {
        public void Seed(PcMarketContext context)
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