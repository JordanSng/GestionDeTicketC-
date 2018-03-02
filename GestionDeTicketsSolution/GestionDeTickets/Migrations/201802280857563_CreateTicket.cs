namespace GestionDeTickets.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateTicket : DbMigration
    {
        public override void Up()
        {
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
                        PersonneId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tickets");
        }
    }
}
