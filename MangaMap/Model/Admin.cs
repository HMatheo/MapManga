using MangaMap.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaMap.Model
{
    public class Admin : Personne
    {
        public Admin(string motDePasse, string email, string pseudo)
        {
            MotDePasse = motDePasse;
            Email = email;
            Pseudo = pseudo;
        }

        public int Id { get; private set; }



        public void ajouterAnime() { }

        public void supprimerAnime() { }
    }
}
