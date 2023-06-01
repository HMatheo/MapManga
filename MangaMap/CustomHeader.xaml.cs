using MangaMap.Views;
namespace MangaMap;
using MangaMap.Model;
using System.ComponentModel;
using INotifyPropertyChanged = System.ComponentModel.INotifyPropertyChanged;

public partial class NewContent1 : ContentView, INotifyPropertyChanged
{
    public Manager my_manager => (App.Current as App).MyManager;
    public NewContent1()
    {
        InitializeComponent();

    }
    async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        //Navigation.PushAsync(new homePage());
        await Shell.Current.GoToAsync("//page/homePage");
    }

    async void SettingButton_Clicked(object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//page/secondaire/settingsPage");
    }

    async void AccountButton_Clicked(object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//page/secondaire/connexionPage");
    }

    async void ListButton_Clicked(object sender, System.EventArgs e)
    {
        //await Shell.Current.GoToAsync("//page/secondaire/listPage");
        await Navigation.PushAsync(new listPage());
    }
}