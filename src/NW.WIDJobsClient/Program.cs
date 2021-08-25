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
        static string SubCommand_ShowAsMetrics_Description = $"Imports a {nameof(Exploration)} from a JSON file, calculates the metrics and shows them on screen.";
        static string Option_AsPercentages_Template = "--aspercentages";
        static string Option_AsPercentages_Description = "Shows metrics as percentages instead of numbers.";
        static string Option_JsonPath_Template = "--jsonpath";
        static string Option_JsonPath_Description = $"The file path to the required JSON file.";
        static string Option_JsonPath_ErrorMessage = "--jsonpath is mandatory.";
        static string SubCommand_ExportAsMetrics_Name = "exportasmetrics";
        static string SubCommand_ExportAsMetrics_Description = $"Imports a {nameof(Exploration)} from a JSON file, calculates the metrics and export them as JSON.";
        static string Option_FolderPath_Template = "--folderpath";
        static string Option_FolderPath_Description = $"A valid folder path.";
        static string Option_FolderPath_ErrorMessage = "--folderpath is mandatory.";

        #endregion

        // Methods_Public
        static int Main(string[] args)
        {

            CommandLineApplication app = CreateApplication();

            AddRoot(app);
            AddAbout(app);
            AddDemo(app);
            AddExploration(app);

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
        private static CommandLineApplication AddRoot(CommandLineApplication app)
        {

            app.OnExecute(() =>
            {

                int exitCode = GenericCommand();
                app.ShowHelp();

                return exitCode;

            });

            return app;

        }
        private static CommandLineApplication AddAbout(CommandLineApplication app)
        {

            app.Command(Command_About_Name, aboutCommand =>
            {

                aboutCommand = AddAboutMain(aboutCommand);

            });

            return app;

        }
        private static CommandLineApplication AddAboutMain(CommandLineApplication aboutCommand)
        {

            aboutCommand.Description = Command_About_Description;
            aboutCommand.OnExecute(() =>
            {

                return About();

            });

            return aboutCommand;

        }
        private static CommandLineApplication AddDemo(CommandLineApplication app)
        {

            app.Command(Command_Demo_Name, demoCommand =>
            {

                demoCommand = AddDemoMain(demoCommand);
                demoCommand = AddDemoRun(demoCommand);

            });

            return app;

        }
        private static CommandLineApplication AddDemoMain(CommandLineApplication demoCommand)
        {

            demoCommand.Description = Command_Demo_Description;
            demoCommand.OnExecute(() =>
            {

                int exitCode = GenericCommand();
                demoCommand.ShowHelp();

                return exitCode;

            });

            return demoCommand;

        }
        private static CommandLineApplication AddDemoRun(CommandLineApplication demoCommand)
        {

            demoCommand.Command(SubCommand_Run_Name, runSubCommand =>
            {

                runSubCommand.Description = SubCommand_Run_Description;

                runSubCommand.OnExecute(() =>
                {
                    return DemoRun();

                });

            });

            return demoCommand;

        }
        private static CommandLineApplication AddExploration(CommandLineApplication app)
        {

            app.Command(Command_Exploration_Name, explorationCommand =>
            {

                explorationCommand = AddExplorationMain(explorationCommand);
                explorationCommand = AddExplorationShowAsMetrics(explorationCommand);
                explorationCommand = AddExplorationExportAsMetrics(explorationCommand);

            });

            return app;

        }
        private static CommandLineApplication AddExplorationMain(CommandLineApplication explorationCommand)
        {

            explorationCommand.Description = Command_Exploration_Description;
            explorationCommand.OnExecute(() =>
            {

                int exitCode = GenericCommand();
                explorationCommand.ShowHelp();

                return exitCode;

            });

            return explorationCommand;

        }
        private static CommandLineApplication AddExplorationShowAsMetrics(CommandLineApplication explorationCommand)
        {

            explorationCommand.Command(SubCommand_ShowAsMetrics_Name, showAsMetricsSubCommand =>
            {

                showAsMetricsSubCommand.Description = SubCommand_ShowAsMetrics_Description;

                CommandOption asPercentagesOption
                    = showAsMetricsSubCommand.Option(Option_AsPercentages_Template, Option_AsPercentages_Description, CommandOptionType.NoValue);

                CommandOption jsonPathOption
                    = showAsMetricsSubCommand.Option(Option_JsonPath_Template, Option_JsonPath_Description, CommandOptionType.SingleValue);
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

            return explorationCommand;

        }
        private static CommandLineApplication AddExplorationExportAsMetrics(CommandLineApplication explorationCommand)
        {

            explorationCommand.Command(SubCommand_ExportAsMetrics_Name, exportAsMetricsSubCommand =>
            {

                exportAsMetricsSubCommand.Description = SubCommand_ExportAsMetrics_Description;

                CommandOption asPercentagesOption
                    = exportAsMetricsSubCommand.Option(Option_AsPercentages_Template, Option_AsPercentages_Description, CommandOptionType.NoValue);

                CommandOption jsonPathOption
                    = exportAsMetricsSubCommand.Option(Option_JsonPath_Template, Option_JsonPath_Description, CommandOptionType.SingleValue);
                jsonPathOption.IsRequired(false, Option_JsonPath_ErrorMessage);

                CommandOption folderPathOption
                    = exportAsMetricsSubCommand.Option(Option_FolderPath_Template, Option_FolderPath_Description, CommandOptionType.SingleValue);
                folderPathOption.IsRequired(false, Option_FolderPath_ErrorMessage);

                exportAsMetricsSubCommand.OnExecute(() =>
                {

                    bool numbersAsPercentages = false;
                    if (asPercentagesOption.HasValue())
                        numbersAsPercentages = true;

                    if (jsonPathOption.HasValue() && folderPathOption.HasValue())
                        return ExplorationExportAsMetrics(jsonPathOption.Value(), folderPathOption.Value(), numbersAsPercentages);

                    return ((int)ExitCodes.Failure);

                });

            });

            return explorationCommand;

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

            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(Application_Description);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(string.Empty);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(MessageCollection.Program_ApplicationAuthor);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(MessageCollection.Program_ApplicationEmail);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(MessageCollection.Program_ApplicationUrl);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(MessageCollection.Program_ApplicationLicense);

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
        static int ExplorationExportAsMetrics(string filePath, string folderPath, bool numbersAsPercentages)
        {

            try
            {

                WIDExplorerSettings settings 
                    = new WIDExplorerSettings(
                            parallelRequests: WIDExplorerSettings.DefaultParallelRequests,
                            pauseBetweenRequestsMs: WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                            folderPath: folderPath,
                            deleteAndRecreateDatabase: WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                        );

                WIDExplorer widExplorer = new WIDExplorer(new WIDExplorerComponents(), settings);

                WIDExplorerComponents.DefaultLoggingActionAsciiBanner(string.Empty);
                widExplorer.LogAsciiBanner();

                Exploration exploration = widExplorer.LoadExplorationFromJsonFile(filePath);
                MetricCollection metricCollection = widExplorer.ConvertToMetricCollection(exploration);
                IFileInfoAdapter fileInfoAdapter = widExplorer.SaveToJsonFile(metricCollection, numbersAsPercentages);

                if (fileInfoAdapter.Exists)
                    return ((int)ExitCodes.Success);

                return ((int)ExitCodes.Failure);

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
    Last Update: 25.08.2021

    WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(MessageCollection.Program_PressAButtonToCloseTheWindow);
    Console.ReadLine();

*/