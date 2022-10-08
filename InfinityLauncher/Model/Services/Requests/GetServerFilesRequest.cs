using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InfinityLauncher.Model.Services.Requests
{
    public class GetServerFilesRequest : IRequest
    {

        private string accessToken;
        private string serverName;

        public GetServerFilesRequest(string _accessToken, string _serverName)
        {
            this.accessToken = _accessToken;
            this.serverName = _serverName;
        }

        public JObject Request()
        {
            var httpClient = new RestClient(IRequest.URL + "/api/servers/" + serverName + "/files");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json; charset=utf-8;");
            request.AddOrUpdateHeader("Authorization", "Bearer " + accessToken);

            RestResponse result = httpClient.ExecuteGet(request);

            if (result == null || result.Content == null)
            {
                MessageBox.Show("Null response");
                return null;
            }
            else if (result.StatusDescription.ToString() == "Unauthorized")
            {
                return JObject.Parse("{\"error\" : \"Unauthorized\"}");
            }
            else if (result.ResponseStatus.ToString() == "Error")
            {
                MessageBox.Show("Error");
                
                return null;
            }
            else
            {
                var response = JObject.Parse(result.Content.ToString());
                return response;
            }
        }
    }
}
