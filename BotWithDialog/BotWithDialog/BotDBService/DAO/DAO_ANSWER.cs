using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotDBService.Entities;
namespace BotDBService.DAO
{
    public class DAO_ANSWER
    {
        public static IEnumerable<BOT_ANSWER> BOT_ANSWER_GetByQuestionId(int QUESTION_ID)
        {
            try
            {
                BotDBContext context = new BotDBContext();
                return context.BOT_ANSWER.Where(answer => answer.QUESTION_ID == QUESTION_ID);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public static IEnumerable<BOT_ANSWER> BOT_ANSWER_GetByPrevAnswerId(int ANSWER_ID)
        {
            try
            {
                BotDBContext context = new BotDBContext();
                return context.BOT_ANSWER.Where(answer => answer.PREVANSWER_ID == ANSWER_ID);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

    }
}
