namespace RadanMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReleaseDate = c.DateTime(nullable: false),
                        IsComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BatchItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BatchID = c.Int(nullable: false),
                        IsComplete = c.Boolean(nullable: false),
                        Qty = c.Int(nullable: false),
                        Part_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Parts", t => t.Part_ID)
                .ForeignKey("dbo.Batches", t => t.BatchID, cascadeDelete: true)
                .Index(t => t.BatchID)
                .Index(t => t.Part_ID);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        Description = c.String(),
                        Material = c.String(),
                        Thickness = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        IsComplete = c.Boolean(nullable: false),
                        Qty = c.Int(nullable: false),
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
                        OrderEntryDate = c.DateTime(nullable: false),
                        OrderDueDate = c.DateTime(nullable: false),
                        IsComplete = c.Boolean(nullable: false),
                        IsBatch = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "PartID", "dbo.Parts");
            DropForeignKey("dbo.OrderItems", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.BatchItems", "BatchID", "dbo.Batches");
            DropForeignKey("dbo.BatchItems", "Part_ID", "dbo.Parts");
            DropIndex("dbo.OrderItems", new[] { "PartID" });
            DropIndex("dbo.OrderItems", new[] { "OrderID" });
            DropIndex("dbo.BatchItems", new[] { "Part_ID" });
            DropIndex("dbo.BatchItems", new[] { "BatchID" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Parts");
            DropTable("dbo.BatchItems");
            DropTable("dbo.Batches");
        }
    }
}
