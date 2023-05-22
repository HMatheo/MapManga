namespace MangaMap.Views;
using Model;

public partial class ficheAnime : ContentPage
{
    public Oeuvre AnimeModel { get; set; }

    public ficheAnime()
    {
        InitializeComponent();

        // Exemple de création d'une instance de la classe Oeuvre
        List<string> genres = new List<string>() { "Action", "Aventure" };
        AnimeModel = new Oeuvre("Nom de l'oeuvre", genres, "Type de l'oeuvre", "Description de l'oeuvre", 5, 12, "Chemin/vers/l'affiche.png");

        this.BindingContext = this;
    }
}