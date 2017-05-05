namespace PCMarket.Data.Repositories
{
    using DataModels;
    using DataModels.CrudOperations;
    using Models.Entities.News;
    using Interfaces;

    public class HardwareNewRepository : PcMarketRepository<HardwareNew>, IHardwareNewRepository
    {
        public HardwareNewRepository(
            PcMarketContextFactory context,
            RepositoryCrudAdapter<HardwareNew> crudAdapter) : base(context, crudAdapter)
        {
        }

        public HardwareNewRepository(PcMarketContextFactory context) : this(
            context,
            new RepositoryCrudAdapter<HardwareNew>(
                new CreateEntity<HardwareNew>(context),
                new UpdateEntity<HardwareNew>(context),
                new DeleteEntity<HardwareNew>(context)))
        {
            
        }
    }
}