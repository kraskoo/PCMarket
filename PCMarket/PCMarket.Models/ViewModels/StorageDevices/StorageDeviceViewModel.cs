namespace PCMarket.Models.ViewModels.StorageDevices
{
    using System.ComponentModel.DataAnnotations;
    using Common.Enums;

    public abstract class StorageDeviceViewModel : BaseViewModel
    {
        [Required]
        public double Size { get; set; }

        [Required]
        public SizeInType SizeType { get; set; }

        [Required]
        public double Speed { get; set; }

        [Required]
        public string Series { get; set; }
    }
}