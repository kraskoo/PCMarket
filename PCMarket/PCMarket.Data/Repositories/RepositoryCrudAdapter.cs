namespace PCMarket.Data.Repositories
{
    using System.Threading.Tasks;
    using Interfaces.CrudOperations;

    public class RepositoryCrudAdapter<TEntity> :
        ICreateable<TEntity>,
        IUpdateable<TEntity>,
        IDeleteable<TEntity>
        where TEntity : class, new()
    {
        public RepositoryCrudAdapter(
            ICreateable<TEntity> create,
            IUpdateable<TEntity> update,
            IDeleteable<TEntity> delete)
        {
            this.Createable = create;
            this.Updateable = update;
            this.Deleteable = delete;
        }

        protected ICreateable<TEntity> Createable { get; }

        protected IUpdateable<TEntity> Updateable { get; }

        protected IDeleteable<TEntity> Deleteable { get; }

        public void Create(TEntity entity)
        {
            this.Createable.Create(entity);
        }

        public Task CreateAsync(TEntity entity)
        {
            return this.Createable.CreateAsync(entity);
        }

        public void Create(params TEntity[] entities)
        {
            this.Createable.Create(entities);
        }

        public Task CreateAsync(params TEntity[] entities)
        {
            return this.Createable.CreateAsync(entities);
        }

        public void Delete(TEntity entity)
        {
            this.Deleteable.Delete(entity);
        }

        public Task DeleteAsync(TEntity entity)
        {
            return this.Deleteable.DeleteAsync(entity);
        }

        public void Update(TEntity entity)
        {
            this.Updateable.Update(entity);
        }

        public Task UpdateAsync(TEntity entity)
        {
            return this.Updateable.UpdateAsync(entity);
        }
    }
}