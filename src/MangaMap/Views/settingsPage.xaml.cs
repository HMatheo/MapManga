///// \brief Fichier pour la classe settingsPage
///// \author HERSAN Mathéo, JOURDY Vianney
/// \file settingsPage.xaml.cs

namespace MangaMap.Views;
using Models;

/// <summary>
/// Classe représentant la page des paramètres de l'application.
/// </summary>
public partial class settingsPage : ContentPage
{
    /// <summary>
    /// Référence au gestionnaire de l'application.
    /// </summary>
    public Manager my_manager => (App.Current as App).MyManager;

    /// <summary>
    /// Constructeur de la page des paramètres.
    /// </summary>
    public settingsPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Gestionnaire d'événement lorsqu'un utilisateur clique sur le bouton "Déconnexion".
    /// </summary>
    /// <param name="sender">L'objet qui a déclenché l'événement.</param>
    /// <param name="e">Arguments de l'événement.</param>
    private async void OnDisconnectClicked(object sender, EventArgs e)
    {
        my_manager.UtilisateurActuel = new Utilisateur();
        my_manager.isAdmin = false;

        foreach (Oeuvre o in my_manager.Oeuvres)
        {
            o.NombresEpVu = 999;
        }

        await Shell.Current.GoToAsync("//page/secondaire/connexionPage");
    }

    /// <summary>
    /// Gestionnaire d'événement lorsqu'un utilisateur clique sur le bouton "Connexion Administrateur".
    /// </summary>
    /// <param name="sender">L'objet qui a déclenché l'événement.</param>
    /// <param name="e">Arguments de l'événement.</param>
    private async void LoginAdminClicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new loginAdminPage());
    }

    /// <summary>
    /// Gestionnaire d'événement lorsqu'un utilisateur clique sur le bouton "Ajouter".
    /// </summary>
    /// <param name="sender">L'objet qui a déclenché l'événement.</param>
    /// <param name="e">Arguments de l'événement.</param>
    private async void AddClicked(object sender, EventArgs e)
    {
        if (!my_manager.isAdmin)
        {
            await DisplayAlert("Erreur", "Vous n'êtes pas connecté en tant qu'Administrateur.", "OK");
            return;
        }
        await Shell.Current.Navigation.PushAsync(new createOeuvre());
    }
}