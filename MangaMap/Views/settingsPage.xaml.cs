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
        await Shell.Current.Navigation.PushAsync(new loginPage());
    }

    private void OnLoginClicked(object sender, EventArgs e)
    {
        //
    }
}