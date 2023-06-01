namespace MangaMap.Views;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MangaMap.Stub;
using MangaMap.Model;

public partial class loginAdminPage : ContentPage
{
    public Manager my_manager => (App.Current as App).MyManager;

    public loginAdminPage()
	{
		InitializeComponent();
	}

    async void userClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//page/secondaire/inscriptionPage");
    }

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

        // On garde la connection admin
        my_manager.isAdmin = true;
        // Rediriger l'utilisateur vers la page principale
        await Shell.Current.GoToAsync("//page/homePage");
    }
}