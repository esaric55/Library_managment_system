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
using Microsoft.Data.SqlClient;
using System.Data;


namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Window
    {
       
        public string usID2 { get; set; }
        
        public Account()
        {
            InitializeComponent();
            UserName();

            
        }
        public void book_click(object sender, RoutedEventArgs e)
        {
            Catalog c = new Catalog();
            c.Show();
            this.Close();

        }
        public void dashboard_click(object sender, RoutedEventArgs e) {
            Dashboard dash2 = new Dashboard();
            dash2.ID = usID2;
            dash2.Show();
            this.Close();
        }
        public void back_click(object sender, RoutedEventArgs e)
        {
            FirstPage fpp = new FirstPage();
            fpp.Show();
            this.Close();

        }
        public void UserName ()

        {
           
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=MyLibrary; Integrated Security=True; ");
            sqlCon.Open();
            SqlCommand comm = new SqlCommand("select UserID from Users where Username='" + LoginWindow.username + "'", sqlCon);
            usName.Text = LoginWindow.username;
            usID2 = Convert.ToString(comm.ExecuteScalar());
        
        }
        public void BackClick(object sender, RoutedEventArgs e) {
            FirstPage page1 = new FirstPage();
            page1.Show();
            this.Close();
        }
        
        public void btn_load_click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=MyLibrary; Integrated Security=True; ");
            sqlCon.Open();
            SqlCommand comm = new SqlCommand("select UserID, FirstName, LastName, Address, Email from Members where UserID='" + usID2 + "'", sqlCon);
            SqlDataReader srd = comm.ExecuteReader();
            while (srd.Read())
            {

                userID.Text = srd.GetValue(0).ToString();
                firstName.Text = srd.GetValue(1).ToString();
                lastName.Text = srd.GetValue(2).ToString();
                address.Text = srd.GetValue(3).ToString();
                email.Text = srd.GetValue(4).ToString();
            }
            sqlCon.Close();

        }
    }
}
