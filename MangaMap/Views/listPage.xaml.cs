namespace MangaMap.Views;
using MangaMap.Model;
using static System.Net.Mime.MediaTypeNames;

public partial class listPage : ContentPage
{
    public Manager my_manager => (App.Current as App).MyManager;

    public listPage()
	{
		InitializeComponent();
        BindingContext = my_manager;
        if (my_manager.UtilisateurActuel.Email != null)
        {
            chargerFavoris();
        }
    }

    private void chargerFavoris()
    {
        int indice = 0;

        for (int i = 0; i < my_manager.UtilisateurActuel.ListeOeuvreEnVisionnage.Count; i++)
        {
            Oeuvre favoris = my_manager.UtilisateurActuel.ListeOeuvreEnVisionnage[i];

            ImageButton imageButton = new ImageButton
            {
                Source = favoris.Affiche,
                WidthRequest = 100,
                HeightRequest = 100,
            };

            int ligne = 1 + indice;

            Grid.SetRow(imageButton, ligne);
            Grid.SetColumn(imageButton, 0);

            //grille.Children.Add(imageButton);

            indice++;
        }
    }
}