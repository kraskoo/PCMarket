namespace PCMarket.Models.Entities.News
{
    using System.ComponentModel.DataAnnotations;
    using Common.Enums;
    using Interfaces;

    public abstract class BaseNew : INew
    {
        protected BaseNew(NewType category)
        {
            this.Category = category;
        }

        protected NewType Category { get; }

        
        public int Id { get; set; }

        [MinLength(5)]
        public string Title { get; set; }

        [MinLength(10)]
        public string Subject { get; set; }

        [MinLength(20)]
        public string Body { get; set; }
    }
}