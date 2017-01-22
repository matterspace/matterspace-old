namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SocialURL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "FacebookUrl", c => c.String(maxLength: 512));
            AddColumn("dbo.Product", "TwitterUrl", c => c.String(maxLength: 512));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "TwitterUrl");
            DropColumn("dbo.Product", "FacebookUrl");
        }
    }
}
