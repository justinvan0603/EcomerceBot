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
        public static BOT_ANSWER BOT_ANSWER_GetById(int id)
        {
            try
            {
                BOT_ANSWER botAnswer;
                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        //BotDBContext context = new BotDBContext();
                        botAnswer = context.BOT_ANSWER.Single(answer => answer.ANSWER_ID == id);
                        return botAnswer;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public static IEnumerable<BOT_ANSWER> BOT_ANSWER_GetByPreviousSelectAnswers(int prevAnswerId)
        {
            try
            {
                IEnumerable<BOT_ANSWER> listAnswer;
                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        //BotDBContext context = new BotDBContext();
                        BOT_ANSWER prevAnswer = context.BOT_ANSWER.Single(answer => answer.ANSWER_ID == prevAnswerId);
                        if (prevAnswer.QUESTION_ID != null)
                        {
                            listAnswer= context.BOT_ANSWER.Where(answer => answer.LEVEL == prevAnswer.LEVEL && answer.QUESTION_ID == prevAnswer.ANSWER_ID);
                            return listAnswer.ToList();
                        }
                        else
                        {
                            listAnswer= context.BOT_ANSWER.Where(answer => answer.LEVEL == prevAnswer.LEVEL && answer.PREVANSWER_ID == prevAnswer.PREVANSWER_ID);
                            return listAnswer.ToList();
                        }
                        //return context.BOT_ANSWER.Where(answer => answer.LEVEL == prevAnswer.LEVEL);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public static bool BOT_ANSWER_IsHasAnswer(int QUESTION_ID)
        {
            try
            {
                bool result;
                using (BotDBContext context = new BotDBContext())
                {
                    //BotDBContext context = new BotDBContext();
                    result= context.BOT_ANSWER.Any(answer => answer.QUESTION_ID == QUESTION_ID);
                    return result;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        
        public static IEnumerable<BOT_ANSWER> BOT_ANSWER_GetByQuestionId(int QUESTION_ID)
        {
            try
            {
                IEnumerable<BOT_ANSWER> listAnswer;
                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        listAnswer = context.BOT_ANSWER.Where(answer => answer.QUESTION_ID == QUESTION_ID);
                        return listAnswer.ToList();
                    }
                    catch(Exception ex)
                    {
                        return null;
                    }
                }
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
                IEnumerable<BOT_ANSWER> listAnswer;

                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        listAnswer = context.BOT_ANSWER.Where(answer => answer.PREVANSWER_ID == ANSWER_ID);
                        return listAnswer.ToList();
                    }
                    catch(Exception ex)
                    {
                        return null;
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

    }
}
