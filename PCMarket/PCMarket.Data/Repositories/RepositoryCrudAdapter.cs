namespace PCMarket.Data.Repositories
{
    using System.Threading.Tasks;
    using Interfaces.CrudOperations;

    public abstract class RepositoryCrudAdapter<TEntity> :
        ICreateable<TEntity>,
        IUpdateable<TEntity>,
        IDeleteable<TEntity>
        where TEntity : class, new()
    {
        protected RepositoryCrudAdapter(
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

        public abstract void Create(TEntity entity);

        public abstract Task CreateAsync(TEntity entity);

        public abstract void Create(params TEntity[] entities);

        public abstract Task CreateAsync(params TEntity[] entities);

        public abstract void Delete(TEntity entity);

        public abstract Task DeleteAsync(TEntity entity);

        public abstract void Update(TEntity entity);

        public abstract Task UpdateAsync(TEntity entity);
    }
}