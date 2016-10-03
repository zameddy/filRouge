namespace MiniFilRouge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProduitMagasins",
                c => new
                    {
                        MagasinId = c.Int(nullable: false),
                        ProduitId = c.Int(nullable: false),
                        quantite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MagasinId, t.ProduitId })
                .ForeignKey("dbo.Magasins", t => t.MagasinId, cascadeDelete: true)
                .ForeignKey("dbo.Produits", t => t.ProduitId, cascadeDelete: true)
                .Index(t => t.MagasinId)
                .Index(t => t.ProduitId);
            
            CreateTable(
                "dbo.Magasins",
                c => new
                    {
                        MagasinId = c.Int(nullable: false, identity: true),
                        NomMagasin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MagasinId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProduitMagasins", "ProduitId", "dbo.Produits");
            DropForeignKey("dbo.ProduitMagasins", "MagasinId", "dbo.Magasins");
            DropIndex("dbo.ProduitMagasins", new[] { "ProduitId" });
            DropIndex("dbo.ProduitMagasins", new[] { "MagasinId" });
            DropTable("dbo.Magasins");
            DropTable("dbo.ProduitMagasins");
        }
    }
}
