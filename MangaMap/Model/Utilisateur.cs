using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaMap.Model
{
    public class Utilisateur : Personne
    {
        public string nom { get; private set; }
        public string prenom { get; private set; }
        public int age { get; private set; }
        public List<Oeuvre> ListeOeuvreEnVisionnage { get; private set; }
        public List<Oeuvre> ListeOeuvreDejaVu { get; private set; }
        public List<Oeuvre> ListeOeuvrePourPlusTard { get; private set; }
        public List<Oeuvre> ListeOeuvreFavorites { get; private set; }

        public Utilisateur(string email, string pseudo, string mdp, string nom, string prenom, int age)
        {
            Email = email;
            Pseudo = pseudo;
            MotDePasse = mdp;
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
