using NUnit.Framework;
using System.Net;
using NW.WIDJobs.HttpRequests;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class HttpWebRequestFactoryTests
    {

        // Fields
        // SetUp
        // Tests
        [Test]
        public void Create_ShouldCreateAnObjectOfTypeHttpWebRequest_WhenInvoked()
        {

            // Arrange
            // Act
            HttpWebRequest actual = new HttpWebRequestFactory().Create("http://www.someurl.com");

            // Assert
            Assert.IsInstanceOf<HttpWebRequest>(actual);

        }

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 15.05.2021
*/
