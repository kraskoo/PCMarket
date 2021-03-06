﻿namespace PCMarket.Models.ViewModels.News
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BaseNewViewModel
    {
        public int Id { get; set; }

        [MinLength(5)]
        public string Title { get; set; }

        [MinLength(10)]
        public string Subject { get; set; }

        [MinLength(20)]
        public ICollection<string> ContentBody { get; set; }
    }
}