namespace PCMarket.Data.Interfaces
{
    using System;
    using System.Data.Entity;

    public interface IContextFactory<out T> : IDisposable
        where T : DbContext
    {
        IDbSet<TEntity> Set<TEntity>()
            where TEntity : class, new();

        IDataWorker DataWorker { get; }
    }
}