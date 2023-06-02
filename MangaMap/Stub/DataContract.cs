using MangaMap.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace MangaMap.Stub
{
    public class DataContract : IPersistanceManager
    {
        public string FileName { get; set; } = "SauvegardeDonnees.xml";
        public string FilePath { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

        public (ObservableCollection<Oeuvre>, List<Utilisateur>) chargeDonne()
        {
            var serializer = new DataContractSerializer(typeof(DataToPersist));
            DataToPersist data;

            if (File.Exists(Path.Combine(FilePath, FileName))) // Vérifiez si le fichier existe
            {
                using (Stream s = File.OpenRead(Path.Combine(FilePath, FileName)))
                {
                    data = serializer.ReadObject(s) as DataToPersist;
                }
            }
            else
            {
                data = new DataToPersist(); // Si le fichier n'existe pas, créez une nouvelle liste
            }

            return (data.Oeuvres, data.Utilisateurs);
        }

        public void sauvegarder(ObservableCollection<Oeuvre> o, List<Utilisateur> u)
        {
            var serializer = new DataContractSerializer(typeof(DataToPersist));

            if (!Directory.Exists(FilePath))
            {
                Debug.WriteLine("Directory doesn't exist.");
                Directory.CreateDirectory(FilePath);
            }

            /*using (Stream s = File.Create(Path.Combine(FilePath, FileName)))
            {
                serializer.WriteObject(s, o);                                           //Version d'enregistrement des données sans indentation.
            }*/

            DataToPersist data = new DataToPersist();
            data.Oeuvres = o;
            data.Utilisateurs = u;

            var settings = new XmlWriterSettings() { Indent = true };
            using (TextWriter tw = File.CreateText(Path.Combine(FilePath, FileName)))
            {
                using (XmlWriter w = XmlWriter.Create(tw, settings))
                {
                    serializer.WriteObject(w, data);                                       //Version d'enregistrement des données avec indentation.
                }
            }
        }
    }

}