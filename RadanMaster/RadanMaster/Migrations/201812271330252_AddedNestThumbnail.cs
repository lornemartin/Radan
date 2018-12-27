namespace RadanMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNestThumbnail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nests", "Thumbnail", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Nests", "Thumbnail");
        }
    }
}
