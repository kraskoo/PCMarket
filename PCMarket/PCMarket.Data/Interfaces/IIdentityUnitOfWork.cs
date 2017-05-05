namespace PCMarket.Data.Interfaces
{
    public interface IIdentityUnitOfWork : IUnitOfWork
    {
        IIdentityRepository Identity { get; }
    }
}