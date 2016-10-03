
namespace MiniFilRouge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commandes",
                c => new
                    {
                        CommandeId = c.Int(nullable: false, identity: true),
                        Statut = c.String(),
                        UserAccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommandeId)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccountId, cascadeDelete: true)
                .Index(t => t.UserAccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commandes", "UserAccountId", "dbo.UserAccounts");
            DropIndex("dbo.Commandes", new[] { "UserAccountId" });
            DropTable("dbo.Commandes");
        }
    }
}
