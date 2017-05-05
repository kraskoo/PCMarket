namespace PCMarket.Data
{
    using System.Data.Entity;
    using System.Diagnostics;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Configurations;
    using Models.Entities;
    using Models.Entities.Cores;
    using Models.Entities.News;
    using Models.Entities.Users;
    using Models.Entities.StorageDevices;

    public class PcMarketContext : IdentityDbContext<User>
    {
        private const string ConnectionString = nameof(PcMarketContext);

        public PcMarketContext() : base(ConnectionString, false)
        {
            this.Configuration.LazyLoadingEnabled = true;
            Database.Log = sql => Debug.Write(sql);
        }

        public IDbSet<AdminUser> AdminUsers { get; set; }

        public IDbSet<RegularUser> RegularUsers { get; set; }

        public IDbSet<ClientUser> ClientUsers { get; set; }

        public IDbSet<Company> Companies { get; set; }

        public IDbSet<Motherboard> Motherboards { get; set; }

        public IDbSet<Processor> Processors { get; set; }

        public IDbSet<VideoCard> VideoCards { get; set; }

        public IDbSet<HardDrive> HardDrives { get; set; }

        public IDbSet<SolidStateDrive> SolidStateDrives { get; set; }

        public IDbSet<BackupDevice> BackupDevices { get; set; }

        public IDbSet<UsbFlash> UsbFlashes { get; set; }

        public IDbSet<SoftwareNew> SoftwareNews { get; set; }

        public IDbSet<HardwareNew> HardwareNews { get; set; }

        public static PcMarketContext Create()
        {
            return new PcMarketContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CompanyConfigurations());
            modelBuilder.Configurations.Add(new SoftwareNewConfigurations());
            modelBuilder.Configurations.Add(new HardwareNewConfigurations());
        }
    }
}