namespace PCMarket.Data.Repositories
{
    using DataModels;
    using Interfaces;
    using Interfaces.CrudOperations;
    using Models.Entities;

    public class RegularUserRepository : PcMarketRepository<RegularUser>, IRegularUserRepository
    {
        public RegularUserRepository(
            PcMarketContextFactory context,
            ICreateable<RegularUser> create,
            IUpdateable<RegularUser> update,
            IDeleteable<RegularUser> delete) : base(context, create, update, delete)
        {
        }

        public RegularUserRepository(PcMarketContextFactory context) : base(context)
        {
        }
    }
}