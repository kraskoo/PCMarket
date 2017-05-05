namespace PCMarket.Data.Repositories
{
    using DataModels;
    using DataModels.CrudOperations;
    using Interfaces;
    using Models.Entities.Softwares;

    public class SoftwareRepository : PcMarketRepository<Software>, ISoftwareRepository
    {
        public SoftwareRepository(
            PcMarketContextFactory context,
            RepositoryCrudAdapter<Software> crudAdapter) : base(
                context, crudAdapter)
        {
        }

        public SoftwareRepository(PcMarketContextFactory context) : this(
            context,
            new RepositoryCrudAdapter<Software>(
                new CreateEntity<Software>(context),
                new UpdateEntity<Software>(context),
                new DeleteEntity<Software>(context)))
        {
            
        }
    }
}