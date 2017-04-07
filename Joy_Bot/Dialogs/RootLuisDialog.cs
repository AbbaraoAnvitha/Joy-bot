
namespace Joy_Bot.Dialogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Builder.FormFlow;
    using Microsoft.Bot.Builder.Luis;
    using Microsoft.Bot.Builder.Luis.Models;
    using Microsoft.Bot.Connector;

    [Serializable]
    [LuisModel("9448d339-8258-4a7f-961c-7cf64543723a", "51ab9c7336424a15aa9a9d3a762321f1")]
    public class RootLuisDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I did not understand '{result.Query}'. Type 'help' if you need assistance.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Sad")]
        public async Task Sad(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            string message = $"Cheer up!";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Lonely")]
        public async Task Lonely(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            string message = $"Don't forget I'm there for you";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }
    }
}