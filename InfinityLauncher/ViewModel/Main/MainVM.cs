using GalaSoft.MvvmLight.Command;
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
        private Account _account;
        private Server _currentServer;
        private Page _currentPage = new ExtraAnarchyPage();
        private readonly IMainModel _model;
        private readonly ICommand _changeServerCommand;
        private readonly ICommand _showAccountPageCommand;

        private Page AccountPage = new AccountPage();

        public ObservableCollection<Server> Servers
        { 
            get { return _model.servers; } 
        }

        public Account Account
        {
            get { return _model.account; }
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

        public Page CurrentPage
        {
            get 
            {
                MessageBox.Show(_currentPage.ToString());
                return _currentPage;
            }
            set
            {
                _currentPage = value;
            }
        }

        public ICommand ChangeServerCommand
        {
            get { return _changeServerCommand; }
        }
        public ICommand ShowAccountPage
        {
            get { 
                MessageBox.Show(CurrentPage.ToString()); 
                return new RelayCommand(() => CurrentPage = AccountPage); 
            }
        }

        public MainVM(IMainModel mainModel)
        {
            _model = mainModel;
            _model.AccountUpdated += model_accountUpdated;
            _model.ServerUpdated += model_serverUpdated;
            _changeServerCommand = new ChangeServerCommand(this);
            //_showAccountPageCommand = new ShowAccountPageCommand(this);
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
            _currentServer = _model.GetServer(serverName);
            MessageBox.Show(currentServer.Name);
        }

    }
}
