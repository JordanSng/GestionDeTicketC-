using System;

namespace GestionDeTickets.Class
{
    /// <summary>
    /// Classe permettant la gestion des commentaires
    /// </summary>
    public class Commentaire
    {
        public int Id { get; set; }

        public int PersonneId { get; set; }

        public int TicketId { get; set; }

        public string Commentaires { get; set; }
        public DateTime DatePublication { get; set; }
    }
}
