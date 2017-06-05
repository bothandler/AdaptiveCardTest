using Autofac;
using Microsoft.Bot.Builder.Scorables;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ARCOLLWF1LUISV1.GlobalScorables;
using Microsoft.Bot.Builder.Dialogs.Internals;

namespace ARCOLLWF1LUISV1.GlobalMessageHandlers
{
	public class GlobalMessageHandlersBotModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

           
            builder
               .Register(c => new HelpScorable(c.Resolve<IDialogTask>()))
               .As<IScorable<IActivity, double>>()
               .InstancePerLifetimeScope();
            

            builder
              .Register(c => new SettingsScorable(c.Resolve<IDialogTask>()))
              .As<IScorable<IActivity, double>>()
              .InstancePerLifetimeScope();

        }

    }
}