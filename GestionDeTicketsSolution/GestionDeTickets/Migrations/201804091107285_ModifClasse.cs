namespace GestionDeTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifClasse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "Personne_Id", "dbo.Personnes");
            DropIndex("dbo.Tickets", new[] { "Personne_Id" });
            RenameColumn(table: "dbo.Tickets", name: "Personne_Id", newName: "PersonneId");
            AlterColumn("dbo.Tickets", "PersonneId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "PersonneId");
            AddForeignKey("dbo.Tickets", "PersonneId", "dbo.Personnes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "PersonneId", "dbo.Personnes");
            DropIndex("dbo.Tickets", new[] { "PersonneId" });
            AlterColumn("dbo.Tickets", "PersonneId", c => c.Int());
            RenameColumn(table: "dbo.Tickets", name: "PersonneId", newName: "Personne_Id");
            CreateIndex("dbo.Tickets", "Personne_Id");
            AddForeignKey("dbo.Tickets", "Personne_Id", "dbo.Personnes", "Id");
        }
    }
}
