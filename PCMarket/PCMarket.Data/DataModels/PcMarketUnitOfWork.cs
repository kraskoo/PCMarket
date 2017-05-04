namespace PCMarket.Data.DataModels
{
    using Interfaces;

    public class PcMarketUnitOfWork : UnitOfWork, IPcMarketUnitOfWork
    {
        public PcMarketUnitOfWork(
            IDataWorker dataWorker,
            ICompanyRepository companies,
            ICategoryRepository categories,
            IProductRepository products) : base(dataWorker)
        {
            this.Companies = companies;
            this.Categories = categories;
            this.Products = products;
        }

        public ICompanyRepository Companies { get; }

        public ICategoryRepository Categories { get; }

        public IProductRepository Products { get; }
    }
}