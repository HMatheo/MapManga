using MangaMap.Model;
using MangaMap.Views;

namespace MangaMap;

public partial class App : Application
{

	public Manager MyManager { get; private set; } = new Manager();
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

	}
}
