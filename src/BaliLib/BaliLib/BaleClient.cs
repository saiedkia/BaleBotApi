using BaleLib.Models;
using BaleLib.Models.Parameters;
using BaleLib.Models.Updates;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BaleLib
{
    public class BaleClient
    {
        readonly string token;
        readonly HttpClient client;
        readonly string baseUrl;

        public BaleClient(string token)
        {
            this.token = token;
            baseUrl = $"https://tapi.bale.ai/{token}/";
            client = new HttpClient();
        }

        public UpdateResult GetUpdates(int offset = 0, int limit = 50, bool callRemoveWebHook = false)
        {
            string url = baseUrl + "getupdates";
            if (callRemoveWebHook) { DeleteWebHook(); }
            string content = Utils.Serialize(new { Offset = offset, Limit = limit });

            HttpResponseMessage response = client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return Utils.Deserialize<UpdateResult>(result);
            }
            else
            {

            }

            return new UpdateResult() { Ok = false };
        }

        public Response<bool> SetWebhook(string secureWebhookUrl)
        {

            string url = baseUrl + "setwebhook";
            string content = Utils.Serialize(new { Url = secureWebhookUrl });

            HttpResponseMessage response = client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Response<bool> result = Utils.Deserialize<Response<bool>>(response.Content.ReadAsStringAsync().Result);

                return result;
            }

            return new Response<bool>() { Ok = false, Result = false };
        }

        public Response<bool> DeleteWebHook()
        {
            string url = baseUrl + "deletewebhook";
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Response<bool> result = Utils.Deserialize<Response<bool>>(response.Content.ReadAsStringAsync().Result);

                return result;
            }

            return new Response<bool>();
        }



        public Response SendTextMessage(TextMessage message)
        {
            string url = baseUrl + "sendmessage";

            string content = Utils.Serialize(message);
            HttpResponseMessage response = client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                Response res = Utils.Deserialize<Response>(result);
                return res;


            }

            return null;
        }

        public Response<bool> DeleteMessage(long chatId, long messageId)
        {
            string url = baseUrl + "deletemessage";

            string content = Utils.Serialize(new { ChatId = chatId, MessageId = messageId });
            HttpResponseMessage response = client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                Response<bool> res = Utils.Deserialize<Response<bool>>(result);
                return res;


            }

            return new Response<bool>();
        }

        public Response EditTextMessage(TextMessage message, long messageId)
        {
            string url = baseUrl + "editmessagetext";

            string content = Utils.Serialize(message, new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("message_id", messageId.ToString())
            });
            HttpResponseMessage response = client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                Response res = Utils.Deserialize<Response>(result);
                return res;


            }

            return null;
        }


        public Response<Chat> GetChat(long chatId)
        {
            string url = baseUrl + "getchat";

            string content = Utils.Serialize(new { ChatId = chatId });
            HttpResponseMessage response = client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                Response<Chat> res = Utils.Deserialize<Response<Chat>>(result);
                return res;


            }

            return new Response<Chat>();
        }
    }
}
