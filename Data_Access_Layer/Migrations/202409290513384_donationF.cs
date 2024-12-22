namespace Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class donationF : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donations", "F_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Donations", "F_Id");
            AddForeignKey("dbo.Donations", "F_Id", "dbo.Foundations", "Id", cascadeDelete: true);
            DropColumn("dbo.Donations", "F_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Donations", "F_Name", c => c.String(nullable: false, maxLength: 100));
            DropForeignKey("dbo.Donations", "F_Id", "dbo.Foundations");
            DropIndex("dbo.Donations", new[] { "F_Id" });
            DropColumn("dbo.Donations", "F_Id");
        }
    }
}
