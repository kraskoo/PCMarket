namespace PCMarket.Data.Interfaces
{
    using Models.Entities.Users;

    public interface IUserRepository<T> : IExtendedRepository<T>
        where T : ApplicationUser, new()
    {
    }
}