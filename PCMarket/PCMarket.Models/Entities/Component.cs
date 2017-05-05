namespace PCMarket.Models.Entities
{
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

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return this.type.ToString();
        }
    }
}