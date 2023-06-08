namespace MangaMap.Views;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Stub;
using Models;

/// <summary>
/// Classe représentant la page de connexion administrateur de l'application.
/// </summary>
public partial class loginAdminPage : ContentPage
{
    /// <summary>
    /// Référence au gestionnaire de l'application.
    /// </summary>
    public Manager my_manager => (App.Current as App).MyManager;

    /// <summary>
    /// Constructeur de la page de connexion administrateur.
    /// </summary>
    public loginAdminPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Gestionnaire d'événement lorsqu'un utilisateur clique sur le bouton "Utilisateur".
    /// </summary>
    /// <param name="sender">L'objet qui a déclenché l'événement.</param>
    /// <param name="e">Arguments de l'événement.</param>
    async void userClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//page/secondaire/inscriptionPage");
    }

    /// <summary>
    /// Gestionnaire d'événement lorsqu'un utilisateur clique sur le bouton "Connexion".
    /// </summary>
    /// <param name="sender">L'objet qui a déclenché l'événement.</param>
    /// <param name="e">Arguments de l'événement.</param>
    async void OnLoginClicked(object sender, EventArgs e)
    {
        // Récupération du pseudo et du mot de passe entrés
        string pseudo = pseudoEntry.Text;
        string password = passwordEntry.Text;

        if (string.IsNullOrWhiteSpace(pseudo) ||
            string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Erreur", "Veuillez remplir tous les champs.", "OK");
            return;
        }

        // Vérifier que l'admin existe
        Admin admin = my_manager.Admins.FirstOrDefault(a => a.Pseudo == pseudo && a.MotDePasse == password);
        if (admin == null)
        {
            await DisplayAlert("Erreur", "Le mot de passe entré est incorrect.", "OK");
            return;
        }

        // On garde la connexion admin
        my_manager.isAdmin = true;
        // Rediriger l'utilisateur vers la page principale
        await Shell.Current.GoToAsync("//page/homePage");
    }
}