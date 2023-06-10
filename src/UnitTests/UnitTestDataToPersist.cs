using DataContractPersistance;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class UnitTestDataToPersist
    {
        /// <summary>
        ///  Vérifie que la propriété Oeuvres est initialisée et est une instance de ObservableCollection<Oeuvre>.
        /// </summary>
        [Fact]
        public void Oeuvres_Should_BeInitialized()
        {
            // Arrange
            var dataToPersist = new DataToPersist();

            // Assert
            Assert.NotNull(dataToPersist.Oeuvres);
            Assert.IsType<ObservableCollection<Oeuvre>>(dataToPersist.Oeuvres);
        }

        /// <summary>
        /// Vérifie que la propriété Utilisateurs est initialisée et est une instance de List<Utilisateur>.
        /// </summary>
        [Fact]
        public void Utilisateurs_Should_BeInitialized()
        {
            // Arrange
            var dataToPersist = new DataToPersist();

            // Assert
            Assert.NotNull(dataToPersist.Utilisateurs);
            Assert.IsType<List<Utilisateur>>(dataToPersist.Utilisateurs);
        }

        /// <summary>
        /// Vérifie que la propriété Oeuvres peut être assignée avec une autre collection d'œuvres et que la valeur assignée est correcte.
        /// </summary>
        [Fact]
        public void Oeuvres_Should_BeAssignable()
        {
            // Arrange
            var dataToPersist = new DataToPersist();
            var oeuvres = new ObservableCollection<Oeuvre>
            {
                new Oeuvre("Evangelion", new List<string> { "Action", "Future" }, "TV", "C'est une bonne série", 4, 150, "evangelion.jpg"),
                new Oeuvre("[Oshi No Ko]", new List<string> { "Action", "Future" }, "DVD", "A la fin il meurt", 2, 24, "oshinoko.png"),
            };

            // Act
            dataToPersist.Oeuvres = oeuvres;

            // Assert
            Assert.Equal(oeuvres, dataToPersist.Oeuvres);
        }

        /// <summary>
        /// vérifie que la propriété Utilisateurs peut être assignée avec une autre liste d'utilisateurs et que la valeur assignée est correcte.
        /// </summary>
        [Fact]
        public void Utilisateurs_Should_BeAssignable()
        {
            // Arrange
            var dataToPersist = new DataToPersist();
            var utilisateurs = new List<Utilisateur> { new Utilisateur(), new Utilisateur() };

            // Act
            dataToPersist.Utilisateurs = utilisateurs;

            // Assert
            Assert.Equal(utilisateurs, dataToPersist.Utilisateurs);
        }
    }
}