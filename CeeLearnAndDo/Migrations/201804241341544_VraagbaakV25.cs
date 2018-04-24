namespace CeeLearnAndDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VraagbaakV25 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Questions", "AnsweredAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "AnsweredAt", c => c.DateTime(nullable: false));
        }
    }
}
