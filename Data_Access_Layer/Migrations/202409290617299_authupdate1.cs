namespace Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authupdate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tokens", "E_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Tokens", "D_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Tokens", "User", c => c.String(nullable: false));
            CreateIndex("dbo.Tokens", "E_Id");
            CreateIndex("dbo.Tokens", "D_Id");
            AddForeignKey("dbo.Tokens", "D_Id", "dbo.Donors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tokens", "E_Id", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "E_Id", "dbo.Employees");
            DropForeignKey("dbo.Tokens", "D_Id", "dbo.Donors");
            DropIndex("dbo.Tokens", new[] { "D_Id" });
            DropIndex("dbo.Tokens", new[] { "E_Id" });
            DropColumn("dbo.Tokens", "User");
            DropColumn("dbo.Tokens", "D_Id");
            DropColumn("dbo.Tokens", "E_Id");
        }
    }
}
