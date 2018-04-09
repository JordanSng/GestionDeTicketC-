using System;
using System.Text.RegularExpressions;
using System.Windows;
using GestionDeTickets.Class;

namespace GestionDeTickets
{
    /// <summary>
    /// Logique d'interaction pour EnregistrerUtilisateur.xaml
    /// </summary>
    public partial class EnregistrerUtilisateur
    {
        public EnregistrerUtilisateur()
        {
            InitializeComponent();
        }

        private readonly GestionContext _dbContext = new GestionContext();

        private void SaveUtilisateur_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (TypeUtilisateur.Text)
                {
                    case "Utilisateur":
                    {
                        Personne personne = new Utilisateur();
                        if (Mdp.Password == ConfMdp.Password)
                        {
                            if (Email.Text.Length == 0)

                            {

                                MessageBox.Show("Entrez une adresse mail");

                                Email.Focus();

                            }

                            else if (!Regex.IsMatch(Email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))

                            {

                                MessageBox.Show("Entrez une adresse mail valide");

                                Email.Select(0, Email.Text.Length);

                                Email.Focus();

                            }
                            else
                            {
                                personne.Email = Email.Text;
                                personne.Login = Login.Text;
                                personne.Password = Mdp.Password;
                                    _dbContext.Personnes.Add(personne);
                                _dbContext.SaveChanges();
                                MessageBox.Show("Utilisateur Enregistré");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Mot de passe non identique");

                        }
                        break;
                    }

                    case "Technicien":
                    {
                        Personne personne = new Technicien();
                        if (Mdp.Password == ConfMdp.Password)
                        {
                            if (Email.Text.Length == 0)

                            {

                                MessageBox.Show("Entrez une adresse mail");

                                Email.Focus();

                            }

                            else if (!Regex.IsMatch(Email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))

                            {

                                MessageBox.Show("Entrez une adresse mail valide");

                                Email.Select(0, Email.Text.Length);

                                Email.Focus();

                            }
                            else
                            {
                                personne.Email = Email.Text;
                                personne.Login = Login.Text;
                                personne.Password = Mdp.Password;
                                _dbContext.Personnes.Add(personne);
                                _dbContext.SaveChanges();
                                MessageBox.Show("Utilisateur Enregistré");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Mot de passe non identique");

                        }
                        break;
                    }

                    default:
                        return;
                            
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
