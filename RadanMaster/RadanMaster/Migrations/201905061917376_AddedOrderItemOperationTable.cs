namespace RadanMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderItemOperationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItemOperations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        qtyRequired = c.Int(nullable: false),
                        qtyDone = c.Int(nullable: false),
                        operationID = c.Int(nullable: false),
                        OrderItem_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Operations", t => t.operationID, cascadeDelete: true)
                .ForeignKey("dbo.OrderItems", t => t.OrderItem_ID)
                .Index(t => t.operationID)
                .Index(t => t.OrderItem_ID);
            
            AddColumn("dbo.OperationPerformeds", "OrderItemOperation_ID", c => c.Int());
            CreateIndex("dbo.OperationPerformeds", "OrderItemOperation_ID");
            AddForeignKey("dbo.OperationPerformeds", "OrderItemOperation_ID", "dbo.OrderItemOperations", "ID");
            DropColumn("dbo.Operations", "qtyRequired");
            DropColumn("dbo.Operations", "qtyDone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Operations", "qtyDone", c => c.Int(nullable: false));
            AddColumn("dbo.Operations", "qtyRequired", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderItemOperations", "OrderItem_ID", "dbo.OrderItems");
            DropForeignKey("dbo.OperationPerformeds", "OrderItemOperation_ID", "dbo.OrderItemOperations");
            DropForeignKey("dbo.OrderItemOperations", "operationID", "dbo.Operations");
            DropIndex("dbo.OperationPerformeds", new[] { "OrderItemOperation_ID" });
            DropIndex("dbo.OrderItemOperations", new[] { "OrderItem_ID" });
            DropIndex("dbo.OrderItemOperations", new[] { "operationID" });
            DropColumn("dbo.OperationPerformeds", "OrderItemOperation_ID");
            DropTable("dbo.OrderItemOperations");
        }
    }
}
