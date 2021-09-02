using System.Net;
using NUnit.Framework;
using NW.WIDJobs.Headers;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class HeaderFactoryTests
    {

        #region Fields

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [Test]
        public void Create_ShouldCreateExpectedWebHeaderCollection_WhenInvoked()
        {

            // Arrange
            // Act
            WebHeaderCollection actual = new HeaderFactory().Create();

            // Assert
            Assert.AreEqual(HeaderFactory.DefaultUserAgent, actual[HttpRequestHeader.UserAgent]);

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
