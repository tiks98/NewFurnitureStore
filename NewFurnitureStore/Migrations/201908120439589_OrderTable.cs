namespace NewFurnitureStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.String(),
                        OrderTotal = c.Double(nullable: false),
                        PId = c.Int(nullable: false),
                        PName = c.String(),
                        PPrice = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CustomerName = c.String(),
                        CustomerPhone = c.String(),
                        CustomerEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
