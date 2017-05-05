namespace PCMarket.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Models.Entities.News;

    public class HardwareNewConfigurations : EntityTypeConfiguration<HardwareNew>
    {
        public HardwareNewConfigurations()
        {
            this.HasRequired(hn => hn.Author)
                .WithMany(a => a.HardwareNews)
                .WillCascadeOnDelete(false);
        }
    }
}