namespace PCMarket.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Common;

    public abstract class BaseViewModel
    {
        [Required]
        [StringLength(5000, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        [RegularExpression(Strings.UriPattern)]
        public string ImageUrl { get; set; }
    }
}