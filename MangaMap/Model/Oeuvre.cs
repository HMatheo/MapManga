using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MangaMap.Model
{
    [DataContract]
    public class Oeuvre
    {
        [DataMember]
        public string Nom { get; private set; }
        [DataMember]
        public List<string> Genre { get; private set; }
        [DataMember]
        public string Type { get; private set; }
        [DataMember]
        public string Description { get; private set; }
        [DataMember]
        public int Note { get; private set; }
        [DataMember]
        public int NbEpisodes { get; private set; }
        [DataMember]
        public string Affiche { get; private set; }

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

        public Oeuvre(string nom, string type, string description, int nbEpisode, string affiche)
        {
            Nom = nom;
            Type = type;
            Description = description;
            NbEpisodes = nbEpisode;
            Affiche = affiche;
        }

        public void AjouterEpisode(int nb)
        {
            NbEpisodes = NbEpisodes + nb;
        }
    }
}