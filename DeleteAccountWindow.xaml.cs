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
    /// Interaction logic for DeleteAccountWindow.xaml
    /// </summary>
    public partial class DeleteAccountWindow : Window
    {
        public DeleteAccountWindow()
        {
            InitializeComponent();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=LAPTOP-2U7I77OE\\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True;";

                string select = $"select CardNum from [Card] where AccNum='{((ComboBoxItem)AccNumCombo.SelectedItem).Tag}';";
                con.Open();
                SqlCommand com = new SqlCommand(select, con);
                SqlDataReader dr;
                dr = com.ExecuteReader();

                string cardNum = "";
                if(dr.Read())
                {
                    cardNum = dr[0].ToString();
                }

                dr.Close();

                string delete = $"delete from CardATM where CardNum='{cardNum}';\n" +
                    $"delete from [Card] where CardNum='{cardNum}';\n" +
                    $"delete from [Transaction] where AccNum='{((ComboBoxItem)AccNumCombo.SelectedItem).Tag}';\n" +
                    $"delete from [Transfer] where SenderAccNum='{((ComboBoxItem)AccNumCombo.SelectedItem).Tag}' or RecieverAccNum='{((ComboBoxItem)AccNumCombo.SelectedItem).Tag}';\n" +
                    $"delete from Account where AccountNum='{((ComboBoxItem)AccNumCombo.SelectedItem).Tag}';";

                com = new SqlCommand(delete, con);

                com.ExecuteNonQuery();
                con.Close();

                AccNumCombo.SelectedItem = null;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            AccNumCombo.Items.Clear();
            LoadAccNumbers();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAccNumbers();
        }

        private void LoadAccNumbers()
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
                con.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
