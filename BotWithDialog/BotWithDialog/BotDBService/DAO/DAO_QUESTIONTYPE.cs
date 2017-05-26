using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotDBService.Entities;
namespace BotDBService.DAO
{
    public class DAO_QUESTIONTYPE
    {
        public static IEnumerable<BOT_QUESTIONTYPE> BOT_QUESTIONTYPE_GetByAll()
        {

            try
            {
                IEnumerable<BOT_QUESTIONTYPE> listQuestionType;

                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        listQuestionType = context.BOT_QUESTIONTYPE;
                        return listQuestionType.ToList();
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
        public static BOT_QUESTIONTYPE BOT_QUESTIONTYPE_GetById(int id)
        {
            try
            {
                BOT_QUESTIONTYPE questionType;

                using (BotDBContext context = new BotDBContext())
                {
                    questionType= context.BOT_QUESTIONTYPE.Single(type => type.QUESTIONTYPE_ID == id);
                    return questionType;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public static bool BOT_QUESTIONTYPE_IsGetInfoQuestion(int QUESTION_TYPE)
        {
            try
            {
                if (QUESTION_TYPE == 1)
                    return true;
                else
                    return false;
                
            }
            catch(Exception ex)
            {
                return false;
            }
        }


    }
}
