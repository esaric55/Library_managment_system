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
using System.Linq;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for FirstPage.xaml
    /// </summary>
    public partial class FirstPage : Window
    {
       
        public FirstPage()
        {
            InitializeComponent();
            FirstPage_Load();
        }
        public void DashboardClick (object sender, RoutedEventArgs e)
        {
            Dashboard dash1 = new Dashboard();
            dash1.Show();
            this.Close();
        }
        public void LogOutClick(object sender, RoutedEventArgs e)
        {
            LoginWindow log1 = new LoginWindow();
            log1.Show();
            this.Close();
        }
        public void BookClick(object sender, RoutedEventArgs e)
        {
            Catalog cat1 = new Catalog();
            cat1.Show();
            this.Close();
        }
        public void AccountClick(object sender, RoutedEventArgs e)
        {
            Account acc2 = new Account();
            
            acc2.Show();
            this.Close();
        }
        public void FirstPage_Load ()
        {
            usDisplay.Text = "Welcome" + "  " + LoginWindow.username +" ! ";
        }
    }
}
