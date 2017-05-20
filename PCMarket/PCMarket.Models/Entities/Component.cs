namespace PCMarket.Models.Entities
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Common;
    using Common.Enums;

    public abstract class Component : Interfaces.IComponent
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
        [DisplayName("Image Url")]
        public string ImageUrl { get; set; }

        public new virtual string ToString => this.type.ToString();
    }
}