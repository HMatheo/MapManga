using MangaMap.Model;
using MangaMap.Stub;
using MangaMap.Views;

namespace MangaMap;

public partial class App : Application
{
	// public Manager MyManager { get; private set; } = new Manager(new Stub.Stub());		//pour utiliser le stub comme moyen de persistance.
	public Manager MyManager { get; private set; } = new Manager(new Stub.DataContract());

	public Admin MyAdmin { get; private set; } = new Admin("test", "test@test.ts", "Pseudo_test");

	public App()
	{
        InitializeComponent();
        MyManager.charger();
		MyManager.Admins.Add(MyAdmin);

		MainPage = new AppShell();
        //MyManager.Persistance = new DataContract();
        MyManager.sauvegarder();
    }
}
