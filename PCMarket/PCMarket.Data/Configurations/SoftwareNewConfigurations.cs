namespace PCMarket.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Models.Entities.News;

    public class SoftwareNewConfigurations : EntityTypeConfiguration<SoftwareNew>
    {
        public SoftwareNewConfigurations()
        {
            this.HasRequired(sn => sn.Author)
                .WithMany(a => a.SoftwareNews)
                .WillCascadeOnDelete(false);
        }
    }
}