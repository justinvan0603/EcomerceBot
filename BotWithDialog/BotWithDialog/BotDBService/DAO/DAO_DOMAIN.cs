using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotDBService.Entities;
namespace BotDBService.DAO
{
    public class DAO_DOMAIN
    {
        public static BOT_DOMAIN GetById(int? DOMAIN_ID, string DOMAIN_NAME)
        {
            try
            {
                BOT_DOMAIN botDomain;

                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        if (DOMAIN_ID != null)
                        {
                            botDomain= context.BOT_DOMAIN.Single(domain => domain.DOMAIN_ID == DOMAIN_ID);
                        }
                        else
                        {
                            botDomain= context.BOT_DOMAIN.Single(domain => domain.DOMAIN.Contains(DOMAIN_NAME));
                        }
                        return botDomain;
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
