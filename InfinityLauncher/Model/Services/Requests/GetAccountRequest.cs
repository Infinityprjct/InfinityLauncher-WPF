﻿using Newtonsoft.Json.Linq;
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
    public class GetAccountRequest : IRequest
    {

        private string accessToken;

        public GetAccountRequest(string _accessToken)
        {
            this.accessToken = _accessToken;
        }

        public JObject Request()
        {
            var httpClient = new RestClient(IRequest.URL + "/api/auth/users/me/");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json; charset=utf-8;");
            request.AddOrUpdateHeader("Authorization", "Bearer " + accessToken);

            MessageBox.Show(accessToken);

            RestResponse result = httpClient.ExecuteGet(request);

            if (result.Content == null)
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
                MessageBox.Show(result.StatusDescription.ToString());
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
