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
                SqlDataAdapter sda = new SqlDataAdapter(
                    "SELECT Discriminator FROM Personnes WHERE Login='"+ Username.Text +"' and Password='"+ Password.Password + "' ", sqlConnection);
                DataSet ds=new DataSet();
                sda.Fill(ds,"Login");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    String discriminator = ds.Tables[0].Rows[0]["Discriminator"].ToString();// Regarde si la personne est un utilisateur ou un technicien
                    if(discriminator=="Technicien")
                    {
                        TicketScreenTech ticketScreenTech = new TicketScreenTech();
                        ticketScreenTech.Show();
                        Close();
                    }
                    else
                    {
                        TicketScreenUser ticketScreenUser = new TicketScreenUser();
                        ticketScreenUser.Show();
                        Close();
 
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
