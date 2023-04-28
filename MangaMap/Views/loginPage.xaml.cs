namespace MangaMap.Views;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public partial class loginPage : ContentPage
{
	public loginPage()
	{
		InitializeComponent();
	}

    async void OnLoginClicked(object sender, EventArgs e)
    {
        // Récupération de l'email et du mot de passe entrés
        string email = emailEntry.Text;
        string password = passwordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password))
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

        // Vérification du mot de passe
        if (password != "monmotdepasse")
        {
            DisplayAlert("Erreur", "Le mot de passe entré est incorrect.", "OK");
            return;
        }

        // Redirection vers la page suivante si le mot de passe est correct
        Navigation.PushAsync(new homePage());
    }
}
