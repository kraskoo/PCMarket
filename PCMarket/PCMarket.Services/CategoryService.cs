namespace PCMarket.Services
{
    using Microsoft.Owin;
    using Data.DataModels;
    using Data.Interfaces;
    using Data.Repositories;


    public class CategoryService : Service
    {
        private ICategoryRepository categoryRepository;

        public CategoryService(
            PcMarketContextFactory contextFactory,
            IOwinContext context) : base(
                contextFactory, context)
        {
            this.categoryRepository = new CategoryRepository(this.ContextFactory);
        }
    }
}