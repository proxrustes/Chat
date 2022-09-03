using Chat_FrontEnd.ObjectModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace Chat_FrontEnd.APIControllers
{
    public class MessageApiService : IApiService<MessageModel>
    {
        private string GetURL(int id) => @$"https://localhost:7069/api/messages/{id}";
        private string GeneralURL() => @$"https://localhost:7069/api/messages";

        private readonly HttpClient client;

        public MessageApiService()
        {
            client = new HttpClient();
        }

#nullable enable
        public List<MessageModel>? GetAll()
        {
            string url = GeneralURL();
            string response = client.GetStringAsync(url).Result;
            return ParseUserModels(response);
        }



#nullable enable
        public MessageModel? Get(int id)
        {
            string url = GetURL(id);
            string response = client.GetStringAsync(url).Result;
            return ParseUserModel(response);
        }



        public async void Add([FromForm] MessageModel value)
        {
            var json = JsonConvert.SerializeObject(value);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var response = await client.PostAsync(GeneralURL(), data);

            var result = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(result);
        }

        public async void Update([FromForm] MessageModel value)
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
        private MessageModel? ParseUserModel(string json)
        {
            MessageModel userModel = JsonConvert.DeserializeObject<MessageModel>(json);
            return userModel;
        }

#nullable enable
        private List<MessageModel>? ParseUserModels(string json)
        {
            List<MessageModel> userModel = new List<MessageModel>();
            MessageModel[] array = JsonConvert.DeserializeObject<MessageModel[]>(json);

            for (int i = 0; i < array.Length; i++)
            {
                userModel.Add(array[i]);
            }
            return userModel;
        }
    }
}
