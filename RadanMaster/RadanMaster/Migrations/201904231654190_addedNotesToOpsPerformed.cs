namespace RadanMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNotesToOpsPerformed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OperationPerformeds", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OperationPerformeds", "Notes");
        }
    }
}
