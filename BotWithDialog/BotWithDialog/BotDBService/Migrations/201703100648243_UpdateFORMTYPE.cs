namespace BotDBService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFORMTYPE : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BOT_FORMTYPE", "FORM_NAME", c => c.String(maxLength: 100));
            AddColumn("dbo.BOT_FORMTYPE", "DESCRIPTION", c => c.String(maxLength: 100));
            DropColumn("dbo.BOT_FORMTYPE", "FROM_NAME");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BOT_FORMTYPE", "FROM_NAME", c => c.String(maxLength: 100));
            DropColumn("dbo.BOT_FORMTYPE", "DESCRIPTION");
            DropColumn("dbo.BOT_FORMTYPE", "FORM_NAME");
        }
    }
}
