namespace PCMarket.Data.Repositories
{
    using Interfaces;
    using Interfaces.CrudOperations;
    using DataModels;
    using Models.Entities;

    public class AdminUserRepository : PcMarketRepository<AdminUser>, IAdminUserRepository
    {
        public AdminUserRepository(
            PcMarketContextFactory context,
            ICreateable<AdminUser> create,
            IUpdateable<AdminUser> update,
            IDeleteable<AdminUser> delete) : base(context, create, update, delete)
        {
        }

        public AdminUserRepository(PcMarketContextFactory context) : base(context)
        {
        }
    }
}