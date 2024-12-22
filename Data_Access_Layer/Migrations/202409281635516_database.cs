namespace Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Donations", "D_name", "dbo.Donors");
            DropIndex("dbo.Donations", new[] { "D_name" });
            RenameColumn(table: "dbo.Donations", name: "D_name", newName: "D_id");
            DropPrimaryKey("dbo.Donors");
            DropPrimaryKey("dbo.Employees");
            DropPrimaryKey("dbo.Foundations");
            AddColumn("dbo.Donors", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Employees", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Foundations", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Donations", "date", c => c.String(nullable: false));
            AlterColumn("dbo.Donations", "D_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Donors", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Foundations", "Email", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Donors", "Id");
            AddPrimaryKey("dbo.Employees", "Id");
            AddPrimaryKey("dbo.Foundations", "Id");
            CreateIndex("dbo.Donations", "D_id");
            AddForeignKey("dbo.Donations", "D_id", "dbo.Donors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donations", "D_id", "dbo.Donors");
            DropIndex("dbo.Donations", new[] { "D_id" });
            DropPrimaryKey("dbo.Foundations");
            DropPrimaryKey("dbo.Employees");
            DropPrimaryKey("dbo.Donors");
            AlterColumn("dbo.Foundations", "Email", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Donors", "Email", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Donations", "D_id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Donations", "date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Foundations", "Id");
            DropColumn("dbo.Employees", "Id");
            DropColumn("dbo.Donors", "Id");
            AddPrimaryKey("dbo.Foundations", "Email");
            AddPrimaryKey("dbo.Employees", "Email");
            AddPrimaryKey("dbo.Donors", "Email");
            RenameColumn(table: "dbo.Donations", name: "D_id", newName: "D_name");
            CreateIndex("dbo.Donations", "D_name");
            AddForeignKey("dbo.Donations", "D_name", "dbo.Donors", "Email");
        }
    }
}
