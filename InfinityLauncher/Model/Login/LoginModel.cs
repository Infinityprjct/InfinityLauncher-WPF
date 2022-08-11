using InfinityLauncher.Model.Services.Authentication;
using InfinityLauncher.Model.Services.Requests;
using System;
using System.Windows;

namespace InfinityLauncher.Model
{
    /// <summary>
    /// Login Model class - model for LoginVM, LauncherAuth.xaml
    /// 
    /// </summary>
    public class LoginModel : ILoginModel
    {
        public User authUser { get; set; }
        public event EventHandler<LoginEventArgs> LoginUpdated = delegate { };

        public LoginModel()
        {
            authUser = new User(null, null);
        }

        public User Login(User _authUser)
        {
            authUser = _authUser;
            LoginUpdated(this, new LoginEventArgs(authUser));
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.Request(authUser.email,authUser.password);
            return null;
        }

    }
}
