using System;
using System.Configuration;

using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using ARCOLLWF1LUISV1.Actions;
using System.Threading;
using ARCOLLWF1LUISV1.ChannelView;

namespace ARCOLLWF1LUISV1.Dialogs
{
   
    [Serializable]
    public class RootDialog : LuisDialog<object>
    {
     
        public RootDialog() : base(new LuisService(new LuisModelAttribute(ConfigurationManager.AppSettings["LUIS_ModelId"], ConfigurationManager.AppSettings["LUIS_SubscriptionKey"])))
        {

        }

        
        [LuisIntent("AuthServer")]
        public async Task AuthServerIntentActionResultHandlerAsync(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {

            //var message = await activity;

            await context.PostAsync($"Am working on it (LUIS)... ");

            
            var authServerAction = new AuthServerAction();          
            await authServerAction.ResumeActionAuthServerLuisFormDialog(context, result);
            

            //AuthServerAdaptiveCardView authCardView = new AuthServerAdaptiveCardView();

            //var resultData = authCardView.GetAuthServerAdaptiveCard();

            //var resultData = AuthServerAdaptiveCardView.GetAuthServerAdaptiveCard();

            //var resultMessage = context.MakeMessage();

            //resultMessage.Attachments.Add(resultData);

            //await context.PostAsync(resultMessage);


        }

        [LuisIntent("MapServer")]
        public async Task MapServerIntentActionResultHandlerAsync(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {

            var message = await activity;

            await context.PostAsync($"Am working on it (Dialog)... ");

            await context.Forward(new MapServerDialog(), ResumeAfterMapSrvrDialog, message, CancellationToken.None);
            //Call dialog

           

        }


        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {

            var messageToForward = await activity;

            var NoneMessage = $"Sorry, I did not understand '{messageToForward.Text}' ";

            context.Wait(MessageReceived);
        }


        private async Task ResumeAfterMapSrvrDialog(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
        }

    }
}