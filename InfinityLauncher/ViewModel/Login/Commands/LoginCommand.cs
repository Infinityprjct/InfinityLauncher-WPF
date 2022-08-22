using InfinityLauncher.ViewModel.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InfinityLauncher.ViewModel.Commands
{
    internal class LoginCommand : ICommand
    {
        private ILoginVM _vm;

        public LoginCommand(ILoginVM viewModel)
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
            //Todo
            return true;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public void Execute(object parameter)
        {
            MessageBox.Show("shehehehe");
            _vm.Login();
            
        }
    }
}
