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
        }

        private void Minimize_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized; // Minimise la fenetre
        }

        private void Maximize_OnClick(object sender, RoutedEventArgs e)
        {
            //Agrandit ou rétabli la fenetre
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); //ferme l'application
        }

        private void Border_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove(); //Permet de déplacer la fenetre
        }

        private void Liste_OnSelected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
        }
    }
}
