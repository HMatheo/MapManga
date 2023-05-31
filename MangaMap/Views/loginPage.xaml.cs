namespace MangaMap.Views;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MangaMap.Stub;
using MangaMap.Model;

public partial class loginPage : ContentPage
{
    public Manager my_manager => (App.Current as App).MyManager;

    public loginPage()
	{
		InitializeComponent();
	}

    async void OnSignUpClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//page/secondaire/inscriptionPage");
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
        //if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        //{
        //    await DisplayAlert("Erreur", "L'email n'est pas valide.", "OK");
        //    return;
        //}

        // Vérifier que l'utilisateur existe
        Utilisateur utilisateur = my_manager.Utilisateurs.FirstOrDefault(u => u.Email == email && u.MotDePasse == password);
        if (utilisateur == null)
        {
            await DisplayAlert("Erreur", "Le mot de passe entré est incorrect.", "OK");
            return;
        }

        // On garde l'utilisateur qui vient de se connecter pour accéder à ses informations
        my_manager.UtilisateurActuel = utilisateur;
        // Rediriger l'utilisateur vers la page principale
        await Shell.Current.GoToAsync("//page/homePage");                                                                                                                                   
    }

}
