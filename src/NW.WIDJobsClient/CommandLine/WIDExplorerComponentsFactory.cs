﻿using NW.WIDJobs;
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
using NW.WIDJobs.Headers;

namespace NW.WIDJobsClient.CommandLine
{
    /// <inheritdoc cref="IWIDExplorerComponentsFactory"/>
    public class WIDExplorerComponentsFactory : IWIDExplorerComponentsFactory
    {

        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="WIDExplorerComponentsFactory"/> instance.</summary>	
        public WIDExplorerComponentsFactory() { }

        #endregion

        #region Methods_public

        public WIDExplorerComponents CreateDefault() => new WIDExplorerComponents();
        public WIDExplorerComponents CreateForDemoData()
        {

            return new WIDExplorerComponents(
                    loggingAction: WIDExplorerComponents.DefaultLoggingAction,
                    loggingActionAsciiBanner: WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
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
                    bulletPointManager: new BulletPointManager(),
                    nowFunction: WIDExplorerComponents.DefaultNowFunction
                  );

        }

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.08.2021
*/