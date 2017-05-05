namespace PCMarket.Data.DataModels
{
    using Interfaces;

    public class CompanyUnitOfWork : UnitOfWork, ICompanyUnitOfWork
    {
        public CompanyUnitOfWork(
            IDataWorker dataWorker,
            ICompanyRepository repository) : base(dataWorker)
        {
            this.Companies = repository;
        }

        public ICompanyRepository Companies { get; }
    }
}