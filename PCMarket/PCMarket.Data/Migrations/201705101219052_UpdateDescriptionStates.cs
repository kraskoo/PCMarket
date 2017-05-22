namespace PCMarket.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDescriptionStates : DbMigration
    {
        public override void Up()
        {
            this.AlterColumn("dbo.BackupDevices", "Description", c => c.String(false));
            this.AlterColumn("dbo.HardDriveBindingModel", "Description", c => c.String(false));
            this.AlterColumn("dbo.Motherboards", "Description", c => c.String(false));
            this.AlterColumn("dbo.Processors", "Description", c => c.String(false));
            this.AlterColumn("dbo.SolidStateDrives", "Description", c => c.String(false));
            this.AlterColumn("dbo.UsbFlashes", "Description", c => c.String(false));
            this.AlterColumn("dbo.VideoCards", "Description", c => c.String(false));
        }
        
        public override void Down()
        {
            this.AlterColumn("dbo.VideoCards", "Description", c => c.String());
            this.AlterColumn("dbo.UsbFlashes", "Description", c => c.String());
            this.AlterColumn("dbo.SolidStateDrives", "Description", c => c.String());
            this.AlterColumn("dbo.Processors", "Description", c => c.String());
            this.AlterColumn("dbo.Motherboards", "Description", c => c.String());
            this.AlterColumn("dbo.HardDriveBindingModel", "Description", c => c.String());
            this.AlterColumn("dbo.BackupDevices", "Description", c => c.String());
        }
    }
}
