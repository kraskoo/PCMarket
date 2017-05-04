namespace PCMarket.Data.Interfaces
{
    public interface IPcMarketUnitOfWork : IUnitOfWork
    {
        ICompanyRepository Companies { get; }

        ICategoryRepository Categories { get; }

        IProductRepository Products { get; }
    }
}