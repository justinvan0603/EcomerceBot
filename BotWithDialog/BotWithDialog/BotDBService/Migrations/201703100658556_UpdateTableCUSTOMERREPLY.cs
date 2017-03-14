namespace BotDBService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableCUSTOMERREPLY : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BOT_CUSTOMERREPLY", "DOMAIN_ID", c => c.Int());
            AddColumn("dbo.BOT_CUSTOMERREPLY", "DOMAIN_NAME", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BOT_CUSTOMERREPLY", "DOMAIN_NAME");
            DropColumn("dbo.BOT_CUSTOMERREPLY", "DOMAIN_ID");
        }
    }
}
