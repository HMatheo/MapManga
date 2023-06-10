using System.Text.RegularExpressions;
using Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace MangaMap.Views;

public partial class createOeuvre : ContentPage
{
    public Manager my_manager => (App.Current as App).MyManager;
    private string imagePath;

    /// <summary>
    /// Constructeur de la page de cr�ation d'oeuvre.
    /// </summary>
    public createOeuvre()
    {
        InitializeComponent();
        BindingContext = this;
    }

    /// <summary>
    /// G�re l'�v�nement de clic sur le bouton de s�lection d'image.
    /// </summary>
    /// <param name="sender">L'objet d�clencheur de l'�v�nement.</param>
    /// <param name="e">Les arguments de l'�v�nement.</param>
    private async void SelectImageClicked(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            FileTypes = FilePickerFileType.Images,
            PickerTitle = "Pick an image"
        });

        if (result != null)
        {
            var stream = await result.OpenReadAsync();
            // Utilisez le chemin d'acc�s � l'image s�lectionn�e
            imagePath = result.FullPath;
        }
    }

    /// <summary>
    /// G�re l'�v�nement de clic sur le bouton d'ajout d'oeuvre.
    /// </summary>
    /// <param name="sender">L'objet d�clencheur de l'�v�nement.</param>
    /// <param name="e">Les arguments de l'�v�nement.</param>
    private async void AddClicked(object sender, System.EventArgs e)
    {
        // R�cup�rer les valeurs des entr�es
        string nom = nameEntry.Text;
        string type = typeEntry.Text;
        int nbEp = Convert.ToInt32(nbEpisodeEntry.Text);
        string description = descriptionEntry.Text;

        if (imagePath == null)
        {
            await DisplayAlert("Erreur", "Veuillez s�lectionner une image.", "OK");
            return;
        }

        foreach (Oeuvre o in my_manager.Oeuvres)
        {
            if (o.Nom == nom)
            {
                await DisplayAlert("Erreur", "L'oeuvre existe d�j�.", "OK");
                return;
            }
        }

        if (string.IsNullOrWhiteSpace(nom) ||
            string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(type))
        {
            await DisplayAlert("Erreur", "Veuillez remplir tous les champs.", "OK");
            return;
        }

        if (nbEp < 0)
        {
            await DisplayAlert("Erreur", "Il faut avoir au moins 1 �pisode pour l'application.", "OK");
            return;
        }

        Oeuvre oeuv = new Oeuvre(nom, type, description, nbEp, imagePath);
        my_manager.Oeuvres.Add(oeuv);
        my_manager.sauvegarder();
        await Navigation.PushAsync(new homePage());
        return;
    }
}
