using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using GestionDeTickets.Class;

namespace GestionDeTickets
{
    /// <summary>
    /// Logique d'interaction pour ConsulterTicket.xaml
    /// </summary>
    public partial class ConsulterTicket
    {
        GestionContext _dbContext = new GestionContext();

        public ConsulterTicket()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Au chargement de la page, mets dans une variable l'id de l'utilisateur connecté
        /// Execute une requete LINQ qui récupère la liste des tickets où PersonneId =  l'id de l'utilisateur connecté
        /// _dbContext.Tickets.Local contient les résultats de la requete LINQ. 
        /// On attribut ensuite les données dans le _dbContext.Tickets.Local dans le DataGrid.ItemsSource
        /// DataGrid.ItemsSource indique que les données de la DataGrid de la page contiennent les données qu'on lui a attribué
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsulterTicket_OnLoaded(object sender, RoutedEventArgs e)
        {
            var id = int.Parse(IdUtilisateur.Text);
            _dbContext.Tickets.Where(i => i.PersonneId == id).Load();

            DataGrid.ItemsSource = _dbContext.Tickets.Local;

        }

        /// <summary>
        /// Au clic du BtnEtat, une instance de Ticket, ici ticketRow est crée avec les données de la ligne du ticket selectionné
        /// L'instance ticket est crée et on lui attribut les données d'une requete LINQ
        /// _dbContext.SaveChanges(); enregistre les modifications dans la BDD
        /// DataGrid.Items.Refresh recharge les données de la page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEtat_OnClick(object sender, RoutedEventArgs e)
        {
            try

            {
                Ticket ticketRow = DataGrid.SelectedItem as Ticket;
                Ticket ticket = (from p in _dbContext.Tickets
                    where p.Id == ticketRow.Id
                    select p).Single();
                if (ticket.Etat == "Réouvert" || ticket.Etat == "En Cours" )
                {
                    return;
                }

                ticket.Etat = "Réouvert";
                _dbContext.SaveChanges();
                MessageBox.Show("Ticket Réouvert");
                DataGrid.Items.Refresh();

            }

            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Au clic du btnCom, pareil que la fonction du dessus
        /// Retourne en plus, la vueCommentaire en lui transmettant l'id de la personne et du ticket concerné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCom_OnClick(object sender, RoutedEventArgs e)
        {
            Ticket ticketRow = DataGrid.SelectedItem as Ticket;
            Ticket ticket = (from p in _dbContext.Tickets
                where p.Id == ticketRow.Id
                select p).Single();
            var vueCom = new VueCommentaire();
            vueCom.IdPersonne.Text = ticket.PersonneId.ToString();
            vueCom.IdTicket.Text = ticket.Id.ToString();
            vueCom.Show();
        }
    }
}
