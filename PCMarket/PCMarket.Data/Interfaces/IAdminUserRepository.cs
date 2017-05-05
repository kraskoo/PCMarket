namespace PCMarket.Data.Interfaces
{
    using Models.Entities.Users;

    public interface IAdminUserRepository : IUserRepository<AdminUser>
    {
    }
}