namespace PCMarket.Models.Interfaces
{
    public interface IModel<out T>
    {
        T Id { get; }
    }
}