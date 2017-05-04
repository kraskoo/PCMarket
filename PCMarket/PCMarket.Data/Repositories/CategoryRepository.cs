namespace PCMarket.Data.Repositories
{
    using DataModels;
    using Models.Entities;
    using Interfaces;
    using Interfaces.CrudOperations;

    public class CategoryRepository : Repository<PcMarketContextFactory, Category>, ICategoryRepository
    {
        public CategoryRepository(
            PcMarketContextFactory context,
            ICreateable<Category> create,
            IUpdateable<Category> update,
            IDeleteable<Category> delete) : base(context, create, update, delete)
        {
        }

        public CategoryRepository(PcMarketContextFactory context) : base(context)
        {
        }
    }
}