namespace EnvanterCreditWest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniDBSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchName = c.String(nullable: false),
                        Latitude = c.String(),
                        Longitude = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChangeDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Changes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        ChangesDetailsId = c.Int(nullable: false),
                        Description = c.String(),
                        IP = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChangeDetails", t => t.ChangesDetailsId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ChangesDetailsId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Brand = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        Barcode = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        ProductionDate = c.DateTime(nullable: false),
                        DateAcquired = c.DateTime(nullable: false),
                        Warranty = c.DateTime(nullable: false),
                        FirmId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Firms", t => t.FirmId, cascadeDelete: true)
                .Index(t => t.BranchId)
                .Index(t => t.FirmId);
            
            CreateTable(
                "dbo.Firms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                        VendorName = c.String(),
                        VendorEmail = c.String(),
                        VendorNumber = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Ram = c.String(),
                        CPU = c.String(),
                        OS = c.String(),
                        Size = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Typeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProducts", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Changes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "FirmId", "dbo.Firms");
            DropForeignKey("dbo.Products", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Changes", "ChangesDetailsId", "dbo.ChangeDetails");
            DropIndex("dbo.UserProducts", new[] { "UserId" });
            DropIndex("dbo.UserProducts", new[] { "ProductId" });
            DropIndex("dbo.ProductDetails", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "FirmId" });
            DropIndex("dbo.Products", new[] { "BranchId" });
            DropIndex("dbo.Changes", new[] { "ProductId" });
            DropIndex("dbo.Changes", new[] { "ChangesDetailsId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserProducts");
            DropTable("dbo.Typeys");
            DropTable("dbo.ProductDetails");
            DropTable("dbo.Firms");
            DropTable("dbo.Products");
            DropTable("dbo.Changes");
            DropTable("dbo.ChangeDetails");
            DropTable("dbo.Brands");
            DropTable("dbo.Branches");
        }
    }
}
