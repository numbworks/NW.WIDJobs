using System;
using NUnit.Framework;

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
                                new JobPageManager(),
                                new JobPageDeserializer(),
                                new JobPostingDeserializer(),
                                new JobPostingExtendedManager(),
                                new JobPostingExtendedDeserializer(),
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
                                new JobPageManager(),
                                new JobPageDeserializer(),
                                new JobPostingDeserializer(),
                                new JobPostingExtendedManager(),
                                new JobPostingExtendedDeserializer(),
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
                                new JobPageManager(),
                                new JobPageDeserializer(),
                                new JobPostingDeserializer(),
                                new JobPostingExtendedManager(),
                                new JobPostingExtendedDeserializer(),
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
                                new JobPageManager(),
                                new JobPageDeserializer(),
                                new JobPostingDeserializer(),
                                new JobPostingExtendedManager(),
                                new JobPostingExtendedDeserializer(),
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
                                new JobPageDeserializer(),
                                new JobPostingDeserializer(),
                                new JobPostingExtendedManager(),
                                new JobPostingExtendedDeserializer(),
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
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_05"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageManager(),
                                null,
                                new JobPostingDeserializer(),
                                new JobPostingExtendedManager(),
                                new JobPostingExtendedDeserializer(),
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
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_06"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageManager(),
                                new JobPageDeserializer(),
                                null,
                                new JobPostingExtendedManager(),
                                new JobPostingExtendedDeserializer(),
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
                                new JobPageManager(),
                                new JobPageDeserializer(),
                                new JobPostingDeserializer(),
                                null,
                                new JobPostingExtendedDeserializer(),
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
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_08"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageManager(),
                                new JobPageDeserializer(),
                                new JobPostingDeserializer(),
                                new JobPostingExtendedManager(),
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
                new ArgumentNullException("jobPostingExtendedDeserializer").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_09"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageManager(),
                                new JobPageDeserializer(),
                                new JobPostingDeserializer(),
                                new JobPostingExtendedManager(),
                                new JobPostingExtendedDeserializer(),
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
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_10"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageManager(),
                                new JobPageDeserializer(),
                                new JobPostingDeserializer(),
                                new JobPostingExtendedManager(),
                                new JobPostingExtendedDeserializer(),
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
                new ArgumentNullException("metricsManager").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_11"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageManager(),
                                new JobPageDeserializer(),
                                new JobPostingDeserializer(),
                                new JobPostingExtendedManager(),
                                new JobPostingExtendedDeserializer(),
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
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_12"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageManager(),
                                new JobPageDeserializer(),
                                new JobPostingDeserializer(),
                                new JobPostingExtendedManager(),
                                new JobPostingExtendedDeserializer(),
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
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_13"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageManager(),
                                new JobPageDeserializer(),
                                new JobPostingDeserializer(),
                                new JobPostingExtendedManager(),
                                new JobPostingExtendedDeserializer(),
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
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_14"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageManager(),
                                new JobPageDeserializer(),
                                new JobPostingDeserializer(),
                                new JobPostingExtendedManager(),
                                new JobPostingExtendedDeserializer(),
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
                new ArgumentNullException("fileNameFactory").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_15"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                                new XPathManager(),
                                new GetRequestManager(),
                                new JobPageManager(),
                                new JobPageDeserializer(),
                                new JobPostingDeserializer(),
                                new JobPostingExtendedManager(),
                                new JobPostingExtendedDeserializer(),
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
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_16")

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
                            new JobPageManager(),
                            new JobPageDeserializer(),
                            new JobPostingDeserializer(),
                            new JobPostingExtendedManager(),
                            new JobPostingExtendedDeserializer(),
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
            Assert.IsInstanceOf<JobPageManager>(actual.JobPageManager);
            Assert.IsInstanceOf<JobPageDeserializer>(actual.JobPageDeserializer);
            Assert.IsInstanceOf<JobPostingDeserializer>(actual.JobPostingDeserializer);
            Assert.IsInstanceOf<JobPostingExtendedManager>(actual.JobPostingExtendedManager);
            Assert.IsInstanceOf<JobPostingExtendedDeserializer>(actual.JobPostingExtendedDeserializer);
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
            Assert.IsInstanceOf<JobPageManager>(actual.JobPageManager);
            Assert.IsInstanceOf<JobPageDeserializer>(actual.JobPageDeserializer);
            Assert.IsInstanceOf<JobPostingDeserializer>(actual.JobPostingDeserializer);
            Assert.IsInstanceOf<JobPostingExtendedManager>(actual.JobPostingExtendedManager);
            Assert.IsInstanceOf<JobPostingExtendedDeserializer>(actual.JobPostingExtendedDeserializer);
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
    Last Update: 12.06.2021
*/