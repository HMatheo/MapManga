using MangaMap.Views;

namespace MangaMap;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute("homePagedetails", typeof(homePage));
        Routing.RegisterRoute("inscriptionPagedetails", typeof(signUpPage));
        Routing.RegisterRoute("connexionPagedetails", typeof(loginPage));
        Routing.RegisterRoute("settingsPagedetails", typeof(settingsPage));
        Routing.RegisterRoute("listPagedetails", typeof(listPage));
        Routing.RegisterRoute("fichePagedetails", typeof(ficheAnime));
    }
}
