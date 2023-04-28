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
        // R�cup�ration de l'email et du mot de passe entr�s
        string email = emailEntry.Text;
        string password = passwordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Erreur", "Veuillez remplir tous les champs.", "OK");
            return;
        }

        // V�rifier que l'e-mail a la bonne forme
        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            await DisplayAlert("Erreur", "L'e-mail n'est pas valide.", "OK");
            return;
        }

        // V�rification du mot de passe
        if (password != "monmotdepasse")
        {
            DisplayAlert("Erreur", "Le mot de passe entr� est incorrect.", "OK");
            return;
        }

        // Redirection vers la page suivante si le mot de passe est correct
        Navigation.PushAsync(new homePage());
    }
}
