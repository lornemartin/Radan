namespace RadanMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingremoverelationships3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.OperationPerformeds", name: "User_UserID", newName: "usr_UserID");
            RenameIndex(table: "dbo.OperationPerformeds", name: "IX_User_UserID", newName: "IX_usr_UserID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.OperationPerformeds", name: "IX_usr_UserID", newName: "IX_User_UserID");
            RenameColumn(table: "dbo.OperationPerformeds", name: "usr_UserID", newName: "User_UserID");
        }
    }
}
