using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Classe responsable de la gestion globale de l'application de gestion de listes d'anime.
    /// </summary>
    public class Manager : System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Obtient ou définit le gestionnaire de persistance utilisé pour charger et sauvegarder les données.
        /// </summary>
        public IPersistanceManager ?Persistance { get; set; }

        /// <summary>
        /// Obtient la liste des administrateurs de l'application.
        /// </summary>
        public List<Admin> Admins { get; private set; }

        /// <summary>
        /// Obtient la liste des utilisateurs de l'application.
        /// </summary>
        public List<Utilisateur> Utilisateurs { get; private set; }

        private ObservableCollection<Oeuvre> ?oeuvres;

        /// <summary>
        /// Obtient ou définit la collection observable des oeuvres de l'application.
        /// </summary>
        public ObservableCollection<Oeuvre> Oeuvres
        {
            get
            {
                return oeuvres ??= new ObservableCollection<Oeuvre>();
            }
            set
            {
                oeuvres = value;
                OnPropertyChanged();
            }
        }
           
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Obtient ou définit l'utilisateur actuellement connecté à l'application.
        /// </summary>
        public Utilisateur UtilisateurActuel { get; set; }

        /// <summary>
        /// Obtient ou définit une valeur indiquant si l'utilisateur actuel est un administrateur.
        /// </summary>
        public bool isAdmin { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe Manager avec un gestionnaire de persistance spécifié.
        /// </summary>
        /// <param name="Pers">Le gestionnaire de persistance à utiliser.</param>
        public Manager(IPersistanceManager Pers)
        {
            Admins = new List<Admin>();
            Utilisateurs = new List<Utilisateur>();
            Oeuvres = new ObservableCollection<Oeuvre>();
            UtilisateurActuel = new Utilisateur();
            isAdmin = false;

            Persistance = Pers;
        }

        /// <summary>
        /// Initialise une nouvelle instance par défaut de la classe Manager.
        /// </summary>
        public Manager()
        {
            Admins = new List<Admin>();
            Utilisateurs = new List<Utilisateur>();
            Oeuvres = new ObservableCollection<Oeuvre>();
            UtilisateurActuel = new Utilisateur();
            isAdmin = false;
        }

        /// <summary>
        /// Charge les données de l'application à partir du gestionnaire de persistance.
        /// </summary>
        public void charger()
        {
            if (Persistance != null)
            {

                var donne = Persistance.chargeDonne();

                foreach (var item in donne.Item1)
                {
                    Oeuvres.Add(item);
                }
                Utilisateurs.AddRange(donne.Item2);
            }
            
            
        }

        /// <summary>
        /// Sauvegarde les données de l'application en utilisant le gestionnaire de persistance.
        /// </summary>
        public void sauvegarder()
        {
            Persistance?.sauvegarder(Oeuvres, Utilisateurs);
        }
    }
}
