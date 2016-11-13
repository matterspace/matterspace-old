namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingreferencestousers : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProductMember", new[] { "Member_Id" });
            DropIndex("dbo.ThreadReply", new[] { "Author_Id" });
            DropIndex("dbo.Thread", new[] { "Author_Id" });
            DropIndex("dbo.ThreadReplyVote", new[] { "User_Id" });
            DropIndex("dbo.ThreadVote", new[] { "User_Id" });
            DropColumn("dbo.ProductMember", "MemberId");
            DropColumn("dbo.ThreadReply", "AuthorId");
            DropColumn("dbo.Thread", "AuthorId");
            DropColumn("dbo.ThreadReplyVote", "UserId");
            DropColumn("dbo.ThreadVote", "UserId");
            RenameColumn(table: "dbo.ProductMember", name: "Member_Id", newName: "MemberId");
            RenameColumn(table: "dbo.ThreadReply", name: "Author_Id", newName: "AuthorId");
            RenameColumn(table: "dbo.ThreadReplyVote", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.Thread", name: "Author_Id", newName: "AuthorId");
            RenameColumn(table: "dbo.ThreadVote", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.ProductMember", "MemberId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ThreadReply", "AuthorId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Thread", "AuthorId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ThreadReplyVote", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.ThreadVote", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ProductMember", "MemberId");
            CreateIndex("dbo.ThreadReply", "AuthorId");
            CreateIndex("dbo.Thread", "AuthorId");
            CreateIndex("dbo.ThreadReplyVote", "UserId");
            CreateIndex("dbo.ThreadVote", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ThreadVote", new[] { "UserId" });
            DropIndex("dbo.ThreadReplyVote", new[] { "UserId" });
            DropIndex("dbo.Thread", new[] { "AuthorId" });
            DropIndex("dbo.ThreadReply", new[] { "AuthorId" });
            DropIndex("dbo.ProductMember", new[] { "MemberId" });
            AlterColumn("dbo.ThreadVote", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.ThreadReplyVote", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Thread", "AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.ThreadReply", "AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductMember", "MemberId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ThreadVote", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Thread", name: "AuthorId", newName: "Author_Id");
            RenameColumn(table: "dbo.ThreadReplyVote", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.ThreadReply", name: "AuthorId", newName: "Author_Id");
            RenameColumn(table: "dbo.ProductMember", name: "MemberId", newName: "Member_Id");
            AddColumn("dbo.ThreadVote", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.ThreadReplyVote", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Thread", "AuthorId", c => c.Int(nullable: false));
            AddColumn("dbo.ThreadReply", "AuthorId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductMember", "MemberId", c => c.Int(nullable: false));
            CreateIndex("dbo.ThreadVote", "User_Id");
            CreateIndex("dbo.ThreadReplyVote", "User_Id");
            CreateIndex("dbo.Thread", "Author_Id");
            CreateIndex("dbo.ThreadReply", "Author_Id");
            CreateIndex("dbo.ProductMember", "Member_Id");
        }
    }
}
