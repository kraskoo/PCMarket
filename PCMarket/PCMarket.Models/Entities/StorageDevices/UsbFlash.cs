namespace PCMarket.Models.Entities.StorageDevices
{
    using Common.Enums;

    public class UsbFlash : StorageDevice
    {
        public UsbFlash() : base(StorageDeviceType.UsbFlash)
        {
        }
    }
}