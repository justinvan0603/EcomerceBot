namespace BotDBService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateConversationContentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BOT_CONVERSATIONCONTENT",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CONVERSATION_ID = c.Int(),
                        QUESTION_ID = c.Int(),
                        QUESTION = c.String(maxLength: 500),
                        ANSWER_ID = c.Int(),
                        ANSWER = c.String(maxLength: 500),
                        CREATE_DT = c.DateTime(),
                        RECORD_STATUS = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BOT_CONVERSATIONCONTENT");
        }
    }
}
