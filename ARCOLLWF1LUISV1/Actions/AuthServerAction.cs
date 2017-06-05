using ARCOLLWF1LUISV1.ChannelView;
using ARCOLLWF1LUISV1.FormQueries;
using ARCOLLWF1LUISV1.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ARCOLLWF1LUISV1.Actions
{
    [Serializable]
    public class AuthServerAction
    {
        
        public async Task ResumeActionAuthServerLuisFormDialog(IDialogContext context, LuisResult result)
        {
            try
            {
                //Based on the LUIS Result, fetch data from ERP 
                //var searchQuery =  result;
               
                //For dialog flow testing demo populate values by hardcoding - 8/May/2017
                AuthServerAdaptiveCardView AuthCardView = new AuthServerAdaptiveCardView();

                //Pass Data to Channel Receipt Card View 
                var resultData = AuthCardView.GetAuthServerAdaptiveCard();
                
                var resultMessage = context.MakeMessage();
                
                resultMessage.Attachments.Add(resultData);
                
                await context.PostAsync(resultMessage);
                
            }
            catch (Exception ex)
            {
                string reply;

                if (ex.InnerException == null)
                {
                    reply = "You have canceled the operation.";
                }
                else
                {
                    reply = $"Oops! Something went wrong :( Technical Details: {ex.InnerException.Message}";
                }

                await context.PostAsync(reply);
            }
            finally
            {
                context.Done<object>(null);
            }

        }
        
        /*
        //testing exception reason
        public async Task ResumeActionAuthServerScorablesFormDialog(IDialogContext context)
        {
            try
            {
               
                //For dialog flow testing demo populate values by hardcoding - 8/May/2017
                AuthServerAdaptiveCardView AuthCardView = new AuthServerAdaptiveCardView();

                //Pass Data to Channel Receipt Card View 
                var resultData = AuthCardView.GetAuthServerAdaptiveCard();

                var resultMessage = context.MakeMessage();

                resultMessage.Attachments.Add(resultData);

                await context.PostAsync(resultMessage);
            }
            catch (Exception ex)
            {
                string reply;

                if (ex.InnerException == null)
                {
                    reply = "You have canceled the operation.";
                }
                else
                {
                    reply = $"Oops! Something went wrong :( Technical Details: {ex.InnerException.Message}";
                }

                await context.PostAsync(reply);
            }
            finally
            {
                context.Done<object>(null);
            }

        }
        */


    }
}