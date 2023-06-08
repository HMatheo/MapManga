namespace MangaMap.Views;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Stub;
using Models;

/// <summary>
/// Classe repr�sentant la page de connexion administrateur de l'application.
/// </summary>
public partial class loginAdminPage : ContentPage
{
    /// <summary>
    /// R�f�rence au gestionnaire de l'application.
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
    /// Gestionnaire d'�v�nement lorsqu'un utilisateur clique sur le bouton "Utilisateur".
    /// </summary>
    /// <param name="sender">L'objet qui a d�clench� l'�v�nement.</param>
    /// <param name="e">Arguments de l'�v�nement.</param>
    async void userClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//page/secondaire/inscriptionPage");
    }

    /// <summary>
    /// Gestionnaire d'�v�nement lorsqu'un utilisateur clique sur le bouton "Connexion".
    /// </summary>
    /// <param name="sender">L'objet qui a d�clench� l'�v�nement.</param>
    /// <param name="e">Arguments de l'�v�nement.</param>
    async void OnLoginClicked(object sender, EventArgs e)
    {
        // R�cup�ration du pseudo et du mot de passe entr�s
        string pseudo = pseudoEntry.Text;
        string password = passwordEntry.Text;

        if (string.IsNullOrWhiteSpace(pseudo) ||
            string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Erreur", "Veuillez remplir tous les champs.", "OK");
            return;
        }

        // V�rifier que l'admin existe
        Admin admin = my_manager.Admins.FirstOrDefault(a => a.Pseudo == pseudo && a.MotDePasse == password);
        if (admin == null)
        {
            await DisplayAlert("Erreur", "Le mot de passe entr� est incorrect.", "OK");
            return;
        }

        // On garde la connexion admin
        my_manager.isAdmin = true;
        // Rediriger l'utilisateur vers la page principale
        await Shell.Current.GoToAsync("//page/homePage");
    }
}