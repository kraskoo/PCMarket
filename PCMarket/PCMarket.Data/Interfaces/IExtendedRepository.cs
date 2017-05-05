namespace PCMarket.Data.Interfaces
{
    public interface IExtendedRepository<T> : IRepository<T>, ICrudAdapter<T>
        where T : class, new()
    {
    }
}