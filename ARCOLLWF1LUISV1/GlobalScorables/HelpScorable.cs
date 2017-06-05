using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Scorables.Internals;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Builder.Internals.Fibers;
using ARCOLLWF1LUISV1.Dialogs;

using Microsoft.Bot.Builder.Dialogs;



namespace ARCOLLWF1LUISV1.GlobalScorables
{
    public class HelpScorable : ScorableBase<IActivity, string, double>
    {

        private readonly IDialogTask task;

        public HelpScorable(IDialogTask task)
        {
            SetField.NotNull(out this.task, nameof(task), task);
        }



        protected override Task DoneAsync(IActivity item, string state, CancellationToken token)
        {
            return Task.CompletedTask;
        }

        protected override double GetScore(IActivity item, string state)
        {
            return 1.0;
        }

        protected override bool HasScore(IActivity item, string state)
        {
            return state != null;
        }

        protected override async Task PostAsync(IActivity item, string state, CancellationToken token)
        {
            var message = item as IMessageActivity;

            if (message != null)
            {
                var helpDialog = new HelpDialog();

                var interruption = helpDialog.Void<object, IMessageActivity>();

                this.task.Call(interruption, null);

                await this.task.PollAsync(token);
            }
        }

        protected override async Task<string> PrepareAsync(IActivity activity, CancellationToken token)
        {
            var message = activity as IMessageActivity;

            if (message != null && !string.IsNullOrWhiteSpace(message.Text))
            {
                if (message.Text.Equals("Help", StringComparison.InvariantCultureIgnoreCase))
                {
                    return message.Text;
                }
                else if (message.Text.Equals("Support", StringComparison.InvariantCultureIgnoreCase))
                {
                    return message.Text;
                }
                else if (message.Text.Equals("F1", StringComparison.InvariantCultureIgnoreCase))
                {
                    return message.Text;
                }
            }

            return null;
        }
    }
}