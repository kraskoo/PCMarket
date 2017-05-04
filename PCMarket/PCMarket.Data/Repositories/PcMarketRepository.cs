namespace PCMarket.Data.Repositories
{
    using DataModels;
    using Interfaces.CrudOperations;

    public class PcMarketRepository<T> : Repository<PcMarketContextFactory, T>
        where T : class, new()
    {
        public PcMarketRepository(
            PcMarketContextFactory context,
            ICreateable<T> create,
            IUpdateable<T> update,
            IDeleteable<T> delete) : base(context, create, update, delete)
        {
        }

        public PcMarketRepository(PcMarketContextFactory context) : base(context)
        {
        }
    }
}