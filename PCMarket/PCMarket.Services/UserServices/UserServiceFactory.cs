namespace PCMarket.Services.UserServices
{
    using System.Linq;
    using Common.Enums;
    using Data;

    internal class UserServiceFactory
    {
        private static PcMarketContext dbContext;

        internal static Role GetCurrentRole()
        {
            if (dbContext == null)
            {
                dbContext = PcMarketContext.Create();
            }

            return dbContext.Users.Any() ? Role.Regular : Role.Admin;
        }
    }
}