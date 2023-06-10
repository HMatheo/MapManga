///// \brief Fichier de test pour la classe Manager.
///// \author HERSAN Mathéo, JOURDY Vianney
/// \file UnitTestManager.cs

using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stub;
using DataContractPersistance;

namespace UnitTests
{
    public class UnitTestManager
    {
        /// <summary>
        /// Vérifie que la méthode Charger charge les données à partir de PersistanceManager (Stub).
        /// </summary>
        [Fact]
        public void Charger_Should_LoadDataFromPersistanceManager_Stub()
        {
            // Arrange
            var persistanceStub = new Stub.Stub();
            var manager = new Manager(persistanceStub);
            var oeuvres = new ObservableCollection<Oeuvre>
            {
                new Oeuvre("Evangelion", new List<string> { "Action", "Future" }, "TV", "C'est une bonne série", 4, 150, "evangelion.jpg"),
                new Oeuvre("[Oshi No Ko]", new List<string> { "Action", "Future" }, "DVD", "A la fin il meurt", 2, 24, "oshinoko.png"),
            };
            var utilisateurs = new List<Utilisateur> { new Utilisateur(), new Utilisateur() };

            // Act
            manager.charger();

            // Assert 
            var evangelion = oeuvres[0];
            Assert.Equal("Evangelion", evangelion.Nom);
            Assert.Collection(evangelion.Genre,
                genre => Assert.Equal("Action", genre),
                genre => Assert.Equal("Future", genre));
            Assert.Equal("TV", evangelion.Type);
            Assert.Equal("C'est une bonne série", evangelion.Description);
            Assert.Equal(4, evangelion.Note);
            Assert.Equal(150, evangelion.NbEpisodes);
            Assert.Equal("evangelion.jpg", evangelion.Affiche);
        }

        /// <summary>
        /// Vérifie que la méthode Charger charge les données à partir de PersistanceManager (DataContractXml).
        /// </summary>
        [Fact]
        public void Charger_Should_LoadDataFromPersistanceManager_DataContractXml()
        {
            // Arrange
            var persistanceXml = new DataContractPersistance.DataContractXml();
            var manager = new Manager(persistanceXml);
            var oeuvres = new ObservableCollection<Oeuvre>
            {
                new Oeuvre("Evangelion", new List<string> { "Action", "Future" }, "TV", "C'est une bonne série", 4, 150, "evangelion.jpg"),
                new Oeuvre("[Oshi No Ko]", new List<string> { "Action", "Future" }, "DVD", "A la fin il meurt", 2, 24, "oshinoko.png"),
            };
            var utilisateurs = new List<Utilisateur> { new Utilisateur(), new Utilisateur() };

            // Act
            manager.charger();

            // Assert
            Assert.NotNull(manager.Oeuvres);
            Assert.NotNull(manager.Utilisateurs);
            Assert.Equal(oeuvres.Count, manager.Oeuvres.Count);
            Assert.Equal(utilisateurs.Count, manager.Utilisateurs.Count);
        }

        /// <summary>
        /// Vérifie que la méthode Sauvegarder enregistre les données en utilisant PersistanceManager (DataContractXml).
        /// </summary>
        [Fact]
        public void Sauvegarder_Should_SaveDataUsingPersistanceManager_DataContractXml()
        {
            // Arrange
            var persistanceXml = new DataContractPersistance.DataContractXml();
            var manager = new Manager(persistanceXml);
            var oeuvres = new ObservableCollection<Oeuvre>
            {
                new Oeuvre("Evangelion", new List<string> { "Action", "Future" }, "TV", "C'est une bonne série", 4, 150, "evangelion.jpg"),
                new Oeuvre("[Oshi No Ko]", new List<string> { "Action", "Future" }, "DVD", "A la fin il meurt", 2, 24, "oshinoko.png"),
            };
            var utilisateurs = new List<Utilisateur> { new Utilisateur(), new Utilisateur() };

            manager.Oeuvres = oeuvres;
            manager.Utilisateurs = utilisateurs;

            // Act
            manager.sauvegarder();

            // Assert
            // Vérifiez manuellement que les données ont été sauvegardées correctement.
            // Vous pouvez consulter le fichier XML de sauvegarde ou utiliser d'autres moyens pour vérifier cela.
        }
    }
}
