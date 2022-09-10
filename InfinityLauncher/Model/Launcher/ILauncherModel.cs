using InfinityLauncher.Model.Services.Requests;
using InfinityLauncher.Types;
using InfinityLauncher.Types.Launcher;
using InfinityLauncher.ViewModel.Login;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityLauncher.Model.Main
{
    public interface ILauncherModel
    {
        LauncherConfiguration LauncherConfig { get; set; }
        DownloadManager DownloadManager { get; set; }
        Account account { get; set; }
        Server currentServer { get; set; }
        ObservableCollection<Server> servers { get; set; }
        Server GetServer(string serverName);
        void InitializeServers(LauncherVM _vm);
        event EventHandler<LauncherEventArgs> LauncherConfigUpdated;
        event EventHandler<AccountEventArgs> AccountUpdated;
        event EventHandler<ServerEventArgs> ServerUpdated;        
    }

    public class LauncherEventArgs : EventArgs
    {
        public LauncherConfiguration launcherConfig { get; set; }
        public LauncherEventArgs(LauncherConfiguration _config)
        {
            launcherConfig = _config;
        }
    }

    public class AccountEventArgs : EventArgs
    {
        public Account currentAccount { get; set; }
        public AccountEventArgs(Account _account)
        {
            currentAccount = _account;
        }
    }
    public class ServerEventArgs : EventArgs
    {
        public Server currentServer { get; set; }
        public ServerEventArgs(Server _server)
        {
            currentServer = _server;
        }
    }
}

