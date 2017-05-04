namespace PCMarket.Data
{
    using System.Data.Entity;
    using System.Diagnostics;
    using Configurations;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.Entities;

    public class PcMarketContext : IdentityDbContext<User>
    {
        private const string ConnectionString = nameof(PcMarketContext);

        public PcMarketContext() : base(ConnectionString, false)
        {
            Database.Log = sql => Debug.Write(sql);
            this.Configuration.LazyLoadingEnabled = true;
        }

        public IDbSet<AdminUser> AdminUsers { get; set; }

        public IDbSet<RegularUser> RegularUsers { get; set; }

        public IDbSet<Company> Companies { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Product> Products { get; set; }

        public static PcMarketContext Create()
        {
            return new PcMarketContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CompanyConfigurations());
        }
    }
}