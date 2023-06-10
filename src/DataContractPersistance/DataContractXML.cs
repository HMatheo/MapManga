using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataContractPersistance
{
    /// <summary>
    /// Implémentation de l'interface IPersistanceManager utilisant la sérialisation avec DataContract.
    /// </summary>
    public class DataContractXml : IPersistanceManager
    {
        /// <summary>
        /// Obtient ou définit le nom du fichier de sauvegarde XML.
        /// </summary>
        public string FileName { get; set; } = "SauvegardeDonnees.xml";

        /// <summary>
        /// Obtient ou définit le chemin du fichier de sauvegarde xml.
        /// </summary>
        public string FilePath { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

        /// <summary>
        /// Charge les données sauvegardées à partir du fichier xml.
        /// </summary>
        /// <returns>Un tuple contenant la liste des oeuvres et la liste des utilisateurs.</returns>
        public (ObservableCollection<Oeuvre>, List<Utilisateur>) chargeDonne()
        {
            var serializer = new DataContractSerializer(typeof(DataToPersist));
            DataToPersist? data;

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

            
            return (data!.Oeuvres, data.Utilisateurs);
            
        }

        /// <summary>
        /// Sauvegarde les données dans le fichier XML.
        /// </summary>
        /// <param name="o">La liste des oeuvres à sauvegarder.</param>
        /// <param name="u">La liste des utilisateurs à sauvegarder.</param>
        public void sauvegarder(ObservableCollection<Oeuvre> o, List<Utilisateur> u)
        {
            var serializer = new DataContractSerializer(typeof(DataToPersist));

            if (!Directory.Exists(FilePath))
            {
                Debug.WriteLine("Directory doesn't exist.");
                Directory.CreateDirectory(FilePath);
            }

            DataToPersist data = new DataToPersist();
            data.Oeuvres = o;
            data.Utilisateurs = u;

            var settings = new XmlWriterSettings() { Indent = true };
            using (TextWriter tw = File.CreateText(Path.Combine(FilePath, FileName)))
            {
                using (XmlWriter w = XmlWriter.Create(tw, settings))
                {
                    serializer.WriteObject(w, data); // Version d'enregistrement des données avec indentation.
                }
            }
        }
    }
}
