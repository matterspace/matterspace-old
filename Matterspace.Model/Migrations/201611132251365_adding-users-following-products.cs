namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingusersfollowingproducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserFollowingProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ProductId = c.Int(nullable: false),
                        StartedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserFollowingProduct", "UserId", "dbo.User");
            DropForeignKey("dbo.ApplicationUserFollowingProduct", "ProductId", "dbo.Product");
            DropIndex("dbo.ApplicationUserFollowingProduct", new[] { "ProductId" });
            DropIndex("dbo.ApplicationUserFollowingProduct", new[] { "UserId" });
            DropTable("dbo.ApplicationUserFollowingProduct");
        }
    }
}
