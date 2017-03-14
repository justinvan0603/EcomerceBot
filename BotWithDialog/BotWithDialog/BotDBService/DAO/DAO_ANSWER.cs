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
        public static IEnumerable<BOT_ANSWER> BOT_ANSWER_GetByPreviousSelectAnswers(int prevAnswerId)
        {
            try
            {
                BotDBContext context = new BotDBContext();
                BOT_ANSWER prevAnswer = context.BOT_ANSWER.Single(answer => answer.ANSWER_ID == prevAnswerId);
                if(prevAnswer.QUESTION_ID != null)
                {
                    return context.BOT_ANSWER.Where(answer => answer.LEVEL == prevAnswer.LEVEL && answer.QUESTION_ID == prevAnswer.ANSWER_ID);
                }
                else
                {
                    return context.BOT_ANSWER.Where(answer => answer.LEVEL == prevAnswer.LEVEL && answer.PREVANSWER_ID == prevAnswer.PREVANSWER_ID);
                }
                //return context.BOT_ANSWER.Where(answer => answer.LEVEL == prevAnswer.LEVEL);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public static bool BOT_ANSWER_IsHasAnswer(int QUESTION_ID)
        {
            BotDBContext context = new BotDBContext();
            return context.BOT_ANSWER.Any(answer => answer.QUESTION_ID == QUESTION_ID);
        }
        
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
