namespace BotDBService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdConversationTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BOT_CONVERSATION", "CREATE_DT", c => c.DateTime());
            AddColumn("dbo.BOT_CONVERSATION", "RECORD_STATUS", c => c.Int());
            DropColumn("dbo.BOT_CONVERSATION", "QUESTION_ID");
            DropColumn("dbo.BOT_CONVERSATION", "QUESTION");
            DropColumn("dbo.BOT_CONVERSATION", "ANSWER_ID");
            DropColumn("dbo.BOT_CONVERSATION", "ANSWER");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BOT_CONVERSATION", "ANSWER", c => c.String(maxLength: 500));
            AddColumn("dbo.BOT_CONVERSATION", "ANSWER_ID", c => c.Int());
            AddColumn("dbo.BOT_CONVERSATION", "QUESTION", c => c.String(maxLength: 500));
            AddColumn("dbo.BOT_CONVERSATION", "QUESTION_ID", c => c.Int());
            DropColumn("dbo.BOT_CONVERSATION", "RECORD_STATUS");
            DropColumn("dbo.BOT_CONVERSATION", "CREATE_DT");
        }
    }
}
