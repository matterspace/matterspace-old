namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingusertypeonstatuschangeevent : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ThreadStatusChangeEvent", new[] { "Author_Id" });
            DropColumn("dbo.ThreadStatusChangeEvent", "AuthorId");
            RenameColumn(table: "dbo.ThreadStatusChangeEvent", name: "Author_Id", newName: "AuthorId");
            AlterColumn("dbo.ThreadStatusChangeEvent", "AuthorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ThreadStatusChangeEvent", "AuthorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ThreadStatusChangeEvent", new[] { "AuthorId" });
            AlterColumn("dbo.ThreadStatusChangeEvent", "AuthorId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ThreadStatusChangeEvent", name: "AuthorId", newName: "Author_Id");
            AddColumn("dbo.ThreadStatusChangeEvent", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.ThreadStatusChangeEvent", "Author_Id");
        }
    }
}
