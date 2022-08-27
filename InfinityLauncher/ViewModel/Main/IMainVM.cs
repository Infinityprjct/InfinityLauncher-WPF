﻿using InfinityLauncher.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InfinityLauncher.ViewModel.Main
{
    public interface IMainVM : INotifyPropertyChanged
    {
        Account Account { get; }
        Page CurrentPage { get; set; }
        Server currentServer { get; set; }

        void СhangeCurrentServer(string serverName);
    }
}
