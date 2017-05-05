namespace PCMarket.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AdminNewsRelation : DbMigration
    {
        public override void Up()
        {
            this.DropForeignKey("dbo.HardwareNews", "AuthorId", "dbo.AdminUsers");
            this.DropForeignKey("dbo.SoftwareNews", "AuthorId", "dbo.AdminUsers");
            this.AddForeignKey("dbo.HardwareNews", "AuthorId", "dbo.AdminUsers", "Id");
            this.AddForeignKey("dbo.SoftwareNews", "AuthorId", "dbo.AdminUsers", "Id");
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.SoftwareNews", "AuthorId", "dbo.AdminUsers");
            this.DropForeignKey("dbo.HardwareNews", "AuthorId", "dbo.AdminUsers");
            this.AddForeignKey("dbo.SoftwareNews", "AuthorId", "dbo.AdminUsers", "Id", true);
            this.AddForeignKey("dbo.HardwareNews", "AuthorId", "dbo.AdminUsers", "Id", true);
        }
    }
}