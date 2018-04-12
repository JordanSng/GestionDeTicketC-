using System;

namespace GestionDeTickets.Class
{
    /// <summary>
    /// Classe Ticket et ses attributs
    /// </summary>
    public class Ticket
    {
        public int Id { get; set; }
        public string Categorie { get; set; }
        public string Titre { get; set; }
        public string Etat { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateFin { get; set; }
       
        /// <summary>
        /// Ajoute la clé étrangère PersonneId lors de la création de la table via le DbSet
        /// Afin de lier la table Ticekts a la table Personne
        /// </summary>
        public int PersonneId { get; set; } 
        public Personne Personne { get; set; }
    }

    
}
