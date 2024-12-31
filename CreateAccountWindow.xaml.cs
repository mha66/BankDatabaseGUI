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
using System.Data.SqlClient;
using System.Data;

namespace BankDatabaseGUI
{
    /// <summary>
    /// Interaction logic for CreateAccountWindow.xaml
    /// </summary>
    public partial class CreateAccountWindow : Window
    {
        public CreateAccountWindow()
        {
            InitializeComponent();
        }



        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (AccNumTxt.Text.Length != 18)
                {
                    MessageBox.Show("Enter account number with 18 digits");
                    e.Handled = true;
                    return;
                }
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=LAPTOP-2U7I77OE\\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True;";
                string insert = $"insert into Account (AccountNum, Balance, AccTypeId, CustomerId) values" +
                    $"('{AccNumTxt.Text}', {BalanceTxt.Text}, {((ComboBoxItem)AccTypeCombo.SelectedItem).Tag}, {((ComboBoxItem)CustomerIdCombo.SelectedItem).Tag});";

                con.Open();
                SqlCommand com = new SqlCommand(insert, con);
                com.ExecuteNonQuery();
                con.Close();

                AccNumTxt.Clear();
                BalanceTxt.Clear();
                AccTypeCombo.SelectedItem = null;
                CustomerIdCombo.SelectedItem = null;

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=LAPTOP-2U7I77OE\\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True;";
                string select = $"select AccTypeId, AccTypeName from AccountType order by AccTypeId;";
                con.Open();
                SqlCommand com = new SqlCommand(select, con);
                SqlDataReader dr;
                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    AccTypeCombo.Items.Add(new ComboBoxItem() { Tag = dr[0], Content = dr[1] });
                }
                dr.Close();
                select = $"select CustId, FName, LName from Customer inner join Person on PersonId=CustId";
                com = new SqlCommand(select, con);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    CustomerIdCombo.Items.Add(new ComboBoxItem() { Tag = dr[0], Content = dr[1] + " " + dr[2]});
                }
                con.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
