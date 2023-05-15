namespace MangaMap.Views;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MangaMap.Stub;
using MangaMap.Model;

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
            await DisplayAlert("Erreur", "L'email n'est pas valide.", "OK");
            return;
        }

        // Charger les données à partir de la persistance
        IPersistanceManager persistanceManager = new DataContract();
        (List<Oeuvre> oeuvres, List<Utilisateur> utilisateurs) = persistanceManager.chargeDonne();

        // Vérifier que l'utilisateur existe
        Utilisateur utilisateur = utilisateurs.FirstOrDefault(u => u.Email == email && u.MotDePasse == password);
        if (utilisateur == null)
        {
<<<<<<< HEAD
            await DisplayAlert("Erreur", "Le mot de passe entré est incorrect.", "OK");
            return;
        }

        // Redirection vers la page suivante si le mot de passe est correct
=======
            await DisplayAlert("Erreur", "L'e-mail ou le mot de passe est incorrect.", "OK");
            return;
        }

        // Rediriger l'utilisateur vers la page principale
>>>>>>> MathÃ©o
        await Navigation.PushAsync(new homePage());
    }

}
