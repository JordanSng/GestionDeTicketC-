namespace GestionDeTickets.Class
{
    /// <summary>
    /// Classe abstraite de personne
    /// </summary>
    public abstract class Personne
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

}
