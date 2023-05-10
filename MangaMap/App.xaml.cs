using MangaMap.Model;
using MangaMap.Views;

namespace MangaMap;

public partial class App : Application
{
	public Manager MyManager { get; private set; } = new Manager(new Stub.Stub());

	public Admin MyAdmin { get; private set; } = new Admin("test", "test@test.ts", "Pseudo_test");

	public App()
	{
		InitializeComponent();
		MyManager.Admins.Add(MyAdmin);

		MainPage = new AppShell();
		MyManager.charger();
	}
}
