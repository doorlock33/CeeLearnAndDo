namespace CeeLearnAndDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteQuestion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Questions", new[] { "UserId" });
            DropTable("dbo.Questions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Content = c.String(),
                        AnsweredAt = c.DateTime(nullable: false),
                        Approved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Questions", "UserId");
            AddForeignKey("dbo.Questions", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
