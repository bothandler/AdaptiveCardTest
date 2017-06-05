using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace ARCOLLWF1LUISV1.Dialogs
{
    public class HelpDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            var helpMessage = context.MakeMessage();

            helpMessage.Text = "Adaptive Card Test";

            List <CardAction> helpCardButtons = new List<CardAction>();

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


            helpCardButtons.Add(luisButton);
            helpCardButtons.Add(gmhButton);
            helpCardButtons.Add(dialogButton);

            helpMessage.SuggestedActions = new SuggestedActions(actions: helpCardButtons);

            await context.PostAsync(helpMessage);

            context.Wait(this.MessageReceived);

        }


        private async Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            var incomingMessage = message.Text.ToLowerInvariant();

            if ((incomingMessage != null) && (incomingMessage.Trim().Length > 0))
            {
                context.Done<object>(null);
            }
            else
            {
                context.Fail(new Exception("Message was not a string or was an empty string."));
            }
        }

    }
}