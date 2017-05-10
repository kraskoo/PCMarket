namespace PCMarket.Data.Interfaces
{
    public interface IComponentUnitOfWork : IUnitOfWork
    {
        IBackupRepository Backups { get; }

        IHardDriveRepository HardDrives { get; }

        IMotherboardRepository Motherboards { get; }

        IProcessorRepository Processors { get; }

        ISolidStateRepository SolidStates { get; }

        IUsbFlashRepository UsbFlashes { get; }

        IVideoCardRepository VideoCards { get; }
    }
}