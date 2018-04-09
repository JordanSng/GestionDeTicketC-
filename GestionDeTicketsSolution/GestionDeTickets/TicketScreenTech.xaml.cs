using System.Windows;
using System.Windows.Input;

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
    }
}
