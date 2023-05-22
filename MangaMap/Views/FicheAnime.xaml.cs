namespace MangaMap.Views;
using Model;
using System.ComponentModel;

public partial class ficheAnime : ContentPage, INotifyPropertyChanged
{
    private Oeuvre animeModel;
    public Oeuvre AnimeModel
    {
        get { return animeModel; }
        set
        {
            if (animeModel != value)
            {
                animeModel = value;
                OnPropertyChanged(nameof(AnimeModel));
            }
        }
    }

    public ficheAnime()
    {
        List<string> genres = new List<string>() { "Action", "Aventure" };
        AnimeModel = new Oeuvre("Evangelion", genres, "Type de l'oeuvre", "Description de l'oeuvre", 5, 12, "Chemin/vers/l'affiche.png");

        InitializeComponent();

        this.BindingContext = this;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}