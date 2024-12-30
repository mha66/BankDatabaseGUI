﻿using System;
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
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=LAPTOP-2U7I77OE\\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True;";
                string insert = "insert into Account (AccountNum, Balance, AccTypeId, CustomerId) values('"
                                + AccNumTxt.Text + "', " + BalanceTxt.Text + ", " + ((ComboBoxItem)AccTypeCombo.SelectedItem).Tag + ", " + ((ComboBoxItem)CustomerIdCombo.SelectedItem).Tag + ");";

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
    }
}
