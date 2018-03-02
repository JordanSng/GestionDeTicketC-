using System.Data.Entity;

namespace GestionDeTickets.Class
{
    public class GestionContext : DbContext
    {
        public DbSet<Personne> Personnes { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

    }
}
