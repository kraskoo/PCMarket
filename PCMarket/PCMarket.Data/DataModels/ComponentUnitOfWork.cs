namespace PCMarket.Data.DataModels
{
    using Interfaces;

    public class ComponentUnitOfWork : UnitOfWork, IComponentUnitOfWork
    {
        public ComponentUnitOfWork(
            IDataWorker dataWorker,
            IBackupRepository backups,
            IHardDriveRepository hardDrives,
            IMotherboardRepository motherboards,
            IProcessorRepository processors,
            ISolidStateRepository solidStates,
            IUsbFlashRepository usbFlashes,
            IVideoCardRepository videoCards) : base(dataWorker)
        {
            this.Backups = backups;
            this.HardDrives = hardDrives;
            this.Motherboards = motherboards;
            this.Processors = processors;
            this.SolidStates = solidStates;
            this.UsbFlashes = usbFlashes;
            this.VideoCards = videoCards;
        }

        public IBackupRepository Backups { get; }

        public IHardDriveRepository HardDrives { get; }

        public IMotherboardRepository Motherboards { get; }

        public IProcessorRepository Processors { get; }

        public ISolidStateRepository SolidStates { get; }

        public IUsbFlashRepository UsbFlashes { get; }

        public IVideoCardRepository VideoCards { get; }
    }
}