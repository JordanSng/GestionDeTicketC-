using System;

namespace GestionDeTickets.Class
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Categorie { get; set; }
        public string Titre { get; set; }
        public string Etat { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateFin { get; set; }

        //Ajoute la clé étrangère lors de l'ajout de migration
        public int PersonneId { get; set; } 
        public Personne Personne { get; set; }
    }

    
}
