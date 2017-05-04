namespace PCMarket.Data.Interfaces
{
    using CrudOperations;

    public interface ICrudAdapter<in TEntity> :
        ICreateable<TEntity>,
        IUpdateable<TEntity>,
        IDeleteable<TEntity>
        where TEntity : class, new()
    {
    }
}