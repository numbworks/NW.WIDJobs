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
                        () => new WIDExplorerSettings(
                                        0, 
                                        WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                                        WIDExplorerSettings.DefaultDatabasePath,
                                        WIDExplorerSettings.DefaultDatabaseName,
                                        WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                                        )
                ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke("parallelRequests")
            ).SetArgDisplayNames($"{nameof(widExplorerSettingsExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                        () => new WIDExplorerSettings(
                                        1,
                                        WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                                        null,
                                        WIDExplorerSettings.DefaultDatabaseName,
                                        WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("databasePath").Message
            ).SetArgDisplayNames($"{nameof(widExplorerSettingsExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                        () => new WIDExplorerSettings(
                                        1,
                                        WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                                        WIDExplorerSettings.DefaultDatabasePath,
                                        null,
                                        WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("databaseName").Message
            ).SetArgDisplayNames($"{nameof(widExplorerSettingsExceptionTestCases)}_03")

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
            WIDExplorerSettings actual 
                = new WIDExplorerSettings(
                            parallelRequests, 
                            pauseBetweenRequestsMs,
                            WIDExplorerSettings.DefaultDatabasePath,
                            WIDExplorerSettings.DefaultDatabaseName,
                            WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                        );

            // Assert
            Assert.AreEqual(parallelRequests, actual.ParallelRequests);
            Assert.AreEqual(pauseBetweenRequestsMs, actual.PauseBetweenRequestsMs);
            Assert.AreEqual(WIDExplorerSettings.DefaultDatabasePath, actual.DatabasePath);
            Assert.AreEqual(WIDExplorerSettings.DefaultDatabaseName, actual.DatabaseName);
            Assert.AreEqual(WIDExplorerSettings.DefaultDeleteAndRecreateDatabase, actual.DeleteAndRecreateDatabase);

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
            Assert.AreEqual(WIDExplorerSettings.DefaultDatabasePath, actual.DatabasePath);
            Assert.AreEqual(WIDExplorerSettings.DefaultDatabaseName, actual.DatabaseName);
            Assert.AreEqual(WIDExplorerSettings.DefaultDeleteAndRecreateDatabase, actual.DeleteAndRecreateDatabase);

        }

        [TestCaseSource(nameof(widExplorerSettingsExceptionTestCases))]
        public void WIDExplorerSettings_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 12.06.2021
*/