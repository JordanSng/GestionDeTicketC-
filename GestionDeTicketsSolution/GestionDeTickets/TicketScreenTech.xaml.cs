using System.Windows;
using System.Windows.Input;

namespace GestionDeTickets
{
    /// <summary>
    /// Logique d'interaction pour TicketScreenTech.xaml
    /// </summary>
    public partial class TicketScreenTech : Window
    {
        public TicketScreenTech()
        {
            InitializeComponent();
        }

        private void Minimize_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Maximize_OnClick(object sender, RoutedEventArgs e)
        {
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
            Application.Current.Shutdown();
        }

        private void Border_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
