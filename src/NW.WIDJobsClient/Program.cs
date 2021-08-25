using System;
using System.Collections.Generic;
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

        #region Fields

        static string Application_Name = "NW.WIDJobsClient.exe";
        static string Application_Description = "Unofficial command-line client for WorkInDenmark.dk.";

        static string Command_About_Name = "about";
        static string Command_About_Description = "About this application.";

        static string Command_Demo_Name = "demo";
        static string Command_Demo_Description = "Groups all the features related to the demo mode.";
        static string SubCommand_Run_Name = "run";
        static string SubCommand_Run_Description = "Runs a demo exploration.";

        static string Command_Exploration_Name = "exploration";
        static string Command_Exploration_Description = "Groups all the features related to the exploration of WorkInDenmark.dk.";
        static string SubCommand_ShowAsMetrics_Name = "showasmetrics";
        static string SubCommand_ShowasMetrics_Description = $"Imports a {nameof(Exploration)} from a JSON file, calculates the metrics out of it and shows them on screen.";
        static string Option_AsPercentages_Template = "--aspercentages";
        static string Option_AsPercentages_Description = "Shows metrics as percentages instead of numbers.";
        static string Option_JsonPath_Template = "--jsonpath";
        static string Option_JsonPath_Description = $"The file path to the required JSON file.";
        static string Option_JsonPath_ErrorMessage = "--jsonpath is mandatory.";

        #endregion

        // Methods_Public
        static int Main(string[] args)
        {

            CommandLineApplication app = CreateApplication();

            AddRootCommandBehaviour(app);
            AddDemoCommandBehaviour(app);
            AddAboutCommandBehaviour(app);
            AddExplorationCommandBehaviour(app);

            app.HelpOption(inherited: true);

            return app.Execute(args);

        }

        private static CommandLineApplication CreateApplication()
        {

            CommandLineApplication app = new CommandLineApplication
            {

                Name = Application_Name,
                Description = Application_Description

            };

            return app;

        }
        private static CommandLineApplication AddRootCommandBehaviour(CommandLineApplication app)
        {

            app.OnExecute(() =>
            {

                int exitCode = GenericCommand();
                app.ShowHelp();

                return exitCode;

            });

            return app;

        }
        private static CommandLineApplication AddAboutCommandBehaviour(CommandLineApplication app)
        {

            app.Command(Command_About_Name, aboutCommand =>
            {

                aboutCommand.Description = Command_About_Description;

                aboutCommand.OnExecute(() =>
                {

                    return About();

                });

            });

            return app;

        }
        private static CommandLineApplication AddDemoCommandBehaviour(CommandLineApplication app)
        {

            app.Command(Command_Demo_Name, demoCommand =>
            {

                demoCommand.Description = Command_Demo_Description;

                demoCommand.OnExecute(() =>
                {

                    int exitCode = GenericCommand();
                    demoCommand.ShowHelp();

                    return exitCode;

                });

                demoCommand.Command(SubCommand_Run_Name, runSubCommand =>
                {

                    runSubCommand.Description = SubCommand_Run_Description;

                    runSubCommand.OnExecute(() =>
                    {
                        return DemoRun();

                    });

                });

            });

            return app;

        }
        private static CommandLineApplication AddExplorationCommandBehaviour(CommandLineApplication app)
        {

            app.Command(Command_Exploration_Name, explorationCommand =>
            {

                explorationCommand.Description = Command_Exploration_Description;

                explorationCommand.OnExecute(() =>
                {

                    int exitCode = GenericCommand();
                    explorationCommand.ShowHelp();

                    return exitCode;

                });

                explorationCommand.Command(SubCommand_ShowAsMetrics_Name, showAsMetricsSubCommand =>
                {

                    showAsMetricsSubCommand.Description = SubCommand_ShowasMetrics_Description;

                    CommandOption asPercentagesOption = showAsMetricsSubCommand.Option(Option_AsPercentages_Template, Option_AsPercentages_Description, CommandOptionType.NoValue);
                    
                    CommandOption jsonPathOption = showAsMetricsSubCommand.Option(Option_JsonPath_Template, Option_JsonPath_Description, CommandOptionType.SingleValue);
                    jsonPathOption.IsRequired(false, Option_JsonPath_ErrorMessage);

                    showAsMetricsSubCommand.OnExecute(() =>
                    {

                        bool numbersAsPercentages = false;
                        if (asPercentagesOption.HasValue())
                            numbersAsPercentages = true;

                        if (jsonPathOption.HasValue())
                            return ExplorationShowAsMetrics(jsonPathOption.Value(), numbersAsPercentages);

                        return ((int)ExitCodes.Failure);

                    });

                });

            });

            return app;

        }


        static int GenericCommand()
        {

            WIDExplorer widExplorer = new WIDExplorer();

            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(string.Empty);
            widExplorer.LogAsciiBanner();

            return ((int)ExitCodes.Success);

        }
        static int About()
        {

            WIDExplorer widExplorer = new WIDExplorer();

            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(string.Empty);
            widExplorer.LogAsciiBanner();

            WIDExplorerComponents.DefaultLoggingActionAsciiBanner("Unofficial command-line client for WorkInDenmark.dk.");

            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(string.Empty);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner("Author: numbworks");
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner("Email: numbworks [AT] gmail [DOT] com");
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(@"Github: http://www.github.com/numbworks");
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner("License: MIT License");

            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(string.Empty);

            return ((int)ExitCodes.Success);

        }
        static int DemoRun() 
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

            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(string.Empty);
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

            return ((int)ExitCodes.Success);

        }
        static int ExplorationShowAsMetrics(string filePath, bool numbersAsPercentages)
        {

            try
            {

                WIDExplorer widExplorer = new WIDExplorer();

                WIDExplorerComponents.DefaultLoggingActionAsciiBanner(string.Empty);
                widExplorer.LogAsciiBanner();

                Exploration exploration = widExplorer.LoadExplorationFromJsonFile(filePath);
                MetricCollection metricCollection = widExplorer.ConvertToMetricCollection(exploration);

                string json = widExplorer.ConvertToJson(metricCollection, numbersAsPercentages);
                WIDExplorerComponents.DefaultLoggingAction.Invoke(MessageCollection.Program_DumpingJSONToConsole);
                WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);
                WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(json);
                WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

                return ((int)ExitCodes.Success);

            }
            catch 
            {

                return ((int)ExitCodes.Failure);

            }

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

            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(MessageCollection.Program_PressAButtonToCloseTheWindow);
            Console.ReadLine();

*/