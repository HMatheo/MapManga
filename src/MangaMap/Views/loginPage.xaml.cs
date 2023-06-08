namespace MangaMap.Views;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Stub;
using Models;

/// <summary>
/// Classe repr�sentant la page de connexion de l'application.
/// </summary>
public partial class loginPage : ContentPage
{
    /// <summary>
    /// R�f�rence au gestionnaire de l'application.
    /// </summary>
    public Manager my_manager => (App.Current as App).MyManager;

    /// <summary>
    /// Constructeur de la page de connexion.
    /// </summary>
    public loginPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Gestionnaire d'�v�nement lorsqu'un utilisateur clique sur le bouton "Inscription".
    /// </summary>
    /// <param name="sender">L'objet qui a d�clench� l'�v�nement.</param>
    /// <param name="e">Arguments de l'�v�nement.</param>
    async void OnSignUpClicked(object sender, EventArgs e)
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
        // R�cup�ration de l'e-mail et du mot de passe entr�s
        string email = emailEntry.Text;
        string password = passwordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Erreur", "Veuillez remplir tous les champs.", "OK");
            return;
        }

        // V�rifier que l'e-mail a la bonne forme
        //if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        //{
        //    await DisplayAlert("Erreur", "L'e-mail n'est pas valide.", "OK");
        //    return;
        //}

        // V�rifier que l'utilisateur existe
        Utilisateur utilisateur = my_manager.Utilisateurs.FirstOrDefault(u => u.Email == email && u.MotDePasse == password);
        if (utilisateur == null)
        {
            await DisplayAlert("Erreur", "Le mot de passe entr� est incorrect.", "OK");
            return;
        }

        // On garde l'utilisateur qui vient de se connecter pour acc�der � ses informations
        my_manager.UtilisateurActuel = utilisateur;

        // Rediriger l'utilisateur vers la page principale
        await Shell.Current.GoToAsync("//page/homePage");
    }
}
