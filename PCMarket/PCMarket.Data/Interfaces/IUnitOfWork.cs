namespace PCMarket.Data.Interfaces
{
    using System.Threading.Tasks;
    using Enums;

    public interface IUnitOfWork
    {
        void ChangeState<TEntity>(TEntity entity, State state)
            where TEntity : class, new();

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}