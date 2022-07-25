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
    /// Interaction logic for BookReport.xaml
    /// </summary>
    public partial class BookReport : Window
    {
        public BookReport()
        {
            InitializeComponent();
            bindDataGrid();
        }
        private void bindDataGrid()
        {
            SqlConnection sqlCon2 = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=MyLibrary; Integrated Security=True; ");
            try
            {

                sqlCon2.Open();
                string query1 = "SELECT * FROM IssuedBooks";
                string query2 = "SELECT * FROM ReturnedBooks";
                SqlCommand comm = new SqlCommand(query1, sqlCon2);
                SqlCommand comm2 = new SqlCommand(query2, sqlCon2);
                comm.ExecuteNonQuery();
                comm2.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(comm);
                SqlDataAdapter dataAdp2 = new SqlDataAdapter(comm2);
                DataTable dt = new DataTable("IssBooks");
                DataTable dt2 = new DataTable("RetBooks");
                dataAdp.Fill(dt);
                dataAdp2.Fill(dt2);

                issuedBooks.ItemsSource = dt.DefaultView;
                returnedBooks.ItemsSource = dt2.DefaultView;

                dataAdp.Update(dt);
                dataAdp2.Update(dt2);

                sqlCon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void back_click(object sender, RoutedEventArgs e)
        {
            Librarian lib3 = new Librarian();
            lib3.Show();
            this.Close();
        }
        private void add_click(object sender, RoutedEventArgs e)
        {
            AddBook addb = new AddBook();
            addb.Show();
            this.Close();
        }
        private void member_click(object sender, RoutedEventArgs e)
        {
            AddMember mem1 = new AddMember();
            mem1.Show();
            this.Close();
        }
    }
}
