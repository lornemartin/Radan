namespace RadanMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOpRelationShips : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.OrderItemOperationPerformeds", name: "OrderItemOperation_ID", newName: "orderItemOperationID");
            RenameColumn(table: "dbo.OrderItemOperationPerformeds", name: "OperationPerformed_ID", newName: "operationPerformedID");
            RenameIndex(table: "dbo.OrderItemOperationPerformeds", name: "IX_OrderItemOperation_ID", newName: "IX_orderItemOperationID");
            RenameIndex(table: "dbo.OrderItemOperationPerformeds", name: "IX_OperationPerformed_ID", newName: "IX_operationPerformedID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.OrderItemOperationPerformeds", name: "IX_operationPerformedID", newName: "IX_OperationPerformed_ID");
            RenameIndex(table: "dbo.OrderItemOperationPerformeds", name: "IX_orderItemOperationID", newName: "IX_OrderItemOperation_ID");
            RenameColumn(table: "dbo.OrderItemOperationPerformeds", name: "operationPerformedID", newName: "OperationPerformed_ID");
            RenameColumn(table: "dbo.OrderItemOperationPerformeds", name: "orderItemOperationID", newName: "OrderItemOperation_ID");
        }
    }
}
