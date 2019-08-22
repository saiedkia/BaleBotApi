using BaleLib.Exceptions;
using BaleLib.Models;
using BaleLib.Models.Parameters;
using BaleLib.Models.Updates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BaleLib
{
    public class BaleClient
    {
        readonly string token;
        readonly HttpClient client;
        readonly string baseUrl;
        readonly string fileBaseUrl;

        public BaleClient(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new InvalidParameterException("token is invalid");

            this.token = token;
            baseUrl = $"https://tapi.bale.ai/{token}/";
            fileBaseUrl = $"https://tapi.bale.ai/file/{token}/";
            client = new HttpClient();
        }

        public async Task<Response<List<Update>>> GetUpdatesAsync(int offset = 1, int limit = 50, bool removeWebHook = false)
        {
            string url = baseUrl + "getupdates";
            if (removeWebHook) { DeleteWebHook(); }

            Response<List<Update>> response = (Response<List<Update>>)await Post<List<Update>>(new { Offset = offset, Limit = limit }, url);

            return response;
        }

        public async Task<Response<bool>> SetWebhookAsync(string secureWebhookUrl)
        {
            if (string.IsNullOrEmpty(secureWebhookUrl)) throw new InvalidParameterException("web hook url is invalid, its null or empty");

            string url = baseUrl + "setwebhook";
            Response<bool> response = (Response<bool>)await Post<bool>(new { Url = secureWebhookUrl }, url);

            return response;
        }

        public Response<bool> DeleteWebHook()
        {
            string url = baseUrl + "deletewebhook";
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Response<bool> result = Utils.Deserialize<Response<bool>>(response.Content.ReadAsStringAsync().Result);

                return result;
            }

            return new Response<bool>();
        }

        public async Task<Response> SendTextAsync(TextMessage message)
        {
            string url = baseUrl + "sendmessage";

            Response response = await Post<VoidType>(message, url);
            return response;
        }

        public async Task<Response<bool>> DeleteMessageAsync(long chatId, long messageId)
        {
            string url = baseUrl + "deletemessage";

            Response<bool> response = (Response<bool>)await Post<bool>(new { ChatId = chatId, MessageId = messageId }, url);

            return response;
        }

        public async Task<Response> EditTextAsync(TextMessage message, long messageId)
        {
            string url = baseUrl + "editmessagetext";

            string content = Utils.Serialize(message, new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("message_id", messageId.ToString())
            });

            Response response = await Post<VoidType>(new StringContent(content, Encoding.UTF8, "application/json"), url);

            return response;
        }


        public async Task<Response<Chat>> GetChat(long chatId)
        {
            string url = baseUrl + "getchat";

            string content = Utils.Serialize(new { ChatId = chatId });
            Response<Chat> response = (Response<Chat>)await Post<Chat>(new { ChatId = chatId }, url);
            return response;
        }

        public Response<From> GetMe()
        {
            string url = baseUrl + "getme";

            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                Response<From> res = Utils.Deserialize<Response<From>>(result);
                return res;


            }

            return new Response<From>();
        }


        public async Task<Response> SendPhotoAsync(PhotoMessage message)
        {
            string url = baseUrl + "sendphoto";

            MultipartFormDataContent content = MultiPartDataContent(message.ChatId, message.Caption, message.ReplyToMessageId, UploadType.Photo, message.Photo);

            Response response = await Post<VoidType>(content, url);
            return response;
        }

        public async Task<Response> SendAudioAsync(AudioMessage message)
        {
            string url = baseUrl + "sendAudio";

            MultipartFormDataContent content = MultiPartDataContent(message.ChatId, message.Caption, message.ReplyToMessageId, UploadType.Audio, message.Audio);
            content.Add(new StringContent(message.Title), "title");

            Response response = await Post<VoidType>(content, url);
            return response;
        }

        public async Task<Response> SendDocumentAsync(DocumentMessage message)
        {
            string url = baseUrl + "senddocument";

            MultipartFormDataContent content = MultiPartDataContent(message.ChatId, message.Caption, message.ReplyToMessageId, UploadType.Document, message.Document);

            Response response = await Post<VoidType>(content, url);
            return response;
        }

        public async Task<Response> SendVideoAsync(VideoMessage message)
        {
            string url = baseUrl + "sendVideo";

            MultipartFormDataContent content = MultiPartDataContent(message.ChatId, message.Caption, message.ReplyToMessageId, UploadType.Video, message.Video);

            Response response = await Post<VoidType>(content, url);
            return response;
        }

        public async Task<Response> SendLocation(LocationMessage message)
        {
            string url = baseUrl + "sendlocation";

            Response response = await Post<VoidType>(message, url);
            return response;
        }

        public async Task<Response> SendContact(ContactMessage message)
        {
            string url = baseUrl + "sendcontact";

            Response response = await Post<VoidType>(message, url);
            return response;
        }

        public async Task<Response> SendInvoice(InvoiceMessage message)
        {
            string url = baseUrl + "sendInvoice";

            Response response = await Post<VoidType>(message, url);
            return response;
        }


        public Response<File> GetFile(string fileId)
        {
            string url = baseUrl + "getfile?file_id=" + fileId;

            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                Response<File> res = Utils.Deserialize<Response<File>>(result);
                return res;


            }

            return new Response<File>();
        }

        public bool DownloadFile(long chatId, string fileId, string filePath, string fileName)
        {
            string url = fileBaseUrl + fileId;
            HttpResponseMessage response = client.GetAsync(url).Result;
            byte[] data = response.Content.ReadAsByteArrayAsync().Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                if (!System.IO.Directory.Exists(filePath))
                    System.IO.Directory.CreateDirectory(filePath);

                System.IO.File.WriteAllBytes(filePath + "\\" + fileName, data);
                return true;
            }

            return false;
        }




        private async Task<Response> Post<ResponseType>(object content, string url)
        {
            if (content == null)
                return Response.CreateInstance<ResponseType>("Invalid input parameter, it can not be null");

            try
            {
                HttpContent _content = content is HttpContent ? (HttpContent)content : new StringContent(Utils.Serialize(content), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(url, _content).Result;

                if (typeof(ResponseType) == typeof(VoidType))
                    return Utils.Deserialize<Response>(await response.Content.ReadAsStringAsync());
                else
                    return Utils.Deserialize<Response<ResponseType>>(await response.Content.ReadAsStringAsync());

            }
            catch (HttpRequestException httpExp)
            {
                return Response.CreateInstance<ResponseType>("Connection failed, " + httpExp.Message);
            }
            catch (JsonException jsonExp)
            {
                return Response.CreateInstance<ResponseType>("Deserialize/Read data failed, " + jsonExp.Message);
            }
            catch (Exception exp)
            {
                return Response.CreateInstance<ResponseType>(exp.Message);
            }
        }

        private MultipartFormDataContent MultiPartDataContent(long chatId, string caption, long? replyToMessageId, UploadType uploadType, byte[] content)
        {
            MultipartFormDataContent multiContent = new MultipartFormDataContent
            {
                { new StringContent(chatId.ToString()), "chat_id" },
                { new StringContent(caption), "caption"  },
            };

            if (replyToMessageId != null)
                multiContent.Add(new StringContent("reply_to_message_id"), replyToMessageId.Value.ToString());

            ByteArrayContent arrayContent = new ByteArrayContent(content);
            arrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/file");

            multiContent.Add(arrayContent, uploadType.ToString().ToLower());
            return multiContent;
        }

        private enum UploadType
        {
            Photo,
            Audio,
            Document,
            Video
        }
    }
}
