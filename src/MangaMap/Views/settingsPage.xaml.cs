///// \brief Fichier pour la classe settingsPage
///// \author HERSAN Math�o, JOURDY Vianney
/// \file settingsPage.xaml.cs

namespace MangaMap.Views;
using Models;

/// <summary>
/// Classe repr�sentant la page des param�tres de l'application.
/// </summary>
public partial class settingsPage : ContentPage
{
    /// <summary>
    /// R�f�rence au gestionnaire de l'application.
    /// </summary>
    public Manager my_manager => (App.Current as App).MyManager;

    /// <summary>
    /// Constructeur de la page des param�tres.
    /// </summary>
    public settingsPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Gestionnaire d'�v�nement lorsqu'un utilisateur clique sur le bouton "D�connexion".
    /// </summary>
    /// <param name="sender">L'objet qui a d�clench� l'�v�nement.</param>
    /// <param name="e">Arguments de l'�v�nement.</param>
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
    /// Gestionnaire d'�v�nement lorsqu'un utilisateur clique sur le bouton "Connexion Administrateur".
    /// </summary>
    /// <param name="sender">L'objet qui a d�clench� l'�v�nement.</param>
    /// <param name="e">Arguments de l'�v�nement.</param>
    private async void LoginAdminClicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new loginAdminPage());
    }

    /// <summary>
    /// Gestionnaire d'�v�nement lorsqu'un utilisateur clique sur le bouton "Ajouter".
    /// </summary>
    /// <param name="sender">L'objet qui a d�clench� l'�v�nement.</param>
    /// <param name="e">Arguments de l'�v�nement.</param>
    private async void AddClicked(object sender, EventArgs e)
    {
        if (!my_manager.isAdmin)
        {
            await DisplayAlert("Erreur", "Vous n'�tes pas connect� en tant qu'Administrateur.", "OK");
            return;
        }
        await Shell.Current.Navigation.PushAsync(new createOeuvre());
    }
}