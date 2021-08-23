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
using NW.WIDJobsClient.Messages;
using McMaster.Extensions.CommandLineUtils;

namespace NW.WIDJobsClient
{
    class Program
    {

        static int Main(string[] args)
        {

            CommandLineApplication app = CreateRootCommand();
            AddRootCommandBehaviour(app);
            AddDemoCommandBehaviour(app);

            app.HelpOption(inherited: true);

            return app.Execute(args);

        }

        private static CommandLineApplication CreateRootCommand()
        {

            CommandLineApplication app = new CommandLineApplication
            {

                Name = "NW.WIDJobsClient.exe",
                Description = "Unofficial command-line client for WorkInDenmark.dk.",

            };

            return app;

        }
        private static CommandLineApplication AddRootCommandBehaviour(CommandLineApplication app)
        {

            app.OnExecute(() =>
            {

                WIDExplorerComponents.DefaultLoggingActionAsciiBanner(string.Empty);
                new WIDExplorer().LogAsciiBanner();
                app.ShowHelp();

                return ((int)ExitCodes.Success);

            });

            return app;

        }
        private static CommandLineApplication AddDemoCommandBehaviour(CommandLineApplication app)
        {

            app.Command("demo", demoCommand =>
            {

                demoCommand.OnExecute(() =>
                {

                    WIDExplorerComponents.DefaultLoggingActionAsciiBanner(string.Empty);
                    new WIDExplorer().LogAsciiBanner();
                    demoCommand.ShowHelp();

                    return ((int)ExitCodes.Success);

                });

                demoCommand.Command("run", runSubCommand =>
                {

                    runSubCommand.OnExecute(() =>
                    {

                        WIDExplorerComponents.DefaultLoggingActionAsciiBanner(string.Empty);
                        RunDemo();

                        return ((int)ExitCodes.Success);

                    });

                });

            });

            return app;

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
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(MessageCollection.Program_DemoMode);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            Exploration exploration = widExplorer.Explore(2, Stages.Stage3_UpToAllJobPostingsExtended);
            WIDExplorerComponents.DefaultLoggingAction.Invoke(MessageCollection.Program_DumpingExplorationToConsole);
            WIDExplorerComponents.DefaultLoggingAction.Invoke(exploration.ToString());

            string json = widExplorer.ConvertToJson(exploration);
            WIDExplorerComponents.DefaultLoggingAction.Invoke(MessageCollection.Program_DumpingJSONToConsole);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(json);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            MetricCollection metricCollection = widExplorer.ConvertToMetricCollection(exploration);
            json = widExplorer.ConvertToJson(metricCollection, false);
            WIDExplorerComponents.DefaultLoggingAction.Invoke(MessageCollection.Program_DumpingJSONToConsole);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(json);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            json = widExplorer.ConvertToJson(metricCollection, true);
            WIDExplorerComponents.DefaultLoggingAction.Invoke(MessageCollection.Program_DumpingJSONToConsole);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(json);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(MessageCollection.Program_PressAButtonToCloseTheWindow);
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
    Last Update: 23.08.2021
*/