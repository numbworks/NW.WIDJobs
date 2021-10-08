using NUnit.Framework;
using System;
using NW.WIDJobs.HttpRequests;
using System.Net;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class GetRequestManagerTests
    {

        #region Fields

        private static TestCaseData[] getRequestManagerExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new GetRequestManager(null, null, null, null, null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("httpWebRequestFactory").Message
            ).SetArgDisplayNames($"{nameof(getRequestManagerExceptionTestCases)}_01")

        };
        private static TestCaseData[] sendExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new GetRequestManager().Send(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("url").Message
            ).SetArgDisplayNames($"{nameof(sendExceptionTestCases)}_01")

        };

        #endregion

        #region SetUp
        #endregion

        #region Tests

        [TestCaseSource(nameof(getRequestManagerExceptionTestCases))]
        public void GetRequestManager_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(sendExceptionTestCases))]
        public void Send_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void GetRequestManager_ShouldCreateAnObjectOfTypeGetRequestManager_WhenInvoked()
        {

            // Arrange
            HttpWebRequestFactory httpWebRequestFactory = new HttpWebRequestFactory();

            // Act
            GetRequestManager actual = new GetRequestManager(httpWebRequestFactory, null, null, null, null);

            // Assert
            Assert.IsInstanceOf<GetRequestManager>(actual);
            Assert.AreEqual("GET", actual.Method);
            Assert.AreEqual(httpWebRequestFactory, actual.HttpWebRequestFactory);
            Assert.AreEqual(null, actual.Headers);
            Assert.AreEqual(null, actual.ContentType);
            Assert.AreEqual(null, actual.CookieContainer);
            Assert.AreEqual(HttpVersion.Version11, actual.ProtocolVersion);


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
