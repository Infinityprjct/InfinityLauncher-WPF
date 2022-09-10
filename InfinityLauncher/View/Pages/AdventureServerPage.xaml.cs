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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InfinityLauncher.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для TestPage1.xaml
    /// </summary>
    public partial class AdventureServerPage : Page
    {
        public AdventureServerPage(LauncherVM _vm)
        {
            InitializeComponent();
            DataContext = _vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
