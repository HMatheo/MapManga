///// \brief Fichier pour la classe Liste
///// \author HERSAN Mathéo, JOURDY Vianney
/// \file Liste.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Liste
    {
        public string Nom { get; private set; }
        public int NbAnime { get; private set; }
        public Oeuvre[]? AnimeListe { get; private set; }

        public Liste(string nom, int nbAnime)
        {
            Nom = nom;
            NbAnime = nbAnime;
            AnimeListe = null;
        }
    }
}
