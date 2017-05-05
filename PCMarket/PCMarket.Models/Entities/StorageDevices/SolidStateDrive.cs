namespace PCMarket.Models.Entities.StorageDevices
{
    using Common.Enums;

    public class SolidStateDrive : StorageDevice
    {
        public SolidStateDrive() : base(StorageDeviceType.Ssd)
        {
        }
    }
}