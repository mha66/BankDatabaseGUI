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

namespace BankDatabaseGUI
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public UpdateWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.MainWindow.Show();
        }

        private void UpdateAccBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateAccountWindow obj = new UpdateAccountWindow();
            obj.Show();
        }

        private void UpdateCardBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateCardWindow obj = new UpdateCardWindow();
            obj.Show();
        }
    }
}
