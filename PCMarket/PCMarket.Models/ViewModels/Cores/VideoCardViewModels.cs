namespace PCMarket.Models.ViewModels.Cores
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Common.Enums;

    public class VideoCardViewModel : BaseViewModel
    {
        [Required]
        [DisplayName("Gpu Architecture")]
        public string GpuArchitecture { get; set; }

        [Required]
        [DisplayName("Gpu Clock Speed Core")]
        public double GpuClockSpeedCore { get; set; }

        [Required]
        [DisplayName("Gpu Clock Speed Shader")]
        public double GpuClockSpeedShader { get; set; }

        [Required]
        [DisplayName("Number Of Shaders")]
        public int NumberOfShaders { get; set; }

        [Required]
        [DisplayName("Gpu Size")]
        public double GpuSize { get; set; }

        [Required]
        public SizeInType SizeType { get; set; }
    }
}