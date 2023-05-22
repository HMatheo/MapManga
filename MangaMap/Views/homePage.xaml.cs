namespace MangaMap.Views;

using MangaMap.Model;


public partial class homePage : ContentPage
{
    public Manager my_manager => (App.Current as App).MyManager;

    public homePage()
	{

        InitializeComponent();
		BindingContext = my_manager;
	}

    private void AnimeImageClicked(object sender, EventArgs e)
    {
        var selectedAnime = (sender as ImageButton)?.BindingContext as Oeuvre;
        if (selectedAnime != null)
        {
            // Naviguez vers la page de la fiche d'anime en passant l'objet sélectionné
            Navigation.PushAsync(new ficheAnime(selectedAnime));
        }
    }
}

