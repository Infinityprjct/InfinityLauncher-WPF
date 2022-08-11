using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityLauncher.Model.Services.Authentication
{
    public interface IAuthenticationService
    {
        void Login(String email, string password);
    }
}
