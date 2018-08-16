namespace EnvanterCreditWest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchName = c.String(nullable: false),
                        Adres = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
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
                        BrandId = c.Int(nullable: false),
                        ProductModelId = c.Int(nullable: false),
                        Barcode = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        UserId = c.Int(),
                        DateAcquired = c.DateTime(nullable: false),
                        Warranty = c.DateTime(nullable: false),
                        FirmId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Price = c.Single(nullable: false),
                        InvoiceURL = c.String(),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Firms", t => t.FirmId, cascadeDelete: true)
                .ForeignKey("dbo.ProductModels", t => t.ProductModelId, cascadeDelete: true)
                .ForeignKey("dbo.Typeys", t => t.TypeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.BrandId)
                .Index(t => t.ProductModelId)
                .Index(t => t.BranchId)
                .Index(t => t.UserId)
                .Index(t => t.FirmId)
                .Index(t => t.TypeId);
            
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
                "dbo.ProductModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Typeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstLastName = c.String(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Changes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "TypeId", "dbo.Typeys");
            DropForeignKey("dbo.Products", "ProductModelId", "dbo.ProductModels");
            DropForeignKey("dbo.Products", "FirmId", "dbo.Firms");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Products", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Changes", "ChangesDetailsId", "dbo.ChangeDetails");
            DropIndex("dbo.ProductDetails", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "TypeId" });
            DropIndex("dbo.Products", new[] { "FirmId" });
            DropIndex("dbo.Products", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "BranchId" });
            DropIndex("dbo.Products", new[] { "ProductModelId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Changes", new[] { "ProductId" });
            DropIndex("dbo.Changes", new[] { "ChangesDetailsId" });
            DropTable("dbo.ProductDetails");
            DropTable("dbo.Users");
            DropTable("dbo.Typeys");
            DropTable("dbo.ProductModels");
            DropTable("dbo.Firms");
            DropTable("dbo.Products");
            DropTable("dbo.Changes");
            DropTable("dbo.ChangeDetails");
            DropTable("dbo.Brands");
            DropTable("dbo.Branches");
        }
    }
}
