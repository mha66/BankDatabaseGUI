using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for SelectAccountWindow.xaml
    /// </summary>
    public partial class SelectAccountWindow : Window
    {
        public SelectAccountWindow()
        {
            InitializeComponent();
        }

        private void SelectAccBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=LAPTOP-2U7I77OE\\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True;";
                string select = $"select AccountNum as 'Account Number', Balance, AccTypeName as 'Account Type', CustomerId " +
                    $"from Account inner join AccountType on AccountType.AccTypeId = Account.AccTypeId " +
                    $"where AccountNum='{AccNumTxt.Text}';";

                SqlDataAdapter da = new SqlDataAdapter(select, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataView.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

        private void SelectAllAccBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=LAPTOP-2U7I77OE\\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True;";
                string select = $"select AccountNum as 'Account Number', Balance, AccTypeName as 'Account Type', CustomerId " +
                    $"from Account inner join AccountType on AccountType.AccTypeId = Account.AccTypeId " +
                    $"order by CustomerId asc;";
                SqlDataAdapter da = new SqlDataAdapter(select, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataView.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
