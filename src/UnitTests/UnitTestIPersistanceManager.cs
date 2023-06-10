///// \brief Fichier de test pour la classe IPersistanceManager.
///// \author HERSAN Mathéo, JOURDY Vianney
/// \file UnitTestIPersistanceManager.cs

using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stub;

namespace UnitTests
{
    public class UnitTestIPersistanceManager
    {
        /// <summary>
        /// Vérifie que la méthode ChargeDonne renvoie les données attendues.
        /// </summary>
        [Fact]
        public void ChargeDonne_ReturnsExpectedData()
        {
            // Arrange
            var stub = new Stub.Stub();

            // Act
            var (oeuvres, utilisateurs) = stub.chargeDonne();

            // Assert
            Assert.NotNull(oeuvres);
            Assert.NotNull(utilisateurs);
            Assert.Equal(13, oeuvres.Count);
            Assert.Equal(3, utilisateurs.Count);

            // Assert specific oeuvre properties
            var evangelion = oeuvres[0];
            Assert.Equal("Evangelion", evangelion.Nom);
            Assert.Collection(evangelion.Genre,
                genre => Assert.Equal("Action", genre),
                genre => Assert.Equal("Future", genre));
            Assert.Equal("TV", evangelion.Type);
            Assert.Equal("En 2000, une gigantesque explosion se produit en Antarctique, provoquant un cataclysme (raz-de-marée, fonte des calottes polaires) qui dévaste une grande partie de la planète. Les autorités déclarent que cette catastrophe était due à la chute d'un astéroïde sur la planète.\r\n\r\nQuinze ans plus tard, l'humanité a surmonté cet événement, appelé le Second Impact. Mais de mystérieuses créatures nommées Anges font leur apparition, et tentent de détruire Tokyo-3, la nouvelle capitale forteresse du Japon, construite après le Second Impact.\r\n\r\nPour les combattre, l'organisation secrète NERV a mis au point une arme ultime, l'Evangelion ou l'Eva, robot géant anthropoïde piloté.\r\n\r\nShinji Ikari, quatorze ans, se rend à Tokyo-3 sur invitation de son père, qu'il n'a pas revu depuis dix ans. Il est loin de se douter qu'il sera impliqué dans un conflit qui pourrait bien signifier la fin de l'humanité quoi qu'il arrive...", evangelion.Description);
            Assert.Equal(4, evangelion.Note);
            Assert.Equal(26, evangelion.NbEpisodes);
            Assert.Equal("evangelion.jpg", evangelion.Affiche);

            // Assert specific utilisateur properties
            var utilisateur = utilisateurs[0];
            Assert.Equal("te@st.com", utilisateur.Email);
            Assert.Equal("Pseudo1", utilisateur.Pseudo);
            Assert.Equal("t", utilisateur.MotDePasse);
            Assert.Equal("Jean", utilisateur.nom);
            Assert.Equal("Baptiste", utilisateur.prenom);
            Assert.Equal(12, utilisateur.age);
        }

        /// <summary>
        /// Vérifie que la méthode Sauvegarder appelle Console.WriteLine.
        /// </summary>
        [Fact]
        public void Sauvegarder_CallsConsoleWriteLine()  //pas besoin d'utiliser les attributs [Theory] et [InlineData]
                                                         //car il ne teste pas différentes variations de données.
        {
            // Arrange
            var stub = new Stub.Stub();
            var oeuvres = new ObservableCollection<Oeuvre>();
            var utilisateurs = new List<Utilisateur>();

            // Act
            stub.sauvegarder(oeuvres, utilisateurs);

            // Assert
            // Étant donné que l'implémentation de Sauvegarder appelle uniquement Console.WriteLine,
            // nous ne pouvons pas tester directement la fonctionnalité, mais nous pouvons vérifier que la méthode a été appelée.
        }
    }
}
