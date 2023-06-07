using MangaMap.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace MangaMap.Stub
{
    /// <summary>
    /// Implémentation de l'interface IPersistanceManager utilisant la sérialisation avec DataContract.
    /// </summary>
    public class DataContractJSON : IPersistanceManager
    {
        /// <summary>
        /// Obtient ou définit le nom du fichier de sauvegarde JSON.
        /// </summary>
        public string FileName { get; set; } = "SauvegardeDonnees.json";

        /// <summary>
        /// Obtient ou définit le chemin du fichier de sauvegarde JSON.
        /// </summary>
        public string FilePath { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

        /// <summary>
        /// Charge les données sauvegardées à partir du fichier JSON.
        /// </summary>
        /// <returns>Un tuple contenant la liste des oeuvres et la liste des utilisateurs.</returns>
        public (ObservableCollection<Oeuvre>, List<Utilisateur>) chargeDonne()
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(DataToPersist));

            DataToPersist data;

            using (FileStream stream2 = File.OpenRead(Path.Combine(FilePath, FileName)))
            {
                data = jsonSerializer.ReadObject(stream2) as DataToPersist;
            }

            return (data.Oeuvres, data.Utilisateurs);
        }

        /// <summary>
        /// Sauvegarde les données dans le fichier JSON.
        /// </summary>
        /// <param name="o">La liste des oeuvres à sauvegarder.</param>
        /// <param name="u">La liste des utilisateurs à sauvegarder.</param>
        public void sauvegarder(ObservableCollection<Oeuvre> o, List<Utilisateur> u)
        {
            DataToPersist data = new DataToPersist();
            data.Oeuvres = o;
            data.Utilisateurs = u;

            if (!Directory.Exists(FilePath))
            {
                Debug.WriteLine("Directory doesn't exist.");
                Directory.CreateDirectory(FilePath);
            }

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(DataToPersist));
            using (FileStream stream = File.Create(Path.Combine(FilePath, FileName)))
            {
                using (var writer = JsonReaderWriterFactory.CreateJsonWriter(
                            stream,
                            System.Text.Encoding.UTF8,
                            false,
                            true))//<- this boolean says that we sant indentation
                {
                    jsonSerializer.WriteObject(writer, data);
                    writer.Flush();
                }
            }
        }
    }
}
