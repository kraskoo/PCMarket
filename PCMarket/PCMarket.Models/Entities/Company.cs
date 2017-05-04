namespace PCMarket.Models.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Common;
    using Interfaces;

    public class Company : IModel<int>
    {
        private ICollection<Category> categories;
        private ICollection<Product> products;

        public Company()
        {
            this.categories = new HashSet<Category>();
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Company name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Logo")]
        [RegularExpression(Strings.UriPattern)]
        public string LogoImageUrl { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Description { get; set; }

        [Display(Name = "Establish On")]
        public DateTime? EstablishOn { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}