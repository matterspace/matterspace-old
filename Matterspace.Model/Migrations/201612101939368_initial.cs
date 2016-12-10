namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
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
            
            CreateTable(
                "dbo.Thread",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThreadType = c.Int(nullable: false),
                        AuthorId = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        ParentThreadId = c.Int(),
                        TextMarkdown = c.String(),
                        BacklogItemStatus = c.Int(),
                        IdeaStatus = c.Int(),
                        IssueStatus = c.Int(),
                        QuestionStatus = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.AuthorId)
                .ForeignKey("dbo.Thread", t => t.ParentThreadId)
                .Index(t => t.AuthorId)
                .Index(t => t.ParentThreadId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ApplicationUserNotification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        TargetUserId = c.String(nullable: false, maxLength: 128),
                        ThreadId = c.Int(),
                        ThreadReplyId = c.Int(),
                        RelatedThreadStatusChangeEventId = c.Int(),
                        Read = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ThreadStatusChangeEvent", t => t.RelatedThreadStatusChangeEventId)
                .ForeignKey("dbo.User", t => t.TargetUserId, cascadeDelete: true)
                .ForeignKey("dbo.Thread", t => t.ThreadId)
                .ForeignKey("dbo.ThreadReply", t => t.ThreadReplyId)
                .Index(t => t.TargetUserId)
                .Index(t => t.ThreadId)
                .Index(t => t.ThreadReplyId)
                .Index(t => t.RelatedThreadStatusChangeEventId);
            
            CreateTable(
                "dbo.ThreadStatusChangeEvent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.String(maxLength: 128),
                        ChangedAt = c.DateTime(nullable: false),
                        ThreadId = c.Int(nullable: false),
                        BacklogItemStatusFrom = c.Int(),
                        BacklogItemStatusTo = c.Int(),
                        IdeaStatusFrom = c.Int(),
                        IdeaStatusTo = c.Int(),
                        IssueStatusFrom = c.Int(),
                        IssueStatusTo = c.Int(),
                        QuestionStatusFrom = c.Int(),
                        QuestionStatusTo = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.AuthorId)
                .ForeignKey("dbo.Thread", t => t.ThreadId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.ThreadId);
            
            CreateTable(
                "dbo.ThreadReply",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        TextMarkdown = c.String(),
                        ThreadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.AuthorId)
                .ForeignKey("dbo.Thread", t => t.ThreadId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.ThreadId);
            
            CreateTable(
                "dbo.ThreadReference",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReferencedThreadId = c.Int(nullable: false),
                        RefererThreadId = c.Int(),
                        RefererThreadReplyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Thread", t => t.ReferencedThreadId, cascadeDelete: true)
                .ForeignKey("dbo.Thread", t => t.RefererThreadId)
                .ForeignKey("dbo.ThreadReply", t => t.RefererThreadReplyId)
                .Index(t => t.ReferencedThreadId)
                .Index(t => t.RefererThreadId)
                .Index(t => t.RefererThreadReplyId);
            
            CreateTable(
                "dbo.ProductMember",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.String(maxLength: 128),
                        ProductId = c.Int(nullable: false),
                        MembershipType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.MemberId)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        DisplayName = c.String(nullable: false, maxLength: 40),
                        ShortDescription = c.String(maxLength: 120),
                        LongDescriptionMarkdown = c.String(),
                        WebsiteUrl = c.String(nullable: false, maxLength: 512),
                        Avatar = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "UQ_Name");
            
            CreateTable(
                "dbo.Release",
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
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ThreadRelease",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThreadId = c.Int(nullable: false),
                        ReleaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Release", t => t.ReleaseId, cascadeDelete: true)
                .ForeignKey("dbo.Thread", t => t.ThreadId, cascadeDelete: true)
                .Index(t => t.ThreadId)
                .Index(t => t.ReleaseId);
            
            CreateTable(
                "dbo.ApplicationUserFollowingProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ProductId = c.Int(nullable: false),
                        StartedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.UserRole", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ThreadReplyVote",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        ThreadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Thread", t => t.ThreadId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ThreadId);
            
            CreateTable(
                "dbo.ThreadVote",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        ThreadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Thread", t => t.ThreadId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ThreadId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.UserRole");
            DropForeignKey("dbo.ApplicationUserFollowingThread", "UserId", "dbo.User");
            DropForeignKey("dbo.ApplicationUserFollowingThread", "ThreadId", "dbo.Thread");
            DropForeignKey("dbo.Thread", "ParentThreadId", "dbo.Thread");
            DropForeignKey("dbo.ThreadVote", "UserId", "dbo.User");
            DropForeignKey("dbo.ThreadVote", "ThreadId", "dbo.Thread");
            DropForeignKey("dbo.Thread", "AuthorId", "dbo.User");
            DropForeignKey("dbo.ThreadReplyVote", "UserId", "dbo.User");
            DropForeignKey("dbo.ThreadReplyVote", "ThreadId", "dbo.Thread");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.User");
            DropForeignKey("dbo.ApplicationUserFollowingProduct", "UserId", "dbo.User");
            DropForeignKey("dbo.ApplicationUserFollowingProduct", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ThreadRelease", "ThreadId", "dbo.Thread");
            DropForeignKey("dbo.ThreadRelease", "ReleaseId", "dbo.Release");
            DropForeignKey("dbo.Release", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductMember", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductMember", "MemberId", "dbo.User");
            DropForeignKey("dbo.ApplicationUserNotification", "ThreadReplyId", "dbo.ThreadReply");
            DropForeignKey("dbo.ThreadReference", "RefererThreadReplyId", "dbo.ThreadReply");
            DropForeignKey("dbo.ThreadReference", "RefererThreadId", "dbo.Thread");
            DropForeignKey("dbo.ThreadReference", "ReferencedThreadId", "dbo.Thread");
            DropForeignKey("dbo.ThreadReply", "ThreadId", "dbo.Thread");
            DropForeignKey("dbo.ThreadReply", "AuthorId", "dbo.User");
            DropForeignKey("dbo.ApplicationUserNotification", "ThreadId", "dbo.Thread");
            DropForeignKey("dbo.ApplicationUserNotification", "TargetUserId", "dbo.User");
            DropForeignKey("dbo.ApplicationUserNotification", "RelatedThreadStatusChangeEventId", "dbo.ThreadStatusChangeEvent");
            DropForeignKey("dbo.ThreadStatusChangeEvent", "ThreadId", "dbo.Thread");
            DropForeignKey("dbo.ThreadStatusChangeEvent", "AuthorId", "dbo.User");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.User");
            DropIndex("dbo.UserRole", "RoleNameIndex");
            DropIndex("dbo.ThreadVote", new[] { "ThreadId" });
            DropIndex("dbo.ThreadVote", new[] { "UserId" });
            DropIndex("dbo.ThreadReplyVote", new[] { "ThreadId" });
            DropIndex("dbo.ThreadReplyVote", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.ApplicationUserFollowingProduct", new[] { "ProductId" });
            DropIndex("dbo.ApplicationUserFollowingProduct", new[] { "UserId" });
            DropIndex("dbo.ThreadRelease", new[] { "ReleaseId" });
            DropIndex("dbo.ThreadRelease", new[] { "ThreadId" });
            DropIndex("dbo.Release", new[] { "ProductId" });
            DropIndex("dbo.Product", "UQ_Name");
            DropIndex("dbo.ProductMember", new[] { "ProductId" });
            DropIndex("dbo.ProductMember", new[] { "MemberId" });
            DropIndex("dbo.ThreadReference", new[] { "RefererThreadReplyId" });
            DropIndex("dbo.ThreadReference", new[] { "RefererThreadId" });
            DropIndex("dbo.ThreadReference", new[] { "ReferencedThreadId" });
            DropIndex("dbo.ThreadReply", new[] { "ThreadId" });
            DropIndex("dbo.ThreadReply", new[] { "AuthorId" });
            DropIndex("dbo.ThreadStatusChangeEvent", new[] { "ThreadId" });
            DropIndex("dbo.ThreadStatusChangeEvent", new[] { "AuthorId" });
            DropIndex("dbo.ApplicationUserNotification", new[] { "RelatedThreadStatusChangeEventId" });
            DropIndex("dbo.ApplicationUserNotification", new[] { "ThreadReplyId" });
            DropIndex("dbo.ApplicationUserNotification", new[] { "ThreadId" });
            DropIndex("dbo.ApplicationUserNotification", new[] { "TargetUserId" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.Thread", new[] { "ParentThreadId" });
            DropIndex("dbo.Thread", new[] { "AuthorId" });
            DropIndex("dbo.ApplicationUserFollowingThread", new[] { "ThreadId" });
            DropIndex("dbo.ApplicationUserFollowingThread", new[] { "UserId" });
            DropTable("dbo.UserRole");
            DropTable("dbo.ThreadVote");
            DropTable("dbo.ThreadReplyVote");
            DropTable("dbo.UserRoles");
            DropTable("dbo.ApplicationUserFollowingProduct");
            DropTable("dbo.ThreadRelease");
            DropTable("dbo.Release");
            DropTable("dbo.Product");
            DropTable("dbo.ProductMember");
            DropTable("dbo.ThreadReference");
            DropTable("dbo.ThreadReply");
            DropTable("dbo.ThreadStatusChangeEvent");
            DropTable("dbo.ApplicationUserNotification");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.User");
            DropTable("dbo.Thread");
            DropTable("dbo.ApplicationUserFollowingThread");
        }
    }
}
