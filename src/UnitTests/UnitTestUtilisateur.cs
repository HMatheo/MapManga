using Models;

namespace UnitTests
{
    public class UnitTestUtilisateur
    {
        [Theory]
        [InlineData("test@test.com", "pseudo", "mdp", "John", "Doe", 30)]
        [InlineData("test2@test.com", "pseudo2", "mdp2", "Jane", "Smith", 25)]
        public void Utilisateur_Constructor_SetsPropertiesCorrectly(string email, string pseudo, string mdp, string nom, string prenom, int age)
        {
            // Arrange & Act
            Utilisateur utilisateur = new Utilisateur(email, pseudo, mdp, nom, prenom, age);

            // Assert
            Assert.Equal(email, utilisateur.Email);
            Assert.Equal(pseudo, utilisateur.Pseudo);
            Assert.Equal(mdp, utilisateur.MotDePasse);
            Assert.Equal(nom, utilisateur.nom);
            Assert.Equal(prenom, utilisateur.prenom);
            Assert.Equal(age, utilisateur.age);
        }

        // Utilisez [MemberData] pour des jeux de données dynamiques
        [Theory]
        [MemberData(nameof(UtilisateursTestData.GetTestData), MemberType = typeof(UtilisateursTestData))]
        public void Utilisateur_SupprimerUtilisateur_SetsPropertiesToNull(Utilisateur utilisateur)
        {
            // Arrange (pas besoin de l'acte car l'objet est fourni par les données)

            // Act
            utilisateur.SupprimerUtilisateur();

            // Assert
            Assert.Null(utilisateur.nom);
            Assert.Null(utilisateur.prenom);
            Assert.Equal(0, utilisateur.age);
        }
    }

    public class UtilisateursTestData
    {
        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { new Utilisateur("test@test.com", "pseudo", "mdp", "John", "Doe", 30) };
            yield return new object[] { new Utilisateur("test2@test.com", "pseudo2", "mdp2", "Jane", "Smith", 25) };
        }
    }
}