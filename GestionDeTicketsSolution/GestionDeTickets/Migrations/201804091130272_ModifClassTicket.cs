namespace GestionDeTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifClassTicket : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "DateFin", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "DateFin", c => c.DateTime(nullable: false));
        }
    }
}
