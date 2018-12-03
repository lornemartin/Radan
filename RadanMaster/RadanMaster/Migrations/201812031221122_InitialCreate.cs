namespace RadanMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NestedParts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Qty = c.Int(nullable: false),
                        Part_ID = c.Int(),
                        Nest_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Parts", t => t.Part_ID)
                .ForeignKey("dbo.Nests", t => t.Nest_ID)
                .Index(t => t.Part_ID)
                .Index(t => t.Nest_ID);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        Description = c.String(),
                        Material = c.String(),
                        Thickness = c.Double(nullable: false),
                        Thumbnail = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Nests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nestName = c.String(),
                        nestPath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        IsComplete = c.Boolean(nullable: false),
                        QtyRequired = c.Int(nullable: false),
                        QtyNested = c.Int(nullable: false),
                        IsInProject = c.Boolean(nullable: false),
                        PartID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.PartID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.PartID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderNumber = c.String(),
                        ScheduleName = c.String(),
                        BatchName = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        IsComplete = c.Boolean(nullable: false),
                        IsBatch = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderItemNests",
                c => new
                    {
                        OrderItem_ID = c.Int(nullable: false),
                        Nest_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderItem_ID, t.Nest_ID })
                .ForeignKey("dbo.OrderItems", t => t.OrderItem_ID, cascadeDelete: true)
                .ForeignKey("dbo.Nests", t => t.Nest_ID, cascadeDelete: true)
                .Index(t => t.OrderItem_ID)
                .Index(t => t.Nest_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "PartID", "dbo.Parts");
            DropForeignKey("dbo.OrderItems", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderItemNests", "Nest_ID", "dbo.Nests");
            DropForeignKey("dbo.OrderItemNests", "OrderItem_ID", "dbo.OrderItems");
            DropForeignKey("dbo.NestedParts", "Nest_ID", "dbo.Nests");
            DropForeignKey("dbo.NestedParts", "Part_ID", "dbo.Parts");
            DropIndex("dbo.OrderItemNests", new[] { "Nest_ID" });
            DropIndex("dbo.OrderItemNests", new[] { "OrderItem_ID" });
            DropIndex("dbo.OrderItems", new[] { "PartID" });
            DropIndex("dbo.OrderItems", new[] { "OrderID" });
            DropIndex("dbo.NestedParts", new[] { "Nest_ID" });
            DropIndex("dbo.NestedParts", new[] { "Part_ID" });
            DropTable("dbo.OrderItemNests");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Nests");
            DropTable("dbo.Parts");
            DropTable("dbo.NestedParts");
        }
    }
}
