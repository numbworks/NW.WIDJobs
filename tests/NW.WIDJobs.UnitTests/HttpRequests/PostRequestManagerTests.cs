using NUnit.Framework;
using System;
using NW.WIDJobs.HttpRequests;
using System.Net;
using System.Text;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class PostRequestManagerTests
    {

        #region Fields

        private static TestCaseData[] postRequestManagerExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PostRequestManager(null, null, null, null, null, null, null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("httpWebRequestFactory").Message
            ).SetArgDisplayNames($"{nameof(postRequestManagerExceptionTestCases)}_01")

        };
        private static TestCaseData[] sendExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PostRequestManager().Send(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("url").Message
            ).SetArgDisplayNames($"{nameof(sendExceptionTestCases)}_01")

        };

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCaseSource(nameof(postRequestManagerExceptionTestCases))]
        public void PostRequestManager_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(sendExceptionTestCases))]
        public void Send_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void PostRequestManager_ShouldCreateAnObjectOfTypePostRequestManager_WhenInvoked()
        {

            // Arrange
            HttpWebRequestFactory httpWebRequestFactory = new HttpWebRequestFactory();

            // Act
            PostRequestManager actual = new PostRequestManager(httpWebRequestFactory, null, null, null, null, null, null);

            // Assert
            Assert.IsInstanceOf<PostRequestManager>(actual);
            Assert.AreEqual("POST", actual.Method);
            Assert.AreEqual(httpWebRequestFactory, actual.HttpWebRequestFactory);
            Assert.AreEqual(null, actual.Headers);
            Assert.AreEqual(null, actual.ContentType);
            Assert.AreEqual(null, actual.CookieContainer);
            Assert.AreEqual(HttpVersion.Version11, actual.ProtocolVersion);
            Assert.AreEqual(null, actual.PostData);
            Assert.AreEqual(Encoding.ASCII, actual.PostDataEncoding);

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
    Last Update: 02.09.2021
*/
