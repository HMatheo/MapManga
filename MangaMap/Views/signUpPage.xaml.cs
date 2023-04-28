namespace MangaMap.Views;

using MangaMap.Model;
using System.Text.RegularExpressions;

public partial class signUpPage : ContentPage
{

    public Manager my_manager => (App.Current as App).MyManager;

	public signUpPage()
	{
        InitializeComponent();
	}

    async void OnSignUpClicked(object sender, System.EventArgs e)
    {
        // Récupérer les valeurs des entrées
        string email = emailEntry.Text;
        string password = passwordEntry.Text;
        string confirmPassword = confirmPasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) ||
        string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
        {
            await DisplayAlert("Erreur", "Veuillez remplir tous les champs.", "OK");
            return;
        }

        // Vérifier que l'e-mail a la bonne forme
        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            await DisplayAlert("Erreur", "L'e-mail n'est pas valide.", "OK");
            return;
        }

        if (IsPasswordStrong(password) == false)
        {
            await DisplayAlert("Erreur", "Le mot de passe n'est pas assez fort", "OK");
            return;
        }

        // Vérifier si les mots de passe correspondent
        if (password != confirmPassword)
        {
            await DisplayAlert("Erreur", "Les mots de passe ne correspondent pas", "OK");
            return;
        }

        if (password == confirmPassword)
        {
            await Navigation.PushAsync(new homePage());
        }

        Utilisateur util = new Utilisateur("Ryan", "Garcia", 12);
        my_manager.ajouterUtilisateur(util);

    }

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