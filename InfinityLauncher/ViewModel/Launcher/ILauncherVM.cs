using InfinityLauncher.Model.Services;
using InfinityLauncher.Model.Services.Requests;
using InfinityLauncher.Types;
using InfinityLauncher.Types.Launcher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InfinityLauncher.ViewModel.Main
{
    public interface ILauncherVM : INotifyPropertyChanged
    {

        LauncherConfiguration LauncherConfig { get; }
        string IsUpdaterVisible { get; set; }
        UpdateManager UpdateManager { get; }
        DownloadManager DownloadManager { get; }
        Account Account { get; }
        Page CurrentPage { get; set; }
        Server СurrentServer { get; set; }

        void СhangeCurrentServer(string serverName);
        Task ChangeUpdaterVisibility();
    }
}
