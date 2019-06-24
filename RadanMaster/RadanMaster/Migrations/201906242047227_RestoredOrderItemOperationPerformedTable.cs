namespace RadanMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestoredOrderItemOperationPerformedTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.OrderItemOperationPerformeds", new[] { "OrderItemOperation_ID" });
            RenameColumn(table: "dbo.OrderItemOperationPerformeds", name: "operationPerformedID", newName: "opPerformedID");
            RenameIndex(table: "dbo.OrderItemOperationPerformeds", name: "IX_operationPerformedID", newName: "IX_opPerformedID");
            AddColumn("dbo.OrderItemOperationPerformeds", "orderItemOpID", c => c.Int());
            CreateIndex("dbo.OrderItemOperationPerformeds", "orderItemOperation_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.OrderItemOperationPerformeds", new[] { "orderItemOperation_ID" });
            DropColumn("dbo.OrderItemOperationPerformeds", "orderItemOpID");
            RenameIndex(table: "dbo.OrderItemOperationPerformeds", name: "IX_opPerformedID", newName: "IX_operationPerformedID");
            RenameColumn(table: "dbo.OrderItemOperationPerformeds", name: "opPerformedID", newName: "operationPerformedID");
            CreateIndex("dbo.OrderItemOperationPerformeds", "OrderItemOperation_ID");
        }
    }
}
