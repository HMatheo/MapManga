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
        public class DataContractXmlTests
        {
            [Fact]
            public void FileName_Should_HaveDefaultValue()
            {
                // Arrange
                var dataContractXml = new DataContractJson();

                // Assert
                Assert.Equal("SauvegardeDonnees.json", dataContractXml.FileName);
            }

            /// <summary>
            /// Vérifie que la propriété FilePath a la valeur par défaut correspondant au répertoire de base de l'application.
            /// </summary>
            [Fact]
            public void FilePath_Should_HaveDefaultValue()
            {
                // Arrange
                var dataContractXml = new DataContractJson();

                // Assert
                Assert.Equal(Path.Combine(AppDomain.CurrentDomain.BaseDirectory), dataContractXml.FilePath);
            }
        }
    }
}
