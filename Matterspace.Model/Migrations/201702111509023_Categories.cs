namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Categories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ThreadCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProductId = c.Int(nullable: false),
                        ThreadType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.Thread", "CategoryId", c => c.Int());
            CreateIndex("dbo.Thread", "CategoryId");
            AddForeignKey("dbo.Thread", "CategoryId", "dbo.ThreadCategory", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Thread", "CategoryId", "dbo.ThreadCategory");
            DropForeignKey("dbo.ThreadCategory", "ProductId", "dbo.Product");
            DropIndex("dbo.ThreadCategory", new[] { "ProductId" });
            DropIndex("dbo.Thread", new[] { "CategoryId" });
            DropColumn("dbo.Thread", "CategoryId");
            DropTable("dbo.ThreadCategory");
        }
    }
}
