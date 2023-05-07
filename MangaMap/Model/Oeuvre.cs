using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaMap.Model
{
   public class Oeuvre
    {
        public string Nom { get; private set; }
        public List <string> Genre { get; private set; }
        public string Type { get; private set; }
        public string Description { get; private set; }
        public int Note { get; private set; }
        public int NbEpisodes { get; private set; }
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

        public void AjouterEpisode(int nb)
        {
            NbEpisodes = NbEpisodes + nb;
        }
    }
}
