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

        /// <summary>
        /// Initialise la connexion à la BDD (Possibilité d'améliorer la connexion en masquant le mot de passe)
        /// Execute une requete SQL récupérant la personne ayant pour login et le mot de passe entrés dans les textbox et passwordbox
        /// Montre la vue technicien ou utilisateur en fonction du Discriminator de la personne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_OnClick(object sender, RoutedEventArgs e)
        {

            var sqlConnection = new SqlConnection(
                @"Data Source=den1.mssql2.gear.host;Initial Catalog=gestiondetickets;Persist Security Info=True;User ID=gestiondetickets;Password=Ib7W6GLSl-~C");
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                var query = "SELECT * FROM Personnes WHERE Login=@Username and Password=@Password";// Les @ protège d'une injection SQL
                var sda = new SqlDataAdapter(query, sqlConnection);
                sda.SelectCommand.Parameters.AddWithValue("@Username", Username.Text); //Attribue la valeur du champ Username.text à @Username dans la requête
                sda.SelectCommand.Parameters.AddWithValue("@Password", Password.Password); //Attribue la valeur du champ Password.Password à @Password dans la requête
                var ds=new DataSet();
                sda.Fill(ds,"Personnes");
                if(ds.Tables[0].Rows.Count == 1) // La requete SQL "query" retourne l'unique ligne où le login et mdp correspondent
                {
                    var discriminator = ds.Tables[0].Rows[0]["Discriminator"].ToString();// Regarde dans le champ Discriminator de la table Personnes si la personne est un utilisateur ou un technicien
                    var utilisteurId = ds.Tables[0].Rows[0]["Id"].ToString();// Récupère l'id
                    var username = ds.Tables[0].Rows[0]["Login"].ToString();// Pareil que pour Discriminator mais avec le champ Login
                    switch (discriminator)
                    {
                        case "Technicien":
                        {
                            var ticketScreenTech = new TicketScreenTech();
                            ticketScreenTech.Bienvenue.Content += username;
                            
                            ticketScreenTech.Show();
                            Close();
                            break;
                        }

                        case "Utilisateur":
                        {
                            var ticketScreenUser = new TicketScreenUser();
                            ticketScreenUser.Bienvenue.Content += username;
                            ticketScreenUser.IdUtilisateur.Text = utilisteurId;
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
            WindowState = WindowState.Minimized; //Minimise la fenetre d'application
        }
    }
}
