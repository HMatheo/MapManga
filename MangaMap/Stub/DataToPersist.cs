using System;
using MangaMap.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MangaMap.Stub
{
    //Cette classe permet de définir ce qui doit être enregistrer par la persistance.
    public class DataToPersist
    {
        public ObservableCollection<Oeuvre> Oeuvres { get; set; } = new ObservableCollection<Oeuvre>();
        public List<Utilisateur> Utilisateurs { get; set; } = new List<Utilisateur>();
        
    }
}
