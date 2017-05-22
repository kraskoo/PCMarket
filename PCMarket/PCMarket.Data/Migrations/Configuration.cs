namespace PCMarket.Data.Migrations
{
    using Seeds;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<PcMarketContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PcMarketContext context)
        {
            new CommonSeed().Seed(context);
        }
    }
}