namespace MiniFilRouge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategorieId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.CategorieId);
            
            CreateTable(
                "dbo.Produits",
                c => new
                    {
                        ProduitId = c.Int(nullable: false, identity: true),
                        NomProduit = c.String(),
                        stock = c.Int(nullable: false),
                        prix = c.Int(nullable: false),
                        CategorieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProduitId)
                .ForeignKey("dbo.Categories", t => t.CategorieId, cascadeDelete: true)
                .Index(t => t.CategorieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produits", "CategorieId", "dbo.Categories");
            DropIndex("dbo.Produits", new[] { "CategorieId" });
            DropTable("dbo.Produits");
            DropTable("dbo.Categories");
        }
    }
}
