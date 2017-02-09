namespace Matterspace.Model.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
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

            this.CreateTable(
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

            this.CreateTable(
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

            this.CreateTable(
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

            this.CreateTable(
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

            this.CreateTable(
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

            this.CreateTable(
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

            this.CreateTable(
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

            this.CreateTable(
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

            this.CreateTable(
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

            this.CreateTable(
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

            this.CreateTable(
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

            this.CreateTable(
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

            this.CreateTable(
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

            this.CreateTable(
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

            this.CreateTable(
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

            this.CreateTable(
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

            this.CreateTable(
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
            this.DropForeignKey("dbo.UserRoles", "RoleId", "dbo.UserRole");
            this.DropForeignKey("dbo.ApplicationUserFollowingThread", "UserId", "dbo.User");
            this.DropForeignKey("dbo.ApplicationUserFollowingThread", "ThreadId", "dbo.Thread");
            this.DropForeignKey("dbo.Thread", "ParentThreadId", "dbo.Thread");
            this.DropForeignKey("dbo.ThreadVote", "UserId", "dbo.User");
            this.DropForeignKey("dbo.ThreadVote", "ThreadId", "dbo.Thread");
            this.DropForeignKey("dbo.Thread", "AuthorId", "dbo.User");
            this.DropForeignKey("dbo.ThreadReplyVote", "UserId", "dbo.User");
            this.DropForeignKey("dbo.ThreadReplyVote", "ThreadId", "dbo.Thread");
            this.DropForeignKey("dbo.UserRoles", "UserId", "dbo.User");
            this.DropForeignKey("dbo.ApplicationUserFollowingProduct", "UserId", "dbo.User");
            this.DropForeignKey("dbo.ApplicationUserFollowingProduct", "ProductId", "dbo.Product");
            this.DropForeignKey("dbo.ThreadRelease", "ThreadId", "dbo.Thread");
            this.DropForeignKey("dbo.ThreadRelease", "ReleaseId", "dbo.Release");
            this.DropForeignKey("dbo.Release", "ProductId", "dbo.Product");
            this.DropForeignKey("dbo.ProductMember", "ProductId", "dbo.Product");
            this.DropForeignKey("dbo.ProductMember", "MemberId", "dbo.User");
            this.DropForeignKey("dbo.ApplicationUserNotification", "ThreadReplyId", "dbo.ThreadReply");
            this.DropForeignKey("dbo.ThreadReference", "RefererThreadReplyId", "dbo.ThreadReply");
            this.DropForeignKey("dbo.ThreadReference", "RefererThreadId", "dbo.Thread");
            this.DropForeignKey("dbo.ThreadReference", "ReferencedThreadId", "dbo.Thread");
            this.DropForeignKey("dbo.ThreadReply", "ThreadId", "dbo.Thread");
            this.DropForeignKey("dbo.ThreadReply", "AuthorId", "dbo.User");
            this.DropForeignKey("dbo.ApplicationUserNotification", "ThreadId", "dbo.Thread");
            this.DropForeignKey("dbo.ApplicationUserNotification", "TargetUserId", "dbo.User");
            this.DropForeignKey("dbo.ApplicationUserNotification", "RelatedThreadStatusChangeEventId", "dbo.ThreadStatusChangeEvent");
            this.DropForeignKey("dbo.ThreadStatusChangeEvent", "ThreadId", "dbo.Thread");
            this.DropForeignKey("dbo.ThreadStatusChangeEvent", "AuthorId", "dbo.User");
            this.DropForeignKey("dbo.UserLogins", "UserId", "dbo.User");
            this.DropForeignKey("dbo.UserClaims", "UserId", "dbo.User");
            this.DropIndex("dbo.UserRole", "RoleNameIndex");
            this.DropIndex("dbo.ThreadVote", new[] { "ThreadId" });
            this.DropIndex("dbo.ThreadVote", new[] { "UserId" });
            this.DropIndex("dbo.ThreadReplyVote", new[] { "ThreadId" });
            this.DropIndex("dbo.ThreadReplyVote", new[] { "UserId" });
            this.DropIndex("dbo.UserRoles", new[] { "RoleId" });
            this.DropIndex("dbo.UserRoles", new[] { "UserId" });
            this.DropIndex("dbo.ApplicationUserFollowingProduct", new[] { "ProductId" });
            this.DropIndex("dbo.ApplicationUserFollowingProduct", new[] { "UserId" });
            this.DropIndex("dbo.ThreadRelease", new[] { "ReleaseId" });
            this.DropIndex("dbo.ThreadRelease", new[] { "ThreadId" });
            this.DropIndex("dbo.Release", new[] { "ProductId" });
            this.DropIndex("dbo.Product", "UQ_Name");
            this.DropIndex("dbo.ProductMember", new[] { "ProductId" });
            this.DropIndex("dbo.ProductMember", new[] { "MemberId" });
            this.DropIndex("dbo.ThreadReference", new[] { "RefererThreadReplyId" });
            this.DropIndex("dbo.ThreadReference", new[] { "RefererThreadId" });
            this.DropIndex("dbo.ThreadReference", new[] { "ReferencedThreadId" });
            this.DropIndex("dbo.ThreadReply", new[] { "ThreadId" });
            this.DropIndex("dbo.ThreadReply", new[] { "AuthorId" });
            this.DropIndex("dbo.ThreadStatusChangeEvent", new[] { "ThreadId" });
            this.DropIndex("dbo.ThreadStatusChangeEvent", new[] { "AuthorId" });
            this.DropIndex("dbo.ApplicationUserNotification", new[] { "RelatedThreadStatusChangeEventId" });
            this.DropIndex("dbo.ApplicationUserNotification", new[] { "ThreadReplyId" });
            this.DropIndex("dbo.ApplicationUserNotification", new[] { "ThreadId" });
            this.DropIndex("dbo.ApplicationUserNotification", new[] { "TargetUserId" });
            this.DropIndex("dbo.UserLogins", new[] { "UserId" });
            this.DropIndex("dbo.UserClaims", new[] { "UserId" });
            this.DropIndex("dbo.User", "UserNameIndex");
            this.DropIndex("dbo.Thread", new[] { "ParentThreadId" });
            this.DropIndex("dbo.Thread", new[] { "AuthorId" });
            this.DropIndex("dbo.ApplicationUserFollowingThread", new[] { "ThreadId" });
            this.DropIndex("dbo.ApplicationUserFollowingThread", new[] { "UserId" });
            this.DropTable("dbo.UserRole");
            this.DropTable("dbo.ThreadVote");
            this.DropTable("dbo.ThreadReplyVote");
            this.DropTable("dbo.UserRoles");
            this.DropTable("dbo.ApplicationUserFollowingProduct");
            this.DropTable("dbo.ThreadRelease");
            this.DropTable("dbo.Release");
            this.DropTable("dbo.Product");
            this.DropTable("dbo.ProductMember");
            this.DropTable("dbo.ThreadReference");
            this.DropTable("dbo.ThreadReply");
            this.DropTable("dbo.ThreadStatusChangeEvent");
            this.DropTable("dbo.ApplicationUserNotification");
            this.DropTable("dbo.UserLogins");
            this.DropTable("dbo.UserClaims");
            this.DropTable("dbo.User");
            this.DropTable("dbo.Thread");
            this.DropTable("dbo.ApplicationUserFollowingThread");
        }
    }
}
