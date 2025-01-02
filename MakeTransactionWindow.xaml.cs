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
    /// Interaction logic for MakeTransactionWindow.xaml
    /// </summary>
    public partial class MakeTransactionWindow : Window
    {
        public MakeTransactionWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=LAPTOP-2U7I77OE\\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True;";
                string select = $"select AccountNum from Account;";
                con.Open();
                SqlCommand com = new SqlCommand(select, con);
                SqlDataReader dr;
                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    AccNumCombo.Items.Add(new ComboBoxItem() { Tag = dr[0], Content = dr[0] });
                }
                dr.Close();
                select = $"select TransactTypeId, TransactTypeName from TransactionType";
                com = new SqlCommand(select, con);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    TransactTypeCombo.Items.Add(new ComboBoxItem() { Tag = dr[0], Content = dr[1] });
                }
                con.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();

                con.ConnectionString = "Data Source=LAPTOP-2U7I77OE\\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True;";
                string insert = $"insert into [Transaction] (TransactTypeId, AccNum, WDAmount, TransactDateTime) values" +
                    $"({((ComboBoxItem)TransactTypeCombo.SelectedItem).Tag}, '{((ComboBoxItem)AccNumCombo.SelectedItem).Tag}', {WDAmountTxt.Text}, getdate());";

                con.Open();
                SqlCommand com = new SqlCommand(insert, con);
                com.ExecuteNonQuery();
                con.Close();

                WDAmountTxt.Clear();
                AccNumCombo.SelectedItem = null;
                TransactTypeCombo.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
