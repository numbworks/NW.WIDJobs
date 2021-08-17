using System;
using System.Collections.Generic;
using NUnit.Framework;
using NW.WIDJobs.Explorations;
using NW.WIDJobs.Files;
using NW.WIDJobs.Messages;
using NW.WIDJobs.Metrics;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class WIDExplorerTests
    {

        // Fields
        private static TestCaseData[] widExplorerExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer(null, new WIDExplorerSettings(), ObjectMother.WIDExplorer_FakeNowFunction)
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("components").Message
            ).SetArgDisplayNames($"{nameof(widExplorerExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer(new WIDExplorerComponents(), null, ObjectMother.WIDExplorer_FakeNowFunction)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("settings").Message
            ).SetArgDisplayNames($"{nameof(widExplorerExceptionTestCases)}_01"),

        };
        private static TestCaseData[] exploreExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                            .Explore(
                                null, 
                                2, 
                                Stages.Stage1_OnlyMetrics
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(widExplorerExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                            .Explore(
                                ObjectMother.Shared_FakeRunId, 
                                0, 
                                Stages.Stage1_OnlyMetrics
                        )),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke("finalPageNumber")
            ).SetArgDisplayNames($"{nameof(widExplorerExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                            .Explore(
                                null, 
                                ObjectMother.WIDExplorer_FakeNow,
                                Stages.Stage1_OnlyMetrics
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(widExplorerExceptionTestCases)}_03")

        };
        private static TestCaseData[] exploreAllExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                            .ExploreAll(
                                null,
                                Stages.Stage1_OnlyMetrics
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(exploreAllExceptionTestCases)}_01")

        };        
        private static TestCaseData[] extractFromJsonExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                        () => new WIDExplorer().ExtractFromJson((IFileInfoAdapter)null)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jsonFile").Message
            ).SetArgDisplayNames($"{nameof(extractFromJsonExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                        () => new WIDExplorer().ExtractFromJson(ObjectMother.FileManager_FileInfoAdapterDoesntExist)
                    ),
                typeof(ArgumentException),
                MessageCollection.Validator_ProvidedPathDoesntExist.Invoke(ObjectMother.FileManager_FileInfoAdapterDoesntExist)
            ).SetArgDisplayNames($"{nameof(extractFromJsonExceptionTestCases)}_02"),           

            new TestCaseData(
                new TestDelegate(
                        () => new WIDExplorer().ExtractFromJson((string)null)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException("filePath").Message
            ).SetArgDisplayNames($"{nameof(extractFromJsonExceptionTestCases)}_03")

        };
        private static TestCaseData[] saveAsSQLiteExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                                .SaveAsSQLite(
                                    null,
                                    ObjectMother.FileManager_FileInfoAdapterDoesntExist,
                                    true
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingsExtended").Message
            ).SetArgDisplayNames($"{nameof(saveAsSQLiteExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                                .SaveAsSQLite(
                                    ObjectMother.Shared_JobPage01_JobPostingsExtended,
                                    null,
                                    true
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("databaseFile").Message
            ).SetArgDisplayNames($"{nameof(saveAsSQLiteExceptionTestCases)}_02")

        };
        private static TestCaseData[] saveAsJsonExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                                .SaveAsJson(
                                    null,
                                    ObjectMother.FileManager_FileInfoAdapterDoesntExist
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("exploration").Message
            ).SetArgDisplayNames($"{nameof(saveAsJsonExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                                .SaveAsJson(
                                    ObjectMother.Shared_ExplorationStage3,
                                    null
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("jsonFile").Message
            ).SetArgDisplayNames($"{nameof(saveAsJsonExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                                .SaveAsJson(
                                    null,
                                    true,
                                    ObjectMother.FileManager_FileInfoAdapterDoesntExist
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("metricCollection").Message
            ).SetArgDisplayNames($"{nameof(saveAsJsonExceptionTestCases)}_03"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                                .SaveAsJson(
                                    ObjectMother.MetricCollection_ExplorationStage3,
                                    true,
                                    null
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("jsonFile").Message
            ).SetArgDisplayNames($"{nameof(saveAsJsonExceptionTestCases)}_04")

        };
        private static TestCaseData[] convertToJsonExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer().ConvertToJson(null)),
                typeof(ArgumentNullException),
                new ArgumentNullException("exploration").Message
            ).SetArgDisplayNames($"{nameof(convertToJsonExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer().ConvertToJson(null, true)),
                typeof(ArgumentNullException),
                new ArgumentNullException("metricCollection").Message
            ).SetArgDisplayNames($"{nameof(convertToJsonExceptionTestCases)}_02")

        };
        private static TestCaseData[] convertToMetricCollectionExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer().ConvertToMetricCollection(null)),
                typeof(ArgumentNullException),
                new ArgumentNullException("exploration").Message
            ).SetArgDisplayNames($"{nameof(convertToMetricCollectionExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                            .ConvertToMetricCollection
                                (ObjectMother.Shared_ExplorationStage3WithNullJobPostings)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException("JobPostings").Message
            ).SetArgDisplayNames($"{nameof(convertToMetricCollectionExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                            .ConvertToMetricCollection
                                (ObjectMother.Shared_ExplorationStage3WithNullJobPostingsExtended)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException("JobPostingsExtended").Message
            ).SetArgDisplayNames($"{nameof(convertToMetricCollectionExceptionTestCases)}_03")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(widExplorerExceptionTestCases))]
        public void WIDExplorer_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(exploreExceptionTestCases))]
        public void Explore_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(exploreAllExceptionTestCases))]
        public void ExploreAll_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(extractFromJsonExceptionTestCases))]
        public void ExtractFromJson_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(saveAsSQLiteExceptionTestCases))]
        public void SaveAsSQLite_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(saveAsJsonExceptionTestCases))]
        public void SaveAsJson_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(convertToJsonExceptionTestCases))]
        public void ConvertToJson_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(convertToMetricCollectionExceptionTestCases))]
        public void ConvertToMetricCollection_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void ConvertToMetricCollection_ShouldReturnExpectedMetricCollectionObject_WhenProperExploration()
        {

            // Arrange
            // Act
            MetricCollection actual = new WIDExplorer().ConvertToMetricCollection(ObjectMother.Shared_ExplorationStage3);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(ObjectMother.MetricCollection_ExplorationStage3, actual)
                );

        }

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 17.08.2021
*/
