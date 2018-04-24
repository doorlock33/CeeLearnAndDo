namespace CeeLearnAndDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VraagbaakV23 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Questions", name: "UserId", newName: "User_Id");
            RenameIndex(table: "dbo.Questions", name: "IX_UserId", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Questions", name: "IX_User_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.Questions", name: "User_Id", newName: "UserId");
        }
    }
}
