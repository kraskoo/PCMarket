namespace PCMarket.Data.DataModels.CrudOperations
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using Interfaces;
    using Interfaces.CrudOperations;

    public class UpdateEntity<TEntity> : IUpdateable<TEntity>
        where TEntity : class, new()
    {
        private readonly IDbSet<TEntity> set;

        public UpdateEntity(IContextFactory<DbContext> factory)
        {
            this.set = factory.Set<TEntity>();
        }

        public void Update(TEntity entity)
        {
            this.set.Attach(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                this.set.Attach(entity);
            });
        }
    }
}