namespace MyShoppingCart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.InvoiceId })
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        CustomerName = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.InvoiceDetails", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.InvoiceDetails", new[] { "InvoiceId" });
            DropIndex("dbo.InvoiceDetails", new[] { "ProductId" });
            DropTable("dbo.Products");
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceDetails");
        }
    }
}
