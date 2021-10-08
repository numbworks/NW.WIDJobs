using NUnit.Framework;
using System;
using NW.WIDJobs.AsciiBanner;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class AsciiBannerManagerTests
    {

        #region Fields

        private static TestCaseData[] createExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new AsciiBannerManager().Create(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("version").Message
            ).SetArgDisplayNames($"{nameof(createExceptionTestCases)}_01")

        };

        #endregion

        #region SetUp
        #endregion

        #region Tests

        [Test]
        public void Create_ShouldReturnAnAsciiBannerThatContainsProvidedVersion_WhenInvoked()
        {

            // Arrange
            string version = "1.0.0.0";

            // Act
            string actual = new AsciiBannerManager().Create(version);

            // Assert
            StringAssert.Contains(version, actual);

        }

        [TestCaseSource(nameof(createExceptionTestCases))]
        public void Create_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        #endregion

        #region TearDown
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.10.2021
*/
