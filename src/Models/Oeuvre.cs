using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Linq;
using System.Runtime.CompilerServices;

namespace Models
{
    /// <summary>
    /// Représente une oeuvre dans le système de gestion de listes d'anime.
    /// </summary>
    [DataContract]
    public class Oeuvre : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Obtient ou définit le nom de l'oeuvre.
        /// </summary>
        [DataMember]
        public string Nom { get; private set; }

        /// <summary>
        /// Obtient ou définit les genres de l'oeuvre.
        /// </summary>
        [DataMember]
        public List<string> Genre { get; private set; }

        /// <summary>
        /// Obtient ou définit le type de l'oeuvre.
        /// </summary>
        [DataMember]
        public string Type { get; private set; }

        /// <summary>
        /// Obtient ou définit la description de l'oeuvre.
        /// </summary>
        [DataMember]
        public string Description { get; private set; }

        /// <summary>
        /// Obtient ou définit la note de l'oeuvre.
        /// </summary>
        [DataMember]
        public int Note
        {
            get => note;
            set
            {
                if (note == value)
                    return;
                note = value;
                OnPropertyChanged();
            }
        }
        private int note;

        /// <summary>
        /// Obtient ou définit le nombre d'épisodes de l'oeuvre.
        /// </summary>
        [DataMember]
        public int NbEpisodes { get; private set; }

        /// <summary>
        /// Obtient ou définit l'affiche de l'oeuvre.
        /// </summary>
        [DataMember]
        public string Affiche { get; private set; }

        [DataMember]
        public int NombresEpVu { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe Oeuvre avec les informations spécifiées.
        /// </summary>
        /// <param name="nom">Le nom de l'oeuvre.</param>
        /// <param name="genre">Les genres de l'oeuvre.</param>
        /// <param name="type">Le type de l'oeuvre.</param>
        /// <param name="description">La description de l'oeuvre.</param>
        /// <param name="note">La note de l'oeuvre.</param>
        /// <param name="nbEpisode">Le nombre d'épisodes de l'oeuvre.</param>
        /// <param name="affiche">L'affiche de l'oeuvre.</param>
        public Oeuvre(string nom, List<string> genre, string type, string description, int note, int nbEpisode, string affiche)
        {
            Nom = nom;
            Genre = genre;
            Type = type;
            Description = description;
            Note = note;
            NbEpisodes = nbEpisode;
            Affiche = affiche;
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe Oeuvre avec les informations spécifiées.
        /// </summary>
        /// <param name="nom">Le nom de l'oeuvre.</param>
        /// <param name="type">Le type de l'oeuvre.</param>
        /// <param name="description">La description de l'oeuvre.</param>
        /// <param name="nbEpisode">Le nombre d'épisodes de l'oeuvre.</param>
        /// <param name="affiche">L'affiche de l'oeuvre.</param>
        public Oeuvre(string nom, string type, string description, int nbEpisode, string affiche)
        {
            Nom = nom;
            Genre = new List<string>();
            Type = type;
            Description = description;
            NbEpisodes = nbEpisode;
            Affiche = affiche;
        }

        /// <summary>
        /// Méthode permettant d'ajouter un certain nombre d'épisodes à l'oeuvre.
        /// </summary>
        /// <param name="nb">Le nombre d'épisodes à ajouter.</param>
        public void AjouterEpisode(int nb)
        {
            NbEpisodes = NbEpisodes + nb;
        }
    }
}
