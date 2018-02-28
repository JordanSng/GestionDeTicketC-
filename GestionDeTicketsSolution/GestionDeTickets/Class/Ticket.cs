using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeTickets.Class
{
    public class Ticket
    {
        public int ID { get; set; }
        public string Categorie { get; set; }
        public string Commentaire { get; set; }
        public string Etat { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateFin { get; set; }
    }
}
