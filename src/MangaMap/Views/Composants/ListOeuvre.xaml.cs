namespace MangaMap.Views.Composants;
using Models;
using System.Diagnostics;
using System.Xml;

public partial class ListOeuvre : ContentView
{
    public Manager my_manager => (App.Current as App).MyManager;

    /// <summary>
    /// Constructeur de la liste d'oeuvres.
    /// </summary>
    public ListOeuvre()
    {
        InitializeComponent();
        BindingContext = this;
    }

    /// <summary>
    /// Gère l'événement de clic sur l'image de l'anime dans la liste.
    /// </summary>
    /// <param name="sender">L'objet déclencheur de l'événement.</param>
    /// <param name="e">Les arguments de l'événement.</param>
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
