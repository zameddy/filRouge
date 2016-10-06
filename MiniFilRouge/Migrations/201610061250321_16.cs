namespace MiniFilRouge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        AdresseId = c.Int(nullable: false, identity: true),
                        NumRue = c.String(),
                        NomRue = c.String(),
                        CodePostal = c.String(),
                        Ville = c.String(),
                    })
                .PrimaryKey(t => t.AdresseId);
            
            AddColumn("dbo.UserAccounts", "AdresseId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserAccounts", "AdresseId");
            AddForeignKey("dbo.UserAccounts", "AdresseId", "dbo.Adresses", "AdresseId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAccounts", "AdresseId", "dbo.Adresses");
            DropIndex("dbo.UserAccounts", new[] { "AdresseId" });
            DropColumn("dbo.UserAccounts", "AdresseId");
            DropTable("dbo.Adresses");
        }
    }
}
