using InfinityLauncher.Model.Services.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InfinityLauncher.ViewModel.Main.Commands
{
    public class LaunchGameAsync : AsyncCommandBase
    {
        private ILauncherVM _vm;

        public LaunchGameAsync(ILauncherVM viewModel)
        {
            _vm = viewModel;
            _vm.PropertyChanged += vm_PropertyChanged;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            MessageBox.Show("Nananan");
            await _vm.DownloadManager.DownloadServerFolder("","");
        }

        private void vm_PropertyChanged(object sender,
            PropertyChangedEventArgs e)
        {
            
        }

        

    }
}
