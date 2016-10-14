namespace MiniFilRouge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _17 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Roles", "NomRole", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "NomRole", c => c.Int(nullable: false));
        }
    }
}
