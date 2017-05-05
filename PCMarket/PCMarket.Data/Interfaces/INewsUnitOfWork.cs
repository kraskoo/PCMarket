namespace PCMarket.Data.Interfaces
{
    public interface INewsUnitOfWork : IUnitOfWork
    {
        ISoftwareNewRepository SoftwareNews { get; }

        IHardwareNewRepository HardwareNews { get; }
    }
}