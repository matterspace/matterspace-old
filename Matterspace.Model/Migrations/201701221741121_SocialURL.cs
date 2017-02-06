namespace Matterspace.Model.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class SocialURL : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Product", "FacebookUrl", c => c.String(maxLength: 512));
            this.AddColumn("dbo.Product", "TwitterUrl", c => c.String(maxLength: 512));
        }
        
        public override void Down()
        {
            this.DropColumn("dbo.Product", "TwitterUrl");
            this.DropColumn("dbo.Product", "FacebookUrl");
        }
    }
}
