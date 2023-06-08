using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Interface pour la gestion de la persistance des données.
    /// </summary>
    public interface IPersistanceManager
    {
        /// <summary>
        /// Charge les données persistantes et renvoie les listes des oeuvres et des utilisateurs.
        /// </summary>
        /// <returns>Un tuple contenant la liste des oeuvres et la liste des utilisateurs.</returns>
        (ObservableCollection<Oeuvre>, List<Utilisateur>) chargeDonne();

        /// <summary>
        /// Sauvegarde les listes des oeuvres et des utilisateurs.
        /// </summary>
        /// <param name="o">La liste des oeuvres à sauvegarder.</param>
        /// <param name="u">La liste des utilisateurs à sauvegarder.</param>
        void sauvegarder(ObservableCollection<Oeuvre> o, List<Utilisateur> u);
    }
}
