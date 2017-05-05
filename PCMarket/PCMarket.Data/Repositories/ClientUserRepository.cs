namespace PCMarket.Data.Repositories
{
    using DataModels;
    using DataModels.CrudOperations;
    using Interfaces;
    using Models.Entities.Users;

    public class ClientUserRepository : PcMarketRepository<ClientUser>, IClientUserRepository
    {
        public ClientUserRepository(
            PcMarketContextFactory context,
            RepositoryCrudAdapter<ClientUser> crudAdapter) : base(
                context, crudAdapter)
        {
        }

        public ClientUserRepository(PcMarketContextFactory context) : this(
            context,
            new RepositoryCrudAdapter<ClientUser>(
                new CreateEntity<ClientUser>(context),
                new UpdateEntity<ClientUser>(context),
                new DeleteEntity<ClientUser>(context)))
        {
            
        }
    }
}