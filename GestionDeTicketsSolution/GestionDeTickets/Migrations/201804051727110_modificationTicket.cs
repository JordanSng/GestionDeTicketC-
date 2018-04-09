namespace GestionDeTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationTicket : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "PersonneId", "dbo.Personnes");
            DropIndex("dbo.Tickets", new[] { "PersonneId" });
            RenameColumn(table: "dbo.Tickets", name: "PersonneId", newName: "Personne_Id");
            AddColumn("dbo.Tickets", "Titre", c => c.String());
            AlterColumn("dbo.Tickets", "Personne_Id", c => c.Int());
            CreateIndex("dbo.Tickets", "Personne_Id");
            AddForeignKey("dbo.Tickets", "Personne_Id", "dbo.Personnes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Personne_Id", "dbo.Personnes");
            DropIndex("dbo.Tickets", new[] { "Personne_Id" });
            AlterColumn("dbo.Tickets", "Personne_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Tickets", "Titre");
            RenameColumn(table: "dbo.Tickets", name: "Personne_Id", newName: "PersonneId");
            CreateIndex("dbo.Tickets", "PersonneId");
            AddForeignKey("dbo.Tickets", "PersonneId", "dbo.Personnes", "Id", cascadeDelete: true);
        }
    }
}
