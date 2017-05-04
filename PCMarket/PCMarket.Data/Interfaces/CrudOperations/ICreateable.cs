namespace PCMarket.Data.Interfaces.CrudOperations
{
    using System.Threading.Tasks;

    public interface ICreateable<in TEntity>
        where TEntity : class, new()
    {
        void Create(TEntity entity);

        Task CreateAsync(TEntity entity);

        void Create(params TEntity[] entities);

        Task CreateAsync(params TEntity[] entities);
    }
}