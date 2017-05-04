namespace PCMarket.Data.Repositories
{
    using DataModels;
    using Models.Entities;
    using Interfaces;
    using Interfaces.CrudOperations;

    public class CompanyRepository : PcMarketRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(
            PcMarketContextFactory context,
            ICreateable<Company> create,
            IUpdateable<Company> update,
            IDeleteable<Company> delete) : base(context, create, update, delete)
        {
        }

        public CompanyRepository(PcMarketContextFactory context) : base(context)
        {
        }
    }
}