using Chat_FrontEnd.ObjectModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace Chat_FrontEnd.APIControllers
{
    public class UserApiService : IApiService<UserModel>
    {
        private string GetURL(int id) => @$"https://localhost:7069/api/users/{id}";
        private string GeneralURL() => @$"https://localhost:7069/api/users";


        private readonly HttpClient client;

        public UserApiService()
        {
            client = new HttpClient();
        }

#nullable enable
        public List<UserModel>? GetAll()
        {
            string url = GeneralURL();
            string response = client.GetStringAsync(url).Result;
            return ParseUserModels(response);
        }

        public string Responce()
        {
            string url = GeneralURL();
            string response = client.GetStringAsync(url).Result;
            return response;
        }

#nullable enable
        public UserModel? Get(int id)
        {
            string url = GetURL(id);
            string response = client.GetStringAsync(url).Result;
            return ParseUserModel(response);
        }

        public async void Add([FromForm] UserModel value)
        {
            var json = JsonConvert.SerializeObject(value);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var response = await client.PostAsync(GeneralURL(), data);

            var result = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(result);
        }

        public async void Update([FromForm] UserModel value)
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
        private UserModel? ParseUserModel(string json)
        {
            UserModel userModel = JsonConvert.DeserializeObject<UserModel>(json);
            return userModel;
        }

#nullable enable
        private List<UserModel>? ParseUserModels(string json)
        {
            List<UserModel> userModel = JsonConvert.DeserializeObject<List<UserModel>>(json);
            Debug.Print(userModel.ToString());
            return userModel;
        }
    }
}
