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
                BotDBContext context = new BotDBContext();
                return context.BOT_QUESTIONTYPE;
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
                BotDBContext context = new BotDBContext();
                return context.BOT_QUESTIONTYPE.Single(type => type.QUESTIONTYPE_ID == id);
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
