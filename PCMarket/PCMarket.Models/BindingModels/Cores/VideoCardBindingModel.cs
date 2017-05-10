namespace PCMarket.Models.BindingModels.Cores
{
    using System.ComponentModel.DataAnnotations;
    using Common.Enums;

    public class VideoCardBindingModel : BaseBindingModel
    {
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
    }
}