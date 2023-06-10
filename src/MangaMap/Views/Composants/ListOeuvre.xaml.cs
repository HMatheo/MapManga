///// \brief Fichier pour la classe ListOeuvre
///// \author HERSAN Math�o, JOURDY Vianney
/// \file ListOeuvre.xaml.cs

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
        WatchInt.Text = my_manager.UtilisateurActuel.ListeOeuvreEnVisionnage.Count.ToString();
        CompInt.Text = my_manager.UtilisateurActuel.ListeOeuvreDejaVu.Count.ToString();
        PlanInt.Text = my_manager.UtilisateurActuel.ListeOeuvrePourPlusTard.Count.ToString();
        FavInt.Text = my_manager.UtilisateurActuel.ListeOeuvreFavorites.Count.ToString();
    }

    /// <summary>
    /// G�re l'�v�nement de clic sur l'image de l'anime dans la liste.
    /// </summary>
    /// <param name="sender">L'objet d�clencheur de l'�v�nement.</param>
    /// <param name="e">Les arguments de l'�v�nement.</param>
    private async void AnimeImageClickedList(object sender, EventArgs e)
    {
        var selectedAnime = (sender as ImageButton)?.BindingContext as Oeuvre;
        if (selectedAnime != null)
        {
            // Naviguez vers la page de la fiche d'anime en passant l'objet s�lectionn�
            await Navigation.PushAsync(new ficheAnime(selectedAnime));
        }
    }
}
