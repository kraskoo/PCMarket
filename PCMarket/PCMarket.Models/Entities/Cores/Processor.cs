namespace PCMarket.Models.Entities.Cores
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Enums;

    public class Processor : CoreComponent
    {
        public Processor() : base(CoreComponentType.Cpu)
        {
        }

        [Required]
        [MinLength(3)]
        public string Type { get; set; }

        [Required]
        [MinLength(2)]
        public string Series { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual Company Company { get; set; }
    }
}