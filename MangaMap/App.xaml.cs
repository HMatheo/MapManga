using MangaMap.Views;

namespace MangaMap;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

	}
}
