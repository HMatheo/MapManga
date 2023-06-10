using Models;
using System.Text.RegularExpressions;

namespace MangaMap.Views;

public partial class loginModifyPage : ContentPage
{
    /// <summary>
    /// Référence au gestionnaire de l'application.
    /// </summary>
    public Manager my_manager => (App.Current as App).MyManager;
    public Utilisateur utilisateurModify;

    public loginModifyPage(Utilisateur u)
	{
        utilisateurModify = u;

		InitializeComponent();
	}

    /// <summary>
    /// Gestionnaire d'événement lorsqu'un utilisateur clique sur le bouton "Inscription".
    /// </summary>
    /// <param name="sender">L'objet qui a déclenché l'événement.</param>
    /// <param name="e">Arguments de l'événement.</param>
    async void OnModifiedClicked(object sender, System.EventArgs e)
    {
        // Récupérer les valeurs des entrées
        string nom = nameEntry.Text;
        string prenom = firstNameEntry.Text;
        int age = Convert.ToInt32(ageEntry.Text);
        string email = emailEntry.Text;
        string pseudo = usernameEntry.Text;
        string password = passwordEntry.Text;
        string confirmPassword = confirmPasswordEntry.Text;

        foreach (Utilisateur u in my_manager.Utilisateurs)
        {
            if (u.Email == email || u.Pseudo == pseudo)
            {
                await DisplayAlert("Erreur", "L'utilisateur existe déjà.", "OK");
                return;
            }
        }

        // Vérifier si les mots de passe correspondent
        if (password != confirmPassword)
        {
            await DisplayAlert("Erreur", "Les mots de passe ne correspondent pas", "OK");
            return;
        }

        if (nom != null)
            utilisateurModify.nom = nom;

        if (prenom != null)
            utilisateurModify.prenom = prenom;

        if (age > 0)
            utilisateurModify.age = age;

        if (email != null)
        {
            // Vérifier que l'e-mail a la bonne forme
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                await DisplayAlert("Erreur", "L'e-mail n'est pas valide.", "OK");
                return;
            }
            utilisateurModify.Email = email;
        }

        if (pseudo != null)
            utilisateurModify.Pseudo = pseudo;

        if (password != null)
        {
            if (IsPasswordStrong(password) == false)
            {
                await DisplayAlert("Erreur", "Le mot de passe n'est pas assez fort", "OK");
                return;
            }

            utilisateurModify.MotDePasse = password;
        }

        my_manager.sauvegarder();
        await Shell.Current.GoToAsync("//page/homePage");
        return;
    }

    /// <summary>
    /// Vérifie si un mot de passe est suffisamment fort.
    /// </summary>
    /// <param name="password">Le mot de passe à vérifier.</param>
    /// <returns>True si le mot de passe est suffisamment fort, sinon False.</returns>
    bool IsPasswordStrong(string password)
    {
        // Vérifier si le mot de passe est assez long
        if (password.Length < 8)
        {
            return false;
        }

        // Vérifier si le mot de passe contient au moins une majuscule, une minuscule et un chiffre
        bool hasUppercase = false;
        bool hasLowercase = false;
        bool hasDigit = false;

        foreach (char c in password)
        {
            if (char.IsUpper(c))
            {
                hasUppercase = true;
            }
            else if (char.IsLower(c))
            {
                hasLowercase = true;
            }
            else if (char.IsDigit(c))
            {
                hasDigit = true;
            }
        }

        return hasUppercase && hasLowercase && hasDigit;
    }
}