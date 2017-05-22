namespace PCMarket.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.AdminUsers",
                c => new
                    {
                        Id = c.Int(false, true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        UserId = c.String(maxLength: 128)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            this.CreateTable(
                "dbo.HardwareNews",
                c => new
                    {
                        Id = c.Int(false, true),
                        AuthorId = c.Int(false),
                        Title = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdminUsers", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            this.CreateTable(
                "dbo.SoftwareNews",
                c => new
                    {
                        Id = c.Int(false, true),
                        AuthorId = c.Int(false),
                        Title = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdminUsers", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            this.CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(false, 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(false),
                        TwoFactorEnabled = c.Boolean(false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(false),
                        AccessFailedCount = c.Int(false),
                        UserName = c.String(false, 256)
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            this.CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(false, true),
                        UserId = c.String(false, 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .Index(t => t.UserId);
            
            this.CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(false, 128),
                        ProviderKey = c.String(false, 128),
                        UserId = c.String(false, 128)
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .Index(t => t.UserId);
            
            this.CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(false, 128),
                        RoleId = c.String(false, 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            this.CreateTable(
                "dbo.BackupDevices",
                c => new
                    {
                        Id = c.Int(false, true),
                        Size = c.Double(false),
                        SizeType = c.Int(false),
                        Speed = c.Double(false),
                        Series = c.String(false),
                        CompanyId = c.Int(false),
                        Description = c.String(),
                        ImageUrl = c.String(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, true)
                .Index(t => t.CompanyId);
            
            this.CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(false, true),
                        CompanyName = c.String(false, 50),
                        LogoImageUrl = c.String(false),
                        Description = c.String(false),
                        EstablishOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CompanyName, unique: true);
            
            this.CreateTable(
                "dbo.HardDriveBindingModel",
                c => new
                    {
                        Id = c.Int(false, true),
                        Size = c.Double(false),
                        SizeType = c.Int(false),
                        Speed = c.Double(false),
                        Series = c.String(false),
                        CompanyId = c.Int(false),
                        Description = c.String(),
                        ImageUrl = c.String(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, true)
                .Index(t => t.CompanyId);
            
            this.CreateTable(
                "dbo.Motherboards",
                c => new
                    {
                        Id = c.Int(false, true),
                        Model = c.String(false),
                        Type = c.String(false),
                        Socket = c.String(false),
                        CompanyId = c.Int(false),
                        Description = c.String(),
                        ImageUrl = c.String(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, true)
                .Index(t => t.CompanyId);
            
            this.CreateTable(
                "dbo.Processors",
                c => new
                    {
                        Id = c.Int(false, true),
                        Type = c.String(false),
                        Series = c.String(false),
                        CompanyId = c.Int(false),
                        Description = c.String(),
                        ImageUrl = c.String(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, true)
                .Index(t => t.CompanyId);
            
            this.CreateTable(
                "dbo.SolidStateDrives",
                c => new
                    {
                        Id = c.Int(false, true),
                        Size = c.Double(false),
                        SizeType = c.Int(false),
                        Speed = c.Double(false),
                        Series = c.String(false),
                        CompanyId = c.Int(false),
                        Description = c.String(),
                        ImageUrl = c.String(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, true)
                .Index(t => t.CompanyId);
            
            this.CreateTable(
                "dbo.UsbFlashes",
                c => new
                    {
                        Id = c.Int(false, true),
                        Size = c.Double(false),
                        SizeType = c.Int(false),
                        Speed = c.Double(false),
                        Series = c.String(false),
                        CompanyId = c.Int(false),
                        Description = c.String(),
                        ImageUrl = c.String(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, true)
                .Index(t => t.CompanyId);
            
            this.CreateTable(
                "dbo.VideoCards",
                c => new
                    {
                        Id = c.Int(false, true),
                        GpuArchitecture = c.String(false),
                        GpuClockSpeedCore = c.Double(false),
                        GpuClockSpeedShader = c.Double(false),
                        NumberOfShaders = c.Int(false),
                        GpuSize = c.Double(false),
                        SizeType = c.Int(false),
                        CompanyId = c.Int(false),
                        Description = c.String(),
                        ImageUrl = c.String(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, true)
                .Index(t => t.CompanyId);
            
            this.CreateTable(
                "dbo.ClientUsers",
                c => new
                    {
                        Id = c.Int(false, true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        UserId = c.String(maxLength: 128)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            this.CreateTable(
                "dbo.RegularUsers",
                c => new
                    {
                        Id = c.Int(false, true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        UserId = c.String(maxLength: 128)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            this.CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(false, 128),
                        Name = c.String(false, 256)
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            this.DropForeignKey("dbo.RegularUsers", "UserId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.ClientUsers", "UserId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.VideoCards", "CompanyId", "dbo.Companies");
            this.DropForeignKey("dbo.UsbFlashes", "CompanyId", "dbo.Companies");
            this.DropForeignKey("dbo.SolidStateDrives", "CompanyId", "dbo.Companies");
            this.DropForeignKey("dbo.Processors", "CompanyId", "dbo.Companies");
            this.DropForeignKey("dbo.Motherboards", "CompanyId", "dbo.Companies");
            this.DropForeignKey("dbo.HardDriveBindingModel", "CompanyId", "dbo.Companies");
            this.DropForeignKey("dbo.BackupDevices", "CompanyId", "dbo.Companies");
            this.DropForeignKey("dbo.AdminUsers", "UserId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.SoftwareNews", "AuthorId", "dbo.AdminUsers");
            this.DropForeignKey("dbo.HardwareNews", "AuthorId", "dbo.AdminUsers");
            this.DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            this.DropIndex("dbo.RegularUsers", new[] { "UserId" });
            this.DropIndex("dbo.ClientUsers", new[] { "UserId" });
            this.DropIndex("dbo.VideoCards", new[] { "CompanyId" });
            this.DropIndex("dbo.UsbFlashes", new[] { "CompanyId" });
            this.DropIndex("dbo.SolidStateDrives", new[] { "CompanyId" });
            this.DropIndex("dbo.Processors", new[] { "CompanyId" });
            this.DropIndex("dbo.Motherboards", new[] { "CompanyId" });
            this.DropIndex("dbo.HardDriveBindingModel", new[] { "CompanyId" });
            this.DropIndex("dbo.Companies", new[] { "CompanyName" });
            this.DropIndex("dbo.BackupDevices", new[] { "CompanyId" });
            this.DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            this.DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            this.DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            this.DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            this.DropIndex("dbo.AspNetUsers", "UserNameIndex");
            this.DropIndex("dbo.SoftwareNews", new[] { "AuthorId" });
            this.DropIndex("dbo.HardwareNews", new[] { "AuthorId" });
            this.DropIndex("dbo.AdminUsers", new[] { "UserId" });
            this.DropTable("dbo.AspNetRoles");
            this.DropTable("dbo.RegularUsers");
            this.DropTable("dbo.ClientUsers");
            this.DropTable("dbo.VideoCards");
            this.DropTable("dbo.UsbFlashes");
            this.DropTable("dbo.SolidStateDrives");
            this.DropTable("dbo.Processors");
            this.DropTable("dbo.Motherboards");
            this.DropTable("dbo.HardDriveBindingModel");
            this.DropTable("dbo.Companies");
            this.DropTable("dbo.BackupDevices");
            this.DropTable("dbo.AspNetUserRoles");
            this.DropTable("dbo.AspNetUserLogins");
            this.DropTable("dbo.AspNetUserClaims");
            this.DropTable("dbo.AspNetUsers");
            this.DropTable("dbo.SoftwareNews");
            this.DropTable("dbo.HardwareNews");
            this.DropTable("dbo.AdminUsers");
        }
    }
}
