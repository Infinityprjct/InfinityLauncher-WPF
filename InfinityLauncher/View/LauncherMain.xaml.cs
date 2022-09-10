using InfinityLauncher.Model;
using InfinityLauncher.Model.Main;
using InfinityLauncher.ViewModel.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InfinityLauncher.View
{
    /// <summary>
    /// Логика взаимодействия для LauncherMain.xaml
    /// </summary>
    public partial class LauncherMain : Window
    {
        //public LauncherMain(Account account)
        //{
        //    InitializeComponent();
        //    MainModel menuModel = new MainModel(account);
        //    DataContext = new MainVM(menuModel);
        //}

        public LauncherMain()
        {
            InitializeComponent();
            LauncherModel mainModel = new LauncherModel();
            DataContext = new LauncherVM(mainModel);
        }

        private void Main_DragAndMove(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
