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
           // try
          //  {
                //using (BotDBContext context = new BotDBContext())
                //{
                    try
                    {
                        BotDBContext context = new BotDBContext();
                        return context.BOT_QUESTION.Where(question => question.LEVEL == level);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            //}
          //  catch(Exception ex)
           // {
              ///  return null;
            //}
        //}
        public static BOT_QUESTION BOT_QUESTION_GetById(int id)
        {
           // try
          //  {
               // using (BotDBContext context = new BotDBContext())
               // {
                    try
                    {
                        BotDBContext context = new BotDBContext();
                        return context.BOT_QUESTION.Single(question => question.QUESTION_ID == id);
                    }
                    catch(Exception ex)
                    {
                        return null;
                    }
              //  }
         //   }
          //  catch(Exception ex)
          //  {
          //      return null;
           // }
        }
        public static IEnumerable<BOT_QUESTION> BOT_QUESTION_GetByAll()
        {
          //  try
          //  {
             //   using (BotDBContext context = new BotDBContext())
               // {
                    try
                    {
                        BotDBContext context = new BotDBContext();
                        return context.BOT_QUESTION;
                    }
                    catch(Exception ex)
                    {
                        return null;
                    }
             //   }
        //    }
           // catch(Exception ex)
           // {
           //     return null;
           // }
           
            
        }
        public static bool BOT_QUESTION_IsHaveNextQuestions(int QUESTION_ID)
        {
          //  try
       //     {
            //    using (BotDBContext context = new BotDBContext())
            //    {
                    try
                    {
                BotDBContext context = new BotDBContext();
                        return context.BOT_QUESTION.Any(question => question.PREVQUESTION_ID == QUESTION_ID);
                    }
                    catch(Exception ex)
                    {
                        return false;
                    }
                //}
           // }
           // catch(Exception ex)
           // {
           //     return false;
           // }
            
           
        }

        public static IEnumerable<BOT_QUESTION> BOT_QUESTION_GetByScenario(int SCENARIO_ID)
        {
           // try
        //   {
              //  using (BotDBContext context = new BotDBContext())
              //  {
                    try
                    {
                BotDBContext context = new BotDBContext();
                        return context.BOT_QUESTION.Where(question => question.SCENARIO_ID == SCENARIO_ID);

                    }
                    catch(Exception ex)
                    {
                        return null;
                    }
                //}
                   
                
           // }
           // catch(Exception ex)
           // {
           //     return null;
          //  }
        }
        
        public static IEnumerable<BOT_QUESTION> BOT_QUESTION_GetPreviousSelectQuestions(int prevQuestionId)
        {
            //try
            //{
            //    using (BotDBContext context = new BotDBContext())
            //    {
                    try
                    {
                        BotDBContext context = new BotDBContext();
                        BOT_QUESTION prevQuestion = context.BOT_QUESTION.Single(prevquestion => prevquestion.QUESTION_ID == prevQuestionId);
                        //return context.BOT_QUESTION.Where(question => question.LEVEL == prevQuestion.LEVEL);
                        if (prevQuestion.PREVQUESTION_ID != null)
                        {
                            return context.BOT_QUESTION.Where(question => question.LEVEL == prevQuestion.LEVEL && question.PREVQUESTION_ID == prevQuestion.PREVQUESTION_ID);

                        }
                        else
                        {
                            return context.BOT_QUESTION.Where(question => question.LEVEL == prevQuestion.LEVEL);
                        }
                    }
                    catch(Exception ex)
                    {
                        return null;
                    }
               // }
                    
                
                
                //return context.BOT_QUESTION.Where(question => question.LEVEL.Value == level);
            //}
            //catch(Exception ex)
            //{
            //    return null;
            //}
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
            // try
            //{
            // using (BotDBContext context = new BotDBContext())
            // {
            try
            {
                BotDBContext context = new BotDBContext();
                return context.BOT_QUESTION.Where(question => question.PREVQUESTION_ID == null && question.PREVANSWER_ID == null && question.SCENARIO_ID == SCENARIO_ID);
            }
            catch (Exception ex)
            {
                return null;
            }
            // }


            //}
            //catch(Exception ex)
            //{
            //    return null;
            //}
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
