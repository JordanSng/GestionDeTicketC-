namespace GestionDeTickets.Class
{
    /// <summary>
    /// Classe Technicien héritant de la classe Personne
    /// Intègre l'attribut Niveau
    /// </summary>
    public class Technicien : Personne
    {
        public int Niveau { get; set; }
    }
}
