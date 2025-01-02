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
    /// Interaction logic for MakeTransferWindow.xaml
    /// </summary>
    public partial class MakeTransferWindow : Window
    {
        public MakeTransferWindow()
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
                    SenderAccNumCombo.Items.Add(new ComboBoxItem() { Tag = dr[0], Content = dr[0] });
                    RecieverAccNumCombo.Items.Add(new ComboBoxItem() { Tag = dr[0], Content = dr[0] });
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
                string insert = $"INSERT INTO [Transfer] (TransferDateTime, TransferAmount, SenderAccNum, RecieverAccNum) VALUES" +
                    $"(getdate() , '{TransferAmountTxt.Text}', '{((ComboBoxItem)SenderAccNumCombo.SelectedItem).Tag}', '{((ComboBoxItem)RecieverAccNumCombo.SelectedItem).Tag}');";

                con.Open();
                SqlCommand com = new SqlCommand(insert, con);
                com.ExecuteNonQuery();
                con.Close();

                TransferAmountTxt.Clear();
                SenderAccNumCombo.SelectedItem = null;
                RecieverAccNumCombo.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
