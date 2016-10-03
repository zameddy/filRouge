namespace MiniFilRouge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LigneCommandes", "PanierId", "dbo.Paniers");
            DropIndex("dbo.LigneCommandes", new[] { "PanierId" });
            AddColumn("dbo.Produits", "selectionne", c => c.Boolean(nullable: false));
            DropColumn("dbo.LigneCommandes", "PanierId");
            DropTable("dbo.Paniers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Paniers",
                c => new
                    {
                        PanierId = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.PanierId);
            
            AddColumn("dbo.LigneCommandes", "PanierId", c => c.Int(nullable: false));
            DropColumn("dbo.Produits", "selectionne");
            CreateIndex("dbo.LigneCommandes", "PanierId");
            AddForeignKey("dbo.LigneCommandes", "PanierId", "dbo.Paniers", "PanierId", cascadeDelete: true);
        }
    }
}
