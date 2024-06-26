﻿using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InfinityLauncher.Model.Services.Requests
{
    public class GetServersRequest : IRequest
    {
        public JObject Request()
        {
            var httpClient = new RestClient(IRequest.URL + "/api/servers/");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json; charset=utf-8;");

            RestResponse result = httpClient.ExecuteGet(request);

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
                var response = JObject.Parse(result.Content.ToString());
                return response;
            }
        }
    }
}
