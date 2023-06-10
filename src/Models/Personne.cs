///// \brief Fichier pour la classe Personne
///// \author HERSAN Mathéo, JOURDY Vianney
/// \file Personne.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Représente une personne dans le système de gestion de listes d'anime.
    /// </summary>
    [DataContract]
    public class Personne
    {
        /// <summary>
        /// Obtient ou définit le mot de passe de la personne.
        /// </summary>
        [DataMember]
        public string? MotDePasse { get; set; }

        /// <summary>
        /// Obtient ou définit l'adresse e-mail de la personne.
        /// </summary>
        [DataMember]
        public string? Email { get; set; }

        /// <summary>
        /// Obtient ou définit le pseudo de la personne.
        /// </summary>
        [DataMember]
        public string? Pseudo { get; set; }

        /// <summary>
        /// Modifie le mot de passe de la personne en vérifiant une confirmation.
        /// </summary>
        /// <param name="MotDePasse">Le nouveau mot de passe.</param>
        /// <returns>True si la modification a réussi, False sinon.</returns>
        public bool MofifierMotDePasse(string MotDePasse)
        {
            string ?test = "";
            test = Console.ReadLine();

            if (test == this.MotDePasse)
            {
                this.MotDePasse = MotDePasse.Trim();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Modifie l'adresse e-mail de la personne en vérifiant une confirmation.
        /// </summary>
        /// <param name="Email">La nouvelle adresse e-mail.</param>
        /// <returns>True si la modification a réussi, False sinon.</returns>
        public bool MofifierEmail(string Email)
        {
            string ?test = "";
            test = Console.ReadLine();

            if (test == this.MotDePasse)
            {
                this.Email = Email.Trim();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Modifie le pseudo de la personne en vérifiant une confirmation.
        /// </summary>
        /// <param name="Pseudo">Le nouveau pseudo.</param>
        /// <returns>True si la modification a réussi, False sinon.</returns>
        public bool MofifierPseudo(string Pseudo)
        {
            string ?test = "";
            test = Console.ReadLine();

            if (test == this.MotDePasse)
            {
                this.Pseudo = Pseudo.Trim();
                return true;
            }

            return false;
        }
    }
}
