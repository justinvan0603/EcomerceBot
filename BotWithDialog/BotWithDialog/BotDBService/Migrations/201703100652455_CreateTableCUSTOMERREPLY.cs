namespace BotDBService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCUSTOMERREPLY : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BOT_CUSTOMERREPLY",
                c => new
                    {
                        REPID = c.Int(nullable: false, identity: true),
                        CUSTOMER_ID = c.Int(),
                        QUESTION_ID = c.Int(),
                        CONTENT = c.String(maxLength: 500),
                        REPLY_TIME = c.DateTime(),
                    })
                .PrimaryKey(t => t.REPID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BOT_CUSTOMERREPLY");
        }
    }
}
