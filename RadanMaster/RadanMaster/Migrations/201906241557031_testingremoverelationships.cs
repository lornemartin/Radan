namespace RadanMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingremoverelationships : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.OrderItemOperationPerformeds", name: "orderItemOperationID", newName: "OrderItemOperation_ID");
            RenameIndex(table: "dbo.OrderItemOperationPerformeds", name: "IX_orderItemOperationID", newName: "IX_OrderItemOperation_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.OrderItemOperationPerformeds", name: "IX_OrderItemOperation_ID", newName: "IX_orderItemOperationID");
            RenameColumn(table: "dbo.OrderItemOperationPerformeds", name: "OrderItemOperation_ID", newName: "orderItemOperationID");
        }
    }
}
