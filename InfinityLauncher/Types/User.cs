using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityLauncher.Types
{
    /// <summary>
    ///  User class is represent information for login request
    ///  
    /// </summary>
    public class User
    {
        public string email { get; set; }
        public string password { get; set; }


        public User(string _email, string _password)
        {
            email = _email;
            password = _password;
        }
    }
}
