namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThreadListInProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Thread", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Thread", "ProductId");
            AddForeignKey("dbo.Thread", "ProductId", "dbo.Product", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Thread", "ProductId", "dbo.Product");
            DropIndex("dbo.Thread", new[] { "ProductId" });
            DropColumn("dbo.Thread", "ProductId");
        }
    }
}
