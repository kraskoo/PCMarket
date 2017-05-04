namespace PCMarket.Data.DataModels.CrudOperations
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using Interfaces;
    using Interfaces.CrudOperations;

    public class DeleteEntity<TEntity> : IDeleteable<TEntity>
        where TEntity : class, new()
    {
        private readonly IDbSet<TEntity> set;

        public DeleteEntity(IContextFactory<DbContext> factory)
        {
            this.set = factory.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            this.set.Remove(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                this.set.Remove(entity);
            });
        }
    }
}