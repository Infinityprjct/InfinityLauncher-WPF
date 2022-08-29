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

namespace InfinityLauncher.View.Supporting
{
    /// <summary>
    /// Логика взаимодействия для InfoBox.xaml
    /// </summary>
    public partial class InfoBox : Window
    {
        public InfoBox(String caption, String message)
        {
            InitializeComponent();
            Caption.Text = caption;
            Message.Text = message;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
