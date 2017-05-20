namespace PCMarket.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common;

    public class BaseBindingModel
    {
        [Required]
        [StringLength(5000, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        [RegularExpression(Strings.UriPattern)]
        public string ImageUrl { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Company name")]
        public string CompanyName { get; set; }
    }
}