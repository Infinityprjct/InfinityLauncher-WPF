using InfinityLauncher.Model.Services.Requests;
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
        //public Int64 id
        //{
        //    get
        //    {
        //        return id;
        //    }
        //    private set
        //    {
        //        id = value;
        //    }
        //}
        public string email;
        public string nickname;
        private int balance;
        private string uuid;
        public string refreshToken { get; set; }
        public string accessToken { get; set; }


        public Account(string _accessToken, string _refreshToken)
        {
            accessToken = _accessToken;
            refreshToken = _refreshToken;
            RefreshAccount();
            
        }

        public void RefreshAccount()
        {
            GetAccountRequest getAccountRequest = new GetAccountRequest(accessToken);
            JObject jsonAccount = getAccountRequest.Request();
            MessageBox.Show(jsonAccount.ToString());
            email = jsonAccount["email"].ToString();
            nickname = jsonAccount["nickname"].ToString();
            balance = ((int)jsonAccount["balance"]);
            uuid = jsonAccount["uuid"].ToString();
        }

        public void UpdateRefreshToken(string _refreshToken)
        {

        }
    }
}
