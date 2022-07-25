using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Data.SqlClient;
using MaterialDesignThemes.Wpf;
using System.Data;
using System.Linq;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static string username;
        public LoginWindow()
        {
            InitializeComponent();
        }
       
        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();
            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }
        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        public void CreateObject()
        {

        }

        public void LoginClick(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=MyLibrary; Integrated Security=True; ");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                
                    
                String query = "SELECT COUNT(1) FROM Users WHERE Username=@Username AND Password=@Password";
             
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);

                SqlCommand comm = new SqlCommand("select UserID from Users where Username='" + LoginWindow.username + "'", sqlCon);

                int usID = Convert.ToInt32(comm.ExecuteScalar());

                String query1 = "SELECT COUNT(1) FROM Members WHERE UserID='"+usID+"'";
                
                SqlCommand comm1 = new SqlCommand(query1, sqlCon);
                int count2 = Convert.ToInt32(comm1.ExecuteScalar());
                


                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
             
                if (count == 1)

                    {
                        username = txtUsername.Text;
                    if (count2==1) {
                        this.Hide();
                        FirstPage fp2 = new FirstPage();

                        fp2.Show(); }
                    else { Librarian lib0 = new Librarian();
                        lib0.Show();
                        this.Close(); }

                        
                   
                      
                }
                    else
                    {
                        MessageBox.Show("Username or password wrong");
                    }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                sqlCon.Close();
            }


        }

        
    }
}
