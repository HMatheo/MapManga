using MangaMap.Views;
namespace MangaMap;

public partial class NewContent1 : ContentView
{
	public NewContent1()
	{
		InitializeComponent();
	}

	void ImageButton_Clicked(System.Object sender, System.EventArgs e)
	{
        Navigation.PushAsync(new homePage());
        //ShellContent(new homePage());
    }

	void SettingButton_Clicked(object sender, System.EventArgs e)
	{
		Navigation.PushAsync(new settingsPage());
	}
}