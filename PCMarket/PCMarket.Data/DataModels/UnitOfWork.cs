namespace PCMarket.Data.DataModels
{
    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using Enums;
    using Interfaces;

    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly IDataWorker dataWorker;

        protected UnitOfWork(IDataWorker dataWorker)
        {
            this.dataWorker = dataWorker;
        }

        public int SaveChanges()
        {
            return this.dataWorker.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.dataWorker.SaveChangesAsync();
        }

        public void ChangeState<TEntity>(TEntity entity, State state)
            where TEntity : class, new()
        {
            this.dataWorker.ChangeState(entity, this.GetOriginalState(state));
        }

        private EntityState GetOriginalState(State state)
        {
            switch (state)
            {
                case State.Added:
                    return EntityState.Added;
                case State.Deleted:
                    return EntityState.Deleted;
                case State.Detached:
                    return EntityState.Detached;
                case State.Modified:
                    return EntityState.Modified;
                case State.Unchanged:
                    return EntityState.Unchanged;
                default:
                    throw new ArgumentException("Unknown state.");
            }
        }
    }
}