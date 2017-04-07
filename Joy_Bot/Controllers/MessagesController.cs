using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Dialogs;
using Joy_Bot.Controllers;
using System.Collections.Generic;
namespace Joy_Bot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                var resp1 = "";
                // calculate something for us to return
                //int length = (activity.Text ?? string.Empty).Length;
                // return our reply to the user
                //Activity reply = activity.CreateReply($"You sent {activity.Text} which was {length} characters");
                //await connector.Conversations.ReplyToActivityAsync(reply);
                if (activity.Text?.Any() == true)
                {
                    var name = activity.Text;
                    var resp = "";
                    if (name.Equals("hi"))
                    {
                        resp = "Hello!! My name is joy.You can share with me your feelings.How are u today ";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);
                    }
                    if (name.Equals("I am angry") || name.Equals("I am furious"))
                    {
                        resp = "You look so angry, you need to calm down.\n 'Anger is your biggest enemy, learn to control it'";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);
                    }
                    else if (name.Equals("I am still angry"))
                    {
                        resp = "Give yourself short breaks during times of the day that tend to be stressful. A few moments of quiet time might help you feel better prepared to handle what's ahead without getting irritated or angry.";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);


                    }
                    else if (name.Equals("thankyou") || name.Equals("thanks") || name.Equals("tq"))
                    {
                        resp = "No problem!";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);

                    }
                    else if (name.Equals("I am sad"))
                    {
                        var message = activity.CreateReply("");
                        message.Type = "message";
                        message.Text = "Why do you look so sad?Wait... I will show you something to make you feel better";
                        message.Attachments = new List<Attachment>();
                        var webClient = new WebClient();
                        byte[] imageBytes = webClient.DownloadData("https://peacepenpineapple.files.wordpress.com/2017/01/cute-three-little-white-puppies-sleeping-together1.jpg?w=660");
                        string url = "data:image/png;base64," + Convert.ToBase64String(imageBytes);
                        message.Attachments.Add(new Attachment { ContentUrl = url, ContentType = "image/png" });
                        await connector.Conversations.ReplyToActivityAsync(message);

                    }
                    else if (name.Equals("I am still sad"))
                    {
                        resp = "Set Goals. Something special happens the moment the paper meets the pen and we write down our goals. Our brain chemistry changes, neurons fire, hormones are deployed, and we start thinking about how we can achieve those goals.";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);

                    }
                    else if (name.Equals("I am happy") || name.Equals("lol"))
                    {
                        resp = "You look happy,that's great\n 'Remember being happy lies in making others happy'";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);
                    }
                    else if (name.Equals("bored") || name.Equals("gloomy"))
                    {
                        resp = "Wanna hear a joke?";
                        var message = activity.CreateReply("");
                        message.Type = "message";
                        message.Text = resp;
                        message.Attachments = new List<Attachment>();
                        var webClient = new WebClient();
                        byte[] imageBytes = webClient.DownloadData("http://2.bp.blogspot.com/-TNrS-xhimac/UDdxn6wCFBI/AAAAAAAJajo/mnN5VhlKSZA/s400/Funny+Jokes+of+Kids+(8).jpg");
                        string url = "data:image/png;base64," + Convert.ToBase64String(imageBytes);
                        message.Attachments.Add(new Attachment { ContentUrl = url, ContentType = "image/png" });
                        await connector.Conversations.ReplyToActivityAsync(message);
                    }
                    else if (name.Equals("I am bored"))
                    {
                        resp = "BE CURIOUS .Let your mind go. Let your imagination soar. Let your natural curiosity free of its self-imposed restrictions.Ask questions. Seek answers. Want to know, to understand, to learn.Hunger for knowledge.Thirst for understanding.";
                        Activity reply = activity.CreateReply(resp);
                        await connector.Conversations.ReplyToActivityAsync(reply);
                    }

                }
                else
                {
                    resp1 = "Cannot understand!";
                    Activity reply = activity.CreateReply(resp1);
                    await connector.Conversations.ReplyToActivityAsync(reply);
                }
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }
            return null;
        }
    }
}