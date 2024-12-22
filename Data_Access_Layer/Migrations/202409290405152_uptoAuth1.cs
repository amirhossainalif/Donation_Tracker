namespace Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uptoAuth1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tokens", "E_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Tokens", "E_Id");
            AddForeignKey("dbo.Tokens", "E_Id", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "E_Id", "dbo.Employees");
            DropIndex("dbo.Tokens", new[] { "E_Id" });
            DropColumn("dbo.Tokens", "E_Id");
        }
    }
}
