namespace PCMarket.Models.Interfaces
{
    public interface IComponent : IModel<int>
    {
        string Description { get; }

        string ImageUrl { get; }
    }
}