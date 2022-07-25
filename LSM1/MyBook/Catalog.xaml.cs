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
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections;
namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        
        public Catalog()
        {
            InitializeComponent();
            bindDataGrid();
        }
        public void DashboardClick(object sender, RoutedEventArgs e)
        {
            Dashboard dash3 = new Dashboard();
            dash3.Show();
            this.Close();
        }
        public void AccountClick(object sender, RoutedEventArgs e)
        {
            Account acc2 = new Account();
            acc2.Show();
            this.Close();
        }
        public void LogOutClick(object sender, RoutedEventArgs e)
        {
            LoginWindow log2 = new LoginWindow();
            log2.Show();
            this.Close();
        }
        private void bindDataGrid ()
        {
            SqlConnection sqlCon2 = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=MyLibrary; Integrated Security=True; ");
            try
            {
                
                sqlCon2.Open();
                string query = "SELECT * FROM Books";
                SqlCommand comm = new SqlCommand(query, sqlCon2);
                comm.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(comm);
                DataTable dt = new DataTable("Books");
                dataAdp.Fill(dt);

                tableLoad.ItemsSource = dt.DefaultView;
                
                dataAdp.Update(dt);

                sqlCon2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtBookName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBookName.Text != "")
            {
                SqlConnection sqlCon2 = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=MyLibrary; Integrated Security=True; ");
                sqlCon2.Open();
                string query2 = "SELECT * FROM Books WHERE Title LIKE '" +txtBookName.Text+ "%'";
                SqlCommand comm2 = new SqlCommand(query2, sqlCon2);

                //comm2.ExecuteNonQuery();
                SqlDataAdapter data = new SqlDataAdapter(comm2);
                DataTable dt = new DataTable("Books");
                data.Fill(dt);
                

                tableLoad.ItemsSource = dt.DefaultView;

            }
            else
            {
                SqlConnection sqlCon2 = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=MyLibrary; Integrated Security=True; ");
                sqlCon2.Open();
            
                string query = "SELECT * FROM Books";
                SqlCommand comm2 = new SqlCommand(query, sqlCon2);
                comm2.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(comm2);
                DataTable dt = new DataTable("Books");
                dataAdp.Fill(dt);

                tableLoad.ItemsSource = dt.DefaultView;

                dataAdp.Update(dt);

                sqlCon2.Close();
            }
        }

      
    }
}
