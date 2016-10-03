namespace MiniFilRouge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Consulters", "Categorie_CategorieId", "dbo.Categories");
            DropIndex("dbo.Consulters", new[] { "Categorie_CategorieId" });
            DropColumn("dbo.Consulters", "Categorie_CategorieId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Consulters", "Categorie_CategorieId", c => c.Int());
            CreateIndex("dbo.Consulters", "Categorie_CategorieId");
            AddForeignKey("dbo.Consulters", "Categorie_CategorieId", "dbo.Categories", "CategorieId");
        }
    }
}
