﻿namespace PCMarket.Models.BindingModels.Cores
{
    using System.ComponentModel.DataAnnotations;

    public class MotherboardViewModel : BaseBindingModel
    {
        [Required]
        public string Model { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Socket { get; set; }
    }
}