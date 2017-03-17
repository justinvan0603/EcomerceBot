namespace BotDBService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateNewAndUpdTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BOT_CONVERSATION",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DOMAIN_ID = c.Int(),
                        DOMAIN_NAME = c.String(maxLength: 100),
                        CUSTOMER_ID = c.Int(),
                        CUSTOMER_NAME = c.String(maxLength: 100),
                        QUESTION_ID = c.Int(),
                        QUESTION = c.String(maxLength: 500),
                        ANSWER_ID = c.Int(),
                        ANSWER = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.BOT_ANSWER", "FORM_ID", c => c.Int());
            AddColumn("dbo.BOT_ANSWER", "FORM_NAME", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BOT_ANSWER", "FORM_NAME");
            DropColumn("dbo.BOT_ANSWER", "FORM_ID");
            DropTable("dbo.BOT_CONVERSATION");
        }
    }
}
