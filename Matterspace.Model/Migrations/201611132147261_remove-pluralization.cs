namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removepluralization : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductMembers", newName: "ProductMember");
            RenameTable(name: "dbo.ThreadReplies", newName: "ThreadReply");
            RenameTable(name: "dbo.Threads", newName: "Thread");
            RenameTable(name: "dbo.ThreadReferences", newName: "ThreadReference");
            RenameTable(name: "dbo.ThreadReleases", newName: "ThreadRelease");
            RenameTable(name: "dbo.Releases", newName: "Release");
            RenameTable(name: "dbo.Products", newName: "Product");
            RenameTable(name: "dbo.ThreadReplyVotes", newName: "ThreadReplyVote");
            RenameTable(name: "dbo.ThreadVotes", newName: "ThreadVote");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ThreadVote", newName: "ThreadVotes");
            RenameTable(name: "dbo.ThreadReplyVote", newName: "ThreadReplyVotes");
            RenameTable(name: "dbo.Product", newName: "Products");
            RenameTable(name: "dbo.Release", newName: "Releases");
            RenameTable(name: "dbo.ThreadRelease", newName: "ThreadReleases");
            RenameTable(name: "dbo.ThreadReference", newName: "ThreadReferences");
            RenameTable(name: "dbo.Thread", newName: "Threads");
            RenameTable(name: "dbo.ThreadReply", newName: "ThreadReplies");
            RenameTable(name: "dbo.ProductMember", newName: "ProductMembers");
        }
    }
}
