using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotDBService.Entities;
namespace BotDBService.DAO
{
    public class DAO_CONVERSATION
    {
        public static BOT_CONVERSATION BOT_CONVERSATION_CreateConversation(int DOMAIN_ID, string DOMAIN_NAME)
        {
            try
            {
                BOT_CONVERSATION newConversation = new BOT_CONVERSATION();

                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        newConversation.CREATE_DT = DateTime.Now;
                        newConversation.DOMAIN_ID = DOMAIN_ID;
                        newConversation.DOMAIN_NAME = DOMAIN_NAME;
                        newConversation.ID = 0;
                        newConversation.RECORD_STATUS = 1;
                        newConversation.CUSTOMER_ID = null;
                        newConversation.CUSTOMER_NAME = null;
                        context.BOT_CONVERSATION.Add(newConversation);
                        return newConversation;
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
        public static BOT_CONVERSATION BOT_CONVERSATION_GetById(int id)
        {
            try
            {
                BOT_CONVERSATION botConversation;
                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        botConversation = context.BOT_CONVERSATION.Single(conv => conv.ID == id);
                        return botConversation;
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
        public static bool BOT_CONVERSATION_Upd(BOT_CONVERSATION conversation)
        {
            try
            {
                using (BotDBContext context = new BotDBContext())
                {
                    try
                    {
                        context.BOT_CONVERSATION.Attach(conversation);
                        context.Entry(conversation).State = System.Data.Entity.EntityState.Modified;
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
