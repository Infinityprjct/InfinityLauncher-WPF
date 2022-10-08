using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InfinityLauncher.Model.Services.Requests
{
    public interface IRequest
    {
        public const string URL = "http://127.0.0.1:8000";
        private RestClient httpClient
        {
            get { return httpClient; }
            set { httpClient = value; }
        }

        JObject Request();
    }
}
