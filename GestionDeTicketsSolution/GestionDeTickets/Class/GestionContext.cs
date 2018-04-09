using System.Data.Entity;

namespace GestionDeTickets.Class
{
    public class GestionContext : DbContext
    {
        public GestionContext()
            :base("Data Source=den1.mssql2.gear.host;Initial Catalog=gestiondetickets;Persist Security Info=True;User ID=gestiondetickets;Password=Ib7W6GLSl-~C")
        {} //Permet de créer les tables dans le mssql renseigné, initial catalog est la bdd concerné

        public DbSet<Personne> Personnes { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Commentaire> Commentaires { get; set; }

    }
}
