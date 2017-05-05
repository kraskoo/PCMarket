namespace PCMarket.Models.Entities.StorageDevices
{
    using Common.Enums;

    public class BackupDevice : StorageDevice
    {
        public BackupDevice() : base(StorageDeviceType.BackupDevice)
        {
        }
    }
}