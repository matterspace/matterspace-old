namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstrelease : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        MembershipType = c.Int(nullable: false),
                        Member_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Member_Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.ThreadReplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        TextMarkdown = c.String(),
                        ThreadId = c.Int(nullable: false),
                        Author_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Author_Id)
                .ForeignKey("dbo.Threads", t => t.ThreadId, cascadeDelete: true)
                .Index(t => t.ThreadId)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThreadType = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ParentThreadId = c.Int(),
                        TextMarkdown = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Author_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Author_Id)
                .ForeignKey("dbo.Threads", t => t.ParentThreadId)
                .Index(t => t.ParentThreadId)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.ThreadReferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReferencedThreadId = c.Int(nullable: false),
                        RefererThreadId = c.Int(),
                        RefererThreadReplyId = c.Int(),
                        Thread_Id = c.Int(),
                        Thread_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Threads", t => t.ReferencedThreadId, cascadeDelete: true)
                .ForeignKey("dbo.Threads", t => t.RefererThreadId)
                .ForeignKey("dbo.ThreadReplies", t => t.RefererThreadReplyId)
                .ForeignKey("dbo.Threads", t => t.Thread_Id)
                .ForeignKey("dbo.Threads", t => t.Thread_Id1)
                .Index(t => t.ReferencedThreadId)
                .Index(t => t.RefererThreadId)
                .Index(t => t.RefererThreadReplyId)
                .Index(t => t.Thread_Id)
                .Index(t => t.Thread_Id1);
            
            CreateTable(
                "dbo.ThreadReleases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThreadId = c.Int(nullable: false),
                        ReleaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Releases", t => t.ReleaseId, cascadeDelete: true)
                .ForeignKey("dbo.Threads", t => t.ThreadId, cascadeDelete: true)
                .Index(t => t.ThreadId)
                .Index(t => t.ReleaseId);
            
            CreateTable(
                "dbo.Releases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        EstimatedReleaseDate = c.DateTime(),
                        ReleasedAt = c.DateTime(),
                        NotesMarkdown = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DisplayName = c.String(),
                        ShortDescription = c.String(),
                        LongDescriptionMarkdown = c.String(),
                        OwnerId = c.Int(nullable: false),
                        Avatar = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ThreadReplyVotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ThreadId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Threads", t => t.ThreadId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.ThreadId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ThreadVotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ThreadId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Threads", t => t.ThreadId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.ThreadId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ThreadVotes", "User_Id", "dbo.User");
            DropForeignKey("dbo.ThreadVotes", "ThreadId", "dbo.Threads");
            DropForeignKey("dbo.ThreadReplyVotes", "User_Id", "dbo.User");
            DropForeignKey("dbo.ThreadReplyVotes", "ThreadId", "dbo.Threads");
            DropForeignKey("dbo.ThreadReleases", "ThreadId", "dbo.Threads");
            DropForeignKey("dbo.ThreadReleases", "ReleaseId", "dbo.Releases");
            DropForeignKey("dbo.Releases", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductMembers", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ThreadReferences", "Thread_Id1", "dbo.Threads");
            DropForeignKey("dbo.ThreadReferences", "Thread_Id", "dbo.Threads");
            DropForeignKey("dbo.ThreadReferences", "RefererThreadReplyId", "dbo.ThreadReplies");
            DropForeignKey("dbo.ThreadReferences", "RefererThreadId", "dbo.Threads");
            DropForeignKey("dbo.ThreadReferences", "ReferencedThreadId", "dbo.Threads");
            DropForeignKey("dbo.ThreadReplies", "ThreadId", "dbo.Threads");
            DropForeignKey("dbo.Threads", "ParentThreadId", "dbo.Threads");
            DropForeignKey("dbo.Threads", "Author_Id", "dbo.User");
            DropForeignKey("dbo.ThreadReplies", "Author_Id", "dbo.User");
            DropForeignKey("dbo.ProductMembers", "Member_Id", "dbo.User");
            DropIndex("dbo.ThreadVotes", new[] { "User_Id" });
            DropIndex("dbo.ThreadVotes", new[] { "ThreadId" });
            DropIndex("dbo.ThreadReplyVotes", new[] { "User_Id" });
            DropIndex("dbo.ThreadReplyVotes", new[] { "ThreadId" });
            DropIndex("dbo.Releases", new[] { "ProductId" });
            DropIndex("dbo.ThreadReleases", new[] { "ReleaseId" });
            DropIndex("dbo.ThreadReleases", new[] { "ThreadId" });
            DropIndex("dbo.ThreadReferences", new[] { "Thread_Id1" });
            DropIndex("dbo.ThreadReferences", new[] { "Thread_Id" });
            DropIndex("dbo.ThreadReferences", new[] { "RefererThreadReplyId" });
            DropIndex("dbo.ThreadReferences", new[] { "RefererThreadId" });
            DropIndex("dbo.ThreadReferences", new[] { "ReferencedThreadId" });
            DropIndex("dbo.Threads", new[] { "Author_Id" });
            DropIndex("dbo.Threads", new[] { "ParentThreadId" });
            DropIndex("dbo.ThreadReplies", new[] { "Author_Id" });
            DropIndex("dbo.ThreadReplies", new[] { "ThreadId" });
            DropIndex("dbo.ProductMembers", new[] { "Member_Id" });
            DropIndex("dbo.ProductMembers", new[] { "ProductId" });
            DropTable("dbo.ThreadVotes");
            DropTable("dbo.ThreadReplyVotes");
            DropTable("dbo.Products");
            DropTable("dbo.Releases");
            DropTable("dbo.ThreadReleases");
            DropTable("dbo.ThreadReferences");
            DropTable("dbo.Threads");
            DropTable("dbo.ThreadReplies");
            DropTable("dbo.ProductMembers");
        }
    }
}
