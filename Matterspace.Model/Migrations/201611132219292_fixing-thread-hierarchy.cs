namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingthreadhierarchy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Thread", "BacklogItemStatus", c => c.Int());
            AddColumn("dbo.Thread", "IdeaStatus", c => c.Int());
            AddColumn("dbo.Thread", "IssueStatus", c => c.Int());
            AddColumn("dbo.Thread", "QuestionStatus", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Thread", "QuestionStatus");
            DropColumn("dbo.Thread", "IssueStatus");
            DropColumn("dbo.Thread", "IdeaStatus");
            DropColumn("dbo.Thread", "BacklogItemStatus");
        }
    }
}
