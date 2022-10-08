using InfinityLauncher.Model.Services.Requests;
using InfinityLauncher.View.Supporting;
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
    public class LaunchGameAsyncCommand : AsyncCommandBase
    {
        private ILauncherVM _vm;

        public LaunchGameAsyncCommand(ILauncherVM viewModel)
        {
            _vm = viewModel;
            _vm.PropertyChanged += vm_PropertyChanged;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            await _vm.ChangeUpdaterVisibility(); 
            await Task.Run(() => _vm.UpdateManager.UpdateServerFolders(parameter.ToString()));
            String libs = "C:\\Users\\Feedok\\Desktop\\Infinity\\Authlib Patching\\clientMC\\client\\1.16.5\\libraries";
            String assets = "C:\\Users\\Feedok\\Desktop\\Infinity\\Authlib Patching\\clientMC\\client\\1.16.5\\assets";
            await _vm.ChangeUpdaterVisibility();
        }

        private void vm_PropertyChanged(object sender,
            PropertyChangedEventArgs e)
        {
            
        }

    }
}
