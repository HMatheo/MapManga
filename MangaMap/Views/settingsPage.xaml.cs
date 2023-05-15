namespace MangaMap.Views;

public partial class settingsPage : ContentPage
{
	public settingsPage()
	{
		InitializeComponent();
	}

    private async void OnDisconnectClicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new loginPage());
    }

    private void OnLoginClicked(object sender, EventArgs e)
    {
        //
    }
}