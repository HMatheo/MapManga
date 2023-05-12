namespace MangaMap.Views;

using MangaMap.Model;

public partial class homePage : ContentPage
{
    public Manager my_manager => (App.Current as App).MyManager;

    public homePage()
	{
		InitializeComponent();
		a1.BindingContext = my_manager;
		a2.BindingContext = my_manager;
	}
}

