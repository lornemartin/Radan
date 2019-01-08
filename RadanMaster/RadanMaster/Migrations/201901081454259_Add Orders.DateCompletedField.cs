namespace RadanMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrdersDateCompletedField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DateCompleted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "DateCompleted");
        }
    }
}
