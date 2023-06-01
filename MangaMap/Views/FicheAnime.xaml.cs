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
        if (my_manager.UtilisateurActuel.Email == null)
        {
            await DisplayAlert("Erreur", "Vous n'�tes pas connect�.", "OK");
            return;
        }

        string selectedOption = await DisplayActionSheet("Ajouter � quelle liste ?", "Annuler", null, "En Visionnage", "D�j� Vu", "Pour Plus Tard", "Favoris");

        if (selectedOption == "Annuler")
            return;

        Debug.WriteLine("Selected Option: " + selectedOption);

        // Ajouter l'anime � la liste s�lectionn�e
        switch (selectedOption)
        {
            case "En Visionnage":
                Debug.WriteLine("Ajout � la liste En Visionnage");
                my_manager.UtilisateurActuel.ListeOeuvreEnVisionnage.Add(AnimeModel);
                break;
            case "D�j� Vu":
                Debug.WriteLine("Ajout � la liste D�j� Vu");
                my_manager.UtilisateurActuel.ListeOeuvreDejaVu.Add(AnimeModel);
                break;
            case "Pour Plus Tard":
                Debug.WriteLine("Ajout � la liste Pour Plus Tard");
                my_manager.UtilisateurActuel.ListeOeuvrePourPlusTard.Add(AnimeModel);
                break;
            case "Favoris":
                Debug.WriteLine("Ajout � la liste Favoris");
                my_manager.UtilisateurActuel.ListeOeuvreFavorites.Add(AnimeModel);
                break;
        }

        ////foreach (oeuvre oeuvre in my_manager.utilisateuractuel.listeoeuvreenvisionnage)
        ////{
        ////    debug.writeline("titre de l'oeuvre : " + oeuvre.nom);
        ////    // faites d'autres op�rations avec chaque �l�ment de la liste
        ////}

        my_manager.sauvegarder();

        await Navigation.PushAsync(new listPage());
        //await Shell.Current.GoToAsync("//page/secondaire/listPage");
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