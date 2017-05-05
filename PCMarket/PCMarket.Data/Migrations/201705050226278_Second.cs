namespace PCMarket.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            this.AlterColumn("dbo.HardwareNews", "Title", c => c.String(maxLength: 60));
            this.AlterColumn("dbo.HardwareNews", "Subject", c => c.String(maxLength: 15));
            this.AlterColumn("dbo.HardwareNews", "Body", c => c.String(maxLength: 200));
            this.AlterColumn("dbo.SoftwareNews", "Title", c => c.String(maxLength: 60));
            this.AlterColumn("dbo.SoftwareNews", "Subject", c => c.String(maxLength: 15));
            this.AlterColumn("dbo.SoftwareNews", "Body", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            this.AlterColumn("dbo.SoftwareNews", "Body", c => c.String());
            this.AlterColumn("dbo.SoftwareNews", "Subject", c => c.String());
            this.AlterColumn("dbo.SoftwareNews", "Title", c => c.String());
            this.AlterColumn("dbo.HardwareNews", "Body", c => c.String());
            this.AlterColumn("dbo.HardwareNews", "Subject", c => c.String());
            this.AlterColumn("dbo.HardwareNews", "Title", c => c.String());
        }
    }
}