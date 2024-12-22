namespace Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uptoAuth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                        F_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Foundations", t => t.F_Id, cascadeDelete: true)
                .Index(t => t.F_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "F_Id", "dbo.Foundations");
            DropIndex("dbo.Tokens", new[] { "F_Id" });
            DropTable("dbo.Tokens");
        }
    }
}
