using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MangaMap.Model
{
    [DataContract]
    public class Utilisateur : Personne
    {
        [DataMember]
        public string nom { get; private set; }
        [DataMember] 
        public string prenom { get; private set; }
        [DataMember] 
        public int age { get; private set; }
        [DataMember] 
        public ObservableCollection<Oeuvre> ListeOeuvreEnVisionnage { get; set; }
        [DataMember] 
        public ObservableCollection<Oeuvre> ListeOeuvreDejaVu { get; set; }
        [DataMember]
        public ObservableCollection<Oeuvre> ListeOeuvrePourPlusTard { get; set; }
        [DataMember]
        public ObservableCollection<Oeuvre> ListeOeuvreFavorites { get; set; }
        [DataMember]
        public Dictionary<string,int> notesOeuvres { get; set; }
        [DataMember]
        public Dictionary<string,int> episodesVus { get; set; }

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
            notesOeuvres = new Dictionary<string, int>();
            episodesVus = new Dictionary<string, int>();
        }

        public Utilisateur() {
            ListeOeuvreEnVisionnage = new ObservableCollection<Oeuvre>();
            ListeOeuvreDejaVu = new ObservableCollection<Oeuvre>();
            ListeOeuvrePourPlusTard = new ObservableCollection<Oeuvre>();
            ListeOeuvreFavorites = new ObservableCollection<Oeuvre>();
            notesOeuvres = new Dictionary<string, int>();
            episodesVus = new Dictionary<string, int>();
        }

        public void SupprimerUtilisateur()
        {
            this.nom = null;
            this.prenom = null;
            this.age = 0;
        }
    }
}