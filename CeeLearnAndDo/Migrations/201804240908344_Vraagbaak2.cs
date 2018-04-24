namespace CeeLearnAndDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vraagbaak2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "Content", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "Content", c => c.String(nullable: false));
        }
    }
}
