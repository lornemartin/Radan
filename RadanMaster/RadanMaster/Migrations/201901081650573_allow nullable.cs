namespace RadanMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allownullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "DateCompleted", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "DateCompleted", c => c.DateTime(nullable: false));
        }
    }
}
