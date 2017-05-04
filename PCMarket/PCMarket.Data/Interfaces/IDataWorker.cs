namespace PCMarket.Data.Interfaces
{
    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public interface IDataWorker : IDisposable
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();

        void ChangeState<TEntity>(TEntity entity, EntityState newState)
            where TEntity : class, new();
    }
}