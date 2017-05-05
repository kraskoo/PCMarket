namespace PCMarket.Data.Repositories
{
    using DataModels;
    using DataModels.CrudOperations;
    using Interfaces;
    using Models.Entities.Cores;

    public class MotherboardRepository : PcMarketRepository<Motherboard>, IMotherboardRepository
    {
        public MotherboardRepository(
            PcMarketContextFactory context,
            RepositoryCrudAdapter<Motherboard> crudAdapter) : base(context, crudAdapter)
        {
        }

        public MotherboardRepository(PcMarketContextFactory context) : this(
            context,
            new RepositoryCrudAdapter<Motherboard>(
                new CreateEntity<Motherboard>(context),
                new UpdateEntity<Motherboard>(context),
                new DeleteEntity<Motherboard>(context)))
        {
            
        }
    }
}