namespace PCMarket.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using DataModels;

    public class Repository<TContext, T>
        where TContext : ContextFactory<PcMarketContext>
        where T : class, new()
    {
        public Repository(TContext context)
        {
            this.Context = context;
        }

        protected TContext Context { get; }

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
            if (wheres.Length == 0)
            {
                return this.Context.Set<T>();
            }

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