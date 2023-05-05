namespace MangaMap.Views.Composants;

public partial class StyleBouton : ContentView
{
	public StyleBouton()
	{
		InitializeComponent();
	}

	private async void ButtonIsPressed(object sender, EventArgs e)
	{
		await Shell.Current.Navigation.PushAsync(new ficheAnime());
	}
}