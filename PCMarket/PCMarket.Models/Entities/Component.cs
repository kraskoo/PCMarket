namespace PCMarket.Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    using Common;
    using Common.Enums;
    using Interfaces;

    public abstract class Component : IComponent
    {
        private readonly ComponentType type;

        protected Component(ComponentType componentType)
        {
            this.type = componentType;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(5000, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        [RegularExpression(Strings.UriPattern)]
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return this.type.ToString();
        }
    }
}