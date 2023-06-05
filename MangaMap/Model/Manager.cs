using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MangaMap.Stub;

namespace MangaMap.Model
{
    public class Manager : System.ComponentModel.INotifyPropertyChanged
    {
        

        public IPersistanceManager Persistance { get; set; }
        public List<Admin> Admins { get; private set; }
        public List<Utilisateur> Utilisateurs { get; private set; }

        private ObservableCollection<Oeuvre> oeuvres;

        public ObservableCollection<Oeuvre> Oeuvres 
        { 
            get
            {
                return oeuvres;
            }
            set
            {
                oeuvres = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public Utilisateur UtilisateurActuel { get; set; }
        public bool isAdmin { get; set; }

        public Manager(IPersistanceManager Pers) { 
            Admins = new List<Admin>();
            Utilisateurs = new List<Utilisateur>();
            Oeuvres = new ObservableCollection<Oeuvre>();
            UtilisateurActuel = new Utilisateur();
            isAdmin = false;

            Persistance = Pers;
        }

        public Manager()
        {
            Admins = new List<Admin>();
            Utilisateurs = new List<Utilisateur>();
            Oeuvres = new ObservableCollection<Oeuvre>();
            UtilisateurActuel = new Utilisateur();
            isAdmin = false;
        }

        /*public Utilisateur charger()
        {
            var donnees = Persistance.chargeDonne();
            foreach (var item in donnees.Item1)
            {
                Oeuvres.Add(item);
            }
            Utilisateurs.AddRange(donnees.Item2);

            //  récupérer le premier utilisateur de la liste Utilisateurs :
            Utilisateur utilisateurActuel = Utilisateurs.FirstOrDefault();

            return utilisateurActuel; // Renvoyez l'utilisateur actuel
        }*/

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