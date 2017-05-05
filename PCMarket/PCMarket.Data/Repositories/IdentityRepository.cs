namespace PCMarket.Data.Repositories
{
    using DataModels;
    using Interfaces;
    using Models.Entities.Users;

    public class IdentityRepository : Repository<PcMarketContextFactory, User>, IIdentityRepository
    {
        public IdentityRepository(PcMarketContextFactory context) : base(context)
        {
        }
    }
}