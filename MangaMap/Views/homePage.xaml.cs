namespace MangaMap.Views
{
    using MangaMap.Model;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Classe repr�sentant la page d'accueil de l'application.
    /// </summary>
    public partial class homePage : ContentPage
    {
        /// <summary>
        /// R�f�rence au gestionnaire de l'application.
        /// </summary>
        public Manager my_manager => (App.Current as App).MyManager;

        /// <summary>
        /// Constructeur de la page d'accueil.
        /// </summary>
        public homePage()
        {
            InitializeComponent();
            BindingContext = my_manager;
            searchResults.ItemsSource = my_manager.Oeuvres;
            //chargerSerie();
        }

        /// <summary>
        /// Gestionnaire d'�v�nement lorsqu'une image d'anime est cliqu�e.
        /// </summary>
        /// <param name="sender">L'objet qui a d�clench� l'�v�nement.</param>
        /// <param name="e">Arguments de l'�v�nement.</param>
        private async void AnimeImageClicked(object sender, EventArgs e)
        {
            var selectedAnime = (sender as ImageButton)?.BindingContext as Oeuvre;
            if (selectedAnime != null)
            {
                // Naviguer vers la page de la fiche d'anime en passant l'objet s�lectionn�
                await Navigation.PushAsync(new ficheAnime(selectedAnime));
            }

            /*var button = (ImageButton)sender;
            var idAutomation = button.AutomationId;

            if (int.TryParse(idAutomation, out int id))
            {
                await Navigation.PushAsync(new ficheAnime(my_manager.Oeuvres[id]));
            }*/
        }

        /*private void chargerSerie()
        {
            int imagesParLigne = 4;
            int indice = 0;

            for (int i = 0; i < my_manager.Oeuvres.Count; i++)
            {
                Oeuvre favoris = my_manager.Oeuvres[i];

                ImageButton imageButton = new ImageButton
                {
                    Source = favoris.Affiche,
                    WidthRequest = 170,
                    MaximumHeightRequest = 190,
                    MinimumHeightRequest = 190,
                    HeightRequest = 190,
                    CornerRadius = 15,
                    Aspect = Aspect.Fill,
                    AutomationId = indice.ToString(),
                    Margin = 90
                };

                imageButton.Clicked += AnimeImageClicked;

                int ligne = 1 + (indice / imagesParLigne);
                int colonne = indice % imagesParLigne;

                Grid.SetRow(imageButton, ligne);
                Grid.SetColumn(imageButton, colonne);
                grille.Children.Add(imageButton);

                indice++;
            }
        }*/

        /// <summary>
        /// Gestionnaire d'�v�nement lorsqu'un texte est modifi� dans la zone de recherche.
        /// </summary>
        /// <param name="sender">L'objet qui a d�clench� l'�v�nement.</param>
        /// <param name="e">Arguments de l'�v�nement contenant le nouveau texte.</param>
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                // Afficher toutes les �uvres si le champ de recherche est vide
                searchResults.ItemsSource = my_manager.Oeuvres;
            }
            else
            {
                // Filtrer les �uvres en fonction du texte de recherche
                searchResults.ItemsSource = my_manager.Oeuvres.Where(i => i.Nom.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }
    }
}
