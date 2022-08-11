using InfinityLauncher.Model;
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

namespace InfinityLauncher
{
    /// <summary>
    /// Interaction logic for LauncherAuth.xaml
    /// </summary>
    public partial class LauncherAuth : Window
    {
        private ILoginModel _loginModel;
        public LauncherAuth()
        {
            InitializeComponent();
            LoginModel loginModel = new LoginModel();
            DataContext = new LoginVM(loginModel);
        }

        private void CloseApp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Drag and move if clicked on a top of windows
        /// </summary>
        private void Login_DragAndMove(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        /// <summary>
        /// Hide TextBlock if password len > 0
        /// </summary>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).password = ((PasswordBox)sender).Password; }

            if (passTextBox.Password.Length > 0)
            {
                PassWatermark.Visibility = Visibility.Collapsed;
            }
            else
            {
                PassWatermark.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
