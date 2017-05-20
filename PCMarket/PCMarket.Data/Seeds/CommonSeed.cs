namespace PCMarket.Data.Seeds
{
    using Interfaces;

    public class CommonSeed : IPcMarketContextSeed
    {
        public void Seed(PcMarketContext context)
        {
            new IdentityRolesSeed().Seed(context);
            new HardwareNewsSeed().Seed(context);
            new SoftwareNewsSeed().Seed(context);
        }
    }
}