namespace PCMarket.Data.DataModels
{
    using Interfaces;

    public class IdentityUnitOfWork : UnitOfWork, IIdentityUnitOfWork
    {
        public IdentityUnitOfWork(
            IDataWorker dataWorker,
            IIdentityRepository repository) : base(dataWorker)
        {
            this.Identity = repository;
        }

        public IIdentityRepository Identity { get; }
    }
}