namespace MiniFilRouge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LigneCommandes",
                c => new
                    {
                        CommandeId = c.Int(nullable: false),
                        ProduitId = c.Int(nullable: false),
                        quantite = c.Int(nullable: false),
                        prix = c.Int(nullable: false),
                        PanierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CommandeId, t.ProduitId })
                .ForeignKey("dbo.Commandes", t => t.CommandeId, cascadeDelete: true)
                .ForeignKey("dbo.Paniers", t => t.PanierId, cascadeDelete: true)
                .ForeignKey("dbo.Produits", t => t.ProduitId, cascadeDelete: true)
                .Index(t => t.CommandeId)
                .Index(t => t.ProduitId)
                .Index(t => t.PanierId);
            
            CreateTable(
                "dbo.Paniers",
                c => new
                    {
                        PanierId = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.PanierId);
            
            AddColumn("dbo.Commandes", "DateCommande", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LigneCommandes", "ProduitId", "dbo.Produits");
            DropForeignKey("dbo.LigneCommandes", "PanierId", "dbo.Paniers");
            DropForeignKey("dbo.LigneCommandes", "CommandeId", "dbo.Commandes");
            DropIndex("dbo.LigneCommandes", new[] { "PanierId" });
            DropIndex("dbo.LigneCommandes", new[] { "ProduitId" });
            DropIndex("dbo.LigneCommandes", new[] { "CommandeId" });
            DropColumn("dbo.Commandes", "DateCommande");
            DropTable("dbo.Paniers");
            DropTable("dbo.LigneCommandes");
        }
    }
}
