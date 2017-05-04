namespace PCMarket.Data.Interfaces.CrudOperations
{
    using System.Threading.Tasks;

    public interface IUpdateable<in TEntity>
        where TEntity : class, new()
    {
        void Update(TEntity entity);

        Task UpdateAsync(TEntity entity);
    }
}