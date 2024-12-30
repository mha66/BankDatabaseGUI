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
    /// Interaction logic for SelectWindow.xaml
    /// </summary>
    public partial class SelectWindow : Window
    {
        public SelectWindow()
        {
            InitializeComponent();
        }

        private void SelectAccBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectAccountWindow obj = new SelectAccountWindow();
            obj.Show();
        }

        private void SelectCardBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SelectTransactBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SelectTransferBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.MainWindow.Show();
        }
    }
}
