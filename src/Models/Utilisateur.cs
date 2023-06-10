using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Représente un utilisateur de l'application de gestion de listes d'anime.
    /// </summary>
    [DataContract]
    public class Utilisateur : Personne
    {
        /// <summary>
        /// Obtient ou définit le nom de l'utilisateur.
        /// </summary>
        [DataMember]
        public string? nom { get; set; }

        /// <summary>
        /// Obtient ou définit le prénom de l'utilisateur.
        /// </summary>
        [DataMember]
        public string? prenom { get; set; }

        /// <summary>
        /// Obtient ou définit l'âge de l'utilisateur.
        /// </summary>
        [DataMember]
        public int age { get; private set; }

        /// <summary>
        /// Obtient ou définit la liste des oeuvres en visionnage de l'utilisateur.
        /// </summary>
        [DataMember]
        public ObservableCollection<Oeuvre> ListeOeuvreEnVisionnage { get; set; }

        /// <summary>
        /// Obtient ou définit la liste des oeuvres déjà vues par l'utilisateur.
        /// </summary>
        [DataMember]
        public ObservableCollection<Oeuvre> ListeOeuvreDejaVu { get; set; }

        /// <summary>
        /// Obtient ou définit la liste des oeuvres à voir ultérieurement par l'utilisateur.
        /// </summary>
        [DataMember]
        public ObservableCollection<Oeuvre> ListeOeuvrePourPlusTard { get; set; }

        /// <summary>
        /// Obtient ou définit la liste des oeuvres favorites de l'utilisateur.
        /// </summary>
        [DataMember]
        public ObservableCollection<Oeuvre> ListeOeuvreFavorites { get; set; }

        /// <summary>
        /// Obtient ou définit le dictionnaire des notes et nombres associés par l'utilisateur.
        /// </summary>
        [DataMember]
        public Dictionary<string, List<int>> notesNombres { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe Utilisateur avec les paramètres spécifiés.
        /// </summary>
        /// <param name="email">L'adresse email de l'utilisateur.</param>
        /// <param name="pseudo">Le pseudo de l'utilisateur.</param>
        /// <param name="mdp">Le mot de passe de l'utilisateur.</param>
        /// <param name="nom">Le nom de l'utilisateur.</param>
        /// <param name="prenom">Le prénom de l'utilisateur.</param>
        /// <param name="age">L'âge de l'utilisateur.</param>
        public Utilisateur(string email, string pseudo, string mdp, string nom, string prenom, int age)
        {
            Email = email;
            Pseudo = pseudo;
            MotDePasse = mdp;
            this.nom = nom;
            this.prenom = prenom;
            this.age = age;

            ListeOeuvreEnVisionnage = new ObservableCollection<Oeuvre>();
            ListeOeuvreDejaVu = new ObservableCollection<Oeuvre>();
            ListeOeuvrePourPlusTard = new ObservableCollection<Oeuvre>();
            ListeOeuvreFavorites = new ObservableCollection<Oeuvre>();
            notesNombres = new Dictionary<string, List<int>>();
        }

        /// <summary>
        /// Initialise une nouvelle instance par défaut de la classe Utilisateur.
        /// </summary>
        public Utilisateur()
        {
            ListeOeuvreEnVisionnage = new ObservableCollection<Oeuvre>();
            ListeOeuvreDejaVu = new ObservableCollection<Oeuvre>();
            ListeOeuvrePourPlusTard = new ObservableCollection<Oeuvre>();
            ListeOeuvreFavorites = new ObservableCollection<Oeuvre>();
            notesNombres = new Dictionary<string, List<int>>();
        }

        /// <summary>
        /// Supprime l'utilisateur en réinitialisant les propriétés nom, prénom et âge.
        /// </summary>
        public void SupprimerUtilisateur()
        {
            this.nom = null;
            this.prenom = null;
            this.age = 0;
        }
    }
}
