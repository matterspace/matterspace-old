namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeowneridfromproduct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Product", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "OwnerId", c => c.Int(nullable: false));
        }
    }
}
