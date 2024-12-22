namespace Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uptoAuth3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tokens", "E_Id", "dbo.Employees");
            DropIndex("dbo.Tokens", new[] { "E_Id" });
            DropColumn("dbo.Tokens", "E_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tokens", "E_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Tokens", "E_Id");
            AddForeignKey("dbo.Tokens", "E_Id", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
