namespace PCMarket.Data.Repositories
{
    using DataModels;
    using DataModels.CrudOperations;
    using Interfaces;
    using Models.Entities.Cores;

    public class ProcessorRepository : PcMarketRepository<Processor>, IProcessorRepository
    {
        public ProcessorRepository(
            PcMarketContextFactory context,
            RepositoryCrudAdapter<Processor> crudAdapter) : base(
                context, crudAdapter)
        {
        }

        public ProcessorRepository(PcMarketContextFactory context) : this(
            context,
            new RepositoryCrudAdapter<Processor>(
                new CreateEntity<Processor>(context),
                new UpdateEntity<Processor>(context),
                new DeleteEntity<Processor>(context)))
        {
        }
    }
}