namespace PCMarket.Models.ViewModels.Identity
{
    using System.ComponentModel.DataAnnotations;

    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
    }
}