using Chat_FrontEnd.ObjectModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace Chat_FrontEnd.APIControllers
{
    public class ChatApiService : IApiService<ChatModel>
    {
        private string GetURL(int id) => @$"https://localhost:7069/api/chats/{id}";
        private string GeneralURL() => @$"https://localhost:7069/api/chats";


        private readonly HttpClient client;

        public ChatApiService()
        {
            client = new HttpClient();
        }

#nullable enable
        public List<ChatModel>? GetAll()
        {
            string url = GeneralURL();
            string response = client.GetStringAsync(url).Result;
            return ParseUserModels(response);
        }

#nullable enable
        public List<ChatModel>? GetUserChats(UserModel user)
        {
            string url = GeneralURL();
            string response = client.GetStringAsync(url).Result;
            List<ChatModel> list = ParseUserModels(response);
            List<ChatModel> finallist = new List<ChatModel>();
            if (user!= null)
            {
                foreach (var item in list)
                {
                    if (item.users.Contains(user))
                    {
                        finallist.Add(item);
                    }
                }
            }
            return finallist;
        }

#nullable enable
        public ChatModel? Get(int id)
        {
            string url = GetURL(id);
            string response = client.GetStringAsync(url).Result;
            return ParseUserModel(response);
        }

        public async void Add([FromForm] ChatModel value)
        {
            var json = JsonConvert.SerializeObject(value);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var response = await client.PostAsync(GeneralURL(), data);

            var result = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(result);
        }

        public async void Update([FromForm] ChatModel value)
        {
            var json = JsonConvert.SerializeObject(value);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var response = await client.PostAsync(GetURL(value.id), data);

            var result = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(result);
        }

        public async void Delete(int id)
        {
            using var client = new HttpClient();

            var response = await client.DeleteAsync(GetURL(id));

            var result = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(result);
        }

        #nullable enable
        private ChatModel? ParseUserModel(string json)
        {
            ChatModel userModel = JsonConvert.DeserializeObject<ChatModel>(json);
            return userModel;
        }

        #nullable enable
        private List<ChatModel>? ParseUserModels(string json)
        {
            List<ChatModel> userModel = JsonConvert.DeserializeObject<List<ChatModel>>(json);
            return userModel;
        }
    }
}
