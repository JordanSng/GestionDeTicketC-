namespace GestionDeTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTicket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Categorie = c.String(),
                        Commentaire = c.String(),
                        Etat = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tickets");
        }
    }
}
