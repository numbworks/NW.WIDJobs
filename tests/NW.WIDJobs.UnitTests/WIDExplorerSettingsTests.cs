using NUnit.Framework;
using System;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class WIDExplorerSettingsTests
    {

        // Fields
        private static TestCaseData[] widExplorerSettingsExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                        () => new WIDExplorerSettings(0, WIDExplorerSettings.DefaultPauseBetweenRequestsMs)
                ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke("parallelRequests")
            ).SetArgDisplayNames($"{nameof(widExplorerSettingsExceptionTestCases)}_01")

        };

        // SetUp
        // Tests
        [Test]
        public void WIDExplorerSettings_ShouldInitializeANewWIDExplorerSettingsObject_WhenProperArguments()
        {

            // Arrange
            ushort parallelRequests = 1;
            uint pauseBetweenRequestsMs = 25000;

            // Act
            WIDExplorerSettings actual = new WIDExplorerSettings(parallelRequests, pauseBetweenRequestsMs);

            // Assert
            Assert.AreEqual(parallelRequests, actual.ParallelRequests);
            Assert.AreEqual(pauseBetweenRequestsMs, actual.PauseBetweenRequestsMs);

        }

        [Test]
        public void WIDExplorerSettings_ShouldInitializeANewWIDExplorerSettingsObject_WhenDefaultConstructor()
        {

            // Arrange
            // Act
            WIDExplorerSettings actual = new WIDExplorerSettings();

            // Assert
            Assert.AreEqual(WIDExplorerSettings.DefaultParallelRequests, actual.ParallelRequests);
            Assert.AreEqual(WIDExplorerSettings.DefaultPauseBetweenRequestsMs, actual.PauseBetweenRequestsMs);

        }

        [TestCaseSource(nameof(widExplorerSettingsExceptionTestCases))]
        public void WIDExplorerSettings_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 15.05.2021
*/
