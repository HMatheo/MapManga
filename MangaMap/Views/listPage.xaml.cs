namespace MangaMap.Views;
using MangaMap.Model;
using static System.Net.Mime.MediaTypeNames;

public partial class listPage : ContentPage
{
    public Manager my_manager => (App.Current as App).MyManager;

    public listPage()
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

    private async void OnAddClicked(object sender, EventArgs e)
    {
        
    }
}