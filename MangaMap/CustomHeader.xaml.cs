using MangaMap.Views;
namespace MangaMap;
using MangaMap.Model;
using System.ComponentModel;
using INotifyPropertyChanged = System.ComponentModel.INotifyPropertyChanged;

/// <summary>
/// Classe représentant le contenu d'en-tête personnalisé (CustomHeader).
/// </summary>
public partial class NewContent1 : ContentView, INotifyPropertyChanged
{
    public Manager my_manager => (App.Current as App).MyManager;

    /// <summary>
    /// Constructeur du contenu d'en-tête personnalisé.
    /// </summary>
    public NewContent1()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Gère l'événement de clic sur le bouton d'accueil.
    /// </summary>
    /// <param name="sender">L'objet déclencheur de l'événement.</param>
    /// <param name="e">Les arguments de l'événement.</param>
    async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//page/homePage");
    }

    /// <summary>
    /// Gère l'événement de clic sur le bouton de paramètres.
    /// </summary>
    /// <param name="sender">L'objet déclencheur de l'événement.</param>
    /// <param name="e">Les arguments de l'événement.</param>
    async void SettingButton_Clicked(object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//page/secondaire/settingsPage");
    }

    /// <summary>
    /// Gère l'événement de clic sur le bouton de compte.
    /// </summary>
    /// <param name="sender">L'objet déclencheur de l'événement.</param>
    /// <param name="e">Les arguments de l'événement.</param>
    async void AccountButton_Clicked(object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//page/secondaire/connexionPage");
    }

    /// <summary>
    /// Gère l'événement de clic sur le bouton de liste.
    /// </summary>
    /// <param name="sender">L'objet déclencheur de l'événement.</param>
    /// <param name="e">Les arguments de l'événement.</param>
    async void ListButton_Clicked(object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new listPage());
    }
}