namespace PCMarket.Data.DataModels
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using Interfaces;

    public class DataWorker : IDataWorker
    {
        private DbContext dbContext;

        public DataWorker(DbContext factory)
        {
            this.dbContext = factory;
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return this.dbContext.SaveChangesAsync();
        }

        public void ChangeState<TEntity>(TEntity entity, EntityState newState) where TEntity : class, new()
        {
            this.dbContext.Entry(entity).State = newState;
        }

        public void Dispose()
        {
            if (this.dbContext != null)
            {
                this.dbContext.Dispose();
                this.dbContext = null;
            }
        }
    }
}