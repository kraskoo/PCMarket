namespace PCMarket.Models.Entities.Cores
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Enums;

    public class VideoCard : CoreComponent
    {
        public VideoCard() : base(CoreComponentType.VideoCard)
        {
        }

        [Required]
        public string GpuArchitecture { get; set; }

        [Required]
        public double GpuClockSpeedCore { get; set; }

        [Required]
        public double GpuClockSpeedShader { get; set; }

        [Required]
        public int NumberOfShaders { get; set; }

        [Required]
        public double GpuSize { get; set; }

        [Required]
        public SizeInType SizeType { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual Company Company { get; set; }
    }
}