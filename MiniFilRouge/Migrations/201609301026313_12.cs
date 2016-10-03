namespace MiniFilRouge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserAccounts", "commentaires");
            //DropColumn("dbo.UserAccounts", "Discriminator");
        }
        
        public override void Down()
        {
           // AddColumn("dbo.UserAccounts", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.UserAccounts", "commentaires", c => c.String());
        }
    }
}
