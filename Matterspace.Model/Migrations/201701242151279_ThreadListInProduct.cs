namespace Matterspace.Model.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ThreadListInProduct : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Thread", "ProductId", c => c.Int(nullable: false));
            this.CreateIndex("dbo.Thread", "ProductId");
            this.AddForeignKey("dbo.Thread", "ProductId", "dbo.Product", "Id");
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.Thread", "ProductId", "dbo.Product");
            this.DropIndex("dbo.Thread", new[] { "ProductId" });
            this.DropColumn("dbo.Thread", "ProductId");
        }
    }
}
