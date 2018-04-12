using System.Windows;
using System.Windows.Input;

namespace GestionDeTickets
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class TicketScreenUser
    {
        public TicketScreenUser()
        {
            InitializeComponent();
            Main.Content = new PageAccueil();
        }

        private void Minimize_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized; // Minimise la fenetre
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); //ferme l'application
        }

        private void Border_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove(); //Permet de déplacer la fenetre
        }

        private void ConsulterTickets_OnClick(object sender, RoutedEventArgs e)
        {
            var consulterTicket = new ConsulterTicket();//Ouvre une nouvelle page, ici CreerTicket dans la frame concerné
            consulterTicket.IdUtilisateur.Text = IdUtilisateur.Text;
            Main.Content = consulterTicket;
        }

        private void CreerTicket_OnClick(object sender, RoutedEventArgs e)
        {
            var creerTicket = new CreerTicket();
            creerTicket.IdUtilisateur.Text = IdUtilisateur.Text;
            Main.Content = creerTicket;
        }

        private void Bienvenue_OnClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageAccueil();
        }
    }
}
