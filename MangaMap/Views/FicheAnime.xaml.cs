namespace MangaMap.Views;

using Model;
using System.ComponentModel;
using System.Diagnostics;


public partial class ficheAnime : ContentPage, INotifyPropertyChanged
{
    public Manager my_manager => (App.Current as App).MyManager;
    public Oeuvre AnimeModel { get; set; }

    public ficheAnime()
    {
        InitializeComponent();

        BindingContext = this;

    }

    public ficheAnime(Oeuvre anime)
    {
        AnimeModel = anime;

        InitializeComponent();

        BindingContext = this;

        SetNote();        
    }

    public async void AjouterListe(object sender, EventArgs e)
    {
        if (my_manager.UtilisateurActuel.Email == null)
        {
            await DisplayAlert("Erreur", "Vous n'êtes pas connecté.", "OK");
            return;
        }

        string selectedOption = await DisplayActionSheet("Ajouter à quelle liste ?", "Annuler", null, "En Visionnage", "Déjà Vu", "Pour Plus Tard", "Favoris");

        if (selectedOption == "Annuler" || selectedOption == null)
            return;

        Debug.WriteLine("Selected Option: " + selectedOption);

        // Ajouter l'anime à la liste sélectionnée
        switch (selectedOption)
        {
            case "En Visionnage":
                Debug.WriteLine("Ajout à la liste En Visionnage");
                my_manager.UtilisateurActuel.ListeOeuvreEnVisionnage.Add(AnimeModel);
                break;
            case "Déjà Vu":
                Debug.WriteLine("Ajout à la liste Déjà Vu");
                my_manager.UtilisateurActuel.ListeOeuvreDejaVu.Add(AnimeModel);
                break;
            case "Pour Plus Tard":
                Debug.WriteLine("Ajout à la liste Pour Plus Tard");
                my_manager.UtilisateurActuel.ListeOeuvrePourPlusTard.Add(AnimeModel);
                break;
            case "Favoris":
                Debug.WriteLine("Ajout à la liste Favoris");
                my_manager.UtilisateurActuel.ListeOeuvreFavorites.Add(AnimeModel);
                break;
        }

        ////foreach (oeuvre oeuvre in my_manager.utilisateuractuel.listeoeuvreenvisionnage)
        ////{
        ////    debug.writeline("titre de l'oeuvre : " + oeuvre.nom);
        ////    // faites d'autres opérations avec chaque élément de la liste
        ////}

        my_manager.sauvegarder();

        await Navigation.PushAsync(new listPage());
    }


    private void SetNote()
    {
        stars.Children.Clear();
        bool test = my_manager.UtilisateurActuel.notesOeuvres.ContainsKey(AnimeModel.Nom);
        int x;

       for (int i = 0; i < 5; i++)
        {
            if (my_manager.UtilisateurActuel.notesOeuvres.TryGetValue(AnimeModel.Nom,out x) && i<x)
            {
                ImageButton imageButton = new ImageButton
                {
                    Source = "star_full.png",
                    WidthRequest = 50,
                    HeightRequest = 50,
                    AutomationId = i.ToString(),
                    Margin = 10,
                };

                imageButton.Clicked += StarClicked;

                Grid.SetRow(imageButton, 0);
                Grid.SetColumn(imageButton, i);
                stars.Children.Add(imageButton);
            }
            else if (!test && i < AnimeModel.Note)
            {
                ImageButton imageButton = new ImageButton
                {
                    Source = "star_full.png",
                    WidthRequest = 50,
                    HeightRequest = 50,
                    AutomationId = i.ToString(),
                    Margin = 10,
                };

                imageButton.Clicked += StarClicked;

                Grid.SetRow(imageButton, 0);
                Grid.SetColumn(imageButton, i);
                stars.Children.Add(imageButton);
            }
            else
            {
                ImageButton imageButton = new ImageButton
                {
                    Source = "star_empty.png",
                    WidthRequest = 50,
                    HeightRequest = 50,
                    AutomationId = i.ToString(),
                    Margin = 10,
                };

                imageButton.Clicked += StarClicked;

                Grid.SetRow(imageButton, 0);
                Grid.SetColumn(imageButton, i);
                stars.Children.Add(imageButton);
            }
        }
    }

    private async void StarClicked(object sender, EventArgs e)
    {
        if (my_manager.UtilisateurActuel.Email == null)
        {
            await DisplayAlert("Erreur", "Vous n'êtes pas connecté.", "OK");
            return;
        }

        var button = (ImageButton)sender;
        var idAutomation = button.AutomationId;

        if (int.TryParse(idAutomation, out int id))
        {
            if (my_manager.UtilisateurActuel.notesOeuvres.ContainsKey(AnimeModel.Nom))
                my_manager.UtilisateurActuel.notesOeuvres.Remove(AnimeModel.Nom);

            my_manager.UtilisateurActuel.notesOeuvres.Add(AnimeModel.Nom, id+1);
            my_manager.sauvegarder();
            SetNote();
        }
    }

    private async void NbEpCheck(object sender, EventArgs e)
    {
        if (my_manager.UtilisateurActuel.Email == null)
        {
            await DisplayAlert("Erreur", "Vous n'êtes pas connecté.", "OK");
            return;
        }

        int nb = Convert.ToInt32(nombreEP.Text);

        if (my_manager.UtilisateurActuel.episodesVus.ContainsKey(AnimeModel.Nom))
            my_manager.UtilisateurActuel.episodesVus.Remove(AnimeModel.Nom);
        
        my_manager.UtilisateurActuel.episodesVus.Add(AnimeModel.Nom, nb);
    }
}