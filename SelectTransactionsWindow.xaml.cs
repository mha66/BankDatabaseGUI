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
    /// Interaction logic for SelectTransactionsWindow.xaml
    /// </summary>
    public partial class SelectTransactionsWindow : Window
    {
        public SelectTransactionsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=LAPTOP-2U7I77OE\\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True;";
                string select = $"select TransactId from [Transaction];";
                con.Open();
                SqlCommand com = new SqlCommand(select, con);
                SqlDataReader dr;
                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    TransactIdCombo.Items.Add(new ComboBoxItem() { Tag = dr[0], Content = dr[0] });
                }
                con.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void SelectTransactBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=LAPTOP-2U7I77OE\\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True;";

                string select = $"select TransactId, TransactTypeName as 'Transaction Type' , AccNum, WDAmount, TransactDateTime\n" +
                    $"from [Transaction] inner join TransactionType on TransactionType.TransactTypeId = [Transaction].TransactTypeId\n" +
                    $"where TransactId={((ComboBoxItem)TransactIdCombo.SelectedItem).Tag};";

                SqlDataAdapter da = new SqlDataAdapter(select, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataView.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void SelectAllTransactsBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=LAPTOP-2U7I77OE\\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True;";

                string select = $"select TransactId, TransactTypeName as 'Transaction Type' , AccNum, WDAmount, TransactDateTime\n" +
                    $"from [Transaction] inner join TransactionType on TransactionType.TransactTypeId = [Transaction].TransactTypeId;";

                SqlDataAdapter da = new SqlDataAdapter(select, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataView.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
