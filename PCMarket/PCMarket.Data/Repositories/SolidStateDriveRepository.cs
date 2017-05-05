namespace PCMarket.Data.Repositories
{
    using DataModels;
    using DataModels.CrudOperations;
    using Interfaces;
    using Models.Entities.StorageDevices;

    public class SolidStateDriveRepository : PcMarketRepository<SolidStateDrive>, ISolidStateRepository
    {
        public SolidStateDriveRepository(
            PcMarketContextFactory context,
            RepositoryCrudAdapter<SolidStateDrive> crudAdapter) : base(
                context, crudAdapter)
        {
        }

        public SolidStateDriveRepository(PcMarketContextFactory context) : this(
            context,
            new RepositoryCrudAdapter<SolidStateDrive>(
                new CreateEntity<SolidStateDrive>(context),
                new UpdateEntity<SolidStateDrive>(context),
                new DeleteEntity<SolidStateDrive>(context)))
        {
        }
    }
}