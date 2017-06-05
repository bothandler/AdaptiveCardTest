using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.ConnectorEx;
using Microsoft.Bot.Builder.Internals;
using Microsoft.Bot.Connector;
using System.Collections.Generic;


namespace ARCOLLWF1LUISV1
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity != null && activity.Type == ActivityTypes.Message)
            {
               await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
                // await Conversation.SendAsync(activity, () => new Dialogs.SettingsDialog());

            }
            else
            {
                await HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

       

        private async Task HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels


                IConversationUpdateActivity iConversationUpdated = message as IConversationUpdateActivity;
                if (iConversationUpdated != null)
                {
                    ConnectorClient connector = new ConnectorClient(new System.Uri(message.ServiceUrl));

                    foreach (var member in iConversationUpdated.MembersAdded ?? System.Array.Empty<ChannelAccount>())
                    {
                        
                        if (member.Id == iConversationUpdated.Recipient.Id)
                        {
                            // var reply = ((Activity)iConversationUpdated).CreateReply(StaticMessages.WelcomeMessage);
                            //await connector.Conversations.ReplyToActivityAsync(reply);
                            
                                var welcomeReply = ((Activity)iConversationUpdated).CreateReply("Adaptive Card Test");

                                List<CardAction> welcomeCardButtons = new List<CardAction>();

                                CardAction luisButton = new CardAction()
                                {
                                    Type = "imBack",
                                    Title = "LUIS - Auth Server",
                                    Value = "Signin"
                                };

                                CardAction gmhButton = new CardAction()
                                {
                                    Type = "imBack",
                                    Title = "Global Msg Handler - Auth Server",
                                    Value = "Settings"
                                };
                                CardAction dialogButton = new CardAction()
                                {
                                    Type = "imBack",
                                    Title = "Dialog - Auth Server",
                                    Value = "Map Server"
                                };
                                

                                welcomeCardButtons.Add(luisButton);
                                welcomeCardButtons.Add(gmhButton);
                                welcomeCardButtons.Add(dialogButton);

                                welcomeReply.SuggestedActions = new SuggestedActions(actions: welcomeCardButtons);


                                await connector.Conversations.ReplyToActivityAsync(welcomeReply);
                           
                        }
                    }
                }


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
                Activity reply = message.CreateReply();
                reply.Type = ActivityTypes.Ping;

                //return reply;
            }

           // return null;
        }
    }
}