using InfinityLauncher.Model.Services;
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
using System.Windows;

namespace InfinityLauncher.Model.Main
{
    public interface ILauncherModel
    {
        LauncherConfiguration LauncherConfig { get; set; }
        UpdateManager UpdateManager { get; set; }
        DownloadManager DownloadManager { get; set; }
        Account account { get; set; }
        Server currentServer { get; set; }
        ObservableCollection<Server> servers { get; set; }
        UpdaterStates updaterState { get; set; }
        Server GetServer(string serverName);
        void InitializeServers(LauncherVM _vm);
        void SetUpdaterStates(UpdaterStates states);
        void SetUpdaterPercentage(int updaterPercentage);
        event EventHandler<LauncherEventArgs> LauncherConfigUpdated;
        event EventHandler<UpdaterEventArgs> UpdaterStatesUpdated;
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

    public class UpdaterEventArgs : EventArgs
    {
        public UpdaterStates updaterStates { get; set; }
        public UpdaterEventArgs(UpdaterStates _updater)
        {
            updaterStates = _updater;

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

