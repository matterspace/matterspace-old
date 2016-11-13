namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingusersfollowingthreads : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserFollowingProduct", "UserId", "dbo.User");
            DropIndex("dbo.ApplicationUserFollowingProduct", new[] { "UserId" });
            CreateTable(
                "dbo.ApplicationUserFollowingThread",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ThreadId = c.Int(nullable: false),
                        StartedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Thread", t => t.ThreadId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ThreadId);
            
            AlterColumn("dbo.ApplicationUserFollowingProduct", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.ApplicationUserFollowingProduct", "UserId");
            AddForeignKey("dbo.ApplicationUserFollowingProduct", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserFollowingProduct", "UserId", "dbo.User");
            DropForeignKey("dbo.ApplicationUserFollowingThread", "UserId", "dbo.User");
            DropForeignKey("dbo.ApplicationUserFollowingThread", "ThreadId", "dbo.Thread");
            DropIndex("dbo.ApplicationUserFollowingThread", new[] { "ThreadId" });
            DropIndex("dbo.ApplicationUserFollowingThread", new[] { "UserId" });
            DropIndex("dbo.ApplicationUserFollowingProduct", new[] { "UserId" });
            AlterColumn("dbo.ApplicationUserFollowingProduct", "UserId", c => c.String(maxLength: 128));
            DropTable("dbo.ApplicationUserFollowingThread");
            CreateIndex("dbo.ApplicationUserFollowingProduct", "UserId");
            AddForeignKey("dbo.ApplicationUserFollowingProduct", "UserId", "dbo.User", "Id");
        }
    }
}
