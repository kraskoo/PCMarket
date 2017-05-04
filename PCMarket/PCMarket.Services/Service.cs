namespace PCMarket.Services
{
    using System.Threading.Tasks;
    using Microsoft.Owin;
    using Data.DataModels;
    using Data.Enums;
    using Data.Interfaces;
    using Data.Repositories;

    public abstract class Service
    {
        protected Service(PcMarketContextFactory contextFactory, IOwinContext context)
        {
            this.ContextFactory = contextFactory;
            this.OwinContext = context;
            this.UnitOfWork = new PcMarketUnitOfWork(
                contextFactory.DataWorker,
                new CompanyRepository(this.ContextFactory),
                new CategoryRepository(this.ContextFactory),
                new ProductRepository(this.ContextFactory));
        }

        protected IOwinContext OwinContext { get; }

        protected PcMarketContextFactory ContextFactory { get; }

        protected IUnitOfWork UnitOfWork { get; }

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