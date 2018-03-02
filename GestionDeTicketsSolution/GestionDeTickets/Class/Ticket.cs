using System;

namespace GestionDeTickets.Class
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Categorie { get; set; }
        public string Commentaire { get; set; }
        public string Etat { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateFin { get; set; }
        public int PersonneId { get; set; }

        public virtual Personne Personne { get; set; } //Ajoute la clé étrangère lors de l'ajout de migration
    }
}
