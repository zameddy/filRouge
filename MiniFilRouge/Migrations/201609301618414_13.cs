namespace MiniFilRouge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consulters",
                c => new
                    {
                        ConsulterId = c.Int(nullable: false, identity: true),
                        ProduitId = c.Int(nullable: false),
                        UserAccountId = c.Int(nullable: false),
                        DateConsultation = c.DateTime(nullable: false),
                        Categorie_CategorieId = c.Int(),
                    })
                .PrimaryKey(t => t.ConsulterId)
                .ForeignKey("dbo.Categories", t => t.Categorie_CategorieId)
                .ForeignKey("dbo.Produits", t => t.ProduitId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccountId, cascadeDelete: true)
                .Index(t => t.ProduitId)
                .Index(t => t.UserAccountId)
                .Index(t => t.Categorie_CategorieId);
            
            AlterColumn("dbo.Produits", "NomProduit", c => c.String(nullable: false));
            AlterColumn("dbo.UserAccounts", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.UserAccounts", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.UserAccounts", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.UserAccounts", "Username", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.UserAccounts", "Password", c => c.String(nullable: false));
            CreateIndex("dbo.UserAccounts", "Username", unique: true, name: "Iusername");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consulters", "UserAccountId", "dbo.UserAccounts");
            DropForeignKey("dbo.Consulters", "ProduitId", "dbo.Produits");
            DropForeignKey("dbo.Consulters", "Categorie_CategorieId", "dbo.Categories");
            DropIndex("dbo.UserAccounts", "Iusername");
            DropIndex("dbo.Consulters", new[] { "Categorie_CategorieId" });
            DropIndex("dbo.Consulters", new[] { "UserAccountId" });
            DropIndex("dbo.Consulters", new[] { "ProduitId" });
            AlterColumn("dbo.UserAccounts", "Password", c => c.String());
            AlterColumn("dbo.UserAccounts", "Username", c => c.String());
            AlterColumn("dbo.UserAccounts", "Email", c => c.String());
            AlterColumn("dbo.UserAccounts", "LastName", c => c.String());
            AlterColumn("dbo.UserAccounts", "FirstName", c => c.String());
            AlterColumn("dbo.Produits", "NomProduit", c => c.String());
            DropTable("dbo.Consulters");
        }
    }
}
