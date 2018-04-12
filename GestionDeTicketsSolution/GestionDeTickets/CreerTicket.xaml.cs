using System;
using System.Windows;
using GestionDeTickets.Class;

namespace GestionDeTickets
{
    /// <summary>
    /// Logique d'interaction pour CreerTicket.xaml
    /// </summary>
    public partial class CreerTicket
    {
        public CreerTicket()
        {
            InitializeComponent();
        }

        private  GestionContext _dbContext = new GestionContext();

        /// <summary>
        /// Créer un ticket au clic du bouton CreerUnTicket
        /// _dbContext.Tickets.Add() ajoute l'instance ticket dans la table Tickets
        /// On confirme l'ajout avec _dbContext.SaveChanges()
        /// Pareil pour commentaire dans la table Commentaires
        ///  var page = new PageAccueil(); et NavigationService.Navigate(page); change la page dans la Frame
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreerUnTicket_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Titre.Text != "" && Commentaire.Text !="")
                {
                    var ticket = new Ticket
                    {
                        Titre = Titre.Text,
                        Categorie = Categorie.Text,
                        DateCreation = DateTime.Now,
                        DateFin = null,
                        Etat = "En Cours",
                        PersonneId = int.Parse(IdUtilisateur.Text)
                    };
                    _dbContext.Tickets.Add(ticket);
                    _dbContext.SaveChanges();
                    int idTicket = ticket.Id;

                    var commentaire = new Commentaire
                    {
                        PersonneId = int.Parse(IdUtilisateur.Text),
                        TicketId = idTicket,
                        Commentaires = Commentaire.Text,
                        DatePublication = DateTime.Now
                    };

                    _dbContext.Commentaires.Add(commentaire);
                    _dbContext.SaveChanges();
                    MessageBox.Show("Ticket Créé");
                    var page = new PageAccueil();
                    NavigationService.Navigate(page);

                }
                else
                {
                    MessageBox.Show("Entrez un titre et un commentaire");
                    Titre.Focus();
                }
                
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
