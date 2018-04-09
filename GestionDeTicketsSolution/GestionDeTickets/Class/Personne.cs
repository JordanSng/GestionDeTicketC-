using System.Collections.Generic;
using System.Data.Entity;

namespace GestionDeTickets.Class
{
    public abstract class Personne
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }

}
