namespace PCMarket.Services
{
    using System.Threading.Tasks;
    using Microsoft.Owin;
    using Data.DataModels;
    using Data.Enums;
    using Data.Interfaces;

    public abstract class Service<T>
        where T : IUnitOfWork
    {
        protected Service(PcMarketContextFactory contextFactory, T unitOfWork, IOwinContext context)
        {
            this.ContextFactory = contextFactory;
            this.OwinContext = context;
            this.UnitOfWork = unitOfWork;
        }

        protected IOwinContext OwinContext { get; }

        protected PcMarketContextFactory ContextFactory { get; }

        protected T UnitOfWork { get; }

        public int SaveChanges()
        {
            return this.UnitOfWork.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return this.UnitOfWork.SaveChangesAsync();
        }

        public void ChangeState<TEntity>(TEntity entity, State state)
            where TEntity : class, new()
        {
            this.UnitOfWork.ChangeState(entity, state);
        }
    }
}