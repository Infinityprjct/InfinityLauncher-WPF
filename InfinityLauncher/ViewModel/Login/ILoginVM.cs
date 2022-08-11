using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityLauncher.ViewModel.Login
{
    public interface ILoginVM : INotifyPropertyChanged
    {
        string email { get; set; }
        string password { get; set; }

        void Login();
    }
}
