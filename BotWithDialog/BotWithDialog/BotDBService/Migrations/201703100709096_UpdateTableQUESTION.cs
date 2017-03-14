namespace BotDBService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableQUESTION : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BOT_QUESTION", "FORM_ID", c => c.Int());
            AddColumn("dbo.BOT_QUESTION", "FORM_NAME", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BOT_QUESTION", "FORM_NAME");
            DropColumn("dbo.BOT_QUESTION", "FORM_ID");
        }
    }
}
