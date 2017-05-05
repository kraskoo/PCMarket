namespace PCMarket.Models.Interfaces
{
    public interface INew : IModel<int>
    {
        string Title { get; }

        string Subject { get; }

        string Body { get; }
    }
}