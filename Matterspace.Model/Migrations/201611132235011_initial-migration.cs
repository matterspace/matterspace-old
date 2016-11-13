namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DisplayName = c.String(),
                        ShortDescription = c.String(),
                        LongDescriptionMarkdown = c.String(),
                        Avatar = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropForeignKey("dbo.ThreadVote", "UserId", "dbo.User");
            DropForeignKey("dbo.ThreadVote", "ThreadId", "dbo.Thread");
            DropForeignKey("dbo.ThreadReplyVote", "UserId", "dbo.User");
            DropForeignKey("dbo.ThreadReplyVote", "ThreadId", "dbo.Thread");
            DropForeignKey("dbo.ThreadRelease", "ThreadId", "dbo.Thread");
            DropForeignKey("dbo.ThreadRelease", "ReleaseId", "dbo.Release");
            DropForeignKey("dbo.Release", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductMember", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ThreadReference", "RefererThreadReplyId", "dbo.ThreadReply");
            DropForeignKey("dbo.ThreadReference", "RefererThreadId", "dbo.Thread");
            DropForeignKey("dbo.ThreadReference", "ReferencedThreadId", "dbo.Thread");
            DropForeignKey("dbo.ThreadReply", "ThreadId", "dbo.Thread");
            DropForeignKey("dbo.Thread", "ParentThreadId", "dbo.Thread");
            DropForeignKey("dbo.Thread", "AuthorId", "dbo.User");
            DropForeignKey("dbo.ThreadReply", "AuthorId", "dbo.User");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.User");
            DropForeignKey("dbo.ProductMember", "MemberId", "dbo.User");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.User");
            DropIndex("dbo.UserRole", "RoleNameIndex");
            DropIndex("dbo.ThreadVote", new[] { "ThreadId" });
            DropIndex("dbo.ThreadVote", new[] { "UserId" });
            DropIndex("dbo.ThreadReplyVote", new[] { "ThreadId" });
            DropIndex("dbo.ThreadReplyVote", new[] { "UserId" });
            DropIndex("dbo.Release", new[] { "ProductId" });
            DropIndex("dbo.ThreadRelease", new[] { "ReleaseId" });
            DropIndex("dbo.ThreadRelease", new[] { "ThreadId" });
            DropIndex("dbo.ThreadReference", new[] { "RefererThreadReplyId" });
            DropIndex("dbo.ThreadReference", new[] { "RefererThreadId" });
            DropIndex("dbo.ThreadReference", new[] { "ReferencedThreadId" });
            DropIndex("dbo.Thread", new[] { "ParentThreadId" });
            DropIndex("dbo.Thread", new[] { "AuthorId" });
            DropIndex("dbo.ThreadReply", new[] { "ThreadId" });
            DropIndex("dbo.ThreadReply", new[] { "AuthorId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.ProductMember", new[] { "ProductId" });
            DropIndex("dbo.ProductMember", new[] { "MemberId" });
            DropTable("dbo.UserRole");
            DropTable("dbo.ThreadVote");
            DropTable("dbo.ThreadReplyVote");
            DropTable("dbo.Product");
            DropTable("dbo.Release");
            DropTable("dbo.ThreadRelease");
            DropTable("dbo.ThreadReference");
            DropTable("dbo.Thread");
            DropTable("dbo.ThreadReply");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.User");
            DropTable("dbo.ProductMember");
        }
    }
}
