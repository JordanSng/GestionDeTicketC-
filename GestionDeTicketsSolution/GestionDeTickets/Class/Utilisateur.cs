namespace GestionDeTickets.Class
{
    /// <summary>
    /// Classe Utilisateur héritant de Personne
    /// Intègre l'attribut Vip
    /// </summary>
    public class Utilisateur : Personne
    {
        public bool Vip { get; set; }

    }
}
