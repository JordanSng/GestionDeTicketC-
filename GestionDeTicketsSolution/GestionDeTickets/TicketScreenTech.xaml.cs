using System.Linq;
using System.Windows;
using System.Windows.Input;
using GestionDeTickets.Class;

namespace GestionDeTickets
{
    /// <summary>
    /// Logique d'interaction pour TicketScreenTech.xaml
    /// </summary>
    public partial class TicketScreenTech
    {
        public TicketScreenTech()
        {
            InitializeComponent();
            Main.Content = new PageAccueil();
        }

        GestionContext _dbContext = new GestionContext();

        private void Minimize_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Border_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void EnregistrerUtilisateur_OnClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new EnregistrerUtilisateur();
        }

        private void ListeTickets_OnClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new ListeDesTickets();
        }

        private void Bienvenue_OnClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageAccueil();
        }


        /// <summary>
        /// Fonction à completer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ouvert_OnLoaded(object sender, RoutedEventArgs e)
        {
            var ticketCount = _dbContext.Tickets.Count(t => t.Etat == "En Cours" || t.Etat == "Réouvert");

            Ouvert.Content = ticketCount.ToString();
        }

        /// <summary>
        /// Fonction à completer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cloturer_OnLoaded(object sender, RoutedEventArgs e)
        {
            var ticketCount = _dbContext.Tickets.Count(t => t.Etat == "Cloturé");

            DataContext = _dbContext.Tickets.Local;

            Cloturer.Content = ticketCount.ToString();
        }
    }
}
