using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaMap.Model
{
    public class Manager
    {

        public List<Admin> Admins { get; private set; }
        public List<Utilisateur> Utilisateurs { get; private set; }
        public List<Oeuvre> Oeuvres { get; private set; }

        public Manager() { 
            Admins = new List<Admin>();
            Utilisateurs = new List<Utilisateur>();
            Oeuvres = new List<Oeuvre>();
        }

        public void ajouterUtilisateur(Utilisateur u)
        {
            Utilisateurs.Add(u);
        }

        public void ajouterAdministrateur(Admin a)
        {
            Admins.Add(a);
        }

        public void ajouterOeuvre(Oeuvre o)
        {
            Oeuvres.Add(o);
        }

        public void charger()
        {
            Utilisateur u1 = new Utilisateur("test@test.ts", "Pseudo1", "MotDePasse123", "Jean", "Baptiste", 12);
            Utilisateur u2 = new Utilisateur("test@test.ts", "Pseudo2", "MotDePasse123", "Baptiste", "Jean", 12);
            Utilisateur u3 = new Utilisateur("test@test.ts", "Pseudo3", "MotDePasse123", "David", "Marc", 12);

            ajouterUtilisateur(u1);
            ajouterUtilisateur(u2);
            ajouterUtilisateur(u3);

            List<string> genres = new List<string>();
            genres.Add("Action");
            genres.Add("Future");
            Oeuvre o1 = new Oeuvre("test",genres, "TV", "C'est une bonne série", 4, 150, "test.jpg");
            Oeuvre o2 = new Oeuvre("test2", genres, "DVD", "A la fin il meurt", 2, 24, "test2.png");

            ajouterOeuvre(o1);
            ajouterOeuvre(o2);
        }
    }
}
