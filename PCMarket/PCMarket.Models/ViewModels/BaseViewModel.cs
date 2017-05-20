namespace PCMarket.Models.ViewModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common;

    public abstract class BaseViewModel
    {
        [Required]
        [StringLength(5000, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        [RegularExpression(Strings.UriPattern)]
        [DisplayName("Image Url")]
        public string ImageUrl { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Company name")]
        public string CompanyName { get; set; }
    }
}