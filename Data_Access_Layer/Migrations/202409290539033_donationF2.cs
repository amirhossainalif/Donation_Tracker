namespace Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class donationF2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Donations", "F_Id", "dbo.Foundations");
            DropIndex("dbo.Donations", new[] { "F_Id" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Donations", "F_Id");
            AddForeignKey("dbo.Donations", "F_Id", "dbo.Foundations", "Id", cascadeDelete: true);
        }
    }
}
