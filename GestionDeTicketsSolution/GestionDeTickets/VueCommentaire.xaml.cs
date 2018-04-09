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

            /*var idPersonne = int.Parse(IdPersonne.Text);
            _dbContext.Commentaires.Join(_dbContext.Personnes,
                    c => c.PersonneId,
                    p => p.Id,
                    (c, p) => new { Commentaire = c, Personne = p }).Where
                    (commentaireEtPersonne => commentaireEtPersonne.Commentaire.TicketId == idPersonne)
                .Load();*/

            DataContext = _dbContext.Commentaires.Local;

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
