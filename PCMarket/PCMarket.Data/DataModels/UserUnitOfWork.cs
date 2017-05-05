namespace PCMarket.Data.DataModels
{
    using Interfaces;

    public class UserUnitOfWork : UnitOfWork, IUserUnitOfWork
    {
        public UserUnitOfWork(
            IDataWorker dataWorker,
            IAdminUserRepository adminUsers,
            IRegularUserRepository regularUsers,
            IClientUserRepository clientUsers) : base(dataWorker)
        {
            this.AdminUsers = adminUsers;
            this.RegularUsers = regularUsers;
            this.ClientUsers = clientUsers;
        }

        public IAdminUserRepository AdminUsers { get; }

        public IRegularUserRepository RegularUsers { get; }

        public IClientUserRepository ClientUsers { get; }
    }
}