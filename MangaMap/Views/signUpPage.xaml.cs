namespace MangaMap.Views;
using System.Text.RegularExpressions;

public partial class signUpPage : ContentPage
{
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

    }
}