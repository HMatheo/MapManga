using System;
using MangaMap.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaMap.Stub
{
    //Cette classe permet de définir ce qui doit être enregistrer par la persistance.
    public class DataToPersist
    {
        public List<Oeuvre> Oeuvres { get; set; } = new List<Oeuvre>();
        public List<Utilisateur> Utilisateurs { get; set; } = new List<Utilisateur>();
    }
}
