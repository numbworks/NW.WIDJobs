using System;
using NUnit.Framework;
using NW.WIDJobs.AsciiBanner;
using NW.WIDJobs.BulletPoints;
using NW.WIDJobs.Database;
using NW.WIDJobs.Filenames;
using NW.WIDJobs.Files;
using NW.WIDJobs.HttpRequests;
using NW.WIDJobs.JobPages;
using NW.WIDJobs.JobPostings;

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
                                new BulletPointManager()
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
                                new BulletPointManager()
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
                                new BulletPointManager()
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
                                new BulletPointManager()
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
                                new BulletPointManager()
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
                                new BulletPointManager()
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
                                new BulletPointManager()
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
                                new BulletPointManager()
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
                                new BulletPointManager()
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
                                new BulletPointManager()
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
                                new BulletPointManager()
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
                                new BulletPointManager()
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
                                new BulletPointManager()
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
                                new BulletPointManager()
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
                                new BulletPointManager()
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
                                new BulletPointManager()
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
                                null
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("bulletPointManager").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_17")

        };

        // SetUp
        // Tests
        [Test]
        public void WIDExplorerComponents_ShouldInitializeANewWIDExplorerComponentsObject_WhenProperArguments()
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
                            new BulletPointManager()
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
            Assert.IsInstanceOf<BulletPointManager>(actual.BulletPointManager);

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
            Assert.IsInstanceOf<BulletPointManager>(actual.BulletPointManager);

        }

        [TestCaseSource(nameof(widExplorerComponentsExceptionTestCases))]
        public void WIDExplorerComponents_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 13.08.2021
*/