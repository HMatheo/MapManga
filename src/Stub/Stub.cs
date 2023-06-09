using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Stub
{
    /// <summary>
    /// Classe de stub pour la gestion de la persistance des données.
    /// </summary>
    public class Stub : IPersistanceManager
    {
        /// <summary>
        /// Charge un jeu de données en mémoire.
        /// </summary>
        /// <returns>Un tuple contenant la liste des oeuvres et la liste des utilisateurs.</returns>
        public (ObservableCollection<Oeuvre>, List<Utilisateur>) chargeDonne()
        {
            ObservableCollection<Oeuvre> l1 = new ObservableCollection<Oeuvre>();
            List<Utilisateur> l2 = new List<Utilisateur>();

            Utilisateur u1 = new Utilisateur("t", "Pseudo1", "t", "Jean", "Baptiste", 12);
            Utilisateur u2 = new Utilisateur("s", "Pseudo2", "s", "Baptiste", "Jean", 12);
            Utilisateur u3 = new Utilisateur("v", "Pseudo3", "v", "David", "Marc", 12);
            List<string> genres = new List<string>();
            genres.Add("Action");
            genres.Add("Future");
            Oeuvre o1 = new Oeuvre("Evangelion", genres, "TV", "C'est une bonne série", 4, 150, "evangelion.jpg");
            Oeuvre o2 = new Oeuvre("[Oshi No Ko]", genres, "DVD", "A la fin il meurt", 2, 24, "oshinoko.png");
            Oeuvre o3 = new Oeuvre("One Piece", genres, "TV", "C'est la meilleur série du monde, regardez absolument", 2, 24, "onepiece.jpg");
            Oeuvre o4 = new Oeuvre("Naruto", genres, "DVD", "A la fin il meurt pas", 2, 24, "oshinoko.png");
            Oeuvre o5 = new Oeuvre("Vinland Saga", genres, "DVD", "A la fin il meurt peut-être", 2, 24, "oshinoko.png");
            Oeuvre o6 = new Oeuvre("Hell's Paradise", genres, "DVD", "A la fin j'espère il meurt pas", 2, 24, "oshinoko.png");

            l1.Add(o1); l1.Add(o2); l1.Add(o3); l1.Add(o4); l1.Add(o5); l1.Add(o6);
            l2.Add(u1); l2.Add(u2); l2.Add(u3);

            return (l1, l2);
        }

        /// <summary>
        /// Méthode non implémentée pour la sauvegarde des données.
        /// </summary>
        /// <param name="o">La liste des oeuvres à sauvegarder.</param>
        /// <param name="u">La liste des utilisateurs à sauvegarder.</param>
        public void sauvegarder(ObservableCollection<Oeuvre> o, List<Utilisateur> u)
        {
            Console.WriteLine("Méthode sauvegarder() appelée.");
        }
    }
}
