namespace PCMarket.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using Models.Entities;

    public class CompanyConfigurations : EntityTypeConfiguration<Company>
    {
        public CompanyConfigurations()
        {
            this.HasOptional(c => c.BackupDevices)
                .WithOptionalPrincipal()
                .WillCascadeOnDelete(false);

            this.HasOptional(c => c.HardDrives)
                .WithOptionalPrincipal()
                .WillCascadeOnDelete(false);

            this.HasOptional(c => c.Motherboards)
                .WithOptionalPrincipal()
                .WillCascadeOnDelete(false);

            this.HasOptional(c => c.Processors)
                .WithOptionalPrincipal()
                .WillCascadeOnDelete(false);

            this.HasOptional(c => c.SolidStateDrives)
                .WithRequired()
                .WillCascadeOnDelete(false);

            this.HasOptional(c => c.UsbFlashes)
                .WithRequired()
                .WillCascadeOnDelete(false);

            this.HasOptional(c => c.VideoCards)
                .WithRequired()
                .WillCascadeOnDelete(false);
        }
    }
}