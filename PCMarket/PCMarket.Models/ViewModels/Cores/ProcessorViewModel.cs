namespace PCMarket.Models.ViewModels.Cores
{
    using System.ComponentModel.DataAnnotations;

    public class ProcessorViewModel : BaseViewModel
    {
        [Required]
        [MinLength(3)]
        public string Type { get; set; }

        [Required]
        [MinLength(2)]
        public string Series { get; set; }
    }
}