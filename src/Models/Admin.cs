///// \brief Fichier pour la classe Admin
///// \author HERSAN Mathéo, JOURDY Vianney
/// \file Admin.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Représente un administrateur dans le système de gestion de listes d'anime.
    /// </summary>
    public class Admin : Personne
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe Admin avec les informations spécifiées.
        /// </summary>
        /// <param name="motDePasse">Le mot de passe de l'administrateur.</param>
        /// <param name="email">L'adresse e-mail de l'administrateur.</param>
        /// <param name="pseudo">Le pseudo de l'administrateur.</param>
        public Admin(string motDePasse, string email, string pseudo)
        {
            MotDePasse = motDePasse;
            Email = email;
            Pseudo = pseudo;
        }

        /// <summary>
        /// Méthode permettant d'ajouter un anime.
        /// </summary>
        static void ajouterAnime() { }

        /// <summary>
        /// Méthode permettant de supprimer un anime.
        /// </summary>
        static void supprimerAnime() { }
    }
}
