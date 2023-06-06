namespace MangaMap.Views
{
    using Model;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Input;
    using System.Xml.Linq;
    using Microsoft.Maui.Graphics;

    public partial class ficheAnime : ContentPage, INotifyPropertyChanged
    {
        public Manager my_manager => (App.Current as App).MyManager;
        public Oeuvre AnimeModel { get; set; }

        /// <summary>
        /// Constructeur par d�faut de la page ficheAnime.
        /// </summary>
        public ficheAnime()
        {
            InitializeComponent();

            BindingContext = this;
        }

        /// <summary>
        /// Constructeur de la page ficheAnime prenant en param�tre un objet Oeuvre.
        /// </summary>
        /// <param name="anime">L'objet Oeuvre � afficher dans la fiche.</param>
        public ficheAnime(Oeuvre anime)
        {
            AnimeModel = anime;

            InitializeComponent();

            BindingContext = this;

            SetNote();
        }

        /// <summary>
        /// G�re l'�v�nement lorsqu'on clique sur le bouton d'ajout � la liste.
        /// </summary>
        /// <param name="sender">L'objet d�clenchant l'�v�nement.</param>
        /// <param name="e">Les arguments de l'�v�nement.</param>
        public async void AjouterListe(object sender, EventArgs e)
        {
            if (my_manager.UtilisateurActuel.Email == null)
            {
                await DisplayAlert("Erreur", "Vous n'�tes pas connect�.", "OK");
                return;
            }

            // Si la s�rie est d�j� dans la liste il faut bloquer l'ajout.
            foreach (Oeuvre oeuvre in my_manager.UtilisateurActuel.ListeOeuvreEnVisionnage)
            {
                if (oeuvre.Nom == AnimeModel.Nom)
                {
                    await DisplayAlert("Erreur", "Avez d�j� cette s�rie dans une la liste 'En visionnage'.", "OK");
                    return;
                }
            }
            foreach (Oeuvre oeuvre in my_manager.UtilisateurActuel.ListeOeuvreDejaVu)
            {
                if (oeuvre.Nom == AnimeModel.Nom)
                {
                    await DisplayAlert("Erreur", "Avez d�j� cette s�rie dans une la liste 'D�j� vu'.", "OK");
                    return;
                }
            }
            foreach (Oeuvre oeuvre in my_manager.UtilisateurActuel.ListeOeuvreFavorites)
            {
                if (oeuvre.Nom == AnimeModel.Nom)
                {
                    await DisplayAlert("Erreur", "Avez d�j� cette s�rie dans une la liste 'En favoris'.", "OK");
                    return;
                }
            }
            foreach (Oeuvre oeuvre in my_manager.UtilisateurActuel.ListeOeuvrePourPlusTard)
            {
                if (oeuvre.Nom == AnimeModel.Nom)
                {
                    await DisplayAlert("Erreur", "Avez d�j� cette s�rie dans une la liste 'Pour plus tard'.", "OK");
                    return;
                }
            }

            string selectedOption = await DisplayActionSheet("Ajouter � quelle liste ?", "Annuler", null, "En Visionnage", "D�j� Vu", "Pour Plus Tard", "Favoris");

            if (selectedOption == "Annuler" || selectedOption == null)
                return;

            Debug.WriteLine("Selected Option: " + selectedOption);

            // Ajouter l'anime � la liste s�lectionn�e
            switch (selectedOption)
            {
                case "En Visionnage":
                    Debug.WriteLine("Ajout � la liste En Visionnage");
                    my_manager.UtilisateurActuel.ListeOeuvreEnVisionnage.Add(AnimeModel);
                    break;
                case "D�j� Vu":
                    Debug.WriteLine("Ajout � la liste D�j� Vu");
                    my_manager.UtilisateurActuel.ListeOeuvreDejaVu.Add(AnimeModel);
                    break;
                case "Pour Plus Tard":
                    Debug.WriteLine("Ajout � la liste Pour Plus Tard");
                    my_manager.UtilisateurActuel.ListeOeuvrePourPlusTard.Add(AnimeModel);
                    break;
                case "Favoris":
                    Debug.WriteLine("Ajout � la liste Favoris");
                    my_manager.UtilisateurActuel.ListeOeuvreFavorites.Add(AnimeModel);
                    break;
            }

            my_manager.sauvegarder();

            await Navigation.PushAsync(new listPage());
        }

        /// <summary>
        /// G�re l'�v�nement lorsqu'on clique sur le bouton de suppression de la liste.
        /// </summary>
        /// <param name="sender">L'objet d�clenchant l'�v�nement.</param>
        /// <param name="e">Les arguments de l'�v�nement.</param>
        public async void SupprimerListe(object sender, EventArgs e)
        {
            if (my_manager.UtilisateurActuel.ListeOeuvreEnVisionnage.Remove(AnimeModel) ||
                my_manager.UtilisateurActuel.ListeOeuvreDejaVu.Remove(AnimeModel) ||
                my_manager.UtilisateurActuel.ListeOeuvreFavorites.Remove(AnimeModel) ||
                my_manager.UtilisateurActuel.ListeOeuvrePourPlusTard.Remove(AnimeModel))
                my_manager.sauvegarder();
            else
            {
                await DisplayAlert("Erreur", "Avez n'avez pas cette s�rie dans une liste.", "OK");
                return;
            }
        }

        /// <summary>
        /// Affiche les �toiles de notation de l'anime.
        /// </summary>
        private void SetNote()
        {
            stars.Children.Clear();
            bool test = my_manager.UtilisateurActuel.notesNombres.ContainsKey(AnimeModel.Nom);
            List<int> x;

            for (int i = 0; i < 5; i++)
            {
                if (my_manager.UtilisateurActuel.notesNombres.TryGetValue(AnimeModel.Nom, out x) && i < x[0])
                {
                    ImageButton imageButton = new ImageButton
                    {
                        Source = "star_full.png",
                        BackgroundColor = Microsoft.Maui.Graphics.Color.FromHex("1E1E1E"),
                        WidthRequest = 50,
                        HeightRequest = 50,
                        AutomationId = i.ToString(),
                        Margin = 10,
                    };

                    imageButton.Clicked += StarClicked;

                    Grid.SetRow(imageButton, 0);
                    Grid.SetColumn(imageButton, i);
                    stars.Children.Add(imageButton);
                }
                else if (!test && i < AnimeModel.Note)
                {
                    ImageButton imageButton = new ImageButton
                    {
                        Source = "star_full.png",
                        BackgroundColor = Microsoft.Maui.Graphics.Color.FromHex("1E1E1E"),
                        WidthRequest = 50,
                        HeightRequest = 50,
                        AutomationId = i.ToString(),
                        Margin = 10,
                    };

                    imageButton.Clicked += StarClicked;

                    Grid.SetRow(imageButton, 0);
                    Grid.SetColumn(imageButton, i);
                    stars.Children.Add(imageButton);
                }
                else
                {
                    ImageButton imageButton = new ImageButton
                    {
                        Source = "star_empty.png",
                        BackgroundColor = Microsoft.Maui.Graphics.Color.FromHex("1E1E1E"),
                        WidthRequest = 50,
                        HeightRequest = 50,
                        AutomationId = i.ToString(),
                        Margin = 10,
                    };

                    imageButton.Clicked += StarClicked;

                    Grid.SetRow(imageButton, 0);
                    Grid.SetColumn(imageButton, i);
                    stars.Children.Add(imageButton);
                }
            }
        }

        /// <summary>
        /// G�re l'�v�nement lorsqu'on clique sur une �toile.
        /// </summary>
        /// <param name="sender">L'objet d�clenchant l'�v�nement.</param>
        /// <param name="e">Les arguments de l'�v�nement.</param>
        private async void StarClicked(object sender, EventArgs e)
        {
            if (my_manager.UtilisateurActuel.Email == null)
            {
                await DisplayAlert("Erreur", "Vous n'�tes pas connect�.", "OK");
                return;
            }

            var button = (ImageButton)sender;
            var idAutomation = button.AutomationId;
            List<int> x = new List<int>();
            int somme = 0;
            int compteur = 0;

            if (int.TryParse(idAutomation, out int id))
            {
                if (my_manager.UtilisateurActuel.notesNombres.ContainsKey(AnimeModel.Nom))
                {
                    my_manager.UtilisateurActuel.notesNombres.Remove(AnimeModel.Nom, out x);
                    x[0] = id + 1;
                    my_manager.UtilisateurActuel.notesNombres.Add(AnimeModel.Nom, x);
                    BackgroundColor = Microsoft.Maui.Graphics.Color.FromHex("1E1E1E");
                }
                else
                {
                    x.Add(id + 1);
                    x.Add(0);
                    my_manager.UtilisateurActuel.notesNombres.Add(AnimeModel.Nom, x);
                    //BackgroundColor = Microsoft.Maui.Graphics.Color.FromHex("1E1E1E");
                }

                SetNote();

                foreach (Utilisateur u in my_manager.Utilisateurs)
                {
                    if (u.notesNombres.TryGetValue(AnimeModel.Nom, out x) && x[0] != 0)
                    {
                        compteur = compteur + 1;
                        somme = somme + x[0];
                    }
                }

                AnimeModel.Note = somme / compteur;
                my_manager.sauvegarder();
            }
        }

        /// <summary>
        /// G�re l'�v�nement lorsqu'on clique sur le bouton de validation du nombre d'�pisodes.
        /// </summary>
        /// <param name="sender">L'objet d�clenchant l'�v�nement.</param>
        /// <param name="e">Les arguments de l'�v�nement.</param>
        private async void NbEpCheck(object sender, EventArgs e)
        {
            if (my_manager.UtilisateurActuel.Email == null)
            {
                await DisplayAlert("Erreur", "Vous n'�tes pas connect�.", "OK");
                return;
            }

            List<int> x = new List<int>();
            int nb = Convert.ToInt32(nombreEP.Text);

            if (my_manager.UtilisateurActuel.notesNombres.ContainsKey(AnimeModel.Nom))
            {
                my_manager.UtilisateurActuel.notesNombres.Remove(AnimeModel.Nom, out x);
                x[1] = nb;
                my_manager.UtilisateurActuel.notesNombres.Add(AnimeModel.Nom, x);
                return;
            }
            else
            {
                x.Add(0);
                x.Add(nb);
                my_manager.UtilisateurActuel.notesNombres.Add(AnimeModel.Nom, x);
            }

            my_manager.sauvegarder();
        }
    }
}
