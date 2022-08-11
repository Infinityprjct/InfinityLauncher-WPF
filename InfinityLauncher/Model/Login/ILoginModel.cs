using InfinityLauncher.Model.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityLauncher.Model
{
    public interface ILoginModel
    {
        User authUser { get; set; }
        event EventHandler<LoginEventArgs> LoginUpdated;
        User Login(User _authUser);
    }

    public class LoginEventArgs : EventArgs
    {
        public User authUser { get; set; }
        public LoginEventArgs(User _user)
        {
            authUser = _user;
        }
    }

}
