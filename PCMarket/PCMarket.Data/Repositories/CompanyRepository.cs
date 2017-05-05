namespace PCMarket.Data.Repositories
{
    using DataModels;
    using DataModels.CrudOperations;
    using Models.Entities;
    using Interfaces;

    public class CompanyRepository : PcMarketRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(
            PcMarketContextFactory context,
            RepositoryCrudAdapter<Company> crudAdapter) : base(
                context, crudAdapter)
        {
        }

        public CompanyRepository(PcMarketContextFactory context) : this(
            context,
            new RepositoryCrudAdapter<Company>(
                new CreateEntity<Company>(context),
                new UpdateEntity<Company>(context),
                new DeleteEntity<Company>(context)))
        {
            
        }
    }
}