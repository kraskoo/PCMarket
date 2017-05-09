namespace PCMarket.Common.APIs
{
    using Properties;

    public class PublicApisAccessability
    {
        private readonly string DropboxAccessToken;
        private readonly string DropboxApplicationKey;
        private readonly string DropboxApplicationSecrete;

        public PublicApisAccessability()
        {
            this.DropboxAccessToken = Resources.DropboxAccessToken;
            this.DropboxApplicationKey = Resources.DropboxApplicationKey;
            this.DropboxApplicationSecrete = Resources.DropboxApplicationSecrete;
        }
    }
}