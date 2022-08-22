using InfinityLauncher.Model.Services.Authentication;
using InfinityLauncher.Model.Services.Requests;
using InfinityLauncher.Types;
using Newtonsoft.Json.Linq;
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

        public Account LoginAccount(User _authUser)
        {
            authUser = _authUser;
            LoginUpdated(this, new LoginEventArgs(authUser));
            CreateTokenRequest request = new CreateTokenRequest(authUser.email,authUser.password);
            JObject tokens = request.Request();
            if (tokens == null)
            {
                return null;
            }    
            string accessToken = tokens["access"].ToString();
            string refreshToken = tokens["refresh"].ToString();
            Account account = new Account(accessToken, refreshToken);
            return account;
        }

    }
}
