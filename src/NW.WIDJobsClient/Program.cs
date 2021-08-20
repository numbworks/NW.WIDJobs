using System;
using NW.WIDJobs;
using NW.WIDJobs.Explorations;
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

namespace NW.WIDJobsClient
{
    class Program
    {
        static void Main(string[] args)
        {

            RunDemo();

        }

        static void RunDemo() 
        {

            WIDExplorerComponents components = new WIDExplorerComponents(
                    loggingAction: WIDExplorerComponents.DefaultLoggingAction,
                    loggingActionAsciiBanner: WIDExplorerComponents.DefaultLoggingActionAsciiBanner,
                    xpathManager: new XPathManager(),
                    getRequestManager: new GetRequestManager(),
                    jobPageDeserializer: new JobPageDeserializer(),
                    jobPageManager: new JobPageManager(postRequestManagerFactory: ObjectMother.WIDExplorer_JobPage0102_FakePostRequestManagerFactory),
                    jobPostingDeserializer: new JobPostingDeserializer(),
                    jobPostingManager: new JobPostingManager(),
                    jobPostingExtendedDeserializer: new JobPostingExtendedDeserializer(),
                    jobPostingExtendedManager: new JobPostingExtendedManager(ObjectMother.WIDExplorer_JobPage0102_FakeGetRequestManagerFactory, new JobPostingExtendedDeserializer()),
                    runIdManager: new RunIdManager(),
                    metricCollectionManager: new MetricCollectionManager(),
                    fileManager: new FileManager(),
                    repositoryFactory: new RepositoryFactory(),
                    asciiBannerManager: new AsciiBannerManager(),
                    filenameFactory: new FilenameFactory(),
                    bulletPointManager: new BulletPointManager(),
                    nowFunction: ObjectMother.WIDExplorer_FakeNowFunction
                  );
            WIDExplorerSettings settings = new WIDExplorerSettings(
                    parallelRequests: WIDExplorerSettings.DefaultParallelRequests,
                    pauseBetweenRequestsMs: 1000,
                    folderPath: WIDExplorerSettings.DefaultFolderPath,
                    deleteAndRecreateDatabase: WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                );

            WIDExplorer widExplorer = new WIDExplorer(components, settings);

            widExplorer.LogAsciiBanner();
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke("*** DEMO MODE ***");
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            Exploration exploration = widExplorer.Explore(2, Stages.Stage3_UpToAllJobPostingsExtended);
            WIDExplorerComponents.DefaultLoggingAction.Invoke(exploration.ToString());
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            string json = widExplorer.ConvertToJson(exploration);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(json);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            MetricCollection metricCollection = widExplorer.ConvertToMetricCollection(exploration);
            json = widExplorer.ConvertToJson(metricCollection, false);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(json);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            json = widExplorer.ConvertToJson(metricCollection, true);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(json);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke("Press a button to close the window.");
            Console.ReadLine();

        }

        static WIDExplorer CreateExplorer()
        {

            WIDExplorerSettings settings
                = new WIDExplorerSettings(
                        WIDExplorerSettings.DefaultParallelRequests,
                        WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                        @"C:\Users\Rubèn\Desktop\",
                        WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                        );
            WIDExplorer explorer
                = new WIDExplorer(new WIDExplorerComponents(), settings);

            return explorer;

        }
        static void ExploreFirstJobPage()
        {

            WIDExplorer explorer = CreateExplorer();
            explorer.LogAsciiBanner();

            Exploration exploration
                = explorer.Explore(1, Stages.Stage3_UpToAllJobPostingsExtended);
            MetricCollection metrics = explorer.ConvertToMetricCollection(exploration);

            explorer.SaveToJsonFile(exploration);
            explorer.SaveToSQLiteDatabase(exploration.JobPostingsExtended);
            explorer.SaveToJsonFile(metrics, false);
            explorer.SaveToJsonFile(metrics, true);

        }

    }

}

/*
    Author: numbworks@gmail.com
    Last Update: 20.08.2021
*/