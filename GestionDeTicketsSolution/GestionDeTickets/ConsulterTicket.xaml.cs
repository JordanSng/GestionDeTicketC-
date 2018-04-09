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

        private void ConsulterTicket_OnLoaded(object sender, RoutedEventArgs e)
        {
            var id = int.Parse(IdUtilisateur.Text);
            _dbContext.Tickets.Where(i => i.PersonneId == id).Load();

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
