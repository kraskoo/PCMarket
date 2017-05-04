namespace PCMarket.Services
{
    using Microsoft.Owin;
    using Data.DataModels;
    using Data.Interfaces;
    using Data.Repositories;
    using Interfaces;

    public class CompanyService : Service, ICompanyService
    {
        private ICompanyRepository companyRepository;

        public CompanyService(
            PcMarketContextFactory contextFactory,
            IOwinContext context) : base(
                contextFactory, context)
        {
            this.companyRepository = new CompanyRepository(this.ContextFactory);
        }

        public void AddCompany()
        {
            // TODO: Implement concrete logic
        }

        public void EditCompany()
        {
            // TODO: Implement concrete logic
        }

        public void DeleteCompany()
        {
            // TODO: Implement concrete logic
        }
    }
}