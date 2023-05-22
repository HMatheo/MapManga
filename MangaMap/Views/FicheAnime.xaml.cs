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

   
        InitializeComponent();

        this.BindingContext = this;
    }

    public ficheAnime(Oeuvre anime)
    {
        AnimeModel = anime;

        InitializeComponent();

        this.BindingContext = this;
    }

    private void SetNote(float note)
    {
        note = (int)note; // Tronquer à un entier car nous ne gérons actuellement pas les demi-étoiles
        var starImages = star.Children.OfType<Image>().Reverse().ToList();
        foreach (var img in starImages)
        {
            if (note > 0)
            {
                img.Opacity = 1;
                note--;
            }
            else
            {
                img.Opacity = 0;
            }
        }
    }

}