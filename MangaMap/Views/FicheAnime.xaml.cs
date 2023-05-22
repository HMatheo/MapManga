namespace MangaMap.Views;
using Model;
using System.ComponentModel;
using System.Xml.Linq;

public partial class ficheAnime : ContentPage, INotifyPropertyChanged
{

    public Manager DataManager { get; set; }
    public Oeuvre AnimeModel { get; set; }

    public ficheAnime()
    {

        List<string> genres = new List<string>() { "Action", "Aventure" };
        AnimeModel = new Oeuvre("Evangelion", genres, "Type de l'oeuvre", "Description de l'oeuvre", 5, 12, "Chemin/vers/l'affiche.png");

        InitializeComponent();

        this.BindingContext = this;
    }

    public ficheAnime(Oeuvre anime)
    {
        AnimeModel = anime;

        InitializeComponent();

        this.BindingContext = this;
    }

}