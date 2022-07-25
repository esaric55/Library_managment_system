using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for IssueBook.xaml
    /// </summary>
    public partial class AddBook: Window
    {
        public AddBook()
        {
            InitializeComponent();
        }
        public void btn_add_click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=MyLibrary; Integrated Security=True; ");
            sqlCon.Open();
            SqlCommand comm = new SqlCommand("insert into Books(Title, Author, Publisher, Edition, Quantity) values ('"+title.Text+"','"+author.Text+"','"+publisher.Text+"','"+edition.Text+"','"+quantity.Text+"')", sqlCon);
            int i = comm.ExecuteNonQuery();
            if (i != 0)
            {
                MessageBox.Show("Added!");
                
            }
            else { MessageBox.Show("Error"); }
            sqlCon.Close();
        }
        public void back_click(object sender, RoutedEventArgs e)
        {
            Librarian lib = new Librarian();
            lib.Show();
            this.Close();
        }
        public void member_click(object sender, RoutedEventArgs e)
        {
            AddMember addmem = new AddMember();
            addmem.Show();
            this.Close();
        }
        public void report_click(object sender, RoutedEventArgs e)
        {
            BookReport rep1 = new BookReport();
            rep1.Show();
            this.Close();
        }
    }
}
