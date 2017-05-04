namespace PCMarket.Data.DataModels.CrudOperations
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using Interfaces;
    using Interfaces.CrudOperations;

    public class CreateEntity<TEntity> : ICreateable<TEntity>
        where TEntity : class, new()
    {
        private readonly IDbSet<TEntity> set;

        public CreateEntity(IContextFactory<DbContext> factory)
        {
            this.set = factory.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            this.set.Add(entity);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                this.set.Add(entity);
            });
        }

        public void Create(params TEntity[] entities)
        {
            foreach (var entity in entities)
            {
                this.set.Add(entity);
            }
        }

        public async Task CreateAsync(params TEntity[] entities)
        {
            await Task.Run(() =>
            {
                foreach (var entity in entities)
                {
                    this.set.Add(entity);
                }
            });
        }
    }
}