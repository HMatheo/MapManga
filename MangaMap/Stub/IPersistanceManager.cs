using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangaMap.Model;

namespace MangaMap.Stub
{
    public interface IPersistanceManager
    {
        (ObservableCollection<Oeuvre>, List<Utilisateur>) chargeDonne();

        void sauvegarder(ObservableCollection<Oeuvre> o, List<Utilisateur> u);
    }
}
