namespace PCMarket.Data.Repositories
{
    using DataModels;
    using DataModels.CrudOperations;
    using Models.Entities.News;
    using Interfaces;

    public class SoftwareNewRepository : PcMarketRepository<SoftwareNew>, ISoftwareNewRepository
    {
        public SoftwareNewRepository(
            PcMarketContextFactory context,
            RepositoryCrudAdapter<SoftwareNew> crudAdapter) : base(
                context, crudAdapter)
        {
        }

        public SoftwareNewRepository(PcMarketContextFactory context) : this(
            context,
            new RepositoryCrudAdapter<SoftwareNew>(
                new CreateEntity<SoftwareNew>(context),
                new UpdateEntity<SoftwareNew>(context),
                new DeleteEntity<SoftwareNew>(context)))
        {
        }
    }
}