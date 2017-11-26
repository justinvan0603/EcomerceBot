using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotDBService.Entities;
namespace BotDBService.DAO
{
    public class DAO_CONVERSATIONCONTENT
    {
        public static bool BOT_CONVERSATIONCONTENT_AddQuestion(int CONVERSATION_ID, int QUESTION_ID, string QUESTION_CONTENT)
        {
            try
            {

                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        BOT_CONVERSATIONCONTENT content = new BOT_CONVERSATIONCONTENT();
                        content.ID = 0;
                        content.CONVERSATION_ID = CONVERSATION_ID;
                        content.RECORD_STATUS = 1;
                        content.QUESTION_ID = QUESTION_ID;
                        content.QUESTION = QUESTION_CONTENT;
                        content.CREATE_DT = DateTime.Now;

                        context.BOT_CONVERSATIONCONTENT.Add(content);
                        context.SaveChanges();
                        return true;
                    }
                    catch(Exception ex)
                    {
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public static bool BOT_CONVERSATIONCONTENT_AddAnswer(int CONVERSATION_ID, int ANSWER_ID, string ANSWER_CONTENT)
        {
            try
            {
                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        BOT_CONVERSATIONCONTENT content = new BOT_CONVERSATIONCONTENT();
                        content.ID = 0;
                        content.CONVERSATION_ID = CONVERSATION_ID;
                        content.ANSWER_ID = ANSWER_ID;
                        content.ANSWER = ANSWER_CONTENT;
                        content.RECORD_STATUS = 1;
                        content.CREATE_DT = DateTime.Now;

                        context.BOT_CONVERSATIONCONTENT.Add(content);
                        context.SaveChanges();
                        return true;
                    }
                    catch(Exception ex)
                    {
                        return false;
                    }
                }
                
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
