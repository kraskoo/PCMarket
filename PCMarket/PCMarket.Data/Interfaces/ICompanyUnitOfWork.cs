namespace PCMarket.Data.Interfaces
{
    public interface ICompanyUnitOfWork : IUnitOfWork
    {
        ICompanyRepository Companies { get; }
    }
}