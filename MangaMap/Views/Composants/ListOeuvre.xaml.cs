namespace MangaMap.Views.Composants;
using MangaMap.Model;

public partial class ListOeuvre : ContentView
{
    public Manager my_manager => (App.Current as App).MyManager;

    public ListOeuvre()
	{
		InitializeComponent();
        BindingContext = my_manager;
    }

    private async void AnimeImageClickedList(object sender, EventArgs e)
    {
        var selectedAnime = (sender as ImageButton)?.BindingContext as Oeuvre;
        if (selectedAnime != null)
        {
            // Naviguez vers la page de la fiche d'anime en passant l'objet sélectionné
            await Navigation.PushAsync(new ficheAnime(selectedAnime));
        }
    }
}