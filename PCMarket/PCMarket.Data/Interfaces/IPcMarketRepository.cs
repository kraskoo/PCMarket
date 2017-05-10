namespace PCMarket.Data.Interfaces
{
    public interface IPcMarketRepository<T> : IRepository<T>, ICrudAdapter<T>
        where T : class, new()
    {
    }
}