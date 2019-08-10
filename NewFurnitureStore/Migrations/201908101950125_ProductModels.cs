namespace NewFurnitureStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        WoodTypeId = c.Int(nullable: false),
                        Discription = c.String(),
                        Brand = c.String(),
                        Color = c.String(),
                        Price = c.Double(nullable: false),
                        ProductTypeId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("dbo.WoodTypes", t => t.WoodTypeId, cascadeDelete: true)
                .Index(t => t.WoodTypeId)
                .Index(t => t.ProductTypeId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WoodTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "WoodTypeId", "dbo.WoodTypes");
            DropForeignKey("dbo.Products", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "StoreId" });
            DropIndex("dbo.Products", new[] { "ProductTypeId" });
            DropIndex("dbo.Products", new[] { "WoodTypeId" });
            DropTable("dbo.WoodTypes");
            DropTable("dbo.Stores");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Products");
        }
    }
}
