namespace PCMarket.Data.Repositories
{
    using DataModels;
    using DataModels.CrudOperations;
    using Interfaces;
    using Models.Entities.Users;

    public class AdminUserRepository : PcMarketRepository<AdminUser>, IAdminUserRepository
    {
        public AdminUserRepository(
            PcMarketContextFactory context,
            RepositoryCrudAdapter<AdminUser> crudAdapter) : base(
                context, crudAdapter)
        {
        }

        public AdminUserRepository(PcMarketContextFactory context) : this(
            context,
            new RepositoryCrudAdapter<AdminUser>(
                new CreateEntity<AdminUser>(context),
                new UpdateEntity<AdminUser>(context),
                new DeleteEntity<AdminUser>(context)))
        {
        }
    }
}