///// \brief Fichier de test pour la classe DataContractXml.
///// \author HERSAN Mathéo, JOURDY Vianney
/// \file UnitTestDataContractXml.cs

using DataContractPersistance;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UnitTests
{
    public class UnitTestDataContractXml
    {
        public class DataContractXmlTests
        {

            /// <summary>
            /// Vérifie que la propriété FileName a la valeur par défaut "SauvegardeDonnees.xml".
            /// </summary>
            [Fact]
            public void FileName_Should_HaveDefaultValue()
            {
                // Arrange
                var dataContractXml = new DataContractXml();

                // Assert
                Assert.Equal("SauvegardeDonnees.xml", dataContractXml.FileName);
            }

            /// <summary>
            /// Vérifie que la propriété FilePath a la valeur par défaut correspondant au répertoire de base de l'application.
            /// </summary>
            [Fact]
            public void FilePath_Should_HaveDefaultValue()
            {
                // Arrange
                var dataContractXml = new DataContractXml();

                // Assert
                Assert.Equal(Path.Combine(AppDomain.CurrentDomain.BaseDirectory), dataContractXml.FilePath);
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
                var dataContractXml = new DataContractXml();

                // Act
                dataContractXml.FilePath = filePath;

                // Assert
                Assert.Equal(filePath, dataContractXml.FilePath);
            }
        }
    }
}
