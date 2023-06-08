using Models;

namespace UnitTests
{
    public class UnitTestUtilisateur
    {
        [Fact]
        public void TestUtilisateur()
        {
            // Arrange
            Utilisateur utilisateur = new Utilisateur("test@test.com", "pseudo", "mdp", "John", "Doe", 30);

            // Act
            utilisateur.SupprimerUtilisateur();

            // Assert
            Assert.Null(utilisateur.nom);
            Assert.Null(utilisateur.prenom);
            Assert.Equal(0, utilisateur.age);
        }

        [Fact]
        public void Utilisateur_DefaultConstructor_SetsPropertiesToDefaultValues()
        {
            // Arrange & Act
            Utilisateur utilisateur = new Utilisateur();

            // Assert
            Assert.Null(utilisateur.nom);
            Assert.Null(utilisateur.prenom);
            Assert.Equal(0, utilisateur.age);
        }

        [Fact]
        public void Utilisateur_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            string email = "test@test.com";
            string pseudo = "pseudo";
            string mdp = "mdp";
            string nom = "John";
            string prenom = "Doe";
            int age = 30;

            // Act
            Utilisateur utilisateur = new Utilisateur(email, pseudo, mdp, nom, prenom, age);

            // Assert
            Assert.Equal(email, utilisateur.Email);
            Assert.Equal(pseudo, utilisateur.Pseudo);
            Assert.Equal(mdp, utilisateur.MotDePasse);
            Assert.Equal(nom, utilisateur.nom);
            Assert.Equal(prenom, utilisateur.prenom);
            Assert.Equal(age, utilisateur.age);
        }
    }
}