namespace PCMarket.Data.Repositories
{
    using DataModels;
    using DataModels.CrudOperations;
    using Interfaces;
    using Models.Entities.Users;

    public class RegularUserRepository : PcMarketRepository<RegularUser>, IRegularUserRepository
    {
        public RegularUserRepository(
            PcMarketContextFactory context,
            RepositoryCrudAdapter<RegularUser> crudAdapter) : base(
                context, crudAdapter)
        {
        }

        public RegularUserRepository(PcMarketContextFactory context) : this(
            context,
            new RepositoryCrudAdapter<RegularUser>(
                new CreateEntity<RegularUser>(context),
                new UpdateEntity<RegularUser>(context),
                new DeleteEntity<RegularUser>(context)))
        {
            
        }
    }
}