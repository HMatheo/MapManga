using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaMap.Model
{
    class Oeuvre
    {
        public string Nom { get; private set; }
        public string[] Genre { get; private set; }
        public string Type { get; private set; }
        public string Description { get; private set; }
        public int Note { get; private set; }
        public int NbEpisodes { get; private set; }

        public Oeuvre(string nom, string[] genre, string type, string description, int note, int nbEpisode)
        {
            Nom = nom;
            Genre = genre;
            Type = type;
            Description = description;
            Note = note;
            NbEpisodes = nbEpisode;
        }

        public void AjouterEpisode(int nb)
        {
            NbEpisodes = NbEpisodes + nb;
        }
    }
}
