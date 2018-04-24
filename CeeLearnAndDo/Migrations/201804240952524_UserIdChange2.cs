namespace CeeLearnAndDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdChange2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Articles", new[] { "User_Id" });
            DropIndex("dbo.Questions", new[] { "User_Id" });
            DropColumn("dbo.Articles", "UserId");
            DropColumn("dbo.Questions", "UserId");
            RenameColumn(table: "dbo.Articles", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.Questions", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Articles", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Questions", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Articles", "UserId");
            CreateIndex("dbo.Questions", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Questions", new[] { "UserId" });
            DropIndex("dbo.Articles", new[] { "UserId" });
            AlterColumn("dbo.Questions", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Articles", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Questions", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Articles", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Questions", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Articles", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "User_Id");
            CreateIndex("dbo.Articles", "User_Id");
        }
    }
}
