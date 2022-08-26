using InfinityLauncher.Model.Main;
using InfinityLauncher.Model.Services.Requests;
using InfinityLauncher.Types;
using InfinityLauncher.View.Pages;
using InfinityLauncher.ViewModel.Main;
using InfinityLauncher.ViewModel.Main.Commands;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace InfinityLauncher.ViewModel.Login
{
    public class MainVM : MainNotifier,IMainVM
    {
        private string _email;
        private string _nickname;
        private int _balance;
        private string _uuid;
        private Server _currentServer;
        private readonly Page _currentPage;
        private readonly IMainModel _model;
        private readonly ICommand _changeServerCommand;

        public ObservableCollection<Server> Servers
        { get { return _model.servers; } }

        public string email
        {
            get { return _email; }
            set 
            {
                _email = value;
                NotifyPropertyChanged("email");
            }

        }
        public string nickname
        {
            get { return _nickname; }
            set 
            { 
                _nickname = value;
                NotifyPropertyChanged("nickname");
            }
        }
        public int balance
        {
            get { return _balance; }
            set 
            { 
                _balance = value;
                NotifyPropertyChanged("balance");
            }
        }
        public string UUID
        {
            get { return _uuid; }
            set 
            { 
                _uuid = value;
                NotifyPropertyChanged("UUID");
            }
        }

        public Server currentServer
        {
            get { return _currentServer;  }
            set 
            { 
                _currentServer = value;
                NotifyPropertyChanged("currentServer");
            }
        }

        public Page currentPage
        {
            get 
            {
                if (currentServer == null)
                {
                    return new ExtraAnarchyPage();
                }
                else
                {
                    return currentServer.serverPage;
                }
            }
        }

        public ICommand ChangeServerCommand
        {
            get { return _changeServerCommand; }
        }

        public MainVM(IMainModel mainModel)
        {
            _model = mainModel;
            _model.AccountUpdated += model_accountUpdated;
            _model.ServerUpdated += model_serverUpdated;
            _changeServerCommand = new ChangeServerCommand(this);
            InitializeServers();


        }
        private void model_accountUpdated(object sender,
                                          AccountEventArgs e)
        {
            MessageBox.Show("UPDATED ACCOUNT");
        }
        private void model_serverUpdated(object sender,
                                          ServerEventArgs e)
        {
            MessageBox.Show("UPDATED SERVER");
            
        }

        public void InitializeServers()
        {
            _model.InitializeServers();
        }

        public void СhangeCurrentServer(string serverName)
        {
            currentServer = _model.GetServer(serverName);
            MessageBox.Show(currentServer.Name);
        }

    }
}
