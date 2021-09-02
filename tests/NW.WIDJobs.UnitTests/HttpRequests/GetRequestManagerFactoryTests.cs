using NUnit.Framework;
using NW.WIDJobs.HttpRequests;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class GetRequestManagerFactoryTests
    {

        #region Fields
        #endregion

        #region SetUp

        #endregion

        #region Tests

        [Test]
        public void GetRequestManagerFactory_ShouldCreateAnObjectOfTypeIGetRequestManager_WhenInvoked()
        {

            // Arrange
            // Act
            IGetRequestManager actual = new GetRequestManagerFactory().Create(null, null, null, null);

            // Assert
            Assert.IsInstanceOf<IGetRequestManager>(actual);

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
