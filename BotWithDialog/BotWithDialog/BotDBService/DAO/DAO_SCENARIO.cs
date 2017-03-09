using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotDBService.Entities;
namespace BotDBService.DAO
{
    public class DAO_SCENARIO
    {
        public static IEnumerable<BOT_SCENARIO> BOT_SCENARIO_GetByDomain(int? DOMAIN_ID, string DOMAIN_NAME)
        {
            try
            {
                BotDBContext context = new BotDBContext();
                if(DOMAIN_ID != null)
                {
                    return context.BOT_SCENARIO.Where(sc => sc.SCENARIO_ID == DOMAIN_ID && sc.RECORD_STATUS == 1);
                }
                else
                {
                    return context.BOT_SCENARIO.Where(sc => sc.DOMAIN_NAME.Contains(DOMAIN_NAME) && sc.RECORD_STATUS == 1);
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

    }
}
