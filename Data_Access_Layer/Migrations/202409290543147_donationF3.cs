namespace Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class donationF3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donations", "date", c => c.String(nullable: false));
            CreateIndex("dbo.Donations", "F_Id");
            AddForeignKey("dbo.Donations", "F_Id", "dbo.Foundations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donations", "F_Id", "dbo.Foundations");
            DropIndex("dbo.Donations", new[] { "F_Id" });
            AlterColumn("dbo.Donations", "date", c => c.DateTime(nullable: false));
        }
    }
}
