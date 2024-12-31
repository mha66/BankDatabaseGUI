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
    /// Interaction logic for InsertWindow.xaml
    /// </summary>
    public partial class InsertWindow : Window
    {
        public InsertWindow()
        {
            InitializeComponent();
        }


        private void CreateAccBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateAccountWindow obj = new CreateAccountWindow();
            obj.Show();
        }

        private void AddCardBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCardWindow obj = new AddCardWindow();
            obj.Show();
        }

        private void MakeTransactBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MakeTransferBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.MainWindow.Show();
        }
    }
}
