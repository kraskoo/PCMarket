namespace PCMarket.Data.Interfaces
{
    using Models.Entities.Users;

    public interface IUserRepository<T> : IPcMarketRepository<T>
        where T : ApplicationUser, new()
    {
    }
}