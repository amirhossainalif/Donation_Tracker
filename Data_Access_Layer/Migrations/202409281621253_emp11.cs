namespace Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emp11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "date", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "date", c => c.DateTime(nullable: false));
        }
    }
}
