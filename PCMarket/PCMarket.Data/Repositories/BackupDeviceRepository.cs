namespace PCMarket.Data.Repositories
{
    using DataModels;
    using DataModels.CrudOperations;
    using Interfaces;
    using Models.Entities.StorageDevices;

    public class BackupDeviceRepository : PcMarketRepository<BackupDevice>, IBackupRepository
    {
        public BackupDeviceRepository(
            PcMarketContextFactory context,
            RepositoryCrudAdapter<BackupDevice> crudAdapter) : base(
                context, crudAdapter)
        {
        }

        public BackupDeviceRepository(PcMarketContextFactory context) : this(
            context,
            new RepositoryCrudAdapter<BackupDevice>(
                new CreateEntity<BackupDevice>(context),
                new UpdateEntity<BackupDevice>(context),
                new DeleteEntity<BackupDevice>(context)))
        {
        }
    }
}