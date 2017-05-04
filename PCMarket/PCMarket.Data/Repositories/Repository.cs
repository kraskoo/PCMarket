namespace PCMarket.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using DataModels;
    using DataModels.CrudOperations;
    using Interfaces.CrudOperations;

    public abstract class Repository<TContext, T> : RepositoryCrudAdapter<T>
        where TContext : ContextFactory<PcMarketContext>
        where T : class, new()
    {
        protected Repository(
            TContext context,
            ICreateable<T> create,
            IUpdateable<T> update,
            IDeleteable<T> delete) : base(
            create, update, delete)
        {
            this.Context = context;
        }

        protected Repository(TContext context) : this(
            context,
            new CreateEntity<T>(context),
            new UpdateEntity<T>(context),
            new DeleteEntity<T>(context))
        {
        }

        protected TContext Context { get; }

        public override void Create(T entity)
        {
            this.Createable.Create(entity);
        }

        public override async Task CreateAsync(T entity)
        {
            await this.Createable.CreateAsync(entity);
        }

        public override void Create(params T[] entities)
        {
            this.Createable.Create(entities);
        }

        public override async Task CreateAsync(params T[] entities)
        {
            await this.Createable.CreateAsync(entities);
        }

        public override void Update(T entity)
        {
            this.Updateable.Update(entity);
            this.Context.ChangeState(entity, EntityState.Modified);
        }

        public override async Task UpdateAsync(T entity)
        {
            await this.Updateable.UpdateAsync(entity);
            this.Context.ChangeState(entity, EntityState.Modified);
        }

        public override void Delete(T entity)
        {
            this.Deleteable.Delete(entity);
        }

        public override async Task DeleteAsync(T entity)
        {
            await this.Deleteable.DeleteAsync(entity);
        }

        public virtual T Find(Expression<Func<T, bool>>[] wheres)
        {
            var set = this.Context.Set<T>().Where(wheres[0]);
            if (wheres.Length == 1)
            {
                return set.FirstOrDefault();
            }

            for (var i = 1; i < wheres.Length; i++)
            {
                set = set.Where(wheres[i]);
            }

            return set.FirstOrDefault();
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>>[] wheres)
        {
            var set = this.Context.Set<T>().Where(wheres[0]);
            if (wheres.Length == 1)
            {
                return await set.FirstOrDefaultAsync();
            }

            for (var i = 1; i < wheres.Length; i++)
            {
                set = set.Where(wheres[1]);
            }

            return await set.FirstOrDefaultAsync();
        }

        public virtual IQueryable<T> FindAll(params Expression<Func<T, bool>>[] wheres)
        {
            var set = this.Context.Set<T>();
            var query = set.Where(wheres[0]);
            if (wheres.Length == 1)
            {
                return query;
            }

            for (var i = 1; i < wheres.Length; i++)
            {
                query = query.Where(wheres[i]);
            }

            return query;
        }
    }
}