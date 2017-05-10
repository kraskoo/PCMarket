namespace PCMarket.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common;

    public class CompanyBindingModel
    {
        [Required]
        [Index(IsUnique = true)]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Company name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Logo")]
        [RegularExpression(Strings.UriPattern)]
        public string LogoImageUrl { get; set; }

        [Required]
        [StringLength(5000, MinimumLength = 3)]
        public string Description { get; set; }

        [Display(Name = "Establish On")]
        public DateTime? EstablishOn { get; set; }
    }
}