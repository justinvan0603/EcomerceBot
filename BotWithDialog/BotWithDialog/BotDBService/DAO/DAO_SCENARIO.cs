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
                IEnumerable<BOT_SCENARIO> listScenario;

                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        if (DOMAIN_ID != null)
                        {
                            listScenario= context.BOT_SCENARIO.Where(sc => sc.SCENARIO_ID == DOMAIN_ID && sc.RECORD_STATUS == 1 && sc.IS_ACTIVE == true);
                            
                        }
                        else
                        {
                            listScenario= context.BOT_SCENARIO.Where(sc => sc.DOMAIN_NAME.Contains(DOMAIN_NAME) && sc.RECORD_STATUS == 1 && sc.IS_ACTIVE == true);
                            
                        }
                        return listScenario;
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
