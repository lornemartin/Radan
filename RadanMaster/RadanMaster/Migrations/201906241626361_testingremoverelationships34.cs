namespace RadanMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingremoverelationships34 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OperationPerformeds", "timePerformed", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OperationPerformeds", "timePerformed");
        }
    }
}
