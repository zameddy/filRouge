namespace MiniFilRouge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        NomRole = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
            AddColumn("dbo.UserAccounts", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserAccounts", "RoleId");
            AddForeignKey("dbo.UserAccounts", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAccounts", "RoleId", "dbo.Roles");
            DropIndex("dbo.UserAccounts", new[] { "RoleId" });
            DropColumn("dbo.UserAccounts", "RoleId");
            DropTable("dbo.Roles");
        }
    }
}
