using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using ARCOLLWF1LUISV1.Actions;
using ARCOLLWF1LUISV1.ChannelView;

namespace ARCOLLWF1LUISV1.Dialogs
{
    public class SettingsDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            AuthServerAdaptiveCardView AuthCardView = new AuthServerAdaptiveCardView();

            var resultData = AuthCardView.GetAuthServerAdaptiveCard();

            var resultMessage = context.MakeMessage();

            resultMessage.Attachments.Add(resultData);

            await context.PostAsync(resultMessage);

            context.Wait(MessageReceived);
        }

        
        private async Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

          

            context.Done<object>(null);

            /*
            var incomingMessage = message.Text.ToLowerInvariant();

            if ((incomingMessage != null) && (incomingMessage.Trim().Length > 0))
            {
                context.Done<object>(null);
            }
            else
            {
                context.Fail(new Exception("Message was not a string or was an empty string."));
            }
            */
        }


    }
}