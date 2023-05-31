namespace MangaMap.Views;

using MangaMap.Model;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

public partial class signUpPage : ContentPage
{

    public Manager my_manager => (App.Current as App).MyManager;

	public signUpPage()
	{
        InitializeComponent();
	}

    async void OnLoginClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//page/secondaire/connexionPage");
    }

    async void OnSignUpClicked(object sender, System.EventArgs e)
    {
        // R�cup�rer les valeurs des entr�es
        string nom = nameEntry.Text;
        string prenom = firstNameEntry.Text;
        int age = Convert.ToInt32(ageEntry.Text);
        string email = emailEntry.Text;
        string pseudo = usernameEntry.Text;
        string password = passwordEntry.Text;
        string confirmPassword = confirmPasswordEntry.Text;

        foreach (Utilisateur u in my_manager.Utilisateurs)
        {
            if (u.Email == email ||u.Pseudo==pseudo)
            {
                await DisplayAlert("Erreur", "L'utilisateur existe d�j�.", "OK");
                return;
            }
        }

        if (string.IsNullOrWhiteSpace(email) ||
        string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
        {
            await DisplayAlert("Erreur", "Veuillez remplir tous les champs.", "OK");
            return;
        }

        if (age < 5)
        {
            await DisplayAlert("Erreur", "Il faut avoir au minimum 5 ans pour utiliser l'application.", "OK");
            return;
        }

        // V�rifier que l'e-mail a la bonne forme
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

        // V�rifier si les mots de passe correspondent
        if (password != confirmPassword)
        {
            await DisplayAlert("Erreur", "Les mots de passe ne correspondent pas", "OK");
            return;
        }

        if (password == confirmPassword)
        {
            Utilisateur util = new Utilisateur(email, pseudo, password, nom, prenom, age);
            my_manager.Utilisateurs.Add(util);
            my_manager.sauvegarder();
            my_manager.UtilisateurActuel = util;
            await Navigation.PushAsync(new homePage());
            return;
        }
    }

    bool IsPasswordStrong(string password)
    {
        // V�rifier si le mot de passe est assez long
        if (password.Length < 8)
        {
            return false;
        }

        // V�rifier si le mot de passe contient au moins une majuscule, une minuscule et un chiffre
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