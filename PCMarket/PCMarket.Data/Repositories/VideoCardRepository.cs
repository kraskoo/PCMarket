namespace PCMarket.Data.Repositories
{
    using DataModels;
    using DataModels.CrudOperations;
    using Interfaces;
    using Models.Entities.Cores;

    public class VideoCardRepository : PcMarketRepository<VideoCard>, IVideoCardRepository
    {
        public VideoCardRepository(
            PcMarketContextFactory context,
            RepositoryCrudAdapter<VideoCard> crudAdapter) : base(
                context, crudAdapter)
        {
        }

        public VideoCardRepository(
            PcMarketContextFactory context) : this(
                context,
                new RepositoryCrudAdapter<VideoCard>(
                    new CreateEntity<VideoCard>(context),
                    new UpdateEntity<VideoCard>(context),
                    new DeleteEntity<VideoCard>(context)))
        {
        }
    }
}