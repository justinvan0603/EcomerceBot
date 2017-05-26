using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotDBService.Entities;
namespace BotDBService.DAO
{
    public class DAO_CUSTOMERINFO
    {
        public static bool BOT_CUSTOMERINFO_Ins(BOT_CUSTOMERINFO data)
        {
            try
            {

                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        context.BOT_CUSTOMERINFO.Add(data);
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
