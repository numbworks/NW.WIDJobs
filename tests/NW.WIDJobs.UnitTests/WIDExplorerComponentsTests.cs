using System;
using NUnit.Framework;
using NW.WIDJobs.AsciiBanner;
using NW.WIDJobs.Database;
using NW.WIDJobs.Filenames;
using NW.WIDJobs.Files;
using NW.WIDJobs.HttpRequests;
using NW.WIDJobs.JobPages;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.JobPostingsExtended;
using NW.WIDJobs.Metrics;
using NW.WIDJobs.Runs;
using NW.WIDJobs.XPath;
using NW.WIDJobs.Formatting;
using NW.WIDJobs.Classification;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class WIDExplorerComponentsTests
    {

        // Fields
        private static TestCaseData[] widExplorerComponentsExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                null,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageDeserializer(),
                                new JobPageManager(),
                                new JobPostingDeserializer(),
                                new JobPostingManager(),
                                new JobPostingExtendedDeserializer(),
                                new JobPostingExtendedManager(),
                                new RunIdManager(),
                                new MetricCollectionManager(),
                                new FileManager(),
                                new RepositoryFactory(),
                                new AsciiBannerManager(),
                                new FilenameFactory(),
                                new ClassificationManager(),
                                WIDExplorerComponents.DefaultNowFunction,
                                new Formatter(),
                                WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("loggingAction").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                null,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageDeserializer(),
                                new JobPageManager(),
                                new JobPostingDeserializer(),
                                new JobPostingManager(),
                                new JobPostingExtendedDeserializer(),
                                new JobPostingExtendedManager(),
                                new RunIdManager(),
                                new MetricCollectionManager(),
                                new FileManager(),
                                new RepositoryFactory(),
                                new AsciiBannerManager(),
                                new FilenameFactory(),
                                new ClassificationManager(),
                                WIDExplorerComponents.DefaultNowFunction,
                                new Formatter(),
                                WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("loggingActionAsciiBanner").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                null,
                                new GetRequestManager(),
                                new JobPageDeserializer(),
                                new JobPageManager(),
                                new JobPostingDeserializer(),
                                new JobPostingManager(),
                                new JobPostingExtendedDeserializer(),
                                new JobPostingExtendedManager(),
                                new RunIdManager(),
                                new MetricCollectionManager(),
                                new FileManager(),
                                new RepositoryFactory(),
                                new AsciiBannerManager(),
                                new FilenameFactory(),
                                new ClassificationManager(),
                                WIDExplorerComponents.DefaultNowFunction,
                                new Formatter(),
                                WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("xpathManager").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_03"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                null,
                                new JobPageDeserializer(),
                                new JobPageManager(),
                                new JobPostingDeserializer(),
                                new JobPostingManager(),
                                new JobPostingExtendedDeserializer(),
                                new JobPostingExtendedManager(),
                                new RunIdManager(),
                                new MetricCollectionManager(),
                                new FileManager(),
                                new RepositoryFactory(),
                                new AsciiBannerManager(),
                                new FilenameFactory(),
                                new ClassificationManager(),
                                WIDExplorerComponents.DefaultNowFunction,
                                new Formatter(),
                                WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("getRequestManager").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_04"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                null,
                                new JobPageManager(),
                                new JobPostingDeserializer(),
                                new JobPostingManager(),
                                new JobPostingExtendedDeserializer(),
                                new JobPostingExtendedManager(),
                                new RunIdManager(),
                                new MetricCollectionManager(),
                                new FileManager(),
                                new RepositoryFactory(),
                                new AsciiBannerManager(),
                                new FilenameFactory(),
                                new ClassificationManager(),
                                WIDExplorerComponents.DefaultNowFunction,
                                new Formatter(),
                                WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPageDeserializer").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_05"),

            //

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageDeserializer(),
                                null,
                                new JobPostingDeserializer(),
                                new JobPostingManager(),
                                new JobPostingExtendedDeserializer(),
                                new JobPostingExtendedManager(),
                                new RunIdManager(),
                                new MetricCollectionManager(),
                                new FileManager(),
                                new RepositoryFactory(),
                                new AsciiBannerManager(),
                                new FilenameFactory(),
                                new ClassificationManager(),
                                WIDExplorerComponents.DefaultNowFunction,
                                new Formatter(),
                                WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPageManager").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_06"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageDeserializer(),
                                new JobPageManager(),
                                null,
                                new JobPostingManager(),
                                new JobPostingExtendedDeserializer(),
                                new JobPostingExtendedManager(),
                                new RunIdManager(),
                                new MetricCollectionManager(),
                                new FileManager(),
                                new RepositoryFactory(),
                                new AsciiBannerManager(),
                                new FilenameFactory(),
                                new ClassificationManager(),
                                WIDExplorerComponents.DefaultNowFunction,
                                new Formatter(),
                                WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingDeserializer").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_07"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageDeserializer(),
                                new JobPageManager(),
                                new JobPostingDeserializer(),
                                null,
                                new JobPostingExtendedDeserializer(),
                                new JobPostingExtendedManager(),
                                new RunIdManager(),
                                new MetricCollectionManager(),
                                new FileManager(),
                                new RepositoryFactory(),
                                new AsciiBannerManager(),
                                new FilenameFactory(),
                                new ClassificationManager(),
                                WIDExplorerComponents.DefaultNowFunction,
                                new Formatter(),
                                WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingManager").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_08"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageDeserializer(),
                                new JobPageManager(),
                                new JobPostingDeserializer(),
                                new JobPostingManager(),
                                null,
                                new JobPostingExtendedManager(),
                                new RunIdManager(),
                                new MetricCollectionManager(),
                                new FileManager(),
                                new RepositoryFactory(),
                                new AsciiBannerManager(),
                                new FilenameFactory(),
                                new ClassificationManager(),
                                WIDExplorerComponents.DefaultNowFunction,
                                new Formatter(),
                                WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingExtendedDeserializer").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_09"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageDeserializer(),
                                new JobPageManager(),
                                new JobPostingDeserializer(),
                                new JobPostingManager(),
                                new JobPostingExtendedDeserializer(),
                                null,
                                new RunIdManager(),
                                new MetricCollectionManager(),
                                new FileManager(),
                                new RepositoryFactory(),
                                new AsciiBannerManager(),
                                new FilenameFactory(),
                                new ClassificationManager(),
                                WIDExplorerComponents.DefaultNowFunction,
                                new Formatter(),
                                WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingExtendedManager").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_10"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageDeserializer(),
                                new JobPageManager(),
                                new JobPostingDeserializer(),
                                new JobPostingManager(),
                                new JobPostingExtendedDeserializer(),
                                new JobPostingExtendedManager(),
                                null,
                                new MetricCollectionManager(),
                                new FileManager(),
                                new RepositoryFactory(),
                                new AsciiBannerManager(),
                                new FilenameFactory(),
                                new ClassificationManager(),
                                WIDExplorerComponents.DefaultNowFunction,
                                new Formatter(),
                                WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("runIdManager").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_11"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageDeserializer(),
                                new JobPageManager(),
                                new JobPostingDeserializer(),
                                new JobPostingManager(),
                                new JobPostingExtendedDeserializer(),
                                new JobPostingExtendedManager(),
                                new RunIdManager(),
                                null,
                                new FileManager(),
                                new RepositoryFactory(),
                                new AsciiBannerManager(),
                                new FilenameFactory(),
                                new ClassificationManager(),
                                WIDExplorerComponents.DefaultNowFunction,
                                new Formatter(),
                                WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("metricCollectionManager").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_12"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageDeserializer(),
                                new JobPageManager(),
                                new JobPostingDeserializer(),
                                new JobPostingManager(),
                                new JobPostingExtendedDeserializer(),
                                new JobPostingExtendedManager(),
                                new RunIdManager(),
                                new MetricCollectionManager(),
                                null,
                                new RepositoryFactory(),
                                new AsciiBannerManager(),
                                new FilenameFactory(),
                                new ClassificationManager(),
                                WIDExplorerComponents.DefaultNowFunction,
                                new Formatter(),
                                WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("fileManager").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_13"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageDeserializer(),
                                new JobPageManager(),
                                new JobPostingDeserializer(),
                                new JobPostingManager(),
                                new JobPostingExtendedDeserializer(),
                                new JobPostingExtendedManager(),
                                new RunIdManager(),
                                new MetricCollectionManager(),
                                new FileManager(),
                                null,
                                new AsciiBannerManager(),
                                new FilenameFactory(),
                                new ClassificationManager(),
                                WIDExplorerComponents.DefaultNowFunction,
                                new Formatter(),
                                WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("repositoryFactory").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_14"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageDeserializer(),
                                new JobPageManager(),
                                new JobPostingDeserializer(),
                                new JobPostingManager(),
                                new JobPostingExtendedDeserializer(),
                                new JobPostingExtendedManager(),
                                new RunIdManager(),
                                new MetricCollectionManager(),
                                new FileManager(),
                                new RepositoryFactory(),
                                null,
                                new FilenameFactory(),
                                new ClassificationManager(),
                                WIDExplorerComponents.DefaultNowFunction,
                                new Formatter(),
                                WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("asciiBannerManager").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_15"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageDeserializer(),
                                new JobPageManager(),
                                new JobPostingDeserializer(),
                                new JobPostingManager(),
                                new JobPostingExtendedDeserializer(),
                                new JobPostingExtendedManager(),
                                new RunIdManager(),
                                new MetricCollectionManager(),
                                new FileManager(),
                                new RepositoryFactory(),
                                new AsciiBannerManager(),
                                null,
                                new ClassificationManager(),
                                WIDExplorerComponents.DefaultNowFunction,
                                new Formatter(),
                                WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("filenameFactory").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_16"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageDeserializer(),
                                new JobPageManager(),
                                new JobPostingDeserializer(),
                                new JobPostingManager(),
                                new JobPostingExtendedDeserializer(),
                                new JobPostingExtendedManager(),
                                new RunIdManager(),
                                new MetricCollectionManager(),
                                new FileManager(),
                                new RepositoryFactory(),
                                new AsciiBannerManager(),
                                new FilenameFactory(),
                                null,
                                WIDExplorerComponents.DefaultNowFunction,
                                new Formatter(),
                                WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("classificationManager").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_17"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageDeserializer(),
                                new JobPageManager(),
                                new JobPostingDeserializer(),
                                new JobPostingManager(),
                                new JobPostingExtendedDeserializer(),
                                new JobPostingExtendedManager(),
                                new RunIdManager(),
                                new MetricCollectionManager(),
                                new FileManager(),
                                new RepositoryFactory(),
                                new AsciiBannerManager(),
                                new FilenameFactory(),
                                new ClassificationManager(),
                                null,
                                new Formatter(),
                                WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("nowFunction").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_18"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageDeserializer(),
                                new JobPageManager(),
                                new JobPostingDeserializer(),
                                new JobPostingManager(),
                                new JobPostingExtendedDeserializer(),
                                new JobPostingExtendedManager(),
                                new RunIdManager(),
                                new MetricCollectionManager(),
                                new FileManager(),
                                new RepositoryFactory(),
                                new AsciiBannerManager(),
                                new FilenameFactory(),
                                new ClassificationManager(),
                                WIDExplorerComponents.DefaultNowFunction,
                                null,
                                WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("formatter").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_19"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageDeserializer(),
                                new JobPageManager(),
                                new JobPostingDeserializer(),
                                new JobPostingManager(),
                                new JobPostingExtendedDeserializer(),
                                new JobPostingExtendedManager(),
                                new RunIdManager(),
                                new MetricCollectionManager(),
                                new FileManager(),
                                new RepositoryFactory(),
                                new AsciiBannerManager(),
                                new FilenameFactory(),
                                new ClassificationManager(),
                                WIDExplorerComponents.DefaultNowFunction,
                                new Formatter(),
                                null
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("textClassifierLoggingAction").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_20"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("settings").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_21")

        };

        // SetUp
        // Tests
        [Test]
        public void WIDExplorerComponents_ShouldInitializeANewWIDExplorerComponentsObject_WhenAllArguments()
        {

            // Arrange
            // Act
            WIDExplorerComponents actual =
                new WIDExplorerComponents(
                            WIDExplorerComponents.DefaultLoggingAction,
                            WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                            new XPathManager(),
                            new GetRequestManager(),
                            new JobPageDeserializer(),
                            new JobPageManager(),
                            new JobPostingDeserializer(),
                            new JobPostingManager(),
                            new JobPostingExtendedDeserializer(),
                            new JobPostingExtendedManager(),
                            new RunIdManager(),
                            new MetricCollectionManager(),
                            new FileManager(),
                            new RepositoryFactory(),
                            new AsciiBannerManager(),
                            new FilenameFactory(),
                            new ClassificationManager(),
                            WIDExplorerComponents.DefaultNowFunction,
                            new Formatter(),
                            WIDExplorerComponents.DefaultDoesNothingLoggingAction
                        );

            // Assert
            Assert.IsInstanceOf<WIDExplorerComponents>(actual);
            Assert.IsInstanceOf<Action<string>>(actual.LoggingAction);
            Assert.IsInstanceOf<Action<string>>(actual.LoggingActionAsciiBanner);
            Assert.IsInstanceOf<XPathManager>(actual.XPathManager);
            Assert.IsInstanceOf<GetRequestManager>(actual.GetRequestManager);
            Assert.IsInstanceOf<JobPageDeserializer>(actual.JobPageDeserializer);
            Assert.IsInstanceOf<JobPageManager>(actual.JobPageManager);
            Assert.IsInstanceOf<JobPostingDeserializer>(actual.JobPostingDeserializer);
            Assert.IsInstanceOf<JobPostingManager>(actual.JobPostingManager);
            Assert.IsInstanceOf<JobPostingExtendedDeserializer>(actual.JobPostingExtendedDeserializer);
            Assert.IsInstanceOf<JobPostingExtendedManager>(actual.JobPostingExtendedManager);
            Assert.IsInstanceOf<RunIdManager>(actual.RunIdManager);
            Assert.IsInstanceOf<MetricCollectionManager>(actual.MetricCollectionManager);
            Assert.IsInstanceOf<FileManager>(actual.FileManager);
            Assert.IsInstanceOf<RepositoryFactory>(actual.RepositoryFactory);
            Assert.IsInstanceOf<AsciiBannerManager>(actual.AsciiBannerManager);
            Assert.IsInstanceOf<FilenameFactory>(actual.FilenameFactory);
            Assert.IsInstanceOf<ClassificationManager>(actual.ClassificationManager);
            Assert.IsInstanceOf<Formatter>(actual.Formatter);
            Assert.IsInstanceOf<Action<string>>(actual.TextClassifierLoggingAction);

        }

        [Test]
        public void WIDExplorerComponents_ShouldInitializeANewWIDExplorerComponentsObject_WhenDefaultConstructor()
        {

            // Arrange
            // Act
            WIDExplorerComponents actual = new WIDExplorerComponents();

            // Assert
            Assert.IsInstanceOf<WIDExplorerComponents>(actual);
            Assert.IsInstanceOf<Action<string>>(actual.LoggingAction);
            Assert.IsInstanceOf<Action<string>>(actual.LoggingActionAsciiBanner);
            Assert.IsInstanceOf<XPathManager>(actual.XPathManager);
            Assert.IsInstanceOf<GetRequestManager>(actual.GetRequestManager);
            Assert.IsInstanceOf<JobPageDeserializer>(actual.JobPageDeserializer);
            Assert.IsInstanceOf<JobPageManager>(actual.JobPageManager);
            Assert.IsInstanceOf<JobPostingDeserializer>(actual.JobPostingDeserializer);
            Assert.IsInstanceOf<JobPostingManager>(actual.JobPostingManager);
            Assert.IsInstanceOf<JobPostingExtendedDeserializer>(actual.JobPostingExtendedDeserializer);
            Assert.IsInstanceOf<JobPostingExtendedManager>(actual.JobPostingExtendedManager);
            Assert.IsInstanceOf<RunIdManager>(actual.RunIdManager);
            Assert.IsInstanceOf<MetricCollectionManager>(actual.MetricCollectionManager);
            Assert.IsInstanceOf<FileManager>(actual.FileManager);
            Assert.IsInstanceOf<RepositoryFactory>(actual.RepositoryFactory);
            Assert.IsInstanceOf<AsciiBannerManager>(actual.AsciiBannerManager);
            Assert.IsInstanceOf<FilenameFactory>(actual.FilenameFactory);
            Assert.IsInstanceOf<ClassificationManager>(actual.ClassificationManager);
            Assert.IsInstanceOf<Formatter>(actual.Formatter);
            Assert.IsInstanceOf<Action<string>>(actual.TextClassifierLoggingAction);

        }

        [TestCaseSource(nameof(widExplorerComponentsExceptionTestCases))]
        public void WIDExplorerComponents_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void WIDExplorerComponents_ShouldInitializeStaticPropertiesAsExpected_WhenInvoked()
        {

            // Arrange
            // Act
            // Assert
            Assert.IsInstanceOf<string>(WIDExplorerComponents.DefaultLoggingActionDateFormat);
            Assert.IsInstanceOf<Action<string>>(WIDExplorerComponents.DefaultLoggingAction);
            Assert.IsInstanceOf<Action<string>>(WIDExplorerComponents.DefaultLoggingActionAsciiBanner);
            Assert.IsInstanceOf<Func<DateTime>>(WIDExplorerComponents.DefaultNowFunction);
            Assert.IsInstanceOf<Action<string>>(WIDExplorerComponents.DefaultDoesNothingLoggingAction);
            Assert.IsInstanceOf<bool>(WIDExplorerComponents.DefaultPredictJobPostingLanguage);
            Assert.IsInstanceOf<bool>(WIDExplorerComponents.DefaultPredictBulletPointType);

        }

        // TearDown

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.10.2021
*/