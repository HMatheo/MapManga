using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MangaMap.Stub
{
    /// <summary>
    /// Classe de données pour la persistance contenant les listes des oeuvres et des utilisateurs.
    /// </summary>
    public class DataToPersist
    {
        /// <summary>
        /// Obtient ou définit la liste des oeuvres à persister.
        /// </summary>
        public ObservableCollection<Oeuvre> Oeuvres { get; set; } = new ObservableCollection<Oeuvre>();

        /// <summary>
        /// Obtient ou définit la liste des utilisateurs à persister.
        /// </summary>
        public List<Utilisateur> Utilisateurs { get; set; } = new List<Utilisateur>();
    }
}
