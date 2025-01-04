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
    /// Interaction logic for DeleteCardWindow.xaml
    /// </summary>
    public partial class DeleteCardWindow : Window
    {
        public DeleteCardWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCardNumbers();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=LAPTOP-2U7I77OE\\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True;";
                string delete = $"delete from CardATM where CardNum='{((ComboBoxItem)CardNumCombo.SelectedItem).Tag}';\n" + 
                    $"delete from [Card] where CardNum='{((ComboBoxItem)CardNumCombo.SelectedItem).Tag}';";
                con.Open();
                SqlCommand com = new SqlCommand(delete, con);


                com.ExecuteNonQuery();
                con.Close();

                CardNumCombo.SelectedItem = null;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            CardNumCombo.Items.Clear();
            LoadCardNumbers();
        }

        private void LoadCardNumbers()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=LAPTOP-2U7I77OE\\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True;";
                string select = $"select CardNum from [Card];";
                con.Open();
                SqlCommand com = new SqlCommand(select, con);
                SqlDataReader dr;
                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    CardNumCombo.Items.Add(new ComboBoxItem() { Tag = dr[0], Content = dr[0] });
                }
                con.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
