using InfinityLauncher.View.Supporting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InfinityLauncher.ViewModel.Main.Commands
{
    internal class LaunchGameCommand : ICommand
    {
        private IMainVM _vm;

        public LaunchGameCommand(IMainVM viewModel)
        {
            _vm = viewModel;
            _vm.PropertyChanged += vm_PropertyChanged;
        }

        private void vm_PropertyChanged(object sender,
            PropertyChangedEventArgs e)
        {
            CanExecuteChanged(this, new EventArgs());
        }

        public bool CanExecute(object parameter)
        {
            // Todo
            return true;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public void Execute(object parameter)
        {
            InfoBox infoBox = new InfoBox("Информация","Майнкрафт запущен");
            infoBox.Show();
            String libs = "C:\\Users\\Feedok\\Desktop\\Infinity\\Authlib Patching\\clientMC\\client\\1.16.5\\libraries";
            String assets = "C:\\Users\\Feedok\\Desktop\\Infinity\\Authlib Patching\\clientMC\\client\\1.16.5\\assets";
            ProcessStartInfo minecraft = new ProcessStartInfo
            {
                FileName = @"C:\Program Files\Java\jre1.8.0_51\bin\javaw.exe",
                CreateNoWindow = false,
                Arguments = @"-Djava.library.path=C:/Users/Feedok/Desktop/Infinity/Authlib/clientMC/client/1.16.5/libraries/natives -cp ""C:/Users/Feedok/Desktop/Infinity/Authlib/clientMC/client/1.16.5/libraries/*"" net.minecraft.client.main.Main --username Steve --version 1.16.5 --gameDir C:\Users\Feedok\Desktop\Infinity\Authlib\clientMC\client\T --assetsDir C:/Users/Feedok/Desktop/Infinity/Authlib/clientMC/client/1.16.5/assets --assetIndex 1.16 --uuid f82fde1a6cfc497fa6df0c67d66ca002 --accessToken 2ca41fec1f154863936c35d27ac3b362 --userType mojang"
                //Arguments = @"java -Djava.library.path=C:/Users/Feedok/Desktop/Infinity/Authlib/clientMC/client/1.16.5/libraries/natives -cp ""C:/Users/Feedok/Desktop/Infinity/Authlib/clientMC/client/1.16.5/libraries/*"" net.minecraft.client.main.Main --username %username% --version 1.16.5 --gameDir . --assetsDir C:/Users/Feedok/Desktop/Infinity/Authlib/clientMC/client/1.16.5/assets --assetIndex 1.16 --uuid %uuid% --accessToken %accessToken% --userType mojang"
            };
            //Process.Start(minecraft);
        }
    }
}
