namespace PCMarket.Services.Features
{
    using System.Threading.Tasks;
    using Dropbox.Api;
    using Dropbox.Api.Auth.Routes;
    using Dropbox.Api.Files.Routes;
    using Dropbox.Api.Paper.Routes;
    using Dropbox.Api.Sharing.Routes;
    using Dropbox.Api.Users.Routes;
    using Common.APIs;

    public class DropboxClientService
    {
        private string accessToken;
        private string key;
        private string secrete;

        public DropboxClientService(DropboxClient client)
        {
            this.Client = client;
            this.Auth = client.Auth;
            this.Files = client.Files;
            this.Paper = client.Paper;
            this.Sharing = client.Sharing;
            this.Users = client.Users;
        }

        public DropboxClientService() : this(
            new DropboxClient(AccessabilityGetter
                .GetAccessParameterByName<DropboxClientService>("AccessToken")))
        {
        }

        public DropboxClient Client { get; }

        public Task<string> AccessTokenTask => Task.Run(() => this.AccessToken);

        public Task<string> ApplicationKeyTask => Task.Run(() => this.Key);

        public Task<string> ApplicationSecreteTask => Task.Run(() => this.Secrete);

        public string AccessToken =>
            this.accessToken ?? (this.accessToken =
                AccessabilityGetter
                    .GetAccessParameterByName<DropboxClientService>("AccessToken"));

        public string Key =>
            this.key ?? (this.key =
                AccessabilityGetter
                    .GetAccessParameterByName<DropboxClientService>("ApplicationKey"));

        private string Secrete =>
            this.secrete ?? (this.secrete =
                AccessabilityGetter
                    .GetAccessParameterByName<DropboxClientService>("ApplicationSecrete"));


        public AuthUserRoutes Auth { get; }

        public FilesUserRoutes Files { get; }

        public PaperUserRoutes Paper { get; }

        public SharingUserRoutes Sharing { get; }

        public UsersUserRoutes Users { get; }
    }
}