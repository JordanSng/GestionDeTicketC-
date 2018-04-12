using System.Data.Entity;

namespace GestionDeTickets.Class
{
    public class GestionContext : DbContext
    {
        /// <summary>
        /// Permet d'établir la connexion a la BDD, Data Source est le serveur concerné et initial catalog est la bdd concerné
        /// </summary>
        public GestionContext()
            :base("Data Source=den1.mssql2.gear.host;Initial Catalog=gestiondetickets;Persist Security Info=True;User ID=gestiondetickets;Password=Ib7W6GLSl-~C")
        {} 

        /// <summary>
        /// Insère les elements des classes spécifiés par les DbSet ci dessous dans la BDD en utilisant le package nuGet Entity Framework 6 et la console du gestionnaire de package nuGet
        /// Pour les insérer en code-first utilisé dans la console de gestionnaire de package, enable-migrations, puis add-migration (un nom vous sera demandé pour la migration) et enfin update-database
        /// </summary>
        public DbSet<Personne> Personnes { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Commentaire> Commentaires { get; set; }

    }
}
