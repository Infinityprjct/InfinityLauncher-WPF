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
    public class RefreshAccessTokenRequest : IRequest
    {
        private string refreshToken;

        public RefreshAccessTokenRequest(string _refresh)
        {
            this.refreshToken = _refresh;
        }

        public JObject Request()
        {
            var payload = new JObject();
            payload.Add("refresh", this.refreshToken);

            var httpClient = new RestClient(IRequest.URL + "/api/auth/jwt/refresh/");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            request.AddStringBody(payload.ToString(),RestSharp.DataFormat.Json);

            
            RestResponse result = httpClient.ExecutePost(request);

            if (result.Content == null)
            {
                MessageBox.Show("Null response");
                return null;
            }
            else if (result.ResponseStatus.ToString() == "Error")
            {
                MessageBox.Show("Error");
                return null;
            }
            else
            {
                JObject response = JObject.Parse(result.Content.ToString());
                return response;
            }
        }
    }
}
