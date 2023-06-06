using MangaMap.Views;

namespace MangaMap;

/// <summary>
/// Classe représentant le Shell.
/// </summary>
public partial class AppShell : Shell
{
    /// <summary>
    /// Constructeur du shell de l'application.
    /// </summary>
    public AppShell()
    {
        InitializeComponent();

        // Enregistrement des routes pour les pages de l'application
        Routing.RegisterRoute("homePagedetails", typeof(homePage));
        Routing.RegisterRoute("inscriptionPagedetails", typeof(signUpPage));
        Routing.RegisterRoute("connexionPagedetails", typeof(loginPage));
        Routing.RegisterRoute("settingsPagedetails", typeof(settingsPage));
        Routing.RegisterRoute("listPagedetails", typeof(listPage));
        Routing.RegisterRoute("fichePagedetails", typeof(ficheAnime));
        Routing.RegisterRoute("connexionAdminPagedetails", typeof(loginAdminPage));
        Routing.RegisterRoute("createPagedetails", typeof(createOeuvre));
    }
}
