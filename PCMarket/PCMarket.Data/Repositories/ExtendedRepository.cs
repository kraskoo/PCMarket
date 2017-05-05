namespace PCMarket.Data.Repositories
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using DataModels;

    public abstract class PcMarketRepository<T> : Repository<ContextFactory<PcMarketContext>, T>
        where T : class, new()
    {
        private readonly RepositoryCrudAdapter<T> crudAdapter;

        protected PcMarketRepository(
            ContextFactory<PcMarketContext> context,
            RepositoryCrudAdapter<T> crudAdapter) : base(context)
        {
            this.crudAdapter = crudAdapter;
        }

        public void Create(T entity)
        {
            this.crudAdapter.Create(entity);
        }

        public async Task CreateAsync(T entity)
        {
            await this.crudAdapter.CreateAsync(entity);
        }

        public void Create(params T[] entities)
        {
            this.crudAdapter.Create(entities);
        }

        public async Task CreateAsync(params T[] entities)
        {
            await this.crudAdapter.CreateAsync(entities);
        }

        public void Update(T entity)
        {
            this.crudAdapter.Update(entity);
            this.Context.ChangeState(entity, EntityState.Modified);
        }

        public async Task UpdateAsync(T entity)
        {
            await this.crudAdapter.UpdateAsync(entity);
            this.Context.ChangeState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            this.crudAdapter.Delete(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await this.crudAdapter.DeleteAsync(entity);
        }
    }
}