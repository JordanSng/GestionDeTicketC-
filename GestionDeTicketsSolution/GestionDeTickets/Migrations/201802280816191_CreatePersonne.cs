namespace GestionDeTickets.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreatePersonne : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Personnes");
        }
    }
}
