using System;
using MangaMap.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaMap.Stub
{
    public class DataToPersist
    {
        public List<Oeuvre> Oeuvres { get; set; } = new List<Oeuvre>();
        public List<Utilisateur> Utilisateurs { get; set; } = new List<Utilisateur>();
    }
}
