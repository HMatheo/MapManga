using MangaMap.Model;

namespace MangaMap.Views.Composants
{
    /// <summary>
    /// Code-behind pour le UserControl StyleBouton.xaml.
    /// </summary>
    public partial class StyleBouton : ContentView
    {
        /// <summary>
        /// Instance du manager pour accéder aux données.
        /// </summary>
        public Manager my_manager => (App.Current as App).MyManager;

        /// <summary>
        /// Constructeur de la classe StyleBouton.
        /// </summary>
        public StyleBouton()
        {
            InitializeComponent();
            BindingContext = my_manager;
        }

        /// <summary>
        /// Gère l'événement lorsqu'une image d'anime est cliquée.
        /// </summary>
        /// <param name="sender">L'objet déclenchant l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private async void AnimeImageClickedList(object sender, EventArgs e)
        {
            var selectedAnime = (sender as ImageButton)?.BindingContext as Oeuvre;
            if (selectedAnime != null)
            {
                // Naviguez vers la page de la fiche d'anime en passant l'objet sélectionné
                await Navigation.PushAsync(new ficheAnime(selectedAnime));
            }
        }
    }
}
