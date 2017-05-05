namespace PCMarket.Models.Entities.StorageDevices
{
    using Common.Enums;

    public class HardDrive : StorageDevice
    {
        public HardDrive() : base(StorageDeviceType.HardDrive)
        {
        }
    }
}