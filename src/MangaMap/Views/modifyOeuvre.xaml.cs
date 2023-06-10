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
    /// Gère l'événement de clic sur le bouton de modification d'une oeuvre.
    /// </summary>
    /// <param name="sender">L'objet déclencheur de l'événement.</param>
    /// <param name="e">Les arguments de l'événement.</param>
    private async void AddClicked(object sender, System.EventArgs e)
    {
        // Récupérer les valeurs des entrées
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
                    await DisplayAlert("Erreur", "Ce nom existe déjà pour une autre oeuvre.", "OK");
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