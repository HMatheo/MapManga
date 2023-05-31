namespace MangaMap.Views;

using MangaMap.Model;


public partial class homePage : ContentPage
{
    public Manager my_manager => (App.Current as App).MyManager;

    public homePage()
	{
        InitializeComponent();
		BindingContext = my_manager;
        chargerSerie();
	}

    private async void AnimeImageClicked(object sender, EventArgs e)
    {
        //var selectedAnime = (sender as ImageButton)?.BindingContext as Oeuvre;
        //if (selectedAnime != null)
        //{
        //    // Naviguez vers la page de la fiche d'anime en passant l'objet sélectionné
        //    await Navigation.PushAsync(new ficheAnime(selectedAnime));
        //}

        var button = (ImageButton)sender;
        var idAutomation = button.AutomationId;

        if (int.TryParse(idAutomation, out int id))
        {
            await Navigation.PushAsync(new ficheAnime(my_manager.Oeuvres[id]));
        }
    }

    private void chargerSerie()
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
                HeightRequest = 190,
                CornerRadius = 15,
                Aspect = Aspect.Fill,
                AutomationId = indice.ToString(),
            };

            imageButton.Clicked += AnimeImageClicked;

            int ligne = 1 + (indice / imagesParLigne);
            int colonne = indice % imagesParLigne;

            Grid.SetRow(imageButton, ligne);
            Grid.SetColumn(imageButton, colonne);
            grille.Children.Add(imageButton);

            indice++;
        }
    }

}

