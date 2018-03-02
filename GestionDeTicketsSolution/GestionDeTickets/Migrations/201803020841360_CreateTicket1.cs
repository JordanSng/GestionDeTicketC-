namespace GestionDeTickets.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateTicket1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "PersonneId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "PersonneId");
            AddForeignKey("dbo.Tickets", "PersonneId", "dbo.Personnes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "PersonneId", "dbo.Personnes");
            DropIndex("dbo.Tickets", new[] { "PersonneId" });
            AlterColumn("dbo.Tickets", "PersonneId", c => c.Int());
        }
    }
}
