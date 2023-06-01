using System.Text.RegularExpressions;
using MangaMap.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MangaMap.Views;

public partial class createOeuvre : ContentPage
{
    public Manager my_manager => (App.Current as App).MyManager;

    public createOeuvre()
	{
		InitializeComponent();
	}

    async void AddClicked(object sender, System.EventArgs e)
    {
        // R�cup�rer les valeurs des entr�es
        string nom = nameEntry.Text;
        string type = typeEntry.Text;
        int nbEp = Convert.ToInt32(nbEpisodeEntry.Text);
        string description = descriptionEntry.Text;

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
            await DisplayAlert("Erreur", "Il faut avoir au 1 �pisode pour l'application.", "OK");
            return;
        }

        Oeuvre oeuv = new Oeuvre(nom, type, description, nbEp, "logo.png");
        my_manager.Oeuvres.Add(oeuv);
        my_manager.sauvegarder();
        await Navigation.PushAsync(new homePage());
        return;
    }
}