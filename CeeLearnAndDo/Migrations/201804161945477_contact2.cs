namespace CeeLearnAndDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contact2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "FullName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Contacts", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Contacts", "Message", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Contacts", "PhoneNumber", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "PhoneNumber", c => c.String(maxLength: 15));
            AlterColumn("dbo.Contacts", "Message", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Contacts", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.Contacts", "FullName", c => c.String(maxLength: 100));
        }
    }
}
