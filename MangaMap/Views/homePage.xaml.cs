namespace MangaMap.Views;

using MangaMap.Model;
using System.Collections.ObjectModel;

public partial class homePage : ContentPage
{
    public Manager my_manager => (App.Current as App).MyManager;

    public homePage()
    {
        InitializeComponent();
        BindingContext = my_manager;
        searchResults.ItemsSource = my_manager.Oeuvres;
        //chargerSerie();
    }

    private async void AnimeImageClicked(object sender, EventArgs e)
    {
        var selectedAnime = (sender as ImageButton)?.BindingContext as Oeuvre;
        if (selectedAnime != null)
        {
            // Naviguez vers la page de la fiche d'anime en passant l'objet sélectionné
            await Navigation.PushAsync(new ficheAnime(selectedAnime));
        }

        /*var button = (ImageButton)sender;
        var idAutomation = button.AutomationId;

        if (int.TryParse(idAutomation, out int id))
        {
            await Navigation.PushAsync(new ficheAnime(my_manager.Oeuvres[id]));
        }*/
    }

    /*private void chargerSerie()
    {
        int imagesParLigne = 4;
        int indice = 0;

        for (int i = 0; i < my_manager.Oeuvres.Count; i++)
        {
            Oeuvre favoris = my_manager.Oeuvres[i];

            ImageButton imageButton = new ImageButton
            {
                Source = favoris.Affiche,
                WidthRequest = 170,
                MaximumHeightRequest = 190,
                MinimumHeightRequest = 190,
                HeightRequest = 190,
                CornerRadius = 15,
                Aspect = Aspect.Fill,
                AutomationId = indice.ToString(),
                Margin = 90
            };

            imageButton.Clicked += AnimeImageClicked;

            int ligne = 1 + (indice / imagesParLigne);
            int colonne = indice % imagesParLigne;

            Grid.SetRow(imageButton, ligne);
            Grid.SetColumn(imageButton, colonne);
            grille.Children.Add(imageButton);

            indice++;
        }
    }*/

    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {

        if(string.IsNullOrWhiteSpace(e.NewTextValue))
        {
            searchResults.ItemsSource = my_manager.Oeuvres;
        }
        else
        {
            searchResults.ItemsSource = my_manager.Oeuvres.Where(i => i.Nom.ToLower().Contains(e.NewTextValue.ToLower()));
        }
    }

}
