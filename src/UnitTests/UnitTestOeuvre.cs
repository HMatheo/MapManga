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
        [Fact]
        public void Oeuvre_Constructor_WithAllParameters_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            string nom = "[Oshi No Ko]";
            List<string> genre = new List<string> { "Action", "Drama", "Fantasy" };
            string type = "TV Series";
            string description = "A thrilling anime series.";
            int note = 9;
            int nbEpisodes = 25;
            string affiche = "oshinoko.png";

            // Act
            Oeuvre oeuvre = new Oeuvre(nom, genre, type, description, note, nbEpisodes, affiche);

            // Assert
            Assert.Equal(nom, oeuvre.Nom);
            Assert.Equal(genre, oeuvre.Genre);
            Assert.Equal(type, oeuvre.Type);
            Assert.Equal(description, oeuvre.Description);
            Assert.Equal(note, oeuvre.Note);
            Assert.Equal(nbEpisodes, oeuvre.NbEpisodes);
            Assert.Equal(affiche, oeuvre.Affiche);
        }

        [Fact]
        public void Oeuvre_Constructor_WithRequiredParameters_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            string nom = "One Piece";
            string type = "TV Series";
            string description = "An epic adventure.";
            int nbEpisodes = 1000;
            string affiche = "onepiece.jpg";

            // Act
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

        [Fact]
        public void AjouterEpisode_ShouldIncreaseNbEpisodesByGivenAmount()
        {
            // Arrange
            Oeuvre oeuvre = new Oeuvre("Naruto", "TV Series", "A ninja's journey.", 220, "evangelion.jpg");
            int nbEpisodesToAdd = 50;
            int expectedNbEpisodes = oeuvre.NbEpisodes + nbEpisodesToAdd;

            // Act
            oeuvre.AjouterEpisode(nbEpisodesToAdd);

            // Assert
            Assert.Equal(expectedNbEpisodes, oeuvre.NbEpisodes);
        }

    }
}
