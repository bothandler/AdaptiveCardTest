using AdaptiveCards;
using Microsoft.Bot.Connector;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ARCOLLWF1LUISV1.ChannelView
{
    public  class AuthServerAdaptiveCardView
    {

       
        public  Attachment GetAuthServerAdaptiveCard()
        {

            AdaptiveCard card = new AdaptiveCard();

            card.FallbackText = "Authenticating Server/Company/Branch";

            card.Body.Add(
                new TextBlock()
                {
                    Text = "App Server Authentication",
                    Size = TextSize.Normal,
                    Color = TextColor.Default
                });


            card.Body.Add(
                new TextInput()
                {
                    Id = "idServerURL",
                    IsRequired = true,
                    Placeholder = "App Server URL",
                    MaxLength = 100,
                    IsMultiline = false,
                    Style = TextInputStyle.Url,
                    Speak = "App Server URL",
                    Value = "abc.com/xyz"

                });
            
            card.Body.Add(
              new ChoiceSet()
              {
                  Id = "idSigninCompany",
                  IsRequired = true,
                  IsMultiSelect = false,
                  Style = ChoiceInputStyle.Compact,
                  Speak = "Company to Authenticate for",
                  Value = "P2PDemo",
                  Choices = new List<Choice>() {
                                                    new Choice()
                                                    {
                                                        Title = "P2PDemo",
                                                        Value = "P2PDemo",
                                                        IsSelected = true,
                                                        Speak = "P2PDemo"
                                                    },

                                                    new Choice()
                                                    {
                                                        Title = "SalesDemo",
                                                        Value = "SalesDemo",
                                                        IsSelected = false,
                                                        Speak = "SalesDemo"
                                                    },

                                                 }

              });


            card.Body.Add(
               new TextInput()
               {
                   Id = "idBranch",
                   IsRequired = true,
                   MaxLength = 30,
                   IsMultiline = false,
                   Style = TextInputStyle.Text,
                   Value = "branch1"

               });


            var submitActionData = JObject.Parse("{ \"Type\": \"idServerURL\" }");

           

            card.Actions.Add(
                /*  new SubmitAction()
                  {
                      Title = "Submit",
                     // Speak = "Submit",
                      Data = Newtonsoft.Json.Linq.JObject.FromObject(new { button = "Submit", ServerUrl = "idServerURL" })
                  }
                  */

                new SubmitAction()
                {
                    Title = "Submit",
                    DataJson = submitActionData.ToString()

                }


                );

            

            var attachment = new Attachment() { ContentType = AdaptiveCard.ContentType, Content = card };

            return attachment;

        }


    }
}