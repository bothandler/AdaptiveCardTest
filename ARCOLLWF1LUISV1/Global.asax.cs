using ARCOLLWF1LUISV1.GlobalMessageHandlers;
using System.Configuration;
using AuthBot;
using Autofac;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ARCOLLWF1LUISV1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {


            this.RegisterBotModules();

           // this.ChatHistoryLogger();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        private void RegisterBotModules()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new ReflectionSurrogateModule());

            builder.RegisterModule<GlobalMessageHandlersBotModule>();


            builder.Update(Conversation.Container);
        }

    }
}
