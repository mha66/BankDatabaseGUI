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
                string delete = $"delete from Account where AccountNum='{AccNumTxt.Text}';";
                con.Open();
                SqlCommand com = new SqlCommand(delete, con);


                com.ExecuteNonQuery();
                con.Close();

                AccNumTxt.Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
