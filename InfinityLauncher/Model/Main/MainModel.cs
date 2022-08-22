using InfinityLauncher.Model.Services.Requests;
using InfinityLauncher.Types;
using InfinityLauncher.View.Pages;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InfinityLauncher.Model.Main
{
    public class MainModel : IMainModel
    {
        public Account currentAccount { get; set; }
        public ObservableCollection<Server> servers { get; set; }
        public event EventHandler<AccountEventArgs> AccountUpdated;
        public event EventHandler<ServerEventArgs> ServerUpdated;

        //public MainModel(Account account)
        //{
        //    if (account != null)
        //    {
        //        MessageBox.Show(account.refreshToken);
        //        MessageBox.Show(account.nickname);
        //        currentAccount = account;
        //    }
        //}

        public MainModel()
        {
            servers = new ObservableCollection<Server>();
        }

        public void InitializeServers()
        {
            GetServersRequest serversRequest = new GetServersRequest();
            JObject serversList = serversRequest.Request();

            foreach (var server in serversList)
            {
                JObject currServer = (JObject)server.Value;                

                Server _srv = new Server(currServer["name"].ToString(), currServer["ip"].ToString(), currServer["launcher_icon_url"].ToString(),
                                         currServer["launcher_page_url"].ToString());
                servers.Add(_srv);
                ServerUpdated(this, new ServerEventArgs(_srv));
            }
        }
        public Server GetServer(string serverName)
        {
            return servers.FirstOrDefault(
                server => server.name == serverName);
        }

    }
}
