namespace PCMarket.Models.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common;

    public class AddCompanyViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Company name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Description")]
        [RegularExpression(Strings.UriPattern)]
        public string CompanyDescription { get; set; }

        [Required]
        [Display(Name = "Logo")]
        [RegularExpression(Strings.UriPattern)]
        public string CompanyLogo { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Establish On")]
        public DateTime? EstablishOn { get; set; }
    }
}