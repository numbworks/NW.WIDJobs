using NUnit.Framework;
using System;
using NW.WIDJobs.Messages;

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
                                        parallelRequests: 0,
                                        pauseBetweenRequestsMs: WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                                        folderPath: WIDExplorerSettings.DefaultFolderPath,
                                        deleteAndRecreateDatabase: WIDExplorerSettings.DefaultDeleteAndRecreateDatabase,
                                        translateJobPostingOccupation: WIDExplorerSettings.DefaultTranslateJobPostingOccupation,
                                        predictJobPostingLanguage: WIDExplorerSettings.DefaultPredictJobPostingLanguage
                                        )
                ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke("parallelRequests")
            ).SetArgDisplayNames($"{nameof(widExplorerSettingsExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                        () => new WIDExplorerSettings(
                                        parallelRequests: 1,
                                        pauseBetweenRequestsMs: WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                                        folderPath: null,
                                        deleteAndRecreateDatabase: WIDExplorerSettings.DefaultDeleteAndRecreateDatabase,
                                        translateJobPostingOccupation: WIDExplorerSettings.DefaultTranslateJobPostingOccupation,
                                        predictJobPostingLanguage: WIDExplorerSettings.DefaultPredictJobPostingLanguage
                                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("folderPath").Message
            ).SetArgDisplayNames($"{nameof(widExplorerSettingsExceptionTestCases)}_02")

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
                            parallelRequests: parallelRequests,
                            pauseBetweenRequestsMs: pauseBetweenRequestsMs,
                            folderPath: WIDExplorerSettings.DefaultFolderPath,
                            deleteAndRecreateDatabase: WIDExplorerSettings.DefaultDeleteAndRecreateDatabase,
                            translateJobPostingOccupation: WIDExplorerSettings.DefaultTranslateJobPostingOccupation,
                            predictJobPostingLanguage: WIDExplorerSettings.DefaultPredictJobPostingLanguage
                        );

            // Assert
            Assert.AreEqual(parallelRequests, actual.ParallelRequests);
            Assert.AreEqual(pauseBetweenRequestsMs, actual.PauseBetweenRequestsMs);
            Assert.AreEqual(WIDExplorerSettings.DefaultFolderPath, actual.FolderPath);
            Assert.AreEqual(WIDExplorerSettings.DefaultDeleteAndRecreateDatabase, actual.DeleteAndRecreateDatabase);
            Assert.AreEqual(WIDExplorerSettings.DefaultTranslateJobPostingOccupation, actual.TranslateJobPostingOccupation);
            Assert.AreEqual(WIDExplorerSettings.DefaultPredictJobPostingLanguage, actual.PredictJobPostingLanguage);

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
            Assert.AreEqual(WIDExplorerSettings.DefaultFolderPath, actual.FolderPath);
            Assert.AreEqual(WIDExplorerSettings.DefaultDeleteAndRecreateDatabase, actual.DeleteAndRecreateDatabase);
            Assert.AreEqual(WIDExplorerSettings.DefaultTranslateJobPostingOccupation, actual.TranslateJobPostingOccupation);
            Assert.AreEqual(WIDExplorerSettings.DefaultPredictJobPostingLanguage, actual.PredictJobPostingLanguage);

        }

        [TestCaseSource(nameof(widExplorerSettingsExceptionTestCases))]
        public void WIDExplorerSettings_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 10.09.2021
*/