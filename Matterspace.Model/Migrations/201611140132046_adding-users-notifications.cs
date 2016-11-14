namespace Matterspace.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingusersnotifications : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ApplicationUserNotification", new[] { "TargetUser_Id" });
            DropColumn("dbo.ApplicationUserNotification", "TargetUserId");
            RenameColumn(table: "dbo.ApplicationUserNotification", name: "TargetUser_Id", newName: "TargetUserId");
            AlterColumn("dbo.ApplicationUserNotification", "TargetUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.ApplicationUserNotification", "TargetUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ApplicationUserNotification", new[] { "TargetUserId" });
            AlterColumn("dbo.ApplicationUserNotification", "TargetUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ApplicationUserNotification", name: "TargetUserId", newName: "TargetUser_Id");
            AddColumn("dbo.ApplicationUserNotification", "TargetUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.ApplicationUserNotification", "TargetUser_Id");
        }
    }
}
