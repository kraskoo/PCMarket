namespace PCMarket.Data.Repositories
{
    using DataModels;
    using Models.Entities;
    using Interfaces;
    using Interfaces.CrudOperations;

    public class IdentityRepository : PcMarketRepository<User>, IIdentityRepository
    {
        public IdentityRepository(
            PcMarketContextFactory context,
            ICreateable<User> create,
            IUpdateable<User> update,
            IDeleteable<User> delete) : base(context, create, update, delete)
        {
        }

        public IdentityRepository(PcMarketContextFactory context) : base(context)
        {
        }
    }
}