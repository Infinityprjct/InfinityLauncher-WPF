using InfinityLauncher.View.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InfinityLauncher.ViewModel.Main.Commands
{
    internal class ShowAccountPageCommand : ICommand
    {
        private IMainVM _vm;

        public ShowAccountPageCommand(IMainVM viewModel)
        {
            _vm = viewModel;
            _vm.PropertyChanged += vm_PropertyChanged;
        }

        private void vm_PropertyChanged(object sender,
            PropertyChangedEventArgs e)
        {
            MessageBox.Show(e.PropertyName.ToString());
            CanExecuteChanged(this, new EventArgs());
        }

        public bool CanExecute(object parameter)
        {
            /* UNCOMMENT ON RELEASE
            if (_vm.Account != null)
            {
                return true;
            }
            else 
            { 
                return false; 
            }
            */
            return true;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public void Execute(object parameter)
        {
            _vm.CurrentPage = new AccountPage();
            MessageBox.Show(_vm.CurrentPage.ToString());
        }
    }
}
