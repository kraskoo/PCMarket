namespace PCMarket.Models.Entities.StorageDevices
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Enums;

    public abstract class StorageDevice : Component
    {
        protected StorageDevice(StorageDeviceType storageDeviceType) : base(ComponentType.StorageDevice)
        {
            this.StorageDeviceType = storageDeviceType;
        }

        protected StorageDeviceType StorageDeviceType { get; }

        [Required]
        public double Size { get; set; }

        [Required]
        public SizeInType SizeType { get; set; }

        [Required]
        public double Speed { get; set; }

        [Required]
        public string Series { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual Company Company { get; set; }

        public override string ToString()
        {
            return this.StorageDeviceType.ToString();
        }
    }
}