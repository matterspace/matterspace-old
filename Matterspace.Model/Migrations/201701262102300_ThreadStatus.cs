namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThreadStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Thread", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Thread", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Thread", "ThreadType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Thread", "ThreadType", c => c.Int(nullable: false));
            DropColumn("dbo.Thread", "Type");
            DropColumn("dbo.Thread", "Status");
        }
    }
}
