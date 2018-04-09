using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using GestionDeTickets.Class;

namespace GestionDeTickets
{
    /// <summary>
    /// Logique d'interaction pour ListeDesTickets.xaml
    /// </summary>
    public partial class ListeDesTickets
    {
        GestionContext _dbContext = new GestionContext();

        public ListeDesTickets()
        {
            InitializeComponent();
        }

        private void ListeDesTickets_OnLoaded(object sender, RoutedEventArgs e)
        {
            _dbContext.Personnes.Join(_dbContext.Tickets,
                    p => p.Id,
                    t => t.PersonneId,
                    (p, t) => new {Personne = p, Ticket = t}).Where
                    (personneEtTicket => personneEtTicket.Ticket.PersonneId == personneEtTicket.Personne.Id)
                .Load();

            DataContext = _dbContext.Tickets.Local;

            DataGrid.ItemsSource = _dbContext.Tickets.Local;
        }

        private void BtnEtat_OnClick(object sender, RoutedEventArgs e)
        {
            try

            {
                Ticket ticketRow = DataGrid.SelectedItem as Ticket;
                Ticket ticket = (from p in _dbContext.Tickets
                    where p.Id == ticketRow.Id
                    select p).Single();
                if (ticket.Etat == "Cloturé")
                {
                    return;
                }
                
                ticket.Etat = "Cloturé";
                ticket.DateFin = DateTime.Now;
                _dbContext.SaveChanges();
                MessageBox.Show("Ticket Cloturé");
                DataGrid.Items.Refresh();

            }

            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }
        }

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
