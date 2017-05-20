namespace PCMarket.Models.Entities.Cores
{
    using Common.Enums;

    public abstract class CoreComponent : Component
    {
        protected CoreComponent(
            CoreComponentType coreComponentType) : base(
                ComponentType.CoreComponent)
        {
            this.CoreComponentType = coreComponentType;
        }

        protected CoreComponentType CoreComponentType { get; }

        public override string ToString => this.CoreComponentType.ToString();
    }
}