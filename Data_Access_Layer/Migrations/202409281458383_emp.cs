namespace Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        F_Name = c.String(nullable: false, maxLength: 100),
                        Amount = c.String(nullable: false),
                        Donation_Mediam = c.String(nullable: false, maxLength: 50),
                        date = c.DateTime(nullable: false),
                        D_name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Donors", t => t.D_name)
                .Index(t => t.D_name);
            
            CreateTable(
                "dbo.Donors",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false),
                        Bank = c.String(),
                        MobileBank = c.String(),
                        DonationGoal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.Foundations",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(),
                        Address = c.String(nullable: false, maxLength: 150),
                        Bank = c.String(nullable: false),
                        MobileBank = c.String(nullable: false),
                        balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Donors", t => t.Email, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Email, cascadeDelete: true)
                .ForeignKey("dbo.Foundations", t => t.Email, cascadeDelete: true)
                .Index(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logins", "Email", "dbo.Foundations");
            DropForeignKey("dbo.Logins", "Email", "dbo.Employees");
            DropForeignKey("dbo.Logins", "Email", "dbo.Donors");
            DropForeignKey("dbo.Donations", "D_name", "dbo.Donors");
            DropIndex("dbo.Logins", new[] { "Email" });
            DropIndex("dbo.Donations", new[] { "D_name" });
            DropTable("dbo.Logins");
            DropTable("dbo.Foundations");
            DropTable("dbo.Employees");
            DropTable("dbo.Donors");
            DropTable("dbo.Donations");
        }
    }
}
