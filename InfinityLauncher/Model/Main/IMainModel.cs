using InfinityLauncher.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityLauncher.Model.Main
{
    public interface IMainModel
    {
        ObservableCollection<Server> servers { get; set; }
        Server GetServer(string serverName);
        void InitializeServers();
        event EventHandler<AccountEventArgs> AccountUpdated;
        event EventHandler<ServerEventArgs> ServerUpdated;
        
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

