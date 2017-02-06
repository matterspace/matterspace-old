namespace Matterspace.Model.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedThreadTitle : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Thread", "Title", c => c.String());
        }
        
        public override void Down()
        {
            this.DropColumn("dbo.Thread", "Title");
        }
    }
}
