using NUnit.Framework;
using System;
using NW.WIDJobs.JobPostingsExtended;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class BulletPointTests
    {

        #region Fields

        private static TestCaseData[] bulletPointExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new BulletPoint(null, null)
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("text").Message
            ).SetArgDisplayNames($"{nameof(bulletPointExceptionTestCases)}_01")

        };

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCaseSource(nameof(bulletPointExceptionTestCases))]
        public void BulletPoint_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void BulletPoint_ShouldCreateAnObjectOfTypeBulletPoint_WhenInvoked()
        {

            // Arrange
            string text = "You have three years experience in development.";
            string type = null;

            // Act
            BulletPoint actual = new BulletPoint(text, type);

            // Assert
            Assert.IsInstanceOf<BulletPoint>(actual);
            Assert.AreEqual(text, actual.Text);
            Assert.AreEqual(type, actual.Type);

        }

        #endregion

        #region TearDown

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 16.09.2021
*/
