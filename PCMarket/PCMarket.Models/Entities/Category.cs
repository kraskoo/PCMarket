namespace PCMarket.Models.Entities
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Interfaces;

    public class Category : IModel<int>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(36, MinimumLength = 4)]
        [DisplayName("Category name")]
        public string CategoryName { get; set; }

        public int ComapanyId { get; set; }

        [ForeignKey(nameof(ComapanyId))]
        public virtual Company Company { get; set; }
    }
}