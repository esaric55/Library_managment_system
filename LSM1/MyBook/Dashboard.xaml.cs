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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
  
    public partial class Dashboard : Window {

        public string ID { get; set; }
        
        public Dashboard()
        {
            InitializeComponent();
            NameDisplay();
        }
        public void NameDisplay()
        {
            name2.Text = LoginWindow.username;
        }
        public void HomeClick(object sender, RoutedEventArgs e)
        {
            FirstPage page2 = new FirstPage();
            page2.Show();
            this.Close();
        }
        public void AccountClick(object sender, RoutedEventArgs e)
        {
            Account acc1 = new Account();
            acc1.Show();
            this.Close();
        }
        public void CatalogClick(object sender, RoutedEventArgs e)
        {
            Catalog cat2 = new Catalog();
            cat2.Show();
            this.Close();
        }
        public void IssuedBooks(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=MyLibrary; Integrated Security=True; ");
            sqlCon.Open();
            SqlCommand comm = new SqlCommand("select * from IssuedBooks where userID='" + ID + "'", sqlCon);
         

            SqlDataAdapter data = new SqlDataAdapter(comm);
            DataTable dtab = new DataTable("IssBooks");
            data.Fill(dtab);

            dataLoad.ItemsSource = dtab.DefaultView;

            data.Update(dtab);

            sqlCon.Close();
        }
            
        public void ReturnBooks(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=MyLibrary; Integrated Security=True; ");
            sqlCon.Open();
            SqlCommand comm = new SqlCommand("select * from ReturnedBooks where userID='" + ID + "'", sqlCon);
           

            SqlDataAdapter datAdp = new SqlDataAdapter(comm);
            DataTable dtab1 = new DataTable("RetBooks");
            datAdp.Fill(dtab1);

            dataLoad.ItemsSource = dtab1.DefaultView;

            datAdp.Update(dtab1);

            sqlCon.Close();
        }
    }
}
