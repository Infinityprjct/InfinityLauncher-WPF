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
        public Account account { get; set; }
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
            Server ExtraAnarchyServer = new Server("ExtraAnarchy","127.0.0.1", null, new ExtraAnarchyPage());
            servers.Add(ExtraAnarchyServer);

        }
        public Server GetServer(string serverName)
        {
            return servers.FirstOrDefault(
                server => server.Name == serverName);
        }

    }
}
