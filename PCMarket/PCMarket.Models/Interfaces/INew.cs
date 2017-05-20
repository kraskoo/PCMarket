namespace PCMarket.Models.Interfaces
{
    using System.Collections.Generic;

    public interface INew : IModel<int>
    {
        string Title { get; }

        string Subject { get; }

        ICollection<string> ContentBody { get; }
    }
}