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

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for AddMember.xaml
    /// </summary>
    public partial class AddMember : Window
    {
        public AddMember()
        {
            InitializeComponent();
        }
        public void btn_add_click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=MyLibrary; Integrated Security=True; ");
            sqlCon.Open();
            SqlCommand comm = new SqlCommand("insert into Members(UserID, FirstName, LastName, Address, Email) values ('" + userID.Text + "','" + firstname.Text + "','" + lastname.Text + "','" + address.Text + "','" + email.Text + "')", sqlCon);
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
            Librarian lib1 = new Librarian();
            lib1.Show();
            this.Close();
        }
        public void book_click(object sender, RoutedEventArgs e)
        {
            AddBook a = new AddBook();
            a.Show();
            this.Close();
        }
        public void report_click(object sender, RoutedEventArgs e)
        {
            BookReport b = new BookReport();
            b.Show();
            this.Close();
        }
    }

}
