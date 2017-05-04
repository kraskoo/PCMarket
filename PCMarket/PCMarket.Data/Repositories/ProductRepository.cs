namespace PCMarket.Data.Repositories
{
    using DataModels;
    using Models.Entities;
    using Interfaces;
    using Interfaces.CrudOperations;

    public class ProductRepository : PcMarketRepository<Product>, IProductRepository
    {
        public ProductRepository(
            PcMarketContextFactory context,
            ICreateable<Product> create,
            IUpdateable<Product> update,
            IDeleteable<Product> delete) : base(context, create, update, delete)
        {
        }

        public ProductRepository(PcMarketContextFactory context) : base(context)
        {
        }
    }
}