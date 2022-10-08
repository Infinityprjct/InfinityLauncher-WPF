using GalaSoft.MvvmLight.Command;
using InfinityLauncher.Model.Main;
using InfinityLauncher.Model.Services;
using InfinityLauncher.Model.Services.Requests;
using InfinityLauncher.Types;
using InfinityLauncher.Types.Launcher;
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
using System.Windows.Threading;

namespace InfinityLauncher.ViewModel.Login
{
    public class LauncherVM : LauncherNotifier,ILauncherVM
    {
        private string _isUpdaterVisible = "Hidden";
        private UpdaterStates _updaterState;
        private Page _currentPage;
        private readonly ILauncherModel _model;
        private readonly ICommand _changeServerCommand;
        private readonly ICommand _showAccountPageCommand;
        private readonly ICommand _launchGameCommand;

        // ViewModel - Model variables  

        public LauncherConfiguration LauncherConfig
        {
            get { return _model.LauncherConfig; }
        }
        public UpdateManager UpdateManager
        {
            get { return _model.UpdateManager; }
        }
        public string IsUpdaterVisible
        {
            get { return _isUpdaterVisible; }
            set { _isUpdaterVisible = value; NotifyPropertyChanged("IsUpdaterVisible"); }
        }
        public UpdaterStates UpdaterState
        {
            get { return _updaterState; }
            set { _updaterState = value; Application.Current.Dispatcher.Invoke(() => NotifyPropertyChanged("UpdaterState")); }
        }

        public DownloadManager DownloadManager { get { return _model.DownloadManager; } }
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
        public LauncherVM(ILauncherModel mainModel)
        {
            _model = mainModel;
            _updaterState = new UpdaterStates();
            _model.AccountUpdated += model_accountUpdated;
            _model.ServerUpdated += model_serverUpdated;
            _model.UpdaterStatesUpdated += model_updaterStateUpdated;
            _changeServerCommand = new ChangeServerCommand(this);
            _showAccountPageCommand = new ShowAccountPageCommand(this);
            _launchGameCommand = new LaunchGameAsyncCommand(this);
            
            // Initialize default page
            _currentPage = new AdventureServerPage(this);

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

        // lmao name
        async private void model_updaterStateUpdated(object sender,
                                          UpdaterEventArgs e)
        {
            UpdaterState = e.updaterStates;
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

        public async Task ChangeUpdaterVisibility()
        {
            if (IsUpdaterVisible == "Hidden")
            {
                IsUpdaterVisible = "Visible";
            }
            else
            {
                IsUpdaterVisible = "Hidden";
            }
        }

    }
}
