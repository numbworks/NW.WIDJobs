using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using NUnit.Framework;
using NW.WIDJobs.AsciiBanner;
using NW.WIDJobs.Database;
using NW.WIDJobs.Explorations;
using NW.WIDJobs.Filenames;
using NW.WIDJobs.Files;
using NW.WIDJobs.HttpRequests;
using NW.WIDJobs.JobPages;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.JobPostingsExtended;
using NW.WIDJobs.Messages;
using NW.WIDJobs.Metrics;
using NW.WIDJobs.JsonSerializerConverters;
using NW.WIDJobs.Runs;
using NW.WIDJobs.XPath;
using NW.WIDJobs.Headers;
using NW.WIDJobs.Formatting;
using NW.WIDJobs.Classification;
using NW.NGramTextClassification;

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
                    () => new WIDExplorer(null, new WIDExplorerSettings())
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("components").Message
            ).SetArgDisplayNames($"{nameof(widExplorerExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer(new WIDExplorerComponents(), null)
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
                Messages.MessageCollection.Validator_VariableCantBeLessThanOne.Invoke("finalPageNumber")
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
            ).SetArgDisplayNames($"{nameof(widExplorerExceptionTestCases)}_03"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                            .Explore(
                                ObjectMother.Shared_FakeRunId,
                                null,
                                Stages.Stage1_OnlyMetrics
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingId").Message
            ).SetArgDisplayNames($"{nameof(widExplorerExceptionTestCases)}_04")

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
        private static TestCaseData[] loadJobPostingsFromJsonExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                        () => new WIDExplorer().LoadJobPostingsFromJsonFile((IFileInfoAdapter)null)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jsonFile").Message
            ).SetArgDisplayNames($"{nameof(loadJobPostingsFromJsonExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                        () => new WIDExplorer().LoadJobPostingsFromJsonFile(ObjectMother.FileManager_FileInfoAdapterDoesntExist)
                    ),
                typeof(ArgumentException),
                Messages.MessageCollection.Validator_ProvidedPathDoesntExist.Invoke(ObjectMother.FileManager_FileInfoAdapterDoesntExist)
            ).SetArgDisplayNames($"{nameof(loadJobPostingsFromJsonExceptionTestCases)}_02"),           

            new TestCaseData(
                new TestDelegate(
                        () => new WIDExplorer().LoadJobPostingsFromJsonFile((string)null)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException("filePath").Message
            ).SetArgDisplayNames($"{nameof(loadJobPostingsFromJsonExceptionTestCases)}_03")

        };
        private static TestCaseData[] loadExplorationFromJsonExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                        () => new WIDExplorer().LoadExplorationFromJsonFile((IFileInfoAdapter)null)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jsonFile").Message
            ).SetArgDisplayNames($"{nameof(loadExplorationFromJsonExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                        () => new WIDExplorer().LoadExplorationFromJsonFile(ObjectMother.FileManager_FileInfoAdapterDoesntExist)
                    ),
                typeof(ArgumentException),
                Messages.MessageCollection.Validator_ProvidedPathDoesntExist.Invoke(ObjectMother.FileManager_FileInfoAdapterDoesntExist)
            ).SetArgDisplayNames($"{nameof(loadExplorationFromJsonExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                        () => new WIDExplorer().LoadExplorationFromJsonFile((string)null)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException("filePath").Message
            ).SetArgDisplayNames($"{nameof(loadExplorationFromJsonExceptionTestCases)}_03")

        };
        private static TestCaseData[] saveToSQLiteDatabaseExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                                .SaveToSQLiteDatabase(
                                    null,
                                    ObjectMother.FileManager_FileInfoAdapterDoesntExist,
                                    true
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("exploration").Message
            ).SetArgDisplayNames($"{nameof(saveToSQLiteDatabaseExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                                .SaveToSQLiteDatabase(
                                    ObjectMother.Shared_ExplorationStage1,
                                    ObjectMother.FileManager_FileInfoAdapterDoesntExist,
                                    true
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("JobPostings").Message
            ).SetArgDisplayNames($"{nameof(saveToSQLiteDatabaseExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                                .SaveToSQLiteDatabase(
                                    ObjectMother.Shared_ExplorationStage3,
                                    null,
                                    true
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("databaseFile").Message
            ).SetArgDisplayNames($"{nameof(saveToSQLiteDatabaseExceptionTestCases)}_03")

        };
        private static TestCaseData[] saveToJsonFileExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                                .SaveToJsonFile(
                                    (Exploration)null,
                                    ObjectMother.FileManager_FileInfoAdapterExists
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("exploration").Message
            ).SetArgDisplayNames($"{nameof(saveToJsonFileExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                                .SaveToJsonFile(
                                    ObjectMother.Shared_ExplorationStage3,
                                    null
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("jsonFile").Message
            ).SetArgDisplayNames($"{nameof(saveToJsonFileExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                                .SaveToJsonFile(
                                    null,
                                    true,
                                    ObjectMother.FileManager_FileInfoAdapterExists
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("metricCollection").Message
            ).SetArgDisplayNames($"{nameof(saveToJsonFileExceptionTestCases)}_03"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                                .SaveToJsonFile(
                                    ObjectMother.MetricCollection_ExplorationStage3,
                                    true,
                                    null
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("jsonFile").Message
            ).SetArgDisplayNames($"{nameof(saveToJsonFileExceptionTestCases)}_04"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                                .SaveToJsonFile(
                                    (List<LabeledExample>)null,
                                    null
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("labeledExamples").Message
            ).SetArgDisplayNames($"{nameof(saveToJsonFileExceptionTestCases)}_05"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                                .SaveToJsonFile(
                                    new ClassificationManager().GetPreLabeledExamplesForBulletPointType(),
                                    null
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("jsonFile").Message
            ).SetArgDisplayNames($"{nameof(saveToJsonFileExceptionTestCases)}_06")

        };
        private static TestCaseData[] convertToJsonExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer().ConvertToJson(exploration: (Exploration)null)),
                typeof(ArgumentNullException),
                new ArgumentNullException("exploration").Message
            ).SetArgDisplayNames($"{nameof(convertToJsonExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer().ConvertToJson(metricCollection: null, true)),
                typeof(ArgumentNullException),
                new ArgumentNullException("metricCollection").Message
            ).SetArgDisplayNames($"{nameof(convertToJsonExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer().ConvertToJson((List<LabeledExample>)null)),
                typeof(ArgumentNullException),
                new ArgumentNullException("labeledExamples").Message
            ).SetArgDisplayNames($"{nameof(convertToJsonExceptionTestCases)}_03")

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
            ).SetArgDisplayNames($"{nameof(convertToMetricCollectionExceptionTestCases)}_02")

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

        [TestCaseSource(nameof(loadJobPostingsFromJsonExceptionTestCases))]
        public void LoadJobPostingsFromJson_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(loadExplorationFromJsonExceptionTestCases))]
        public void LoadExplorationFromJson_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(saveToSQLiteDatabaseExceptionTestCases))]
        public void SaveToSQLiteDatabase_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(saveToJsonFileExceptionTestCases))]
        public void SaveToJsonFile_ShouldThrowACertainException_WhenUnproperArguments
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
        public void LogAsciiBanner_ShouldReturnLogExpectedAsciiBanner_WhenInvoked()
        {

            // Arrange
            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: WIDExplorerComponents.DefaultNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, new WIDExplorerSettings());

            List<string> expectedLogMessages = new List<string>()
            {

                new AsciiBannerManager().Create(widExplorer.Version)

            };

            // Act
            widExplorer.LogAsciiBanner();

            // Assert
            Assert.AreEqual(expectedLogMessages, fakeLoggerAsciiBanner.Messages);

        }

        [Test]
        public void GetPreLabeledExamplesForBulletPointType_ShouldReturnExpectedLabeledExamplesObjectAndLogExpectedMessages_WhenInvoked()
        {

            // Arrange
            List<LabeledExample> expected = new ClassificationManager().GetPreLabeledExamplesForBulletPointType();
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_RetrievingPreLabeledExamplesForBulletPointType,
                Messages.MessageCollection.WIDExplorer_PreLabeledExamplesForBulletPointTypeRetrieved.Invoke(expected.Count)

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: WIDExplorerComponents.DefaultNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, new WIDExplorerSettings());

            // Act
            List<LabeledExample> actual = widExplorer.GetPreLabeledExamplesForBulletPointType();

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(expected, actual)
                );
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void ConvertToMetricCollection_ShouldReturnExpectedMetricCollectionObjectAndLogExpectedMessages_WhenProperExplorationStage2()
        {

            // Arrange
            MetricCollection expected = ObjectMother.MetricCollection_ExplorationStage2;
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_ConvertingExplorationToMetricCollection,
                Messages.MessageCollection.WIDExplorer_RunIdIs.Invoke(ObjectMother.Shared_ExplorationStage3.RunId),
                Messages.MessageCollection.WIDExplorer_ExplorationConvertedToMetricCollection

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: WIDExplorerComponents.DefaultNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, new WIDExplorerSettings());

            // Act
            MetricCollection actual = widExplorer.ConvertToMetricCollection(ObjectMother.Shared_ExplorationStage2);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(expected, actual)
                );
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void ConvertToMetricCollection_ShouldReturnExpectedMetricCollectionObjectAndLogExpectedMessages_WhenProperExplorationStage3()
        {

            // Arrange
            MetricCollection expected = ObjectMother.MetricCollection_ExplorationStage3;
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_ConvertingExplorationToMetricCollection,
                Messages.MessageCollection.WIDExplorer_RunIdIs.Invoke(ObjectMother.Shared_ExplorationStage3.RunId),
                Messages.MessageCollection.WIDExplorer_ExplorationConvertedToMetricCollection

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: WIDExplorerComponents.DefaultNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, new WIDExplorerSettings());
            
            // Act
            MetricCollection actual = widExplorer.ConvertToMetricCollection(ObjectMother.Shared_ExplorationStage3);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(expected, actual)
                );
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void ConvertToJson_ShouldReturnExpectedStringAndLogExpectedMessages_WhenProperExplorationStage1()
        {

            // Arrange
            string expected = ObjectMother.WIDExplorer_ExplorationStage1AsJson_Content;
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_ConvertingExplorationToJsonString,
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(JavaScriptEncoder.UnsafeRelaxedJsonEscaping)),
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(DateTimeToDateConverter)),
                Messages.MessageCollection.WIDExplorer_VerboseSerializationIs.Invoke(false),
                Messages.MessageCollection.WIDExplorer_ConvertedExplorationToJsonString

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: WIDExplorerComponents.DefaultNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, new WIDExplorerSettings());

            // Act
            string actual = widExplorer.ConvertToJson(ObjectMother.Shared_ExplorationStage1);

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void ConvertToJson_ShouldReturnExpectedStringAndLogExpectedMessages_WhenProperExplorationStage2()
        {

            // Arrange
            string expected = ObjectMother.WIDExplorer_ExplorationStage2AsJson_Content;
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_ConvertingExplorationToJsonString,
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(JavaScriptEncoder.UnsafeRelaxedJsonEscaping)),
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(DateTimeToDateConverter)),
                Messages.MessageCollection.WIDExplorer_VerboseSerializationIs.Invoke(false),
                Messages.MessageCollection.WIDExplorer_ConvertedExplorationToJsonString

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: WIDExplorerComponents.DefaultNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, new WIDExplorerSettings());

            // Act
            string actual = widExplorer.ConvertToJson(ObjectMother.Shared_ExplorationStage2);

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void ConvertToJson_ShouldReturnExpectedStringAndLogExpectedMessages_WhenProperExplorationStage3()
        {

            // Arrange
            string expected = ObjectMother.WIDExplorer_ExplorationStage3AsJson_Content;
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_ConvertingExplorationToJsonString,
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(JavaScriptEncoder.UnsafeRelaxedJsonEscaping)),
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(DateTimeToDateConverter)),
                Messages.MessageCollection.WIDExplorer_VerboseSerializationIs.Invoke(false),
                Messages.MessageCollection.WIDExplorer_ConvertedExplorationToJsonString

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: WIDExplorerComponents.DefaultNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, new WIDExplorerSettings());

            // Act
            string actual = widExplorer.ConvertToJson(ObjectMother.Shared_ExplorationStage3);

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void ConvertToJson_ShouldReturnExpectedStringAndLogExpectedMessages_WhenMetricCollectionStage2AndNumbers()
        {

            // Arrange
            bool numbersAsPercentages = false;
            string expected = ObjectMother.WIDExplorer_ExplorationStage2MetricCollectionNumbersAsJson_Content;
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_ConvertingMetricCollectionToJsonString,
                Messages.MessageCollection.WIDExplorer_NumbersAsPercentagesIs.Invoke(numbersAsPercentages),
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(JavaScriptEncoder.UnsafeRelaxedJsonEscaping)),
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(DateTimeToDateConverter)),
                Messages.MessageCollection.WIDExplorer_ConvertedMetricsCollectionToJsonString

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: WIDExplorerComponents.DefaultNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, new WIDExplorerSettings());

            // Act
            string actual = widExplorer.ConvertToJson(ObjectMother.MetricCollection_ExplorationStage2, numbersAsPercentages);

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void ConvertToJson_ShouldReturnExpectedStringAndLogExpectedMessages_WhenMetricCollectionStage2AndPercentages()
        {

            // Arrange
            bool numbersAsPercentages = true;
            string expected = ObjectMother.WIDExplorer_ExplorationStage2MetricCollectionPercentagesAsJson_Content;
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_ConvertingMetricCollectionToJsonString,
                Messages.MessageCollection.WIDExplorer_NumbersAsPercentagesIs.Invoke(numbersAsPercentages),
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(JavaScriptEncoder.UnsafeRelaxedJsonEscaping)),
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(DateTimeToDateConverter)),
                Messages.MessageCollection.WIDExplorer_ConvertedMetricsCollectionToJsonString

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: WIDExplorerComponents.DefaultNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, new WIDExplorerSettings());

            // Act
            string actual = widExplorer.ConvertToJson(ObjectMother.MetricCollection_ExplorationStage2, numbersAsPercentages);

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void ConvertToJson_ShouldReturnExpectedStringAndLogExpectedMessages_WhenMetricCollectionStage3AndNumbers()
        {

            // Arrange
            bool numbersAsPercentages = false;
            string expected = ObjectMother.WIDExplorer_ExplorationStage3MetricCollectionNumbersAsJson_Content;
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_ConvertingMetricCollectionToJsonString,
                Messages.MessageCollection.WIDExplorer_NumbersAsPercentagesIs.Invoke(numbersAsPercentages),
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(JavaScriptEncoder.UnsafeRelaxedJsonEscaping)),
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(DateTimeToDateConverter)),
                Messages.MessageCollection.WIDExplorer_ConvertedMetricsCollectionToJsonString

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: WIDExplorerComponents.DefaultNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, new WIDExplorerSettings());

            // Act
            string actual = widExplorer.ConvertToJson(ObjectMother.MetricCollection_ExplorationStage3, numbersAsPercentages);

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void ConvertToJson_ShouldReturnExpectedStringAndLogExpectedMessages_WhenMetricCollectionStage3AndPercentages()
        {

            // Arrange
            bool numbersAsPercentages = true;
            string expected = ObjectMother.WIDExplorer_ExplorationStage3MetricCollectionPercentagesAsJson_Content;
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_ConvertingMetricCollectionToJsonString,
                Messages.MessageCollection.WIDExplorer_NumbersAsPercentagesIs.Invoke(numbersAsPercentages),
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(JavaScriptEncoder.UnsafeRelaxedJsonEscaping)),
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(DateTimeToDateConverter)),
                Messages.MessageCollection.WIDExplorer_ConvertedMetricsCollectionToJsonString

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: WIDExplorerComponents.DefaultNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, new WIDExplorerSettings());

            // Act
            string actual = widExplorer.ConvertToJson(ObjectMother.MetricCollection_ExplorationStage3, numbersAsPercentages);

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void ConvertToJson_ShouldReturnExpectedStringAndLogExpectedMessages_WhenProperLabeledExamples()
        {

            // Arrange
            int expectedCount = 395;
            string expected = ObjectMother.WIDExplorer_PreLabeledExamplesForBulletPointTypeAsJson_Content;
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_RetrievingPreLabeledExamplesForBulletPointType,
                Messages.MessageCollection.WIDExplorer_PreLabeledExamplesForBulletPointTypeRetrieved.Invoke(expectedCount),
                Messages.MessageCollection.WIDExplorer_ConvertingLabeledExamplesToJsonString,
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(JavaScriptEncoder.UnsafeRelaxedJsonEscaping)),
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(DateTimeToDateConverter)),
                Messages.MessageCollection.WIDExplorer_ConvertedLabeledExamplesToJsonString

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: WIDExplorerComponents.DefaultNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, new WIDExplorerSettings());

            // Act
            List<LabeledExample> labeledExamples = widExplorer.GetPreLabeledExamplesForBulletPointType();
            string actual = widExplorer.ConvertToJson(labeledExamples);

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void LoadJobPostingsFromJsonFile_ShouldReturnExpectedJobPostingsAndLogExpectedMessages_WhenProperJsonFile()
        {

            // Arrange
            DateTime now = ObjectMother.WIDExplorer_FakeNowFunction.Invoke();
            string runId = new RunIdManager().Create(now);
            ushort pageNumber = 1;
            string content = ObjectMother.Shared_JobPage01_Content;
            IFileInfoAdapter fakeFileInfoAdapter = new FakeFileInfoAdapter(true, ObjectMother.WIDExplorer_JobPage01_FakeFilePath);
            List<JobPosting> expected = new List<JobPosting>()
            {

                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[0], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[1], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[2], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[3], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[4], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[5], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[6], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[7], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[8], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[9], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[10], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[11], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[12], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[13], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[14], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[15], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[16], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[17], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[18], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[19], runId, pageNumber)

            };
            expected = ObjectMother.TranslateOccupations(expected);
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_LoadingJobPostingsFromJsonFile,
                Messages.MessageCollection.WIDExplorer_SomeDefaultValuesUsedJsonFile,
                Messages.MessageCollection.WIDExplorer_RunIdIs.Invoke(runId),
                Messages.MessageCollection.WIDExplorer_PageNumberIs.Invoke(pageNumber),
                Messages.MessageCollection.WIDExplorer_JobPostingsExtractedFromJsonFile.Invoke(expected)

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FakeFileManager(content),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: ObjectMother.WIDExplorer_FakeNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, new WIDExplorerSettings());
            bool compareLanguage = true;

            // Act
            List<JobPosting> actual = widExplorer.LoadJobPostingsFromJsonFile(fakeFileInfoAdapter);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(expected, actual, compareLanguage)
                );
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void LoadJobPostingsFromJsonFile_ShouldReturnExpectedJobPostingsAndLogExpectedMessages_WhenProperFilePath()
        {

            // Arrange
            DateTime now = ObjectMother.WIDExplorer_FakeNowFunction.Invoke();
            string runId = new RunIdManager().Create(now);
            ushort pageNumber = 1;
            string content = ObjectMother.Shared_JobPage01_Content;
            IFileInfoAdapter fakeFileInfoAdapter = new FakeFileInfoAdapter(true, ObjectMother.WIDExplorer_JobPage01_FakeFilePath);
            List<JobPosting> expected = new List<JobPosting>()
            {

                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[0], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[1], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[2], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[3], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[4], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[5], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[6], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[7], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[8], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[9], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[10], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[11], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[12], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[13], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[14], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[15], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[16], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[17], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[18], runId, pageNumber),
                ObjectMother.UpdateRunIdPageNumber(ObjectMother.Shared_JobPage01_JobPostings[19], runId, pageNumber)

            };
            expected = ObjectMother.TranslateOccupations(expected);
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_LoadingJobPostingsFromJsonFile,
                Messages.MessageCollection.WIDExplorer_SomeDefaultValuesUsedJsonFile,
                Messages.MessageCollection.WIDExplorer_RunIdIs.Invoke(runId),
                Messages.MessageCollection.WIDExplorer_PageNumberIs.Invoke(pageNumber),
                Messages.MessageCollection.WIDExplorer_JobPostingsExtractedFromJsonFile.Invoke(expected)

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FakeFileManager(content),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: ObjectMother.WIDExplorer_FakeNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, new WIDExplorerSettings());
            bool compareLanguage = true;

            // Act
            List<JobPosting> actual = widExplorer.LoadJobPostingsFromJsonFile(ObjectMother.WIDExplorer_JobPage01_FakeFilePath);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(expected, actual, compareLanguage)
                );
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void LoadExplorationFromJsonFile_ShouldReturnExpectedExplorationAndLogExpectedMessages_WhenProperJsonFile()
        {

            // Arrange
            string content = ObjectMother.WIDExplorer_ExplorationStage3AsJson_Content;
            IFileInfoAdapter fakeFileInfoAdapter = new FakeFileInfoAdapter(true, ObjectMother.WIDExplorer_FakeJsonFilePath);
            Exploration expected = ObjectMother.ConvertToDeserializedExploration(ObjectMother.Shared_ExplorationStage3);
            List<string> expectedLogMessages = new List<string>()
            {

               Messages.MessageCollection.WIDExplorer_LoadingExplorationFromJsonFile

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FakeFileManager(content),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: WIDExplorerComponents.DefaultNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, new WIDExplorerSettings());
            bool compareLanguage = true;

            // Act
            Exploration actual = widExplorer.LoadExplorationFromJsonFile(fakeFileInfoAdapter);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(expected, actual, compareLanguage)
                );
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void LoadExplorationFromJsonFile_ShouldReturnExpectedExplorationsAndLogExpectedMessages_WhenProperFilePath()
        {

            // Arrange
            string content = ObjectMother.WIDExplorer_ExplorationStage3AsJson_Content;
            IFileInfoAdapter fakeFileInfoAdapter = new FakeFileInfoAdapter(true, ObjectMother.WIDExplorer_FakeJsonFilePath);
            Exploration expected = ObjectMother.ConvertToDeserializedExploration(ObjectMother.Shared_ExplorationStage3);
            List<string> expectedLogMessages = new List<string>()
            {

               Messages.MessageCollection.WIDExplorer_LoadingExplorationFromJsonFile

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FakeFileManager(content),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: WIDExplorerComponents.DefaultNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, new WIDExplorerSettings());
            bool compareLanguage = true;

            // Act
            Exploration actual = widExplorer.LoadExplorationFromJsonFile(ObjectMother.WIDExplorer_FakeJsonFilePath);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(expected, actual, compareLanguage)
                );
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void SaveToJsonFile_ShouldWriteJsonFileToDiskAndLogExpectedMessages_WhenProperMetricCollectionAndFileInfoAdapter()
        {

            // Arrange
            MetricCollection metricCollection = ObjectMother.MetricCollection_ExplorationStage3;
            bool numbersAsPercentages = false;
            IFileInfoAdapter fakeFileInfoAdapter = new FakeFileInfoAdapter(false, ObjectMother.WIDExplorer_FakeJsonFilePath);
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_SavingMetricCollectionToJsonFile,
                Messages.MessageCollection.WIDExplorer_RunIdIs.Invoke(metricCollection.RunId),
                Messages.MessageCollection.WIDExplorer_NumbersAsPercentagesIs.Invoke(numbersAsPercentages),
                Messages.MessageCollection.WIDExplorer_JSONFileIs.Invoke(fakeFileInfoAdapter),

                // ConvertToJson
                Messages.MessageCollection.WIDExplorer_ConvertingMetricCollectionToJsonString,
                Messages.MessageCollection.WIDExplorer_NumbersAsPercentagesIs.Invoke(numbersAsPercentages),
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(JavaScriptEncoder.UnsafeRelaxedJsonEscaping)),
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(DateTimeToDateConverter)),
                Messages.MessageCollection.WIDExplorer_ConvertedMetricsCollectionToJsonString,

                Messages.MessageCollection.WIDExplorer_MetricCollectionSavedToJsonFile

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FakeFileManager(null), // Content is not relevant, we'll just use this fake to simulate writing.
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: WIDExplorerComponents.DefaultNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, new WIDExplorerSettings());

            // Act
            IFileInfoAdapter actual = widExplorer.SaveToJsonFile(metricCollection, numbersAsPercentages, fakeFileInfoAdapter);

            // Assert
            Assert.AreEqual(fakeFileInfoAdapter.FullName, actual.FullName);
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void SaveToJsonFile_ShouldWriteJsonFileToDiskAndLogExpectedMessages_WhenProperMetricCollection()
        {

            // Arrange
            MetricCollection metricCollection = ObjectMother.MetricCollection_ExplorationStage3;
            bool numbersAsPercentages = true;
            DateTime now = ObjectMother.WIDExplorer_FakeNowFunction.Invoke();
            string fakeFullName = new FilenameFactory().CreateForMetricCollectionJson(ObjectMother.WIDExplorer_FakeFolderPath, now, numbersAsPercentages);
            IFileInfoAdapter expected = new FakeFileInfoAdapter(false, fakeFullName);
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_MethodCalledWithoutIFileInfoAdapter.Invoke("SaveToJsonFile"),
                Messages.MessageCollection.WIDExplorer_DefaultValuesCreateIFileInfoAdapter,
                Messages.MessageCollection.WIDExplorer_FolderPathIs.Invoke(ObjectMother.WIDExplorer_FakeFolderPath),
                Messages.MessageCollection.WIDExplorer_NowIs.Invoke(now),

                // SaveToJsonFile
                Messages.MessageCollection.WIDExplorer_SavingMetricCollectionToJsonFile,
                Messages.MessageCollection.WIDExplorer_RunIdIs.Invoke(metricCollection.RunId),
                Messages.MessageCollection.WIDExplorer_NumbersAsPercentagesIs.Invoke(numbersAsPercentages),
                Messages.MessageCollection.WIDExplorer_JSONFileIs.Invoke(expected),

                // ConvertToJson
                Messages.MessageCollection.WIDExplorer_ConvertingMetricCollectionToJsonString,
                Messages.MessageCollection.WIDExplorer_NumbersAsPercentagesIs.Invoke(numbersAsPercentages),
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(JavaScriptEncoder.UnsafeRelaxedJsonEscaping)),
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(DateTimeToDateConverter)),
                Messages.MessageCollection.WIDExplorer_ConvertedMetricsCollectionToJsonString,

                Messages.MessageCollection.WIDExplorer_MetricCollectionSavedToJsonFile


            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerSettings fakeExplorerSettings = new WIDExplorerSettings(
                    parallelRequests: WIDExplorerSettings.DefaultParallelRequests,
                    pauseBetweenRequestsMs: WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                    folderPath: ObjectMother.WIDExplorer_FakeFolderPath,
                    deleteAndRecreateDatabase: WIDExplorerSettings.DefaultDeleteAndRecreateDatabase,
                    translateJobPostingOccupation: WIDExplorerSettings.DefaultTranslateJobPostingOccupation,
                    predictJobPostingLanguage: WIDExplorerSettings.DefaultPredictJobPostingLanguage
                );
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FakeFileManager(null), // Content is not relevant, we'll just use this fake to simulate writing.
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: ObjectMother.WIDExplorer_FakeNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, fakeExplorerSettings);

            // Act
            IFileInfoAdapter actual = widExplorer.SaveToJsonFile(metricCollection, numbersAsPercentages);

            // Assert
            Assert.AreEqual(expected.FullName, actual.FullName);
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void SaveToJsonFile_ShouldWriteJsonFileToDiskAndLogExpectedMessages_WhenProperExplorationAndFileInfoAdapter()
        {

            // Arrange
            Exploration exploration = ObjectMother.Shared_ExplorationStage3;
            IFileInfoAdapter fakeFileInfoAdapter = new FakeFileInfoAdapter(false, ObjectMother.WIDExplorer_FakeJsonFilePath);
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_SavingExplorationToJsonFile,
                Messages.MessageCollection.WIDExplorer_RunIdIs.Invoke(exploration.RunId),
                Messages.MessageCollection.WIDExplorer_JSONFileIs.Invoke(fakeFileInfoAdapter),

                // ConvertToJson
                Messages.MessageCollection.WIDExplorer_ConvertingExplorationToJsonString,
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(JavaScriptEncoder.UnsafeRelaxedJsonEscaping)),
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(DateTimeToDateConverter)),
                Messages.MessageCollection.WIDExplorer_VerboseSerializationIs.Invoke(false),
                Messages.MessageCollection.WIDExplorer_ConvertedExplorationToJsonString,

                Messages.MessageCollection.WIDExplorer_ExplorationSavedToJsonFile

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FakeFileManager(null), // Content is not relevant, we'll just use this fake to simulate writing.
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: WIDExplorerComponents.DefaultNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, new WIDExplorerSettings());

            // Act
            IFileInfoAdapter actual = widExplorer.SaveToJsonFile(exploration, fakeFileInfoAdapter);

            // Assert
            Assert.AreEqual(fakeFileInfoAdapter.FullName, actual.FullName);
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void SaveToJsonFile_ShouldWriteJsonFileToDiskAndLogExpectedMessages_WhenProperExploration()
        {

            // Arrange
            Exploration exploration = ObjectMother.Shared_ExplorationStage3;
            DateTime now = ObjectMother.WIDExplorer_FakeNowFunction.Invoke();
            string fakeFullName = new FilenameFactory().CreateForExplorationJson(ObjectMother.WIDExplorer_FakeFolderPath, now);
            IFileInfoAdapter expected = new FakeFileInfoAdapter(false, fakeFullName);
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_MethodCalledWithoutIFileInfoAdapter.Invoke("SaveToJsonFile"),
                Messages.MessageCollection.WIDExplorer_DefaultValuesCreateIFileInfoAdapter,
                Messages.MessageCollection.WIDExplorer_FolderPathIs.Invoke(ObjectMother.WIDExplorer_FakeFolderPath),
                Messages.MessageCollection.WIDExplorer_NowIs.Invoke(now),

                // SaveToJsonFile
                Messages.MessageCollection.WIDExplorer_SavingExplorationToJsonFile,
                Messages.MessageCollection.WIDExplorer_RunIdIs.Invoke(exploration.RunId),
                Messages.MessageCollection.WIDExplorer_JSONFileIs.Invoke(expected),

                // ConvertToJson
                Messages.MessageCollection.WIDExplorer_ConvertingExplorationToJsonString,
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(JavaScriptEncoder.UnsafeRelaxedJsonEscaping)),
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(DateTimeToDateConverter)),
                Messages.MessageCollection.WIDExplorer_VerboseSerializationIs.Invoke(false),
                Messages.MessageCollection.WIDExplorer_ConvertedExplorationToJsonString,

                Messages.MessageCollection.WIDExplorer_ExplorationSavedToJsonFile

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerSettings fakeExplorerSettings = new WIDExplorerSettings(
                    parallelRequests: WIDExplorerSettings.DefaultParallelRequests,
                    pauseBetweenRequestsMs: WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                    folderPath: ObjectMother.WIDExplorer_FakeFolderPath,
                    deleteAndRecreateDatabase: WIDExplorerSettings.DefaultDeleteAndRecreateDatabase,
                    translateJobPostingOccupation: WIDExplorerSettings.DefaultTranslateJobPostingOccupation,
                    predictJobPostingLanguage: WIDExplorerSettings.DefaultPredictJobPostingLanguage
                );
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FakeFileManager(null), // Content is not relevant, we'll just use this fake to simulate writing.
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: ObjectMother.WIDExplorer_FakeNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, fakeExplorerSettings);

            // Act
            IFileInfoAdapter actual = widExplorer.SaveToJsonFile(exploration);

            // Assert
            Assert.AreEqual(expected.FullName, actual.FullName);
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void SaveToJsonFile_ShouldWriteJsonFileToDiskAndLogExpectedMessages_WhenProperLabeledExamples()
        {

            // Arrange
            List<LabeledExample> labeledExamples = new ClassificationManager().GetPreLabeledExamplesForBulletPointType();
            DateTime now = ObjectMother.WIDExplorer_FakeNowFunction.Invoke();
            string fakeFullName = new FilenameFactory().CreateForBulletPointTypesJson(ObjectMother.WIDExplorer_FakeFolderPath, now);
            IFileInfoAdapter expected = new FakeFileInfoAdapter(false, fakeFullName);
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_MethodCalledWithoutIFileInfoAdapter.Invoke("SaveToJsonFile"),
                Messages.MessageCollection.WIDExplorer_DefaultValuesCreateIFileInfoAdapter,
                Messages.MessageCollection.WIDExplorer_FolderPathIs.Invoke(ObjectMother.WIDExplorer_FakeFolderPath),
                Messages.MessageCollection.WIDExplorer_NowIs.Invoke(now),

                Messages.MessageCollection.WIDExplorer_SavingLabeledExamplesToJsonFile,
                Messages.MessageCollection.WIDExplorer_LabeledExamplesAre.Invoke(labeledExamples.Count),
                Messages.MessageCollection.WIDExplorer_JSONFileIs.Invoke(expected),

                // ConvertToJson
                Messages.MessageCollection.WIDExplorer_ConvertingLabeledExamplesToJsonString,
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(JavaScriptEncoder.UnsafeRelaxedJsonEscaping)),
                Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(DateTimeToDateConverter)),
                Messages.MessageCollection.WIDExplorer_ConvertedLabeledExamplesToJsonString,

                Messages.MessageCollection.WIDExplorer_LabeledExamplesSavedToJsonFile

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerSettings fakeExplorerSettings = new WIDExplorerSettings(
                    parallelRequests: WIDExplorerSettings.DefaultParallelRequests,
                    pauseBetweenRequestsMs: WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                    folderPath: ObjectMother.WIDExplorer_FakeFolderPath,
                    deleteAndRecreateDatabase: WIDExplorerSettings.DefaultDeleteAndRecreateDatabase,
                    translateJobPostingOccupation: WIDExplorerSettings.DefaultTranslateJobPostingOccupation,
                    predictJobPostingLanguage: WIDExplorerSettings.DefaultPredictJobPostingLanguage
                );
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FakeFileManager(null), // Content is not relevant, we'll just use this fake to simulate writing.
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: ObjectMother.WIDExplorer_FakeNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, fakeExplorerSettings);

            // Act
            IFileInfoAdapter actual = widExplorer.SaveToJsonFile(labeledExamples);

            // Assert
            Assert.AreEqual(expected.FullName, actual.FullName);
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void SaveToSQLiteDatabase_ShouldWriteDatabaseFileToDiskAndLogExpectedMessages_WhenProperExplorationAndFileInfoAdapter()
        {

            // Arrange
            Exploration exploration = ObjectMother.Shared_ExplorationStage3;
            bool deleteAndRecreateDatabase = true;
            IFileInfoAdapter fakeFileInfoAdapter = new FakeFileInfoAdapter(false, ObjectMother.WIDExplorer_FakeSQLiteDatabaseFilePath);
            int affectedRows = 467;
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_SavingExplorationToSQLiteDatabase,
                Messages.MessageCollection.WIDExplorer_ExplorationIs.Invoke(exploration),
                Messages.MessageCollection.WIDExplorer_DatabaseFileIs.Invoke(fakeFileInfoAdapter.FullName),
                Messages.MessageCollection.WIDExplorer_DeleteAndRecreateDatabaseIs.Invoke(deleteAndRecreateDatabase),
                Messages.MessageCollection.WIDExplorer_AffectedRowsAre.Invoke(affectedRows),
                Messages.MessageCollection.WIDExplorer_ExplorationSavedToSQLiteDatabase

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new FakeRepositoryFactory(affectedRows),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: WIDExplorerComponents.DefaultNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, new WIDExplorerSettings());

            // Act
            IFileInfoAdapter actual = widExplorer.SaveToSQLiteDatabase(exploration, fakeFileInfoAdapter, deleteAndRecreateDatabase);

            // Assert
            Assert.AreEqual(fakeFileInfoAdapter.FullName, actual.FullName);
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void SaveToSQLiteDatabase_ShouldWriteDatabaseFileToDiskAndLogExpectedMessages_WhenProperExploration()
        {

            // Arrange
            Exploration exploration = ObjectMother.Shared_ExplorationStage3;
            bool deleteAndRecreateDatabase = false;
            DateTime now = ObjectMother.WIDExplorer_FakeNowFunction.Invoke();
            string fakeFullName = new FilenameFactory().CreateForDatabase(ObjectMother.WIDExplorer_FakeFolderPath, now);
            IFileInfoAdapter expected = new FakeFileInfoAdapter(true, fakeFullName);
            int affectedRows = 467;
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_MethodCalledWithoutIFileInfoAdapter.Invoke("SaveToSQLiteDatabase"),
                Messages.MessageCollection.WIDExplorer_DefaultValuesCreateIFileInfoAdapter,
                Messages.MessageCollection.WIDExplorer_FolderPathIs.Invoke(ObjectMother.WIDExplorer_FakeFolderPath),
                Messages.MessageCollection.WIDExplorer_NowIs.Invoke(now),

                // SaveToSQLiteDatabase
                Messages.MessageCollection.WIDExplorer_SavingExplorationToSQLiteDatabase,
                Messages.MessageCollection.WIDExplorer_ExplorationIs.Invoke(exploration),
                Messages.MessageCollection.WIDExplorer_DatabaseFileIs.Invoke(expected.FullName),
                Messages.MessageCollection.WIDExplorer_DeleteAndRecreateDatabaseIs.Invoke(deleteAndRecreateDatabase),
                Messages.MessageCollection.WIDExplorer_AffectedRowsAre.Invoke(affectedRows),
                Messages.MessageCollection.WIDExplorer_ExplorationSavedToSQLiteDatabase

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerSettings fakeExplorerSettings = new WIDExplorerSettings(
                    parallelRequests: WIDExplorerSettings.DefaultParallelRequests,
                    pauseBetweenRequestsMs: WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                    folderPath: ObjectMother.WIDExplorer_FakeFolderPath,
                    deleteAndRecreateDatabase: deleteAndRecreateDatabase,
                    translateJobPostingOccupation: WIDExplorerSettings.DefaultTranslateJobPostingOccupation,
                    predictJobPostingLanguage: WIDExplorerSettings.DefaultPredictJobPostingLanguage
                );
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new FakeRepositoryFactory(affectedRows),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: ObjectMother.WIDExplorer_FakeNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, fakeExplorerSettings);

            // Act
            IFileInfoAdapter actual = widExplorer.SaveToSQLiteDatabase(exploration);

            // Assert
            Assert.AreEqual(expected.FullName, actual.FullName);
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void Explore_ShouldReturnExpectedExplorationObjectAndLogExpectedMessages_WhenFinalPageNumberAndStage1()
        {

            // Arrange
            Stages stage = Stages.Stage1_OnlyMetrics;
            ushort finalPageNumber = 2;
            DateTime now = ObjectMother.WIDExplorer_FakeNowFunction.Invoke();
            string runId = new RunIdManager().Create(now, WIDExplorer.DefaultInitialPageNumber, finalPageNumber);
            ushort parallelRequests = 3;
            uint pauseBetweenRequestsMs = 0;
            Exploration expected = ObjectMother.UpdateRunIds(ObjectMother.Shared_ExplorationStage1, runId);
            
            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_ExplorationStarted,
                Messages.MessageCollection.WIDExplorer_RunIdIs(runId),
                Messages.MessageCollection.WIDExplorer_DefaultInitialPageNumberIs(WIDExplorer.DefaultInitialPageNumber),
                Messages.MessageCollection.WIDExplorer_FinalPageNumberIs(finalPageNumber),
                Messages.MessageCollection.WIDExplorer_StageIs(stage),

                // ProcessStage1
                Messages.MessageCollection.WIDExplorer_ExecutionStageStarted(Stages.Stage1_OnlyMetrics),
                Messages.MessageCollection.WIDExplorer_JobPageSuccessfullyRetrieved.Invoke((ushort)1),
                Messages.MessageCollection.WIDExplorer_TotalResultCountIs(expected.TotalResultCount),
                Messages.MessageCollection.WIDExplorer_TotalJobPagesIs(expected.TotalJobPages),

                Messages.MessageCollection.WIDExplorer_ExplorationCompleted

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerSettings fakeExplorerSettings = new WIDExplorerSettings(
                    parallelRequests: parallelRequests,
                    pauseBetweenRequestsMs: pauseBetweenRequestsMs,
                    folderPath: WIDExplorerSettings.DefaultFolderPath,
                    deleteAndRecreateDatabase: WIDExplorerSettings.DefaultDeleteAndRecreateDatabase,
                    translateJobPostingOccupation: WIDExplorerSettings.DefaultTranslateJobPostingOccupation,
                    predictJobPostingLanguage: WIDExplorerSettings.DefaultPredictJobPostingLanguage
                );
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(postRequestManagerFactory: ObjectMother.WIDExplorer_JobPage0102_FakePostRequestManagerFactory, headerFactory: new HeaderFactory()),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: ObjectMother.WIDExplorer_FakeNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, fakeExplorerSettings);
            bool compareLanguage = true;

            // Act
            Exploration actual = widExplorer.Explore(finalPageNumber, stage);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(expected, actual, compareLanguage)
                );
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void Explore_ShouldReturnExpectedExplorationObjectAndLogExpectedMessages_WhenFinalPageNumberAndStage2()
        {

            // Arrange
            Stages stage = Stages.Stage2_UpToAllJobPostings;
            ushort finalPageNumber = 2;
            DateTime now = ObjectMother.WIDExplorer_FakeNowFunction.Invoke();
            string runId = new RunIdManager().Create(now, WIDExplorer.DefaultInitialPageNumber, finalPageNumber);
            ushort parallelRequests = 3;
            uint pauseBetweenRequestsMs = 0;
            IFormatter formatter = new Formatter();
            Exploration expected = ObjectMother.UpdateRunIds(ObjectMother.Shared_ExplorationStage2, runId);
            expected = ObjectMother.TranslateOccupations(expected);

            // No need to run these thru TranslateOccupations(), we use it only for logging reasons
            List<JobPosting> jobPostingsStage1 = ObjectMother.UpdateRunIds(ObjectMother.Shared_JobPage01_JobPostings, runId);
            List<JobPosting> jobPostingsStage2 = ObjectMother.UpdateRunIds(ObjectMother.Shared_JobPage02_JobPostings, runId);

            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_ExplorationStarted,
                Messages.MessageCollection.WIDExplorer_RunIdIs(runId),
                Messages.MessageCollection.WIDExplorer_DefaultInitialPageNumberIs(WIDExplorer.DefaultInitialPageNumber),
                Messages.MessageCollection.WIDExplorer_FinalPageNumberIs(finalPageNumber),
                Messages.MessageCollection.WIDExplorer_StageIs(Stages.Stage2_UpToAllJobPostings),

                // ProcessStage1
                Messages.MessageCollection.WIDExplorer_ExecutionStageStarted(Stages.Stage1_OnlyMetrics),
                Messages.MessageCollection.WIDExplorer_JobPageSuccessfullyRetrieved.Invoke((ushort)1),
                Messages.MessageCollection.WIDExplorer_TotalResultCountIs(expected.TotalResultCount),
                Messages.MessageCollection.WIDExplorer_TotalJobPagesIs(expected.TotalJobPages),

                // ProcessStage2
                Messages.MessageCollection.WIDExplorer_ExecutionStageStarted(Stages.Stage2_UpToAllJobPostings),
                Messages.MessageCollection.WIDExplorer_AntiFloodingStrategy,
                Messages.MessageCollection.WIDExplorer_ParallelRequestsAre(parallelRequests),
                Messages.MessageCollection.WIDExplorer_PauseBetweenRequestsIs(pauseBetweenRequestsMs),
                formatter.Format(jobPostingsStage1[0]),
                formatter.Format(jobPostingsStage1[1]),
                formatter.Format(jobPostingsStage1[2]),
                formatter.Format(jobPostingsStage1[3]),
                formatter.Format(jobPostingsStage1[4]),
                formatter.Format(jobPostingsStage1[5]),
                formatter.Format(jobPostingsStage1[6]),
                formatter.Format(jobPostingsStage1[7]),
                formatter.Format(jobPostingsStage1[8]),
                formatter.Format(jobPostingsStage1[9]),
                formatter.Format(jobPostingsStage1[10]),
                formatter.Format(jobPostingsStage1[11]),
                formatter.Format(jobPostingsStage1[12]),
                formatter.Format(jobPostingsStage1[13]),
                formatter.Format(jobPostingsStage1[14]),
                formatter.Format(jobPostingsStage1[15]),
                formatter.Format(jobPostingsStage1[16]),
                formatter.Format(jobPostingsStage1[17]),
                formatter.Format(jobPostingsStage1[18]),
                formatter.Format(jobPostingsStage1[19]),
                Messages.MessageCollection.WIDExplorer_JobPageProcessed(1, 2, jobPostingsStage2),
                formatter.Format(jobPostingsStage2[0]),
                formatter.Format(jobPostingsStage2[1]),
                formatter.Format(jobPostingsStage2[2]),
                formatter.Format(jobPostingsStage2[3]),
                formatter.Format(jobPostingsStage2[4]),
                formatter.Format(jobPostingsStage2[5]),
                formatter.Format(jobPostingsStage2[6]),
                formatter.Format(jobPostingsStage2[7]),
                formatter.Format(jobPostingsStage2[8]),
                formatter.Format(jobPostingsStage2[9]),
                formatter.Format(jobPostingsStage2[10]),
                formatter.Format(jobPostingsStage2[11]),
                formatter.Format(jobPostingsStage2[12]),
                formatter.Format(jobPostingsStage2[13]),
                formatter.Format(jobPostingsStage2[14]),
                formatter.Format(jobPostingsStage2[15]),
                formatter.Format(jobPostingsStage2[16]),
                formatter.Format(jobPostingsStage2[17]),
                formatter.Format(jobPostingsStage2[18]),
                formatter.Format(jobPostingsStage2[19]),
                Messages.MessageCollection.WIDExplorer_JobPageProcessed(2, 2, jobPostingsStage2),
                Messages.MessageCollection.WIDExplorer_JobPostingObjectsCreatedTotal(expected.JobPostings),

                Messages.MessageCollection.WIDExplorer_ExplorationCompleted

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerSettings fakeExplorerSettings = new WIDExplorerSettings(
                    parallelRequests: parallelRequests,
                    pauseBetweenRequestsMs: pauseBetweenRequestsMs,
                    folderPath: WIDExplorerSettings.DefaultFolderPath,
                    deleteAndRecreateDatabase: WIDExplorerSettings.DefaultDeleteAndRecreateDatabase,
                    translateJobPostingOccupation: WIDExplorerSettings.DefaultTranslateJobPostingOccupation,
                    predictJobPostingLanguage: WIDExplorerSettings.DefaultPredictJobPostingLanguage
                );
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(postRequestManagerFactory: ObjectMother.WIDExplorer_JobPage0102_FakePostRequestManagerFactory, headerFactory: new HeaderFactory()),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: ObjectMother.WIDExplorer_FakeNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, fakeExplorerSettings);
            bool compareLanguage = true;

            // Act
            Exploration actual = widExplorer.Explore(finalPageNumber, stage);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(expected, actual, compareLanguage)
                );
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void Explore_ShouldReturnExpectedExplorationObjectAndLogExpectedMessages_WhenFinalPageNumberAndStage3()
        {

            // Arrange
            Stages stage = Stages.Stage3_UpToAllJobPostingsExtended;
            ushort finalPageNumber = 2;
            DateTime now = ObjectMother.WIDExplorer_FakeNowFunction.Invoke();
            string runId = new RunIdManager().Create(now, WIDExplorer.DefaultInitialPageNumber, finalPageNumber);
            ushort parallelRequests = 3;
            uint pauseBetweenRequestsMs = 0;
            IFormatter formatter = new Formatter();
            Exploration expected = ObjectMother.UpdateRunIds(ObjectMother.Shared_ExplorationStage3, runId);
            expected = ObjectMother.TranslateOccupations(expected);

            // No need to run these thru TranslateOccupations(), we use it only for logging reasons
            List<JobPosting> jobPostingsStage1 = ObjectMother.UpdateRunIds(ObjectMother.Shared_JobPage01_JobPostings, runId);
            List<JobPosting> jobPostingsStage2 = ObjectMother.UpdateRunIds(ObjectMother.Shared_JobPage02_JobPostings, runId);

            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_ExplorationStarted,
                Messages.MessageCollection.WIDExplorer_RunIdIs(runId),
                Messages.MessageCollection.WIDExplorer_DefaultInitialPageNumberIs(WIDExplorer.DefaultInitialPageNumber),
                Messages.MessageCollection.WIDExplorer_FinalPageNumberIs(finalPageNumber),
                Messages.MessageCollection.WIDExplorer_StageIs(Stages.Stage3_UpToAllJobPostingsExtended),

                // ProcessStage1
                Messages.MessageCollection.WIDExplorer_ExecutionStageStarted(Stages.Stage1_OnlyMetrics),
                Messages.MessageCollection.WIDExplorer_JobPageSuccessfullyRetrieved.Invoke((ushort)1),
                Messages.MessageCollection.WIDExplorer_TotalResultCountIs(expected.TotalResultCount),
                Messages.MessageCollection.WIDExplorer_TotalJobPagesIs(expected.TotalJobPages),

                // ProcessStage2
                Messages.MessageCollection.WIDExplorer_ExecutionStageStarted(Stages.Stage2_UpToAllJobPostings),
                Messages.MessageCollection.WIDExplorer_AntiFloodingStrategy,
                Messages.MessageCollection.WIDExplorer_ParallelRequestsAre(parallelRequests),
                Messages.MessageCollection.WIDExplorer_PauseBetweenRequestsIs(pauseBetweenRequestsMs),
                formatter.Format(jobPostingsStage1[0]),
                formatter.Format(jobPostingsStage1[1]),
                formatter.Format(jobPostingsStage1[2]),
                formatter.Format(jobPostingsStage1[3]),
                formatter.Format(jobPostingsStage1[4]),
                formatter.Format(jobPostingsStage1[5]),
                formatter.Format(jobPostingsStage1[6]),
                formatter.Format(jobPostingsStage1[7]),
                formatter.Format(jobPostingsStage1[8]),
                formatter.Format(jobPostingsStage1[9]),
                formatter.Format(jobPostingsStage1[10]),
                formatter.Format(jobPostingsStage1[11]),
                formatter.Format(jobPostingsStage1[12]),
                formatter.Format(jobPostingsStage1[13]),
                formatter.Format(jobPostingsStage1[14]),
                formatter.Format(jobPostingsStage1[15]),
                formatter.Format(jobPostingsStage1[16]),
                formatter.Format(jobPostingsStage1[17]),
                formatter.Format(jobPostingsStage1[18]),
                formatter.Format(jobPostingsStage1[19]),
                Messages.MessageCollection.WIDExplorer_JobPageProcessed(1, 2, jobPostingsStage2),
                formatter.Format(jobPostingsStage2[0]),
                formatter.Format(jobPostingsStage2[1]),
                formatter.Format(jobPostingsStage2[2]),
                formatter.Format(jobPostingsStage2[3]),
                formatter.Format(jobPostingsStage2[4]),
                formatter.Format(jobPostingsStage2[5]),
                formatter.Format(jobPostingsStage2[6]),
                formatter.Format(jobPostingsStage2[7]),
                formatter.Format(jobPostingsStage2[8]),
                formatter.Format(jobPostingsStage2[9]),
                formatter.Format(jobPostingsStage2[10]),
                formatter.Format(jobPostingsStage2[11]),
                formatter.Format(jobPostingsStage2[12]),
                formatter.Format(jobPostingsStage2[13]),
                formatter.Format(jobPostingsStage2[14]),
                formatter.Format(jobPostingsStage2[15]),
                formatter.Format(jobPostingsStage2[16]),
                formatter.Format(jobPostingsStage2[17]),
                formatter.Format(jobPostingsStage2[18]),
                formatter.Format(jobPostingsStage2[19]),
                Messages.MessageCollection.WIDExplorer_JobPageProcessed(2, 2, jobPostingsStage2),
                Messages.MessageCollection.WIDExplorer_JobPostingObjectsCreatedTotal(expected.JobPostings),

                // ProcessStage3
                Messages.MessageCollection.WIDExplorer_ExecutionStageStarted(Stages.Stage3_UpToAllJobPostingsExtended),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting01),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended01),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting02),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended02),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting03),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended03),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting04),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended04),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting05),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended05),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting06),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended06),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting07),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended07),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting08),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended08),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting09),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended09),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting10),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended10),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting11),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended11),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting12),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended12),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting13),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended13),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting14),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended14),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting15),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended15),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting16),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended16),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting17),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended17),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting18),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended18),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting19),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended19),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage01_JobPosting20),
                formatter.Format(ObjectMother.Shared_JobPage01_JobPostingExtended20),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting01),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended01),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting02),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended02),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting03),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended03),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting04),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended04),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting05),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended05),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting06),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended06),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting07),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended07),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting08),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended08),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting09),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended09),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting10),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended10),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting11),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended11),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting12),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended12),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting13),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended13),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting14),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended14),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting15),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended15),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting16),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended16),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting17),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended17),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting18),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended18),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting19),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended19),
                Messages.MessageCollection.WIDExplorer_JobPostingProcessed(ObjectMother.Shared_JobPage02_JobPosting20),
                formatter.Format(ObjectMother.Shared_JobPage02_JobPostingExtended20),
                Messages.MessageCollection.WIDExplorer_JobPostingExtendedCreatedTotal(expected.JobPostingsExtended),

                Messages.MessageCollection.WIDExplorer_ExplorationCompleted

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerSettings fakeExplorerSettings = new WIDExplorerSettings(
                    parallelRequests: parallelRequests,
                    pauseBetweenRequestsMs: pauseBetweenRequestsMs,
                    folderPath: WIDExplorerSettings.DefaultFolderPath,
                    deleteAndRecreateDatabase: WIDExplorerSettings.DefaultDeleteAndRecreateDatabase,
                    translateJobPostingOccupation: WIDExplorerSettings.DefaultTranslateJobPostingOccupation,
                    predictJobPostingLanguage: WIDExplorerSettings.DefaultPredictJobPostingLanguage
                );
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(postRequestManagerFactory: ObjectMother.WIDExplorer_JobPage0102_FakePostRequestManagerFactory, headerFactory: new HeaderFactory()),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(ObjectMother.WIDExplorer_JobPage0102_FakeGetRequestManagerFactory, new JobPostingExtendedDeserializer(), new HeaderFactory()),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: ObjectMother.WIDExplorer_FakeNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, fakeExplorerSettings);
            bool compareLanguage = true;

            // Act
            Exploration actual = widExplorer.Explore(finalPageNumber, stage);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(expected, actual, compareLanguage)
                );
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void Explore_ShouldReturnExpectedExplorationObjectAndLogExpectedMessages_WhenThresholdDateAndStage2()
        {

            // Arrange
            Stages stage = Stages.Stage2_UpToAllJobPostings;
            DateTime thresholdDate = ObjectMother.Shared_JobPage01Alt_ThresholdDate01;
            DateTime now = ObjectMother.WIDExplorer_FakeNowFunction.Invoke();
            string runId = new RunIdManager().Create(now, thresholdDate);
            ushort parallelRequests = 3;
            uint pauseBetweenRequestsMs = 0;
            List<JobPage> jobPages = new List<JobPage>() 
            {
                ObjectMother.Shared_JobPage01Alt_Object
            };
            jobPages = ObjectMother.UpdateRunIds(jobPages, runId);
            List<JobPosting> jobPostings = ObjectMother.UpdateRunIds(ObjectMother.Shared_JobPage01Alt_RangeForThresholdDate01, runId);
            jobPostings = ObjectMother.TranslateOccupations(jobPostings);

            Exploration expected = new Exploration(
                    runId: runId,
                    totalResultCount: ObjectMother.Shared_JobPage01_TotalResultCount,
                    totalJobPages: ObjectMother.Shared_JobPage01_TotalJobPages,
                    stage: Stages.Stage2_UpToAllJobPostings,
                    isCompleted: true,
                    jobPages: jobPages,
                    jobPostings: jobPostings,
                    jobPostingsExtended: null
                );
            IFormatter formatter = new Formatter();

            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_ExplorationStarted,
                Messages.MessageCollection.WIDExplorer_RunIdIs(runId),
                Messages.MessageCollection.WIDExplorer_DefaultInitialPageNumberIs(WIDExplorer.DefaultInitialPageNumber),
                Messages.MessageCollection.WIDExplorer_ThresholdDateIs(thresholdDate),
                Messages.MessageCollection.WIDExplorer_StageIs(Stages.Stage2_UpToAllJobPostings),

                // ProcessStage1
                Messages.MessageCollection.WIDExplorer_ExecutionStageStarted(Stages.Stage1_OnlyMetrics),
                Messages.MessageCollection.WIDExplorer_JobPageSuccessfullyRetrieved.Invoke((ushort)1),
                Messages.MessageCollection.WIDExplorer_TotalResultCountIs(expected.TotalResultCount),
                Messages.MessageCollection.WIDExplorer_TotalJobPagesIs(expected.TotalJobPages),

                // ProcessStage2WhenThresholdDate
                Messages.MessageCollection.WIDExplorer_ExecutionStageStarted(Stages.Stage2_UpToAllJobPostings),
                Messages.MessageCollection.WIDExplorer_AntiFloodingStrategy,
                Messages.MessageCollection.WIDExplorer_ParallelRequestsAre(parallelRequests),
                Messages.MessageCollection.WIDExplorer_PauseBetweenRequestsIs(pauseBetweenRequestsMs),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting01),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting02),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting03),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting04),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting05),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting06),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting07),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting08),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting09),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting10),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting11),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting12),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting13),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting14),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting15),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting16),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting17),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting18),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting19),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting20),
                Messages.MessageCollection.WIDExplorer_JobPageProcessed(1, expected.TotalJobPages, ObjectMother.Shared_JobPage01Alt_JobPostings),
                Messages.MessageCollection.WIDExplorer_ThresholdDateFoundJobPageNr(thresholdDate, 1),
                Messages.MessageCollection.WIDExplorer_XJobPostingsRemovedJobPageNr(ObjectMother.Shared_JobPage01Alt_RangeForThresholdDate01.Count, 1),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting01),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting02),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting03),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting04),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting05),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting06),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting07),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting08),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting09),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting10),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting11),
                Messages.MessageCollection.WIDExplorer_FinalPageNumberThresholdDate(1),

                Messages.MessageCollection.WIDExplorer_ExplorationCompleted

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerSettings fakeExplorerSettings = new WIDExplorerSettings(
                    parallelRequests: parallelRequests,
                    pauseBetweenRequestsMs: pauseBetweenRequestsMs,
                    folderPath: WIDExplorerSettings.DefaultFolderPath,
                    deleteAndRecreateDatabase: WIDExplorerSettings.DefaultDeleteAndRecreateDatabase,
                    translateJobPostingOccupation: WIDExplorerSettings.DefaultTranslateJobPostingOccupation,
                    predictJobPostingLanguage: WIDExplorerSettings.DefaultPredictJobPostingLanguage
                );
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(postRequestManagerFactory: ObjectMother.WIDExplorer_JobPage01Alt_FakePostRequestManagerFactory, headerFactory: new HeaderFactory()),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: ObjectMother.WIDExplorer_FakeNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, fakeExplorerSettings);
            bool compareLanguage = true;

            // Act
            Exploration actual = widExplorer.Explore(thresholdDate, stage);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(expected, actual, compareLanguage)
                );
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

        [Test]
        public void Explore_ShouldReturnExpectedExplorationObjectAndLogExpectedMessages_WhenJobPostingIdAndStage2()
        {

            // Arrange
            Stages stage = Stages.Stage2_UpToAllJobPostings;
            string jobPostingId = ObjectMother.Shared_JobPage01_JobPostingId01;
            DateTime now = ObjectMother.WIDExplorer_FakeNowFunction.Invoke();
            string runId = new RunIdManager().Create(now, jobPostingId);
            ushort parallelRequests = 3;
            uint pauseBetweenRequestsMs = 0;
            List<JobPage> jobPages = new List<JobPage>()
            {
                ObjectMother.Shared_JobPage01_Object
            };
            jobPages = ObjectMother.UpdateRunIds(jobPages, runId);
            List<JobPosting> jobPostings = ObjectMother.UpdateRunIds(ObjectMother.Shared_JobPage01_RangeForJobPostingId01, runId);
            jobPostings = ObjectMother.TranslateOccupations(jobPostings);
            Exploration expected = new Exploration(
                    runId: runId,
                    totalResultCount: ObjectMother.Shared_JobPage01_TotalResultCount,
                    totalJobPages: ObjectMother.Shared_JobPage01_TotalJobPages,
                    stage: Stages.Stage2_UpToAllJobPostings,
                    isCompleted: true,
                    jobPages: jobPages,
                    jobPostings: jobPostings,
                    jobPostingsExtended: null
                );
            IFormatter formatter = new Formatter();

            List<string> expectedLogMessages = new List<string>()
            {

                Messages.MessageCollection.WIDExplorer_ExplorationStarted,
                Messages.MessageCollection.WIDExplorer_RunIdIs(runId),
                Messages.MessageCollection.WIDExplorer_DefaultInitialPageNumberIs(WIDExplorer.DefaultInitialPageNumber),
                Messages.MessageCollection.WIDExplorer_JobPostingIdIs(jobPostingId),
                Messages.MessageCollection.WIDExplorer_StageIs(Stages.Stage2_UpToAllJobPostings),

                // ProcessStage1
                Messages.MessageCollection.WIDExplorer_ExecutionStageStarted(Stages.Stage1_OnlyMetrics),
                Messages.MessageCollection.WIDExplorer_JobPageSuccessfullyRetrieved.Invoke((ushort)1),
                Messages.MessageCollection.WIDExplorer_TotalResultCountIs(expected.TotalResultCount),
                Messages.MessageCollection.WIDExplorer_TotalJobPagesIs(expected.TotalJobPages),

                // ProcessStage2WhenThresholdDate
                Messages.MessageCollection.WIDExplorer_ExecutionStageStarted(Stages.Stage2_UpToAllJobPostings),
                Messages.MessageCollection.WIDExplorer_AntiFloodingStrategy,
                Messages.MessageCollection.WIDExplorer_ParallelRequestsAre(parallelRequests),
                Messages.MessageCollection.WIDExplorer_PauseBetweenRequestsIs(pauseBetweenRequestsMs),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting01),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting02),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting03),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting04),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting05),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting06),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting07),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting08),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting09),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting10),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting11),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting12),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting13),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting14),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting15),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting16),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting17),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting18),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting19),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting20),
                Messages.MessageCollection.WIDExplorer_JobPageProcessed(1, expected.TotalJobPages, ObjectMother.Shared_JobPage01Alt_JobPostings),
                Messages.MessageCollection.WIDExplorer_JobPostingIdFoundJobPageNr(jobPostingId, 1),
                Messages.MessageCollection.WIDExplorer_XJobPostingsRemovedJobPageNr(ObjectMother.Shared_JobPage01_RangeForJobPostingId01.Count, 1),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting01),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting02),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting03),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting04),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting05),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting06),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting07),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting08),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting09),
                formatter.Format(ObjectMother.Shared_JobPage01Alt_JobPosting10),
                Messages.MessageCollection.WIDExplorer_FinalPageNumberJobPostingId(1),

                Messages.MessageCollection.WIDExplorer_ExplorationCompleted

            };

            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerSettings fakeExplorerSettings = new WIDExplorerSettings(
                    parallelRequests: parallelRequests,
                    pauseBetweenRequestsMs: pauseBetweenRequestsMs,
                    folderPath: WIDExplorerSettings.DefaultFolderPath,
                    deleteAndRecreateDatabase: WIDExplorerSettings.DefaultDeleteAndRecreateDatabase,
                    translateJobPostingOccupation: WIDExplorerSettings.DefaultTranslateJobPostingOccupation,
                    predictJobPostingLanguage: WIDExplorerSettings.DefaultPredictJobPostingLanguage
                );
            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: fakeLoggingAction,
                    loggingActionAsciiBanner: fakeLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(postRequestManagerFactory: ObjectMother.WIDExplorer_JobPage0102_FakePostRequestManagerFactory, headerFactory: new HeaderFactory()),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    classificationManager: new ClassificationManager(),
                    nowFunction: ObjectMother.WIDExplorer_FakeNowFunction,
                    formatter: new Formatter()
                  );
            WIDExplorer widExplorer = new WIDExplorer(components, fakeExplorerSettings);
            bool compareLanguage = true;

            // Act
            Exploration actual = widExplorer.Explore(jobPostingId, stage);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(expected, actual, compareLanguage)
                );
            Assert.AreEqual(expectedLogMessages, fakeLogger.Messages);

        }

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 14.09.2021
*/
