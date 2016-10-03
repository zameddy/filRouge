namespace MiniFilRouge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Magasins", "NomMagasin", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Magasins", "NomMagasin", c => c.Int(nullable: false));
        }
    }
}
