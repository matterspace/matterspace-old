namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedThreadTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Thread", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Thread", "Title");
        }
    }
}
