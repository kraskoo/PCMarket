namespace PCMarket.Data.Repositories
{
    using DataModels;
    using DataModels.CrudOperations;
    using Interfaces;
    using Models.Entities.StorageDevices;

    public class HardDriveRepository : PcMarketRepository<HardDrive>, IHardDriveRepository
    {
        public HardDriveRepository(
            PcMarketContextFactory context,
            RepositoryCrudAdapter<HardDrive> crudAdapter) : base(
                context, crudAdapter)
        {
        }

        public HardDriveRepository(PcMarketContextFactory context) : this(
            context,
            new RepositoryCrudAdapter<HardDrive>(
                new CreateEntity<HardDrive>(context),
                new UpdateEntity<HardDrive>(context),
                new DeleteEntity<HardDrive>(context)))
        {
            
        }
    }
}