using NUnit.Framework;
using System.Net;
using NW.WIDJobs.HttpRequests;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class HttpWebRequestFactoryTests
    {

        #region Fields
        #endregion

        #region SetUp
        #endregion

        #region Tests

        [Test]
        public void Create_ShouldCreateAnObjectOfTypeHttpWebRequest_WhenInvoked()
        {

            // Arrange
            // Act
            HttpWebRequest actual = new HttpWebRequestFactory().Create("http://www.someurl.com");

            // Assert
            Assert.IsInstanceOf<HttpWebRequest>(actual);

        }

        #endregion

        #region TearDown
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.10.2021
*/
