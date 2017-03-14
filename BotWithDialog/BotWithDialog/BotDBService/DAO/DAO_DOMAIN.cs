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
                BotDBContext context = new BotDBContext();
                if(DOMAIN_ID != null)
                {
                    return context.BOT_DOMAIN.Single(domain => domain.DOMAIN_ID == DOMAIN_ID);
                }
                else
                {
                    return context.BOT_DOMAIN.Single(domain => domain.DOMAIN.Contains(DOMAIN_NAME));
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
