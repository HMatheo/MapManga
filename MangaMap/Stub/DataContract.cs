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
        public string FileName { get; set; } = "SauvegardeDonnees.xml";
        public string FilePath { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);

        public (List<Oeuvre>, List<Utilisateur>) chargeDonne()
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

        public void sauvegarder(List<Oeuvre> o, List<Utilisateur> u)
        {
            var serializer = new DataContractSerializer(typeof(DataToPersist));
            DataToPersist data;

            if (File.Exists(Path.Combine(FilePath, FileName)))
            {
                using (Stream s = File.OpenRead(Path.Combine(FilePath, FileName)))
                {
                    data = serializer.ReadObject(s) as DataToPersist;
                }
            }
            else
            {
                data = new DataToPersist();
            }

            // Parcourir les nouveaux utilisateurs
            foreach (var newUser in u)
            {
                // Vérifier si un utilisateur avec le même nom d'utilisateur existe déjà
                var existingUser = data.Utilisateurs.FirstOrDefault(user => user.Pseudo == newUser.Pseudo);
                if (existingUser != null)
                {
                    // Mettre à jour les informations de l'utilisateur existant
                    existingUser.MotDePasse = newUser.MotDePasse;
                    existingUser.Email = newUser.Email;
                }
                else
                {
                    // Ajouter le nouvel utilisateur à la liste existante
                    data.Utilisateurs.Add(newUser);
                }
            }

            var settings = new XmlWriterSettings() { Indent = true };
            using (TextWriter tw = File.CreateText(Path.Combine(FilePath, FileName)))
            {
                using (XmlWriter w = XmlWriter.Create(tw, settings))
                {
                    serializer.WriteObject(w, data);   // Enregistrer toutes les données dans le fichier
                }
            }
        }

    }

}