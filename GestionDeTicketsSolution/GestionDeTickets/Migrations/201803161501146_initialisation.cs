namespace GestionDeTickets.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Dans le dossier Migrations, il y a l'historique des scripts utilisés pour mettre à jour la BDD
    /// Hérite de DbMigration afin de migrer les classes et leurs attributs dans leurs tables respectives
    /// </summary>
    public partial class initialisation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personnes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Niveau = c.Int(),
                        Vip = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Categorie = c.String(),
                        Commentaire = c.String(),
                        Etat = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                        PersonneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personnes", t => t.PersonneId, cascadeDelete: true)
                .Index(t => t.PersonneId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "PersonneId", "dbo.Personnes");
            DropIndex("dbo.Tickets", new[] { "PersonneId" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Personnes");
        }
    }
}
