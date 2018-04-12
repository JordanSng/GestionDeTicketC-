using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using GestionDeTickets.Class;

namespace GestionDeTickets
{
    /// <summary>
    /// Logique d'interaction pour Commentaire.xaml
    /// </summary>
    public partial class VueCommentaire
    {
        public VueCommentaire()
        {
            InitializeComponent();
        }

        GestionContext _dbContext = new GestionContext();

        /// <summary>
        /// Requete LINQ effectué au chargement, récupère les données de la requete
        /// Et les attribue aux ItemsSource du DataContext de la fenetre concerné
        /// Fonction à améliorer, le commentaire ne mentionne pas la personne qui l'a crée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VueCommentaire_OnLoaded(object sender, RoutedEventArgs e)
        {
            var idTicket = int.Parse(IdTicket.Text);
            _dbContext.Commentaires.Join(_dbContext.Tickets,
                    c => c.TicketId,
                    t => t.Id,
                    (c, t) => new {Commentaire = c, Ticket = t})
                    .Join(_dbContext.Personnes,
                    co => co.Commentaire.PersonneId,
                    pe => pe.Id,
                    (co, pe) => new {Commentaires = co, Personnes = pe}).Where
                    (commentaireEtTicketEtPersonne => commentaireEtTicketEtPersonne.Commentaires.Ticket.Id == idTicket)
                    .Load();

            DataGrid.ItemsSource = _dbContext.Commentaires.Local;
        }

        private void Envoyer_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Com.Text != "")
                {
                    var commentaire = new Commentaire
                    {
                        PersonneId = int.Parse(IdPersonne.Text),
                        TicketId = int.Parse(IdTicket.Text),
                        Commentaires = Com.Text,
                        DatePublication = DateTime.Now
                    };
                    _dbContext.Commentaires.Add(commentaire);
                    _dbContext.SaveChanges();
                    MessageBox.Show("Commentaire ajouté");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
