using InfinityLauncher.Model.Services.Requests;
using InfinityLauncher.Types;
using InfinityLauncher.Types.Launcher;
using InfinityLauncher.View.Pages;
using InfinityLauncher.ViewModel.Login;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace InfinityLauncher.Model.Main
{
    public class LauncherModel : ILauncherModel
    {
        public LauncherConfiguration LauncherConfig { get; set; }
        public DownloadManager DownloadManager { get; set; }
        public Account account { get; set; }
        public Server currentServer { get; set; }
        public ObservableCollection<Server> servers { get; set; }
        public event EventHandler<LauncherEventArgs> LauncherConfigUpdated;
        public event EventHandler<AccountEventArgs> AccountUpdated;
        public event EventHandler<ServerEventArgs> ServerUpdated;

        /// <summary>
        /// Model for main launcher part. Here we startup minecraft, show account info and setting up launcher
        /// </summary>
        /// <param name="account">User's account</param>
        /// <see cref="Account"/>
        //public MainModel(Account account)
        //{
        //    if (account != null)
        //    {
        //        MessageBox.Show(account.refreshToken);
        //        MessageBox.Show(account.nickname);
        //        currentAccount = account;
        //    }
        //}

        public LauncherModel()
        {
            LauncherConfig = new LauncherConfiguration();
            DownloadManager = new DownloadManager();
            servers = new ObservableCollection<Server>();
        }

        public void InitializeLauncher()
        {
        }

        /// <summary>
        /// At the beginning I want to make auto-updating servers-list, with requests, but I gave up this idea
        /// InitializeServers() method generates servers list
        /// <see cref="servers"/>
        /// </summary>
        public void InitializeServers(LauncherVM _vm)
        {
            Server ExtraAnarchyServer = new Server("ExtraAnarchy","127.0.0.1", null, new AdventureServerPage(_vm));
            servers.Add(ExtraAnarchyServer);

        }

        /// <summary>
        /// Find server from servers list by name
        /// </summary>
        /// <param name="serverName">Name of server which we want to find</param>
        /// <returns>Server Class</returns>
        /// <see cref="Server"/>
        public Server GetServer(string serverName)
        {
            return servers.FirstOrDefault(
                server => server.Name == serverName);
        }

    }
}
