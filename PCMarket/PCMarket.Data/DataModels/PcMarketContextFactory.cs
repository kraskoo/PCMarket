namespace PCMarket.Data.DataModels
{
    using Interfaces;

    public class PcMarketContextFactory : ContextFactory<PcMarketContext>, IPcMarketContextFactory
    {
        public PcMarketContextFactory(PcMarketContext context) : base(context)
        {
        }

        protected override void DisponseCore()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
                this.Context = null;
            }
        }
    }
}