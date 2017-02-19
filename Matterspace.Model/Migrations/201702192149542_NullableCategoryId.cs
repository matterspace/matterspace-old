namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableCategoryId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Thread", "CategoryId", "dbo.ThreadCategory");
            DropIndex("dbo.Thread", new[] { "CategoryId" });
            AddColumn("dbo.Thread", "Category_Id", c => c.Int());
            CreateIndex("dbo.Thread", "Category_Id");
            AddForeignKey("dbo.Thread", "Category_Id", "dbo.ThreadCategory", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Thread", "Category_Id", "dbo.ThreadCategory");
            DropIndex("dbo.Thread", new[] { "Category_Id" });
            DropColumn("dbo.Thread", "Category_Id");
            CreateIndex("dbo.Thread", "CategoryId");
            AddForeignKey("dbo.Thread", "CategoryId", "dbo.ThreadCategory", "Id");
        }
    }
}
