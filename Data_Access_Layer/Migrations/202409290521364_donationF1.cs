namespace Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class donationF1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donations", "date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donations", "date", c => c.String(nullable: false));
        }
    }
}
