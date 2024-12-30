using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for UpdateAccountWindow.xaml
    /// </summary>
    public partial class UpdateAccountWindow : Window
    {
        public UpdateAccountWindow()
        {
            InitializeComponent();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=LAPTOP-2U7I77OE\\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True;";
                string update = $"update Account set Balance={BalanceTxt.Text} where AccountNum='{AccNumTxt.Text}';";
                con.Open();
                SqlCommand com = new SqlCommand(update, con);

                com.ExecuteNonQuery();
                con.Close();

                AccNumTxt.Clear();
                BalanceTxt.Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
