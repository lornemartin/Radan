namespace RadanMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class current : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        Part_ID = c.Int(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Parts", t => t.Part_ID)
                .Index(t => t.Part_ID);
            
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        PartID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Parts", t => t.PartID, cascadeDelete: true)
                .Index(t => t.PartID);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Thickness = c.Single(nullable: false),
                        StructuralCode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Orders", "DateCompleted", c => c.DateTime());
            AddColumn("dbo.Parts", "Title", c => c.String());
            AddColumn("dbo.Parts", "ParentPartNumber", c => c.String());
            AddColumn("dbo.Parts", "CategoryName", c => c.String());
            AddColumn("dbo.Parts", "StructuralCode", c => c.String());
            AddColumn("dbo.Parts", "PlantID", c => c.String());
            AddColumn("dbo.Parts", "IsStock", c => c.Boolean(nullable: false));
            AddColumn("dbo.Parts", "RequiresPDF", c => c.Boolean(nullable: false));
            AddColumn("dbo.Parts", "Comment", c => c.String());
            AddColumn("dbo.Parts", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Parts", "State", c => c.String());
            AddColumn("dbo.Parts", "Keywords", c => c.String());
            AddColumn("dbo.Parts", "Notes", c => c.String());
            AddColumn("dbo.Parts", "Revision", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operations", "PartID", "dbo.Parts");
            DropForeignKey("dbo.Files", "Part_ID", "dbo.Parts");
            DropIndex("dbo.Operations", new[] { "PartID" });
            DropIndex("dbo.Files", new[] { "Part_ID" });
            DropColumn("dbo.Parts", "Revision");
            DropColumn("dbo.Parts", "Notes");
            DropColumn("dbo.Parts", "Keywords");
            DropColumn("dbo.Parts", "State");
            DropColumn("dbo.Parts", "ModifiedDate");
            DropColumn("dbo.Parts", "Comment");
            DropColumn("dbo.Parts", "RequiresPDF");
            DropColumn("dbo.Parts", "IsStock");
            DropColumn("dbo.Parts", "PlantID");
            DropColumn("dbo.Parts", "StructuralCode");
            DropColumn("dbo.Parts", "CategoryName");
            DropColumn("dbo.Parts", "ParentPartNumber");
            DropColumn("dbo.Parts", "Title");
            DropColumn("dbo.Orders", "DateCompleted");
            DropTable("dbo.Materials");
            DropTable("dbo.Operations");
            DropTable("dbo.Files");
        }
    }
}
