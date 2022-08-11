using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InfinityLauncher.Model.Services.Requests
{
    public class LoginRequest
    {
        public Dictionary<string, string> Body { get; set; }
        public Dictionary<string, string> Headers { get; set; }

        private static readonly HttpClient client = new HttpClient();

        public async void Request(string email, string password)
        {
            var payload = new JObject();
            payload.Add("email", email);
            payload.Add("password", password);

            var httpClient = new RestClient("http://127.0.0.1:8000/api/auth/token/create/");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            request.AddStringBody(payload.ToString(),RestSharp.DataFormat.Json);

            
            RestResponse result = httpClient.ExecutePost(request);

            if (result.StatusCode.ToString() == "BadRequest")
            {
                MessageBox.Show("Bad request");
            }
            else
            {
                var response = JObject.Parse(result.Content.ToString());
                MessageBox.Show(response["refresh"].ToString());
            }
        }
    }
}
