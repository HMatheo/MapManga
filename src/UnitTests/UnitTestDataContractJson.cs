using DataContractPersistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class UnitTestDataContractJson
    {
        /// <summary>
        /// Vérifie que la propriété FileName a la valeur par défaut "SauvegardeDonnees.json".
        /// </summary>
        public class DataContractJsonTests
        {
            [Fact]
            public void FileName_Should_HaveDefaultValue()
            {
                // Arrange
                var dataContractJson = new DataContractJson();

                // Assert
                Assert.Equal("SauvegardeDonnees.json", dataContractJson.FileName);
            }

            /// <summary>
            /// Vérifie que la propriété FilePath a la valeur par défaut correspondant au répertoire de base de l'application.
            /// </summary>
            [Fact]
            public void FilePath_Should_HaveDefaultValue()
            {
                // Arrange
                var dataContractJson = new DataContractJson();

                // Assert
                Assert.Equal(Path.Combine(AppDomain.CurrentDomain.BaseDirectory), dataContractJson.FilePath);
            }

            /// <summary>
            /// Vérifie que la propriété FilePath peut être assignée avec une autre valeur et que la valeur assignée est correcte.
            /// </summary>
            [Theory]
            [InlineData("C:\\Data\\")]
            [InlineData("D:\\Backup\\")]
            public void FilePath_Should_BeAssignable(string filePath)
            {
                // Arrange
                var dataContractJson = new DataContractJson();

                // Act
                dataContractJson.FilePath = filePath;

                // Assert
                Assert.Equal(filePath, dataContractJson.FilePath);
            }
        }
    }
}
