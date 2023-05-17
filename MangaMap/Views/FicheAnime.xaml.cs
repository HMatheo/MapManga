namespace MangaMap.Views;
using Model;

public partial class ficheAnime : ContentPage
{
    public Manager DataManager { get; set; }

    public ficheAnime()
    {
        InitializeComponent();

        DataManager = new Manager();

        this.BindingContext = this;
    }
}