using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangaMap.Stub;

namespace MangaMap.Model
{
    public class Manager
    {
        public IPersistanceManager Persistance { get; set; }
        public List<Admin> Admins { get; private set; }
        public List<Utilisateur> Utilisateurs { get; private set; }
        public List<Oeuvre> Oeuvres { get; private set; }

        public Utilisateur UtilisateurActuel { get; set; }

        public Manager(IPersistanceManager Pers) { 
            Admins = new List<Admin>();
            Utilisateurs = new List<Utilisateur>();
            Oeuvres = new List<Oeuvre>();
            UtilisateurActuel = null;

            Persistance = Pers;
        }

        public Manager()
        {
            Admins = new List<Admin>();
            Utilisateurs = new List<Utilisateur>();
            Oeuvres = new List<Oeuvre>();
            UtilisateurActuel = null;
        }

        public void charger()
        {
            var donne = Persistance.chargeDonne();
            foreach (var item in donne.Item1)
            {
                Oeuvres.Add(item);
            }
            Utilisateurs.AddRange(donne.Item2);
        }

        public void sauvegarder()
        {
            Persistance.sauvegarder(Oeuvres, Utilisateurs);
        }
    }
}