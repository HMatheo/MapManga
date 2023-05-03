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
    }
}
