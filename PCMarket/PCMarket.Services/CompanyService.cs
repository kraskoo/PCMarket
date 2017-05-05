namespace PCMarket.Services
{
    using Microsoft.Owin;
    using Data.DataModels;
    using Data.Interfaces;
    using Interfaces;

    public class CompanyService : Service<ICompanyUnitOfWork>, ICompanyService
    {
        public CompanyService(
            PcMarketContextFactory contextFactory,
            ICompanyUnitOfWork unitOfWork,
            IOwinContext context) : base(
                contextFactory, unitOfWork, context)
        {
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