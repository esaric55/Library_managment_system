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

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for Librarian.xaml
    /// </summary>
    public partial class Librarian : Window
    {
        public Librarian()
        {
          InitializeComponent();
          
        }
       
        public void add_click (object sender, RoutedEventArgs e)
        {
            AddBook addbook = new AddBook();
            addbook.Show();
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
            BookReport bookrep = new BookReport();
            bookrep.Show();
            this.Close();
        }
        public void logout_click(object sender, RoutedEventArgs e)
        {
            LoginWindow log3 = new LoginWindow();
            log3.Show();
            this.Close();
        }
        public void return_Click(object sender, RoutedEventArgs e)
        {
        }
        public void report_Click(object sender, RoutedEventArgs e)
        {

        }
        public void LogOutClick (object sender, RoutedEventArgs e) { }
    }
}
