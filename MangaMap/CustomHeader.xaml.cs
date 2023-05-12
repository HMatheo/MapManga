using MangaMap.Views;
namespace MangaMap;

public partial class NewContent1 : ContentView
{
	public NewContent1()
	{
		InitializeComponent();
	}

	async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
	{
		//Navigation.PushAsync(new homePage());
		await Shell.Current.GoToAsync("//page/homePage");
    }

	async void SettingButton_Clicked(object sender, System.EventArgs e)
	{
		await Shell.Current.GoToAsync("//page/secondaire/settingsPage");
	}
}