using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangaMap.Model;

namespace MangaMap.Stub
{
    public interface IPersistanceManager
    {
        (List<Oeuvre>, List<Utilisateur>) chargeDonne();

        void sauvegarder(List<Oeuvre> o, List<Utilisateur> u);
    }
}
