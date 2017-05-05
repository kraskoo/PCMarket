namespace PCMarket.Data.Interfaces
{
    public interface INormalRepository<T> : IRepository<T>
        where T : class, new()
    {
    }
}