using NUnit.Framework;
using NW.WIDJobsClient.CommandLine;
using NW.WIDJobs;

namespace NW.WIDJobsClient.UnitTests
{
    [TestFixture]
    public class WIDExplorerComponentsFactoryTests
    {

        #region Fields

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [Test]
        public void WIDExplorerComponentsFactory_ShouldCreateAnObjectOfTypeWIDExplorerComponentsFactory_WhenInvoked()
        {

            // Arrange
            // Act
            WIDExplorerComponentsFactory actual = new WIDExplorerComponentsFactory();

            // Assert
            Assert.IsInstanceOf<WIDExplorerComponentsFactory>(actual);

        }

        [Test]
        public void CreateDefault_ShouldCreateAnObjectOfTypeWIDExplorerComponents_WhenInvoked()
        {

            // Arrange
            // Act
            WIDExplorerComponents actual = new WIDExplorerComponentsFactory().CreateDefault();

            // Assert
            Assert.IsInstanceOf<WIDExplorerComponents>(actual);

        }

        [Test]
        public void CreateForDemoData_ShouldCreateAnObjectOfTypeWIDExplorerComponents_WhenInvoked()
        {

            // Arrange
            // Act
            WIDExplorerComponents actual = new WIDExplorerComponentsFactory().CreateForDemoData();

            // Assert
            Assert.IsInstanceOf<WIDExplorerComponents>(actual);

        }

        #endregion

        #region TearDown

        #endregion

        #region Support_methods

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 29.08.2021
*/
