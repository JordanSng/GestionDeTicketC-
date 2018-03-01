using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace GestionDeTickets
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class LoginScreen
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
                string query = "SELECT Discriminator FROM Personnes WHERE Login=@Username and Password=@Password";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
                sda.SelectCommand.Parameters.AddWithValue("@Username", Username.Text); //Attribue la valeur du champ Username.text à @Username dans la requête
                sda.SelectCommand.Parameters.AddWithValue("@Password", Password.Password); //Attribue la valeur du champ Password.Password à @Password dans la requête
                DataSet ds=new DataSet();
                sda.Fill(ds,"Login");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    String discriminator = ds.Tables[0].Rows[0]["Discriminator"].ToString();// Regarde si la personne est un utilisateur ou un technicien

                    switch (discriminator)
                    {
                        case "Technicien":
                        {
                            TicketScreenTech ticketScreenTech = new TicketScreenTech();
                            ticketScreenTech.Show();
                            Close();
                            break;
                        }

                        case "Utilisateur":
                        {
                            TicketScreenUser ticketScreenUser = new TicketScreenUser();
                            ticketScreenUser.Show();
                            Close();
                            break;
                        }
                        default:
                            MessageBox.Show("Login ou Mot de passe incorrect");
                            break;
                    }
                }
                sqlConnection.Close();
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
