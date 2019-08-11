namespace NewFurnitureStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhoneToUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CustomerName", c => c.String());
            AddColumn("dbo.AspNetUsers", "CustomerPhone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CustomerPhone");
            DropColumn("dbo.AspNetUsers", "CustomerName");
        }
    }
}
