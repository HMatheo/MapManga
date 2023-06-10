///// \brief Fichier de test pour la classe Utilisateur.
///// \author HERSAN Math�o, JOURDY Vianney
/// \file UnitTestUtilisateur.cs

using Models;

namespace UnitTests
{
    public class UnitTestUtilisateur
    {
        /// <summary>
        /// V�rifie que le constructeur de la classe Utilisateur initialise correctement les propri�t�s.
        /// </summary>
        /// <param name="email">L'adresse e-mail de l'utilisateur.</param>
        /// <param name="pseudo">Le pseudo de l'utilisateur.</param>
        /// <param name="mdp">Le mot de passe de l'utilisateur.</param>
        /// <param name="nom">Le nom de l'utilisateur.</param>
        /// <param name="prenom">Le pr�nom de l'utilisateur.</param>
        /// <param name="age">L'�ge de l'utilisateur.</param>
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

        /// <summary>
        /// V�rifie que la m�thode SupprimerUtilisateur r�initialise les propri�t�s de l'utilisateur � null.
        /// </summary>
        /// <param name="utilisateur">L'utilisateur � supprimer.</param>
        // Utilisez [MemberData] pour des jeux de donn�es dynamiques
        [Theory]
        [MemberData(nameof(UtilisateursTestData.GetTestData), MemberType = typeof(UtilisateursTestData))]
        public void Utilisateur_SupprimerUtilisateur_SetsPropertiesToNull(Utilisateur utilisateur)
        {
            // Arrange (pas besoin de l'acte car l'objet est fourni par les donn�es)

            // Act
            utilisateur.SupprimerUtilisateur();

            // Assert
            Assert.Null(utilisateur.nom);
            Assert.Null(utilisateur.prenom);
            Assert.Equal(0, utilisateur.age);
        }
    }

    /// <summary>
    /// Classe de donn�es pour les tests de la classe Utilisateur.
    /// </summary>
    public class UtilisateursTestData
    {
        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { new Utilisateur("test@test.com", "pseudo", "mdp", "John", "Doe", 30) };
            yield return new object[] { new Utilisateur("test2@test.com", "pseudo2", "mdp2", "Jane", "Smith", 25) };
        }
    }
}
