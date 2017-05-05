namespace PCMarket.Data.Interfaces
{
    public interface IUserUnitOfWork : IUnitOfWork
    {
        IAdminUserRepository AdminUsers { get; }

        IRegularUserRepository RegularUsers { get; }

        IClientUserRepository ClientUsers { get; }
    }
}