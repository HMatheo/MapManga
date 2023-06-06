using MangaMap.Model;

namespace MangaMap.Views.Composants
{
    /// <summary>
    /// Code-behind pour le UserControl StyleBouton.xaml.
    /// </summary>
    public partial class StyleBouton : ContentView
    {
        /// <summary>
        /// Instance du manager pour acc�der aux donn�es.
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
        /// G�re l'�v�nement lorsqu'une image d'anime est cliqu�e.
        /// </summary>
        /// <param name="sender">L'objet d�clenchant l'�v�nement.</param>
        /// <param name="e">Les arguments de l'�v�nement.</param>
        private async void AnimeImageClickedList(object sender, EventArgs e)
        {
            var selectedAnime = (sender as ImageButton)?.BindingContext as Oeuvre;
            if (selectedAnime != null)
            {
                // Naviguez vers la page de la fiche d'anime en passant l'objet s�lectionn�
                await Navigation.PushAsync(new ficheAnime(selectedAnime));
            }
        }
    }
}
