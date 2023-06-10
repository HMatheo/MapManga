using Models;

namespace MangaMap.Views;

public partial class modifyOeuvre : ContentPage
{
    public Manager my_manager => (App.Current as App).MyManager;
    public Oeuvre oeuvreModifie { get; set; }

    public modifyOeuvre(Oeuvre anime)
    {
        oeuvreModifie = anime;

        InitializeComponent();

        BindingContext = oeuvreModifie;
    }

    /// <summary>
    /// G�re l'�v�nement de clic sur le bouton de modification d'une oeuvre.
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

        if (nom != null)
        {
            foreach (Oeuvre o in my_manager.Oeuvres)
            {
                if (o.Nom == nom)
                {
                    await DisplayAlert("Erreur", "Ce nom existe d�j� pour une autre oeuvre.", "OK");
                    return;
                }

                oeuvreModifie.Nom = nom;
            }

            if (type != null)
                oeuvreModifie.Type = type;

            if (description != null)
                oeuvreModifie.Description = description;

            if (nbEp > 0)
                oeuvreModifie.NbEpisodes = nbEp;

            my_manager.sauvegarder();
            await Navigation.PushAsync(new homePage());
            return;
        }
    }
}