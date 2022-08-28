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
        private Page _currentPage;
        private readonly IMainModel _model;
        private readonly ICommand _changeServerCommand;
        private readonly ICommand _showAccountPageCommand;
        private readonly ICommand _launchGameCommand;

        // ViewModel - Model variables  
        public ObservableCollection<Server> Servers
        { 
            get { return _model.servers; } 
        }
        public Account Account { get { return _model.account; } }
        public Server СurrentServer
        {
            get { return _model.currentServer;  }
            set 
            { 
                _model.currentServer = value;
                NotifyPropertyChanged("currentServer");
            }
        }

        // ViewModel variables
        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                NotifyPropertyChanged("CurrentPage");

            }
        }
        public ICommand ChangeServerCommand
        {
            get { return _changeServerCommand; }
        }
        public ICommand ShowAccountPageCommand
        {
            get 
            {
                //return new RelayCommand(() => CurrentPage = AccountPage); 
                 return _showAccountPageCommand; 
            }
        }
        public ICommand LaunchGameCommand
        {
            get
            {
                return _launchGameCommand;
            }
        }

        /// <summary>
        /// Initializing Main ViewModel class. Here we setting up delegates with model updating events, commands and set up default current page
        /// to first server
        /// </summary>
        public MainVM(IMainModel mainModel)
        {
            _model = mainModel;
            _model.AccountUpdated += model_accountUpdated;
            _model.ServerUpdated += model_serverUpdated;
            _changeServerCommand = new ChangeServerCommand(this);
            _showAccountPageCommand = new ShowAccountPageCommand(this);
            _launchGameCommand = new LaunchGameCommand(this);
            
            // Initialize default page
            _currentPage = new ExtraAnarchyPage(this);

            InitializeServers();
        }
        /// <summary>
        /// Updating event voids from model. 
        /// </summary>
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
            _model.InitializeServers(this);
        }

        /// <summary>
        /// Changing current server and page also
        /// </summary>
        /// <param name="serverName">Name of server which we want to find</param>
        /// <returns>Server Class</returns>
        /// <see cref="CurrentPage"/>
        /// <see cref="СurrentServer"/>
        /// <see cref="Server"/>
        public void СhangeCurrentServer(string serverName)
        {
            СurrentServer = _model.GetServer(serverName);
            CurrentPage = СurrentServer.serverPage;
        }

    }
}
