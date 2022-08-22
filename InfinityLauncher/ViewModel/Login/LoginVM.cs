using InfinityLauncher.Model;
using InfinityLauncher.Model.Services.Authentication;
using InfinityLauncher.Types;
using InfinityLauncher.View;
using InfinityLauncher.ViewModel.Commands;
using InfinityLauncher.ViewModel.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InfinityLauncher.ViewModel.Login
{
    public class LoginVM : LoginNotifier, ILoginVM
    {
        private string _email;
        private string _password { get; set; }
        private readonly ILoginModel _model;
        private readonly ICommand _loginCommand; 

        public string email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyPropertyChanged("email");
            }

        }
        public string password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyPropertyChanged("password");
            }

        }

        public ICommand LoginCommand
        {
            get { return _loginCommand; }
        }

        public User authUser
        {
            get
            {
                return new User(_email, _password);
            }
        }   

        public LoginVM(ILoginModel loginModel)
        {
            _model = loginModel;
            _model.LoginUpdated += model_LoginUpdated;
            _loginCommand = new LoginCommand(this);
        }

        public void Login()
        {
            Account currentAccount = _model.LoginAccount(authUser);
            if (currentAccount != null)
            {
                //LauncherMain menuView = new LauncherMain(currentAccount);
                //menuView.Show();
                
            }
        }

        private void model_LoginUpdated(object sender,
                                          LoginEventArgs e)
        {
            MessageBox.Show("UPDATED");
        }

       
    }
}
