namespace PCMarket.Data.DataModels
{
    using Interfaces;

    public class NewsUnitOfWork : UnitOfWork, INewsUnitOfWork
    {
        public NewsUnitOfWork(
            IDataWorker dataWorker,
            ISoftwareNewRepository softwareNews,
            IHardwareNewRepository hardwareNews) : base(dataWorker)
        {
            this.SoftwareNews = softwareNews;
            this.HardwareNews = hardwareNews;
        }

        public ISoftwareNewRepository SoftwareNews { get; }

        public IHardwareNewRepository HardwareNews { get; }
    }
}