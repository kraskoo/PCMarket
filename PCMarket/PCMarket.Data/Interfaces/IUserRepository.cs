namespace PCMarket.Data.Interfaces
{
    using Models.Entities;

    public interface IUserRepository<T> : IRepository<T>
        where T : ApplicationUser, new()
    {
    }
}