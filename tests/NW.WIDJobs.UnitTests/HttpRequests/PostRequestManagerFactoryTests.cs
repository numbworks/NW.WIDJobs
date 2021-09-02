using NUnit.Framework;
using NW.WIDJobs.HttpRequests;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class PostRequestManagerFactoryTests
    {

        #region Fields
        #endregion

        #region SetUp

        #endregion

        #region Tests

        [Test]
        public void PostRequestManagerFactory_ShouldCreateAnObjectOfTypeIPostRequestManager_WhenInvoked()
        {

            // Arrange
            // Act
            IPostRequestManager actual = new PostRequestManagerFactory().Create(null, null, null, null, null, null, null);

            // Assert
            Assert.IsInstanceOf<IPostRequestManager>(actual);

        }

        #endregion

        #region TearDown

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 02.09.2021
*/
