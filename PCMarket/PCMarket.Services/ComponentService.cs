namespace PCMarket.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Owin;
    using Data.DataModels;
    using Data.Interfaces;
    using Data.Repositories;
    using Models.ViewModels.Cores;
    using Models.ViewModels.StorageDevices;

    public class ComponentService : Service<IComponentUnitOfWork>
    {
        public ComponentService(
            PcMarketContextFactory contextFactory,
            IComponentUnitOfWork unitOfWork,
            IOwinContext context) : base(contextFactory, unitOfWork, context)
        {
        }

        public ComponentService(
            PcMarketContextFactory contextFactory,
            IOwinContext context) : this(
                contextFactory,
                new ComponentUnitOfWork(
                    contextFactory.DataWorker,
                    new BackupDeviceRepository(contextFactory),
                    new HardDriveRepository(contextFactory),
                    new MotherboardRepository(contextFactory),
                    new ProcessorRepository(contextFactory),
                    new SolidStateDriveRepository(contextFactory),
                    new UsbFlashRepository(contextFactory),
                    new VideoCardRepository(contextFactory)),
                context)
        {
        }

        public IEnumerable<MotherboardViewModel> GetAllMotherboards()
        {
            return this.UnitOfWork
                .Motherboards
                .FindAll()
                .Select(p =>
                    new MotherboardViewModel
                    {
                        CompanyName = p.Company.CompanyName,
                        Model = p.Model,
                        Type = p.Type,
                        Description = p.Description,
                        ImageUrl = p.ImageUrl
                    });
        }

        public IEnumerable<VideoCardViewModel> GetAllVideoCards()
        {
            return this.UnitOfWork
                .VideoCards
                .FindAll()
                .Select(p =>
                    new VideoCardViewModel
                    {
                        CompanyName = p.Company.CompanyName,
                        Description = p.Description,
                        ImageUrl = p.ImageUrl,
                        GpuArchitecture = p.GpuArchitecture,
                        GpuClockSpeedCore = p.GpuClockSpeedCore,
                        GpuClockSpeedShader = p.GpuClockSpeedShader,
                        GpuSize = p.GpuSize,
                        NumberOfShaders = p.NumberOfShaders
                    });
        }

        public IEnumerable<ProcessorViewModel> GetAllProcessors()
        {
            return this.UnitOfWork
                .Processors
                .FindAll()
                .Select(p =>
                    new ProcessorViewModel
                    {
                        CompanyName = p.Company.CompanyName,
                        Type = p.Type,
                        Series = p.Series,
                        Description = p.Description,
                        ImageUrl = p.ImageUrl
                    });
        }

        public IEnumerable<HardDriveViewModels> GetAllHardDrives()
        {
            return this.UnitOfWork
                .HardDrives
                .FindAll()
                .Select(p => new HardDriveViewModels
                {
                    CompanyName = p.Company.CompanyName,
                    Speed = p.Speed,
                    Size = p.Size,
                    SizeType = p.SizeType,
                    Series = p.Series,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl
                });
        }

        public IEnumerable<SolidStateDriveViewModel> GetAllSolidStates()
        {
            return this.UnitOfWork
                .SolidStates
                .FindAll()
                .Select(p => new SolidStateDriveViewModel
                {
                    CompanyName = p.Company.CompanyName,
                    Speed = p.Speed,
                    Size = p.Size,
                    SizeType = p.SizeType,
                    Series = p.Series,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl
                });
        }

        public IEnumerable<UsbFlashViewModels> GetAllUsbFlashes()
        {
            return this.UnitOfWork
                .UsbFlashes
                .FindAll()
                .Select(p => new UsbFlashViewModels
                {
                    CompanyName = p.Company.CompanyName,
                    Speed = p.Speed,
                    Size = p.Size,
                    SizeType = p.SizeType,
                    Series = p.Series,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl
                });
        }

        public IEnumerable<BackupDeviceViewModel> GetAllBackupDevices()
        {
            return this.UnitOfWork
                .Backups
                .FindAll()
                .Select(p => new BackupDeviceViewModel
                {
                    CompanyName = p.Company.CompanyName,
                    Speed = p.Speed,
                    Size = p.Size,
                    SizeType = p.SizeType,
                    Series = p.Series,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl
                });
        }
    }
}