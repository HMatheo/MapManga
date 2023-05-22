namespace MangaMap.Views;
using MangaMap.Model;

public partial class listPage : ContentPage
{
    public Manager my_manager => (App.Current as App).MyManager;

    public listPage()
	{
		InitializeComponent();
        BindingContext = my_manager.UtilisateurActuel;
    }

}