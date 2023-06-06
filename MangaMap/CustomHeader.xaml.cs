using MangaMap.Views;
namespace MangaMap;
using MangaMap.Model;
using System.ComponentModel;
using INotifyPropertyChanged = System.ComponentModel.INotifyPropertyChanged;

/// <summary>
/// Classe repr�sentant le contenu d'en-t�te personnalis� (CustomHeader).
/// </summary>
public partial class NewContent1 : ContentView, INotifyPropertyChanged
{
    public Manager my_manager => (App.Current as App).MyManager;

    /// <summary>
    /// Constructeur du contenu d'en-t�te personnalis�.
    /// </summary>
    public NewContent1()
    {
        InitializeComponent();
    }

    /// <summary>
    /// G�re l'�v�nement de clic sur le bouton d'accueil.
    /// </summary>
    /// <param name="sender">L'objet d�clencheur de l'�v�nement.</param>
    /// <param name="e">Les arguments de l'�v�nement.</param>
    async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//page/homePage");
    }

    /// <summary>
    /// G�re l'�v�nement de clic sur le bouton de param�tres.
    /// </summary>
    /// <param name="sender">L'objet d�clencheur de l'�v�nement.</param>
    /// <param name="e">Les arguments de l'�v�nement.</param>
    async void SettingButton_Clicked(object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//page/secondaire/settingsPage");
    }

    /// <summary>
    /// G�re l'�v�nement de clic sur le bouton de compte.
    /// </summary>
    /// <param name="sender">L'objet d�clencheur de l'�v�nement.</param>
    /// <param name="e">Les arguments de l'�v�nement.</param>
    async void AccountButton_Clicked(object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync("//page/secondaire/connexionPage");
    }

    /// <summary>
    /// G�re l'�v�nement de clic sur le bouton de liste.
    /// </summary>
    /// <param name="sender">L'objet d�clencheur de l'�v�nement.</param>
    /// <param name="e">Les arguments de l'�v�nement.</param>
    async void ListButton_Clicked(object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new listPage());
    }
}