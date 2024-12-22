namespace Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emp1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Logins", "Email", "dbo.Donors");
            DropForeignKey("dbo.Logins", "Email", "dbo.Employees");
            DropForeignKey("dbo.Logins", "Email", "dbo.Foundations");
            DropIndex("dbo.Logins", new[] { "Email" });
            AddColumn("dbo.Donors", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Foundations", "Password", c => c.String(nullable: false));
            DropColumn("dbo.Foundations", "Id");
            DropTable("dbo.Logins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Foundations", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Foundations", "Password");
            DropColumn("dbo.Employees", "Password");
            DropColumn("dbo.Donors", "Password");
            CreateIndex("dbo.Logins", "Email");
            AddForeignKey("dbo.Logins", "Email", "dbo.Foundations", "Email", cascadeDelete: true);
            AddForeignKey("dbo.Logins", "Email", "dbo.Employees", "Email", cascadeDelete: true);
            AddForeignKey("dbo.Logins", "Email", "dbo.Donors", "Email", cascadeDelete: true);
        }
    }
}
