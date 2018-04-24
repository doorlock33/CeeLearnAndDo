namespace CeeLearnAndDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Referentiesv4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.References", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.References", "Image", c => c.String(nullable: false));
        }
    }
}
