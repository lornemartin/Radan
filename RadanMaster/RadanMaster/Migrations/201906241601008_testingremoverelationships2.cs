namespace RadanMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingremoverelationships2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.OperationPerformeds", name: "usr_UserID", newName: "User_UserID");
            RenameIndex(table: "dbo.OperationPerformeds", name: "IX_usr_UserID", newName: "IX_User_UserID");
            DropColumn("dbo.OperationPerformeds", "timePerformed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OperationPerformeds", "timePerformed", c => c.DateTime(nullable: false));
            RenameIndex(table: "dbo.OperationPerformeds", name: "IX_User_UserID", newName: "IX_usr_UserID");
            RenameColumn(table: "dbo.OperationPerformeds", name: "User_UserID", newName: "usr_UserID");
        }
    }
}
