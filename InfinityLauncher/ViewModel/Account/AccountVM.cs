using InfinityLauncher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InfinityLauncher.ViewModel
{

    public class AccountVM : AccountNotifier
    {
        private Int64 _id;
        private string _email;
        private string _nickname;
        private string _uuid;

        private readonly IAccountModel _model;
        private readonly ICommand _updateCommand;

        public AccountVM(Account account)
        {
            if (account == null)
            {
                return;
            }
            ID = account.id;
            Email = account.email;
            Nickname = account.nickname;
            UUID = account.uuid;
        }

        public Int64 ID
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyPropertyChanged("Id");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyPropertyChanged("Email");
            }
        }

        public string Nickname
        {
            get { return _nickname; }
            set
            {
                _nickname = value;
                NotifyPropertyChanged("Nickname");
            }
        }

        public string UUID
        {
            get { return _uuid; }
            set
            {
                _uuid = value;
                NotifyPropertyChanged("UUID");
            }
        }

      
        public void Update(Account account)
        {
            if (account == null)
            {
                return;
            }
            ID = account.id;
            Email = account.email;
            Nickname = account.nickname;
            UUID = account.uuid;
        }

        public ICommand UpdateCommand
        {
            get { return _updateCommand; }
        }



        private Account GetAccount()
        {
            return new Account(ID,Email,Nickname,UUID);
        }
    }
}

