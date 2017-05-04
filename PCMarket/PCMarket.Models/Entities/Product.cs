namespace PCMarket.Models.Entities
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common;
    using Interfaces;

    public class Product : IModel<int>
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Product")]
        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual Company Company { get; set; }
        
        [Required]
        [RegularExpression(Strings.UriPattern)]
        [DisplayName("Image")]
        public string ProductImageUrl { get; set; }
    }
}