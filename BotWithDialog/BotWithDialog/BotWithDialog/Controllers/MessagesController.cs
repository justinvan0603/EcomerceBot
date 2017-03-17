using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Dialogs;
using BotWithDialog.Dialog;
using Microsoft.Bot.Builder.FormFlow;
using System.Threading;

namespace BotWithDialog
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        //public static string Url;
        //internal static IDialog<FormFlow> MakeRootDialog()
        //{
        //    return Chain.From(()=> FormDialog.FromForm(FormFlow.BuildForm));
        //}
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                
                //      StateClient stateClient = activity.GetStateClient();
                //BotData userData = await stateClient.BotState.GetUserDataAsync(activity.ChannelId, activity.From.Id);
                //    BotData userData = await stateClient.BotState.GetConversationDataAsync(activity.ChannelId,activity.Conversation.Id);
                //  userData.SetProperty<string>("ServiceUrl", "http://google.com.vn");

                await Conversation.SendAsync(activity, () => new RootDialog());
                //Url = activity.ServiceUrl;
               // await Conversation.SendAsync(activity,MakeRootDialog);
                //ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                //// calculate something for us to return
                //int length = (activity.Text ?? string.Empty).Length;

                //// return our reply to the user
                //Activity reply = activity.CreateReply($"You sent {activity.Text} which was {length} characters");
                //await connector.Conversations.ReplyToActivityAsync(reply);
            }
         
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                if (message.MembersAdded.Any(o => o.Id == message.Recipient.Id))
                {
                    ConnectorClient connector = new ConnectorClient(new Uri(message.ServiceUrl));
                    Activity reply = message.CreateReply($"Chào mừng bạn đã ghé thăm Website của chúng tôi!");
                    connector.Conversations.ReplyToActivityAsync(reply);
                    
                }
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}