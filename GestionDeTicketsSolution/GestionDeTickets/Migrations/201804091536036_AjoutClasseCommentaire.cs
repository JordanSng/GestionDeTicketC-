namespace GestionDeTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutClasseCommentaire : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commentaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonneId = c.Int(nullable: false),
                        TicketId = c.Int(nullable: false),
                        Commentaires = c.String(),
                        DatePublication = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Commentaires");
        }
    }
}
