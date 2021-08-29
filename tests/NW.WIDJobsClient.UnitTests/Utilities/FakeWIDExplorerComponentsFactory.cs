using System;
using NW.WIDJobs;
using NW.WIDJobs.JobPostingsExtended;
using NW.WIDJobs.Metrics;
using NW.WIDJobs.JobPages;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.Runs;
using NW.WIDJobs.HttpRequests;
using NW.WIDJobs.XPath;
using NW.WIDJobs.Files;
using NW.WIDJobs.Database;
using NW.WIDJobs.AsciiBanner;
using NW.WIDJobs.Filenames;
using NW.WIDJobs.BulletPoints;
using NW.WIDJobs.UnitTests;
using NW.WIDJobsClient.CommandLine;

namespace NW.WIDJobsClient.UnitTests
{

    public class FakeWIDExplorerComponentsFactory : IWIDExplorerComponentsFactory
    {

        #region Fields

        #endregion

        #region Properties

        WIDExplorerComponents _fakeComponents;

        #endregion

        #region Constructors

        public FakeWIDExplorerComponentsFactory
            (FakeWIDExplorerComponentsTypes fakeComponentsType, Action<string> loggingAction, Action<string> loggingActionAsciiBanner) 
        {

            _fakeComponents = CreateFake(fakeComponentsType, loggingAction, loggingActionAsciiBanner);

        }
        
        public FakeWIDExplorerComponentsFactory(FakeWIDExplorerComponentsTypes fakeComponentsType)
            : this(fakeComponentsType, WIDExplorerComponents.DefaultLoggingAction, WIDExplorerComponents.DefaultLoggingActionAsciiBanner) { }

        #endregion

        #region Methods_public

        public WIDExplorerComponents CreateDefault() => _fakeComponents;
        public WIDExplorerComponents CreateForDemoData() => _fakeComponents;

        #endregion

        #region Methods_private

        private WIDExplorerComponents CreateFake
            (FakeWIDExplorerComponentsTypes fakeComponentsType, Action<string> loggingAction, Action<string> loggingActionAsciiBanner)
        {

            if (fakeComponentsType == FakeWIDExplorerComponentsTypes.allsuccess)
                return CreateFake(
                            loggingAction,
                            loggingActionAsciiBanner,
                            new JobPageManager(postRequestManagerFactory: WIDJobs.UnitTests.ObjectMother.WIDExplorer_JobPage0102_FakePostRequestManagerFactory),
                            new JobPostingExtendedManager(WIDJobs.UnitTests.ObjectMother.WIDExplorer_JobPage0102_FakeGetRequestManagerFactory, new JobPostingExtendedDeserializer()),
                            new FakeFileManager("some content"),
                            new FakeRepositoryFactory(467),
                            WIDExplorerComponents.DefaultNowFunction
                        );

            throw new Exception(fakeComponentsType.ToString());

        }
        private WIDExplorerComponents CreateFake(
                    Action<string> loggingAction,
                    Action<string> loggingActionAsciiBanner,
                    IJobPageManager jobPageManager,
                    IJobPostingExtendedManager jobPostingExtendedManager,
                    IFileManager fileManager,
                    IRepositoryFactory repositoryFactory,
                    Func<DateTime> nowFunction
            )
        {

            return new WIDExplorerComponents(
                    loggingAction: loggingAction,
                    loggingActionAsciiBanner: loggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: jobPageManager,
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: jobPostingExtendedManager,
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: fileManager,
                    repositoryFactory: repositoryFactory,
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    bulletPointManager: new BulletPointManager(),
                    nowFunction: nowFunction
                  );

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: xx.xx.2021
*/