namespace MangaMap.Views;
using Model;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;

public partial class ficheAnime : ContentPage, INotifyPropertyChanged
{

    public Manager my_manager => (App.Current as App).MyManager;
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

    public async void AjouterListe(object sender, EventArgs e)
    {
        if (my_manager.UtilisateurActuel == null)
        {
            await DisplayAlert("Erreur", "Vous n'�tes pas connect�.", "OK");
            return;
        }

        if (my_manager.UtilisateurActuel.ListeOeuvreEnVisionnage == null)
        {
            // Initialisez la liste si elle est nulle
            //my_manager.UtilisateurActuel.ListeOeuvreEnVisionnage = new List<Oeuvre>();
        }
        Debug.WriteLine("Iciii");

        my_manager.UtilisateurActuel.ListeOeuvreEnVisionnage.Add(AnimeModel);
        Debug.WriteLine("Okkkkkkkkkkkk");
        // Naviguez vers la page de la fiche d'anime en passant l'objet s�lectionn�
        await Navigation.PushAsync(new listPage());
    }

    private void SetNote(float note)
    {
        note = (int)note; // Tronquer � un entier car nous ne g�rons actuellement pas les demi-�toiles
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