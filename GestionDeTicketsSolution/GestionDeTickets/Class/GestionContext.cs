using System.Data.Entity;

namespace GestionDeTickets.Class
{
    public class GestionContext : DbContext
    {
        /// <summary>
        /// Permet de créer les tables dans le mssql renseigné, initial catalog est la bdd concerné
        /// </summary>
        public GestionContext()
            :base("Data Source=den1.mssql2.gear.host;Initial Catalog=gestiondetickets;Persist Security Info=True;User ID=gestiondetickets;Password=Ib7W6GLSl-~C")
        {} 

        /// <summary>
        /// Insère les elements des classes spécifiés dans la BDD en utilisant EF6 et la console du gestionnaire de package nuGet
        /// Pour les insérer en code-first utilisé dans la console, enable-migrations, puis add-migration et enfin update-database
        /// </summary>
        public DbSet<Personne> Personnes { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Commentaire> Commentaires { get; set; }

    }
}
