namespace Matterspace.Model.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ThreadStatus : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Thread", "Status", c => c.Int(nullable: false));
            this.AddColumn("dbo.Thread", "Type", c => c.Int(nullable: false));
            this.DropColumn("dbo.Thread", "ThreadType");
        }
        
        public override void Down()
        {
            this.AddColumn("dbo.Thread", "ThreadType", c => c.Int(nullable: false));
            this.DropColumn("dbo.Thread", "Type");
            this.DropColumn("dbo.Thread", "Status");
        }
    }
}
