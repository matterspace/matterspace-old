namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingconstraintsfortheProducttable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "WebsiteUrl", c => c.String(nullable: false, maxLength: 512));
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Product", "DisplayName", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Product", "ShortDescription", c => c.String(maxLength: 120));
            CreateIndex("dbo.Product", "Name", unique: true, name: "UQ_Name");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Product", "UQ_Name");
            AlterColumn("dbo.Product", "ShortDescription", c => c.String());
            AlterColumn("dbo.Product", "DisplayName", c => c.String());
            AlterColumn("dbo.Product", "Name", c => c.String());
            DropColumn("dbo.Product", "WebsiteUrl");
        }
    }
}
