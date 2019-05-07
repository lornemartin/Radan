namespace RadanMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOperationsPerformed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OperationPerformeds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        qtyDone = c.Int(nullable: false),
                        timePerformed = c.DateTime(nullable: false),
                        OperationID = c.Int(nullable: false),
                        usr_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Operations", t => t.OperationID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.usr_UserID)
                .Index(t => t.OperationID)
                .Index(t => t.usr_UserID);
            
            AddColumn("dbo.Operations", "qtyRequired", c => c.Int(nullable: false));
            AddColumn("dbo.Operations", "qtyDone", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OperationPerformeds", "usr_UserID", "dbo.Users");
            DropForeignKey("dbo.OperationPerformeds", "OperationID", "dbo.Operations");
            DropIndex("dbo.OperationPerformeds", new[] { "usr_UserID" });
            DropIndex("dbo.OperationPerformeds", new[] { "OperationID" });
            DropColumn("dbo.Operations", "qtyDone");
            DropColumn("dbo.Operations", "qtyRequired");
            DropTable("dbo.OperationPerformeds");
        }
    }
}
