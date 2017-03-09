using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotDBService.Entities;
namespace BotDBService.DAO
{
    public class DAO_QUESTION
    {
        public static IEnumerable<BOT_QUESTION> BOT_QUESTION_GetByScenario(int SCENARIO_ID)
        {
            try
            {
                BotDBContext context = new BotDBContext();
                return context.BOT_QUESTION.Where(question => question.SCENARIO_ID == SCENARIO_ID);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public static IEnumerable<BOT_QUESTION> BOT_QUESTION_GetByPrevQuestionId(int PREVQUESTION_ID)
        {
            try
            {
                BotDBContext context = new BotDBContext();
                return context.BOT_QUESTION.Where(question => question.QUESTION_ID == PREVQUESTION_ID);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public static IEnumerable<BOT_QUESTION> BOT_QUESTION_GetListFirstQuestionByScenario(int SCENARIO_ID)
        {
            try
            {
                BotDBContext context = new BotDBContext();
                return context.BOT_QUESTION.Where(question => question.PREVQUESTION_ID == null && question.PREVANSWER_ID == null && question.SCENARIO_ID == SCENARIO_ID);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public static IEnumerable<BOT_QUESTION> BOT_QUESTION_GetByPrevAnswer(int PREVANSWER_ID)
        {
            try
            {
                BotDBContext context = new BotDBContext();
                return context.BOT_QUESTION.Where(question => question.PREVANSWER_ID == PREVANSWER_ID);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
