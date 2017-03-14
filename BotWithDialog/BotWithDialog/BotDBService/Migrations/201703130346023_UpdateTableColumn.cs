namespace BotDBService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BOT_ANSWER", "LEVEL", c => c.Int());
            AddColumn("dbo.BOT_QUESTION", "LEVEL", c => c.Int());
            AlterColumn("dbo.BOT_ANSWER", "CONTENT", c => c.String(maxLength: 500));

            AlterColumn("dbo.BOT_CUSTOMERINFO", "DOMAIN_NAME", c => c.String(maxLength: 100));
            AlterColumn("dbo.BOT_CUSTOMERINFO", "NAME", c => c.String(maxLength: 100));
            AlterColumn("dbo.BOT_CUSTOMERINFO", "PHONE", c => c.String(maxLength: 20));
            AlterColumn("dbo.BOT_CUSTOMERINFO", "EMAIL", c => c.String(maxLength: 100));
            AlterColumn("dbo.BOT_DOMAIN", "DOMAIN", c => c.String(maxLength: 100));

            AlterColumn("dbo.BOT_FORMTYPE", "DOMAIN_NAME", c => c.String(maxLength: 100));
            AlterColumn("dbo.BOT_QUESTION", "DOMAIN_NAME", c => c.String(maxLength: 100));
            AlterColumn("dbo.BOT_QUESTION", "CONTENT", c => c.String(maxLength: 500));
            AlterColumn("dbo.BOT_QUESTIONTYPE", "QUESTION_TYPE", c => c.String(maxLength: 100));

            AlterColumn("dbo.BOT_SCENARIO", "DOMAIN_NAME", c => c.String(maxLength: 100));
            AlterColumn("dbo.BOT_SCENARIO", "NAME", c => c.String(maxLength: 100));
            AlterColumn("dbo.BOT_USER", "USERNAME", c => c.String(maxLength: 50));
            AlterColumn("dbo.BOT_USER", "PASSWORD", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BOT_QUESTION", "LEVEL");
            DropColumn("dbo.BOT_ANSWER", "LEVEL");
        }
    }
}
