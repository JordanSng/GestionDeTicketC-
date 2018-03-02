using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace GestionDeTickets
{
    /// <summary>
    /// Logique d'interaction pour LoginScreen.xaml
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
                string query = "SELECT * FROM Personnes WHERE Login=@Username and Password=@Password";// Les @ protège d'une injection SQL
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
                sda.SelectCommand.Parameters.AddWithValue("@Username", Username.Text); //Attribue la valeur du champ Username.text à @Username dans la requête
                sda.SelectCommand.Parameters.AddWithValue("@Password", Password.Password); //Attribue la valeur du champ Password.Password à @Password dans la requête
                DataSet ds=new DataSet();
                sda.Fill(ds,"Personnes");
                if(ds.Tables[0].Rows.Count == 1) // La requete SQL "query" retourne l'unique ligne où le login et mdp correspondent
                {
                    String discriminator = ds.Tables[0].Rows[0]["Discriminator"].ToString();// Regarde dans le champ Discriminator de la table Personnes si la personne est un utilisateur ou un technicien
                    string username = ds.Tables[0].Rows[0]["Login"].ToString();// Pareil que pour Discriminator mais avec le champ Login
                    switch (discriminator)
                    {
                        case "Technicien":
                        {
                            TicketScreenTech ticketScreenTech = new TicketScreenTech();
                            ticketScreenTech.Bienvenue.Text += username;
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
                    }
                }
                else
                {
                    MessageBox.Show("Login ou Mot de passe incorrect");
                }
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        private void Border_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Minimize_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized; //Minimise la fenetre d'application
        }
    }
}
