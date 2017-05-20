namespace PCMarket.Models.Entities.News
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Enums;
    using Interfaces;

    public abstract class BaseNew : INew
    {
        protected BaseNew(NewType category)
        {
            this.Category = category;
            this.NewsDate = DateTime.Now;
        }

        protected NewType Category { get; }

        
        public int Id { get; set; }

        [MinLength(5)]
        public string Title { get; set; }

        [MinLength(10)]
        public string Subject { get; set; }

        [MinLength(1)]
        public ICollection<string> ContentBody { get; set; }

        public DateTime NewsDate { get; }
    }
}