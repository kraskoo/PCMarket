namespace PCMarket.Models.ViewModels.Cores
{
    using System.ComponentModel.DataAnnotations;

    public class MotherboardViewModel : BaseViewModel
    {
        [Required]
        public string Model { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Socket { get; set; }
    }
}