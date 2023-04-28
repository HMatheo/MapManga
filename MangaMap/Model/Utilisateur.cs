using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaMap.Model
{
    public class Utilisateur
    {
        public string nom { get; private set; }
        public string prenom { get; private set; }
        public int age { get; private set; }

        public Utilisateur(string nom, string prenom, int age)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.age = age;
        }

        public void SupprimerUtilisateur()
        {
            this.nom = null;
            this.prenom = null;
            this.age = 0;
        }
    }
}
