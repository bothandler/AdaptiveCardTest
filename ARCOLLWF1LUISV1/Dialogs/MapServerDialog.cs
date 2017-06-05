using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using ARCOLLWF1LUISV1.ChannelView;
using Microsoft.Bot.Connector;

namespace ARCOLLWF1LUISV1.Dialogs
{
    public class MapServerDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(this.MessageReceived);
        }

        private async Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            if (message != null && !string.IsNullOrWhiteSpace(message.Text))
            {
                if (message.Text.Equals("Map Server", StringComparison.InvariantCultureIgnoreCase))
                {
                    AuthServerAdaptiveCardView AuthCardView = new AuthServerAdaptiveCardView();

                    var resultData = AuthCardView.GetAuthServerAdaptiveCard();

                    var resultMessage = context.MakeMessage();

                    resultMessage.Attachments.Add(resultData);

                    await context.PostAsync(resultMessage);
                }
            }

            

           // context.Wait(this.MessageReceivedAsync);
           
        }
    }
}