namespace GestionDeTickets.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ModifTicket2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tickets", "Commentaire");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "Commentaire", c => c.String());
        }
    }
}
