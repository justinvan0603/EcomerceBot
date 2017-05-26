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
        public static IEnumerable<BOT_QUESTION> BOT_QUESTION_GetByLevel(int level)
        {
            try
            {
                IEnumerable<BOT_QUESTION> listQuestion;
                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        //BotDBContext context = new BotDBContext();
                        listQuestion= context.BOT_QUESTION.Where(question => question.LEVEL == level);
                        return listQuestion.ToList();
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
        public static BOT_QUESTION BOT_QUESTION_GetById(int id)
        {
            try
            {
                BOT_QUESTION botQuestion;
                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        //BotDBContext context = new BotDBContext();
                        botQuestion= context.BOT_QUESTION.Single(question => question.QUESTION_ID == id);
                        return botQuestion;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static IEnumerable<BOT_QUESTION> BOT_QUESTION_GetByAll()
        {
            try
            {
                IEnumerable<BOT_QUESTION> listQuestion;
                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        //BotDBContext context = new BotDBContext();
                        listQuestion= context.BOT_QUESTION;
                        return listQuestion.ToList();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        public static bool BOT_QUESTION_IsHaveNextQuestions(int QUESTION_ID)
        {
            try
            {
                bool result;
                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        //BotDBContext context = new BotDBContext();
                        result= context.BOT_QUESTION.Any(question => question.PREVQUESTION_ID == QUESTION_ID);
                        return result;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public static IEnumerable<BOT_QUESTION> BOT_QUESTION_GetByScenario(int SCENARIO_ID)
        {
            try
            {
                IEnumerable<BOT_QUESTION> listQuestion;
                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        //BotDBContext context = new BotDBContext();
                        listQuestion= context.BOT_QUESTION.Where(question => question.SCENARIO_ID == SCENARIO_ID);
                        return listQuestion.ToList();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public static IEnumerable<BOT_QUESTION> BOT_QUESTION_GetPreviousSelectQuestions(int prevQuestionId)
        {
            try
            {
                IEnumerable<BOT_QUESTION> listPrevQuestion;
                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        //BotDBContext context = new BotDBContext();
                        BOT_QUESTION prevQuestion = context.BOT_QUESTION.Single(prevquestion => prevquestion.QUESTION_ID == prevQuestionId);
                        return context.BOT_QUESTION.Where(question => question.LEVEL == prevQuestion.LEVEL);
                        if (prevQuestion.PREVQUESTION_ID != null)
                        {
                            listPrevQuestion= context.BOT_QUESTION.Where(question => question.LEVEL == prevQuestion.LEVEL && question.PREVQUESTION_ID == prevQuestion.PREVQUESTION_ID);
                            return listPrevQuestion.ToList();
                        }
                        else
                        {
                            listPrevQuestion= context.BOT_QUESTION.Where(question => question.LEVEL == prevQuestion.LEVEL);
                            return listPrevQuestion.ToList();
                        }
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static IEnumerable<BOT_QUESTION> BOT_QUESTION_GetNextQuestions(int QUESTION_ID)
        {

            try
            {
                IEnumerable<BOT_QUESTION> listQuestion;
                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        //BotDBContext context = new BotDBContext();
                        listQuestion= context.BOT_QUESTION.Where(question => question.PREVQUESTION_ID == QUESTION_ID);
                        return listQuestion.ToList();
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
        public static IEnumerable<BOT_QUESTION> BOT_QUESTION_GetListFirstQuestionByScenario(int SCENARIO_ID)
        {
            try
            {
                IEnumerable<BOT_QUESTION> listQuestion;
                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        //BotDBContext context = new BotDBContext();
                        listQuestion = context.BOT_QUESTION.Where(question => question.PREVQUESTION_ID == null && question.PREVANSWER_ID == null && question.SCENARIO_ID == SCENARIO_ID);
                        return listQuestion.ToList();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static IEnumerable<BOT_QUESTION> BOT_QUESTION_GetByPrevAnswer(int PREVANSWER_ID)
        {
            try
            {
                IEnumerable<BOT_QUESTION> listQuestion;
                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        //BotDBContext context = new BotDBContext();
                        listQuestion= context.BOT_QUESTION.Where(question => question.PREVANSWER_ID == PREVANSWER_ID);
                        return listQuestion.ToList();
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
        
    }
}
