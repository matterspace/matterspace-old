namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingthreadstatuschangeevents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ThreadStatusChangeEvent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
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
                        Author_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Author_Id)
                .ForeignKey("dbo.Thread", t => t.ThreadId, cascadeDelete: true)
                .Index(t => t.ThreadId)
                .Index(t => t.Author_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ThreadStatusChangeEvent", "ThreadId", "dbo.Thread");
            DropForeignKey("dbo.ThreadStatusChangeEvent", "Author_Id", "dbo.User");
            DropIndex("dbo.ThreadStatusChangeEvent", new[] { "Author_Id" });
            DropIndex("dbo.ThreadStatusChangeEvent", new[] { "ThreadId" });
            DropTable("dbo.ThreadStatusChangeEvent");
        }
    }
}
