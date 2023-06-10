///// \brief Fichier de test pour la classe DataToPersist.
///// \author HERSAN Mathéo, JOURDY Vianney
/// \file UnitTestDataToPersist.cs

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
        /// Vérifie que la propriété Oeuvres est initialisée et est une instance de ObservableCollection<Oeuvre>.
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
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Oeuvres_Should_BeAssignable(int oeuvresCount)
        {
            // Arrange
            var dataToPersist = new DataToPersist();
            var oeuvres = new ObservableCollection<Oeuvre>();

            // Add oeuvresCount number of oeuvres
            for (int i = 0; i < oeuvresCount; i++)
            {
                oeuvres.Add(new Oeuvre($"Oeuvre{i}", new List<string>(), "Type", "Description", 0, 0, "Affiche"));
            }

            // Act
            dataToPersist.Oeuvres = oeuvres;

            // Assert
            Assert.Equal(oeuvres, dataToPersist.Oeuvres);
        }

        /// <summary>
        /// Vérifie que la propriété Utilisateurs peut être assignée avec une autre liste d'utilisateurs et que la valeur assignée est correcte.
        /// </summary>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Utilisateurs_Should_BeAssignable(int utilisateursCount)
        {
            // Arrange
            var dataToPersist = new DataToPersist();
            var utilisateurs = new List<Utilisateur>();

            // Add utilisateursCount number of utilisateurs
            for (int i = 0; i < utilisateursCount; i++)
            {
                utilisateurs.Add(new Utilisateur());
            }

            // Act
            dataToPersist.Utilisateurs = utilisateurs;

            // Assert
            Assert.Equal(utilisateurs, dataToPersist.Utilisateurs);
        }
    }
}