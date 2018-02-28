using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionDeTickets
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void Login_OnClick(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(
                @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=GestionDeTickets.Class.GestionContext; Integrated Security=True;");
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                string query = "SELECT COUNT(1) FROM Personnes WHERE Login=@Username AND Password=@Password";
                SqlCommand sqlCommand = new SqlCommand(query,sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Username", Username.Text);
                sqlCommand.Parameters.AddWithValue("@Password", Password.Password);
                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                if (count == 1)
                {
                    MainWindow dashMainWindow = new MainWindow();
                    dashMainWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Login ou mot de passe incorrect.");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
