namespace PCMarket.Data.Repositories
{
    using DataModels;
    using DataModels.CrudOperations;
    using Interfaces;
    using Models.Entities.StorageDevices;

    public class UsbFlashRepository : PcMarketRepository<UsbFlash>, IUsbFlashRepository
    {
        public UsbFlashRepository(
            PcMarketContextFactory context,
            RepositoryCrudAdapter<UsbFlash> crudAdapter) : base(context, crudAdapter)
        {
        }

        public UsbFlashRepository(PcMarketContextFactory context) : this(
            context,
            new RepositoryCrudAdapter<UsbFlash>(
                new CreateEntity<UsbFlash>(context),
                new UpdateEntity<UsbFlash>(context),
                new DeleteEntity<UsbFlash>(context)))
        {
        }
    }
}