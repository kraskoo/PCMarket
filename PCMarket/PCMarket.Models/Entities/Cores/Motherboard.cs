namespace PCMarket.Models.Entities.Cores
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Enums;

    public class Motherboard : CoreComponent
    {
        public Motherboard() : base(CoreComponentType.Motherboard)
        {
        }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Socket { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual Company Company { get; set; }
    }
}