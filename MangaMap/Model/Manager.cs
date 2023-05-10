using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaMap.Model
{
    public class Manager
    {
        public IPersistanceManager Persistance { get; set; }
        public List<Admin> Admins { get; private set; }
        public List<Utilisateur> Utilisateurs { get; private set; }
        public List<Oeuvre> Oeuvres { get; private set; }

        public Manager(IPersistanceManager Pers) { 
            Admins = new List<Admin>();
            Utilisateurs = new List<Utilisateur>();
            Oeuvres = new List<Oeuvre>();

            Persistance = Pers;
        }

        public Manager()
        {
            Admins = new List<Admin>();
            Utilisateurs = new List<Utilisateur>();
            Oeuvres = new List<Oeuvre>();
        }

        public void charger()
        {
            var donne = Persistance.chargeDonne();
            foreach (var item in donne.Item1)
            {
                Oeuvres.Add(item);
            }
            foreach (var item in donne.Item2)
            {
                Utilisateurs.Add(item);
            }
        }

        public void sauvegarder()
        {
            Persistance.sauvegarder(Oeuvres, Utilisateurs);
        }
    }
}