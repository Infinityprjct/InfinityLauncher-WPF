using InfinityLauncher.Model.Services.Requests;
using InfinityLauncher.View.Supporting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InfinityLauncher.Types
{
    /// <summary>
    ///  Account class is represent information of player to launcher
    ///  
    /// </summary>
    public class Account
    {
        public string email;
        public string nickname;
        private int balance;
        private string uuid;
        public string refreshToken
        { get { return Settings.Default.RefreshToken; } set { Settings.Default.RefreshToken = value; Settings.Default.Save(); } }
        public string accessToken { get { return Settings.Default.AccessToken; } set { Settings.Default.AccessToken = value; Settings.Default.Save(); } }


        public Account(string _accessToken, string _refreshToken)
        {
            UpdateAccessToken();
            RefreshAccount();
        }

        public void RefreshAccount()
        {
            GetAccountRequest request = new GetAccountRequest(accessToken);
            JObject jsonAccount = request.Request();
            if (jsonAccount["error"] != null)
            {
                if (jsonAccount["error"].ToString() == "Unauthorized")
                {
                    UpdateAccessToken();
                    request = new GetAccountRequest(accessToken);
                    jsonAccount = request.Request();
                }
            }
            else
            { 
                email = jsonAccount["email"].ToString();
                nickname = jsonAccount["nickname"].ToString();
                balance = ((int)jsonAccount["balance"]);
                uuid = jsonAccount["uuid"].ToString();
            }
        }

        public void UpdateAccessToken()
        {
            RefreshAccessTokenRequest request = new RefreshAccessTokenRequest("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ0b2tlbl90eXBlIjoicmVmcmVzaCIsImV4cCI6MTY2MzY5NzI4MSwianRpIjoiYTBhMmFiYmE5NzFmNDdkYWIxZjYzNWQ0OTY1MGNmMzMiLCJ1c2VyX2lkIjoxfQ.pFWZLcv4Y4bwkjkyQ-OEBDGtLelVMiV42BKDnjBzVy8");
            JObject token = request.Request();
            if (token == null || token["access"] == null)
            {
                InfoBox exitInfo = new InfoBox("Информация", "Сессия устарела выходим");
                exitInfo.Show();
            }
            else
            {
                this.accessToken = token["access"].ToString();
            }
             
            
        }
    }
}
