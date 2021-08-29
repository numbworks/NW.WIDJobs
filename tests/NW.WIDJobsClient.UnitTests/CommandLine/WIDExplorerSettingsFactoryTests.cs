using NUnit.Framework;
using NW.WIDJobsClient.CommandLine;
using NW.WIDJobs;

namespace NW.WIDJobsClient.UnitTests
{
    [TestFixture]
    public class WIDExplorerSettingsFactoryTests
    {

        #region Fields

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [Test]
        public void WIDExplorerSettingsFactory_ShouldCreateAnObjectOfTypeWIDExplorerSettingsFactory_WhenInvoked()
        {

            // Arrange
            // Act
            WIDExplorerSettingsFactory actual = new WIDExplorerSettingsFactory();

            // Assert
            Assert.IsInstanceOf<WIDExplorerSettingsFactory>(actual);

        }

        [Test]
        public void Create_ShouldCreateAnObjectOfTypeWIDExplorerSettings_WhenNoNullParameters()
        {

            // Arrange
            // Act
            WIDExplorerSettings actual 
                = new WIDExplorerSettingsFactory()
                    .Create(
                        parallelRequests: WIDExplorerSettings.DefaultParallelRequests.ToString(),
                        pauseBetweenRequestsMs: WIDExplorerSettings.DefaultPauseBetweenRequestsMs.ToString(),
                        folderPath: WIDExplorerSettings.DefaultFolderPath,
                        deleteAndRecreateDatabase: WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                        );

            // Assert
            Assert.IsInstanceOf<WIDExplorerSettings>(actual);

        }

        [Test]
        public void Create_ShouldCreateAnObjectOfTypeWIDExplorerSettings_WhenNullParameters()
        {

            // Arrange
            // Act
            WIDExplorerSettings actual = new WIDExplorerSettingsFactory().Create();

            // Assert
            Assert.IsInstanceOf<WIDExplorerSettings>(actual);

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
