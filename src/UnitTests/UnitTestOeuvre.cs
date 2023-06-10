///// \brief Fichier de test pour la classe Oeuvre.
///// \author HERSAN Mathéo, JOURDY Vianney
/// \file UnitTestOeuvre.cs

using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class UnitTestOeuvre
    {
        /// <summary>
        /// Vérifie que le constructeur de la classe Oeuvre initialise correctement les propriétés avec tous les paramètres.
        /// </summary>
        /// <param name="nom">Le nom de l'œuvre.</param>
        /// <param name="genres">Les genres de l'œuvre.</param>
        /// <param name="type">Le type de l'œuvre.</param>
        /// <param name="description">La description de l'œuvre.</param>
        /// <param name="note">La note de l'œuvre.</param>
        /// <param name="nbEpisodes">Le nombre d'épisodes de l'œuvre.</param>
        /// <param name="affiche">L'affiche de l'œuvre.</param>
        [Theory]
        [InlineData("[Oshi No Ko]", new string[] { "Action", "Drama", "Fantasy" }, "TV Series", "A thrilling anime series.", 9, 25, "oshinoko.png")]
        public void Oeuvre_Constructor_WithAllParameters_ShouldSetPropertiesCorrectly(
            string nom, string[] genres, string type, string description, int note, int nbEpisodes, string affiche)
        {
            // Arrange & Act
            Oeuvre oeuvre = new Oeuvre(nom, new List<string>(genres), type, description, note, nbEpisodes, affiche);

            // Assert
            Assert.Equal(nom, oeuvre.Nom);
            Assert.Equal(new List<string>(genres), oeuvre.Genre);
            Assert.Equal(type, oeuvre.Type);
            Assert.Equal(description, oeuvre.Description);
            Assert.Equal(note, oeuvre.Note);
            Assert.Equal(nbEpisodes, oeuvre.NbEpisodes);
            Assert.Equal(affiche, oeuvre.Affiche);
        }

        /// <summary>
        /// Vérifie que le constructeur de la classe Oeuvre initialise correctement les propriétés avec les paramètres requis.
        /// </summary>
        /// <param name="nom">Le nom de l'œuvre.</param>
        /// <param name="type">Le type de l'œuvre.</param>
        /// <param name="description">La description de l'œuvre.</param>
        /// <param name="nbEpisodes">Le nombre d'épisodes de l'œuvre.</param>
        /// <param name="affiche">L'affiche de l'œuvre.</param>
        [Theory]
        [InlineData("One Piece", "TV Series", "An epic adventure.", 1000, "onepiece.jpg")]
        public void Oeuvre_Constructor_WithRequiredParameters_ShouldSetPropertiesCorrectly(
            string nom, string type, string description, int nbEpisodes, string affiche)
        {
            // Arrange & Act
            Oeuvre oeuvre = new Oeuvre(nom, type, description, nbEpisodes, affiche);

            // Assert
            Assert.Equal(nom, oeuvre.Nom);
            Assert.Empty(oeuvre.Genre);
            Assert.Equal(type, oeuvre.Type);
            Assert.Equal(description, oeuvre.Description);
            Assert.Equal(0, oeuvre.Note);
            Assert.Equal(nbEpisodes, oeuvre.NbEpisodes);
            Assert.Equal(affiche, oeuvre.Affiche);
        }

        /// <summary>
        /// Vérifie que la méthode AjouterEpisode augmente le nombre d'épisodes de l'œuvre du montant donné.
        /// </summary>
        /// <param name="nom">Le nom de l'œuvre.</param>
        /// <param name="type">Le type de l'œuvre.</param>
        /// <param name="description">La description de l'œuvre.</param>
        /// <param name="nbEpisodes">Le nombre d'épisodes de l'œuvre.</param>
        /// <param name="affiche">L'affiche de l'œuvre.</param>
        /// <param name="nbEpisodesToAdd">Le nombre d'épisodes à ajouter.</param>
        [Theory]
        [InlineData("Naruto", "TV Series", "A ninja's journey.", 220, "evangelion.jpg", 50)]
        [InlineData("Dragon Ball", "TV Series", "A Saiyan's story.", 291, "evangelion.jpg", 20)]
        public void AjouterEpisode_ShouldIncreaseNbEpisodesByGivenAmount(
            string nom, string type, string description, int nbEpisodes, string affiche, int nbEpisodesToAdd)
        {
            // Arrange
            Oeuvre oeuvre = new Oeuvre(nom, type, description, nbEpisodes, affiche);
            int expectedNbEpisodes = oeuvre.NbEpisodes + nbEpisodesToAdd;

            // Act
            oeuvre.AjouterEpisode(nbEpisodesToAdd);

            // Assert
            Assert.Equal(expectedNbEpisodes, oeuvre.NbEpisodes);
        }
    }
}
