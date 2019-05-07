namespace RadanMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TweakedOps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Operations", "isFinalOp", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Operations", "isFinalOp");
        }
    }
}
