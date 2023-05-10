using MangaMap.Model;
using System;
using System.Collections.Generic;
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
        public string FilePath2 { get; set; } = Path.Combine(Directory.GetCurrentDirectory(),"//Dossier1_XML");
        public string FilePath { get; set; } = "C:\\Users\\vjour\\UCA\\MapManga\\MangaMap";
        public string FileName { get; set; } = "Test1.xml";

        public (List<Oeuvre>, List<Utilisateur>) chargeDonne()
        {
            var serializer = new DataContractSerializer(typeof(List<Oeuvre>));
            List<Oeuvre> liste;

            using (Stream s = File.OpenRead(Path.Combine(FilePath, FileName)))
            {
                liste = serializer.ReadObject(s) as List<Oeuvre>;
            }

            return (liste, new List<Utilisateur>());
        }

        public void sauvegarder(List<Oeuvre> o, List<Utilisateur> u)
        {
            var serializer = new DataContractSerializer(typeof(List<Oeuvre>));

            if(!Directory.Exists(FilePath))
            {
                Debug.WriteLine("Directory doesn't exist.");
                Directory.CreateDirectory(FilePath);
            }

            /*using (Stream s = File.Create(Path.Combine(FilePath, FileName)))
            {
                serializer.WriteObject(s, o);
            }*/

            var settings = new XmlWriterSettings() { Indent = true };
            using (TextWriter tw = File.CreateText(Path.Combine(FilePath, FileName)))
            {
                using (XmlWriter w = XmlWriter.Create(tw, settings))
                {
                    serializer.WriteObject(w, o); //data to persist
                }
            }
        }
    }
}
