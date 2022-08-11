using InfinityLauncher.Model.Services.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityLauncher.Model
{
    public class AccountNotifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void NotifyPropertyChanged(
            string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public interface IAccountModel
    {
        Account account { get; set; }
        event EventHandler<AccountEventArgs> accountUpdated;
        void UpdateAccount(Account updateAccount);
    }

    public class AccountEventArgs : EventArgs
    {
        public Account account { get; set; }
        public AccountEventArgs(Account _account)
        {
            account = _account;
        }
    }

    public class AccountModel : IAccountModel
    {
        public Account account { get; set; }
        public event EventHandler<AccountEventArgs> accountUpdated = delegate { };

        public AccountModel()
        {
            
        }

        public void UpdateAccount(Account _updatedAccount)
        {
            account = _updatedAccount;

        }

    }
}
