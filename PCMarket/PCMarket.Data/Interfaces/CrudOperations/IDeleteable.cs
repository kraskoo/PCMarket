namespace PCMarket.Data.Interfaces.CrudOperations
{
    using System.Threading.Tasks;

    public interface IDeleteable<in TEntity>
        where TEntity : class, new()
    {
        void Delete(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}