namespace PCMarket.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Models.Entities;

    public class CompanyConfigurations : EntityTypeConfiguration<Company>
    {
        public CompanyConfigurations()
        {
            this.HasMany(c => c.Categories)
                .WithRequired(c => c.Company)
                .WillCascadeOnDelete(false);

            this.HasMany(c => c.Products)
                .WithRequired(p => p.Company)
                .WillCascadeOnDelete(false);
        }
    }
}