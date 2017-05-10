namespace PCMarket.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using Common;

    public class BaseBindingModel
    {
        [Required]
        [StringLength(5000, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        [RegularExpression(Strings.UriPattern)]
        public string ImageUrl { get; set; }
    }
}