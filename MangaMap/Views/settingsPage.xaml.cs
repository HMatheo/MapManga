namespace MangaMap.Views;
using Model;

public partial class settingsPage : ContentPage
{
    public Manager my_manager => (App.Current as App).MyManager;

	public settingsPage()
	{
		InitializeComponent();
	}

    private async void OnDisconnectClicked(object sender, EventArgs e)
    {
        my_manager.UtilisateurActuel = new Utilisateur();
        my_manager.isAdmin = false;
        await Shell.Current.GoToAsync("//page/secondaire/connexionPage");
    }

    private async void LoginAdminClicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new loginAdminPage());
    }

    private async void AddClicked(object sender, EventArgs e)
    {
        if(!my_manager.isAdmin)
        {
            await DisplayAlert("Erreur", "Vous n'êtes pas connecté en tant qu'Administrateur.", "OK");
            return;
        }
        await Shell.Current.Navigation.PushAsync(new createOeuvre());
    }
}