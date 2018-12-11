namespace RadanMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHasBendproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parts", "HasBends", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parts", "HasBends");
        }
    }
}
