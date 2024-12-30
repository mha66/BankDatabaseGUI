using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankDatabaseGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertWindow obj = new InsertWindow();
            obj.Show();
            this.Hide();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateWindow obj = new UpdateWindow();
            obj.Show();
            this.Hide();
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            DeleteWindow obj = new DeleteWindow();
            obj.Show();
            this.Hide();
        }

        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectWindow obj = new SelectWindow();
            obj.Show();
            this.Hide();
        }





        //Navigate to another form:
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Form2 obj = new Form2();
        //    obj.Show();
        //    this.Hide();
        //}
    }
}