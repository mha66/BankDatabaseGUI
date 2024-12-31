using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
    /// Interaction logic for AddCardWindow.xaml
    /// </summary>
    public partial class AddCardWindow : Window
    {
        public AddCardWindow()
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
                con.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CardNumTxt.Text.Length != 16)
            {
                MessageBox.Show("Enter card number with 16 digits");
                e.Handled = true;
                return;
            }
            if (CVVTxt.Text.Length != 3)
            {
                MessageBox.Show("Enter CVV/CVC with 3 digits");
                e.Handled = true;
                return;
            }
            if (PinTxt.Text.Length != 4)
            {
                MessageBox.Show("Enter pin with 4 digits");
                e.Handled = true;
                return;
            }

            SqlConnection con = new SqlConnection();
            
            con.ConnectionString = "Data Source=LAPTOP-2U7I77OE\\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True;";
            string insert = $"insert into Card (CardNum, CreationDate, CVV, Pin, AccNum) values" +
                $"('{CardNumTxt.Text}', getdate() , '{CVVTxt.Text}', '{PinTxt.Text}', '{((ComboBoxItem)AccNumCombo.SelectedItem).Tag}');";

            con.Open();
            SqlCommand com = new SqlCommand(insert, con);
            com.ExecuteNonQuery();
            con.Close();

            CardNumTxt.Clear();
            CVVTxt.Clear();
            PinTxt.Clear();
            AccNumCombo.SelectedItem = null;
        }
    }
}
