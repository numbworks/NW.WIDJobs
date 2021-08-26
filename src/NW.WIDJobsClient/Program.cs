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

        static string Command_Exploration_Name = "exploration";
        static string Command_Exploration_Description = "Groups all the features related to the exploration of WorkInDenmark.dk.";

        static string SubCommand_ShowAsMetrics_Name = "showasmetrics";
        static string SubCommand_ShowAsMetrics_Description = $"Loads an {nameof(Exploration)} from a JSON file, calculates the metrics and shows them on screen.";
        static string Option_AsPercentages_Template = "--aspercentages";
        static string Option_AsPercentages_Description = "Shows metrics as percentages instead of numbers.";
        static string Option_JsonPath_Template = "--jsonpath";
        static string Option_JsonPath_Description = $"The file path to the required JSON file.";
        static string Option_JsonPath_ErrorMessage = "--jsonpath is mandatory.";
        static string SubCommand_SaveAsMetrics_Name = "saveasmetrics";
        static string SubCommand_SaveAsMetrics_Description = $"Loads an {nameof(Exploration)} from a JSON file, calculates the metrics and saves them as JSON.";
        static string Option_FolderPath_Template = "--folderpath";
        static string Option_FolderPath_Description = $"A valid folder path.";
        static string Option_FolderPath_ErrorMessage = $"{Option_FolderPath_Template} is mandatory.";
        static string SubCommand_SaveAsDatabase_Name = "saveasdatabase";
        static string SubCommand_SaveAsDatabase_Description = $"Loads an {nameof(Exploration)} from a JSON file, calculates the metrics and saves them as SQLite database.";

        static string SubCommand_Describe_Name = "describe";
        static string SubCommand_Describe_Description = $"Describes the current state of WorkInDenmark.dk.";
        static string Option_Output_Template = "--output";
        static string Option_Output_Description = $"The output(s) of the operation.";
        static string Option_Output_ErrorMessage = $"{Option_Output_Template} is mandatory.";

        static string Option_UseDemoData_Template = "--usedemodata";
        static string Option_UseDemoData_Description = $"Use demo data instead of real data. This options doesn't require internet connection.";

        #endregion

        // Methods_Public
        static int Main(string[] args)
        {

            CommandLineApplication app = CreateApplication();

            return app.Execute(args);

        }

        private static CommandLineApplication CreateApplication()
        {

            CommandLineApplication app = new CommandLineApplication
            {

                Name = Application_Name,
                Description = Application_Description

            };

            AddRoot(app);
            AddAbout(app);
            AddExploration(app);

            app.HelpOption(inherited: true);

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

        private static CommandLineApplication AddExploration(CommandLineApplication app)
        {

            app.Command(Command_Exploration_Name, explorationCommand =>
            {

                explorationCommand = AddExplorationMain(explorationCommand);
                explorationCommand = AddExplorationShowAsMetrics(explorationCommand);
                explorationCommand = AddExplorationSaveAsMetrics(explorationCommand);
                explorationCommand = AddExplorationSaveAsDatabase(explorationCommand);
                explorationCommand = AddExplorationDescribe(explorationCommand);

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
        private static CommandLineApplication AddExplorationSaveAsMetrics(CommandLineApplication explorationCommand)
        {

            explorationCommand.Command(SubCommand_SaveAsMetrics_Name, saveAsMetricsSubCommand =>
            {

                saveAsMetricsSubCommand.Description = SubCommand_SaveAsMetrics_Description;

                CommandOption asPercentagesOption
                    = saveAsMetricsSubCommand.Option(Option_AsPercentages_Template, Option_AsPercentages_Description, CommandOptionType.NoValue);

                CommandOption jsonPathOption
                    = saveAsMetricsSubCommand.Option(Option_JsonPath_Template, Option_JsonPath_Description, CommandOptionType.SingleValue);
                jsonPathOption.IsRequired(false, Option_JsonPath_ErrorMessage);

                CommandOption folderPathOption
                    = saveAsMetricsSubCommand.Option(Option_FolderPath_Template, Option_FolderPath_Description, CommandOptionType.SingleValue);
                folderPathOption.IsRequired(false, Option_FolderPath_ErrorMessage);

                saveAsMetricsSubCommand.OnExecute(() =>
                {

                    bool numbersAsPercentages = false;
                    if (asPercentagesOption.HasValue())
                        numbersAsPercentages = true;

                    if (jsonPathOption.HasValue() && folderPathOption.HasValue())
                        return ExplorationSaveAsMetrics(jsonPathOption.Value(), folderPathOption.Value(), numbersAsPercentages);

                    return ((int)ExitCodes.Failure);

                });

            });

            return explorationCommand;

        }
        private static CommandLineApplication AddExplorationSaveAsDatabase(CommandLineApplication explorationCommand)
        {

            explorationCommand.Command(SubCommand_SaveAsDatabase_Name, saveAsDatabaseSubCommand =>
            {

                saveAsDatabaseSubCommand.Description = SubCommand_SaveAsDatabase_Description;

                CommandOption jsonPathOption
                    = saveAsDatabaseSubCommand.Option(Option_JsonPath_Template, Option_JsonPath_Description, CommandOptionType.SingleValue);
                jsonPathOption.IsRequired(false, Option_JsonPath_ErrorMessage);

                CommandOption folderPathOption
                    = saveAsDatabaseSubCommand.Option(Option_FolderPath_Template, Option_FolderPath_Description, CommandOptionType.SingleValue);
                folderPathOption.IsRequired(false, Option_FolderPath_ErrorMessage);

                saveAsDatabaseSubCommand.OnExecute(() =>
                {

                    if (jsonPathOption.HasValue() && folderPathOption.HasValue())
                        return ExplorationSaveAsDatabase(jsonPathOption.Value(), folderPathOption.Value());

                    return ((int)ExitCodes.Failure);

                });

            });

            return explorationCommand;

        }
        private static CommandLineApplication AddExplorationDescribe(CommandLineApplication explorationCommand)
        {

            explorationCommand.Command(SubCommand_Describe_Name, describeSubCommand =>
            {

                describeSubCommand.Description = SubCommand_Describe_Description;

                CommandOption outputOption 
                    = describeSubCommand
                        .Option(Option_Output_Template, Option_Output_Description, CommandOptionType.SingleValue)
                        .IsRequired(false, Option_Output_ErrorMessage)
                        .Accepts(validator => validator.Enum<Outputs>());

                CommandOption folderPathOption
                    = describeSubCommand
                        .Option(Option_FolderPath_Template, Option_FolderPath_Description, CommandOptionType.SingleValue)
                        .Accepts(validator => validator.ExistingDirectory());

                CommandOption useDemoDataOption
                    = describeSubCommand
                        .Option(Option_UseDemoData_Template, Option_UseDemoData_Description, CommandOptionType.NoValue);

                describeSubCommand.OnExecute(() =>
                {

                    return ExplorationDescribe(ConvertToOutputs(outputOption.Value()), folderPathOption.Value(), useDemoDataOption.HasValue());

                });

            });

            return explorationCommand;

        }

        static int GenericCommand()
        {

            LogAsciiBanner();

            return ((int)ExitCodes.Success);

        }
        static int About()
        {

            LogAsciiBanner();

            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(Application_Description);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(string.Empty);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(MessageCollection.Program_ApplicationAuthor);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(MessageCollection.Program_ApplicationEmail);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(MessageCollection.Program_ApplicationUrl);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(MessageCollection.Program_ApplicationLicense);

            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(string.Empty);

            return ((int)ExitCodes.Success);

        }
        static int ExplorationShowAsMetrics(string filePath, bool numbersAsPercentages)
        {

            try
            {

                LogAsciiBanner();

                WIDExplorer widExplorer = new WIDExplorer();
                Exploration exploration = widExplorer.LoadExplorationFromJsonFile(filePath);
                MetricCollection metricCollection = widExplorer.ConvertToMetricCollection(exploration);

                string json = widExplorer.ConvertToJson(metricCollection, numbersAsPercentages);
                DumpJsonToConsole(json);

                return ((int)ExitCodes.Success);

            }
            catch (Exception e)
            {

                return DumpExceptionToConsole(e);

            }

        }
        static int ExplorationSaveAsMetrics(string filePath, string folderPath, bool numbersAsPercentages)
        {

            try
            {

                LogAsciiBanner();

                WIDExplorerSettings settings 
                    = new WIDExplorerSettings(
                            parallelRequests: WIDExplorerSettings.DefaultParallelRequests,
                            pauseBetweenRequestsMs: WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                            folderPath: folderPath,
                            deleteAndRecreateDatabase: WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                        );

                WIDExplorer widExplorer = new WIDExplorer(new WIDExplorerComponents(), settings);
                Exploration exploration = widExplorer.LoadExplorationFromJsonFile(filePath);
                MetricCollection metricCollection = widExplorer.ConvertToMetricCollection(exploration);
                IFileInfoAdapter fileInfoAdapter = widExplorer.SaveToJsonFile(metricCollection, numbersAsPercentages);
                
                WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

                if (fileInfoAdapter.Exists)
                    return ((int)ExitCodes.Success);

                return ((int)ExitCodes.Failure);

            }
            catch (Exception e)
            {

                return DumpExceptionToConsole(e);

            }

        }
        static int ExplorationSaveAsDatabase(string filePath, string folderPath)
        {

            try
            {

                LogAsciiBanner();

                WIDExplorerSettings settings
                    = new WIDExplorerSettings(
                            parallelRequests: WIDExplorerSettings.DefaultParallelRequests,
                            pauseBetweenRequestsMs: WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                            folderPath: folderPath,
                            deleteAndRecreateDatabase: WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                        );

                WIDExplorer widExplorer = new WIDExplorer(new WIDExplorerComponents(), settings);
                Exploration exploration = widExplorer.LoadExplorationFromJsonFile(filePath);
                IFileInfoAdapter fileInfoAdapter = widExplorer.SaveToSQLiteDatabase(exploration.JobPostingsExtended);

                WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

                if (fileInfoAdapter.Exists)
                    return ((int)ExitCodes.Success);

                return ((int)ExitCodes.Failure);

            }
            catch (Exception e)
            {

                return DumpExceptionToConsole(e);

            }

        }        
        static int ExplorationDescribe(Outputs output, string folderPath, bool useDemoData)
        {

            try
            {

                LogAsciiBanner();

                WIDExplorerComponents components = new WIDExplorerComponents();
                if (useDemoData)
                    components = CreateComponentsWithDemoData();

                WIDExplorerSettings settings
                    = new WIDExplorerSettings(
                            parallelRequests: WIDExplorerSettings.DefaultParallelRequests,
                            pauseBetweenRequestsMs: WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                            folderPath: folderPath ?? WIDExplorerSettings.DefaultFolderPath,
                            deleteAndRecreateDatabase: WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                        );

                WIDExplorer widExplorer = new WIDExplorer(components, settings);
                Exploration exploration = widExplorer.Explore(1, Stages.Stage1_OnlyMetrics);

                if (output == Outputs.console)
                    return DumpExploratonToConsole(widExplorer, exploration);

                if (output == Outputs.jsonfile)
                    return SaveExplorationToJson(widExplorer, exploration);

                if (output == Outputs.both)
                    return DumpExplorationToConsoleAndSaveToJson(widExplorer, exploration);

                throw CreateOutputException(output.ToString());

            }
            catch (Exception e)
            {

                return DumpExceptionToConsole(e);

            }

        }

        // Methods_Private
        private static void LogAsciiBanner()
        {

            WIDExplorer widExplorer = new WIDExplorer();

            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(string.Empty);
            widExplorer.LogAsciiBanner();

        }
        private static int DumpExceptionToConsole(Exception e)
        {

            WIDExplorerComponents.DefaultLoggingAction.Invoke(MessageCollection.Program_FormattedErrorMessage.Invoke(e.Message));
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            return ((int)ExitCodes.Failure);

        }
        private static void DumpJsonToConsole(string json)
        {

            WIDExplorerComponents.DefaultLoggingAction.Invoke(MessageCollection.Program_DumpingJsonToConsole);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(json);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

        }
        private static Outputs ConvertToOutputs(string optionValue)
        {

            if (optionValue == nameof(Outputs.jsonfile))
                return Outputs.jsonfile;

            if (optionValue == nameof(Outputs.console))
                return Outputs.console;

            if (optionValue == nameof(Outputs.both))
                return Outputs.both;

            throw CreateOutputException(optionValue);

        }
        private static Exception CreateOutputException(string outputValue)
        {

            return new Exception(MessageCollection.Program_OutputValueCantBeConvertedOutputs.Invoke(outputValue));

        }
        private static int DumpExploratonToConsole(WIDExplorer widExplorer, Exploration exploration)
        {

            string json = widExplorer.ConvertToJson(exploration);
            DumpJsonToConsole(json);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            return ((int)ExitCodes.Success);

        }
        private static int SaveExplorationToJson(WIDExplorer widExplorer, Exploration exploration)
        {
            IFileInfoAdapter fileInfoAdapter = widExplorer.SaveToJsonFile(exploration);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            if (!fileInfoAdapter.Exists)
                return ((int)ExitCodes.Failure);

            return ((int)ExitCodes.Success);
        }
        private static int DumpExplorationToConsoleAndSaveToJson(WIDExplorer widExplorer, Exploration exploration)
        {

            DumpExploratonToConsole(widExplorer, exploration);
            
            return SaveExplorationToJson(widExplorer, exploration);

        }
        private static WIDExplorerComponents CreateComponentsWithDemoData()
        {

            return new WIDExplorerComponents(
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

        }

    }

}

/*
    Author: numbworks@gmail.com
    Last Update: 25.08.2021

    WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(MessageCollection.Program_PressAButtonToCloseTheWindow);
    Console.ReadLine();

*/