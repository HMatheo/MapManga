using MangaMap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaMap.Stub
{
    public class Stub : IPersistanceManager

        //Cette classe sert à faire charger un jeu de données qui n'est pas celui enregistrer dans le fichier sur l'ordinateur.
        //Il permet de faire des transistion entre différent moyen de persister.
    {
        public (List<Oeuvre>, List<Utilisateur>) chargeDonne()
        {
            List<Oeuvre> l1 = new List<Oeuvre>();
            List<Utilisateur> l2 = new List<Utilisateur>();

            Utilisateur u1 = new Utilisateur("test@test.ts", "Pseudo1", "MotDePasse123", "Jean", "Baptiste", 12);
            Utilisateur u2 = new Utilisateur("test@test.ts", "Pseudo2", "MotDePasse123", "Baptiste", "Jean", 12);
            Utilisateur u3 = new Utilisateur("test@test.ts", "Pseudo3", "MotDePasse123", "David", "Marc", 12);
            List<string> genres = new List<string>();
            genres.Add("Action");
            genres.Add("Future");
            Oeuvre o1 = new Oeuvre("Evangelion", genres, "TV", "C'est une bonne série", 4, 150, "evangelion.jpg");
            Oeuvre o2 = new Oeuvre("[Oshi No Ko]", genres, "DVD", "A la fin il meurt", 2, 24, "oshinoko.png");

            l1.Add(o1); l1.Add(o2);
            l2.Add(u1); l2.Add(u2); l2.Add(u3);

            return (l1, l2);
        }

        public void sauvegarder(List<Oeuvre> o, List<Utilisateur> u)
        {
            throw new NotImplementedException();
        }
    }
}
