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
        static string SubCommand_Calculate_Name = "calculate";
        static string SubCommand_Calculate_Description = $"Loads an {nameof(Exploration)} from a JSON file and calculates the metrics.";
        static string SubCommand_Convert_Name = "convert";
        static string SubCommand_Convert_Description = $"Loads an {nameof(Exploration)} from a JSON file and convert it to a SQLite database.";
        static string SubCommand_Describe_Name = "describe";
        static string SubCommand_Describe_Description = $"Describes the current state of WorkInDenmark.dk.";


        static string Option_JsonPath_Template = "--jsonpath";
        static string Option_JsonPath_Description = $"The file path to the required JSON file.";
        static string Option_JsonPath_ErrorMessage = $"{Option_JsonPath_Template} is mandatory.";
        static string Option_FolderPath_Template = "--folderpath";
        static string Option_FolderPath_Description = $"A valid folder path.";
        static string Option_FolderPath_ErrorMessage = $"{Option_FolderPath_Template} is mandatory.";
        static string Option_Output_Template = "--output";
        static string Option_Output_Description = $"The output(s) of the operation.";
        static string Option_Output_ErrorMessage = $"{Option_Output_Template} is mandatory.";
        static string Option_AsPercentages_Template = "--aspercentages";
        static string Option_AsPercentages_Description = "Shows metrics as percentages instead of numbers.";
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
                explorationCommand = AddExplorationCalculate(explorationCommand);
                explorationCommand = AddExplorationConvert(explorationCommand);
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
        private static CommandLineApplication AddExplorationCalculate(CommandLineApplication explorationCommand)
        {

            explorationCommand.Command(SubCommand_Calculate_Name, calculateSubCommand =>
            {

                calculateSubCommand.Description = SubCommand_Calculate_Description;

                CommandOption jsonPathOption = CreateJsonPathOption(calculateSubCommand);
                CommandOption outputOption = CreateJsonConsoleOutputOption(calculateSubCommand);
                CommandOption folderPathOption = CreateOptionalFolderPathOption(calculateSubCommand);
                CommandOption asPercentagesOption = CreateAsPercentagesOption(calculateSubCommand);

                calculateSubCommand.OnExecute(() =>
                {

                    return ExplorationCalculate(
                                jsonPathOption.Value(),
                                ConvertToJsonConsoleOutputs(outputOption.Value()),
                                folderPathOption.Value(),
                                asPercentagesOption.HasValue());

                });

            });

            return explorationCommand;

        }
        private static CommandLineApplication AddExplorationConvert(CommandLineApplication explorationCommand)
        {

            explorationCommand.Command(SubCommand_Convert_Name, convertSubCommand =>
            {

                convertSubCommand.Description = SubCommand_Convert_Description;

                CommandOption jsonPathOption = CreateJsonPathOption(convertSubCommand);
                CommandOption outputOption = CreateDatabaseOutputOption(convertSubCommand);
                CommandOption folderPathOption = CreateRequiredFolderPathOption(convertSubCommand);

                convertSubCommand.OnExecute(() =>
                {

                    return ExplorationConvert(
                                jsonPathOption.Value(), 
                                ConvertToDatabaseOutputs(outputOption.Value()),
                                folderPathOption.Value());

                });

            });

            return explorationCommand;

        }
        private static CommandLineApplication AddExplorationDescribe(CommandLineApplication explorationCommand)
        {

            explorationCommand.Command(SubCommand_Describe_Name, describeSubCommand =>
            {

                describeSubCommand.Description = SubCommand_Describe_Description;

                CommandOption outputOption = CreateJsonConsoleOutputOption(describeSubCommand);
                CommandOption folderPathOption = CreateOptionalFolderPathOption(describeSubCommand);
                CommandOption useDemoDataOption = CreateDemoDataOption(describeSubCommand);

                describeSubCommand.OnExecute(() =>
                {

                    return ExplorationDescribe(
                                ConvertToJsonConsoleOutputs(outputOption.Value()), 
                                folderPathOption.Value(), 
                                useDemoDataOption.HasValue());

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
        static int ExplorationCalculate(string filePath, JsonConsoleOutputs output, string folderPath, bool numbersAsPercentages)
        {

            try
            {

                LogAsciiBanner();

                WIDExplorerComponents components = new WIDExplorerComponents();
                WIDExplorerSettings settings
                    = new WIDExplorerSettings(
                            parallelRequests: WIDExplorerSettings.DefaultParallelRequests,
                            pauseBetweenRequestsMs: WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                            folderPath: folderPath ?? WIDExplorerSettings.DefaultFolderPath,
                            deleteAndRecreateDatabase: WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                        );

                WIDExplorer widExplorer = new WIDExplorer(components, settings);
                Exploration exploration = widExplorer.LoadExplorationFromJsonFile(filePath);
                MetricCollection metricCollection = widExplorer.ConvertToMetricCollection(exploration);

                if (output == JsonConsoleOutputs.console)
                    return DumpMetricCollectionToConsole(widExplorer, metricCollection, numbersAsPercentages);

                if (output == JsonConsoleOutputs.jsonfile)
                    return SaveMetricCollectionToJson(widExplorer, metricCollection, numbersAsPercentages);

                if (output == JsonConsoleOutputs.both)
                    return DumpMetricCollectionToConsoleAndSaveToJson(widExplorer, metricCollection, numbersAsPercentages);

                throw CreateOutputException<JsonConsoleOutputs>(output.ToString());

            }
            catch (Exception e)
            {

                return DumpExceptionToConsole(e);

            }

        }
        static int ExplorationConvert(string filePath, DatabaseOutputs output, string folderPath)
        {

            try
            {

                LogAsciiBanner();

                WIDExplorerComponents components = new WIDExplorerComponents();
                WIDExplorerSettings settings
                    = new WIDExplorerSettings(
                            parallelRequests: WIDExplorerSettings.DefaultParallelRequests,
                            pauseBetweenRequestsMs: WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                            folderPath: folderPath,
                            deleteAndRecreateDatabase: WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                        );

                WIDExplorer widExplorer = new WIDExplorer(components, settings);
                Exploration exploration = widExplorer.LoadExplorationFromJsonFile(filePath);

                // At the moment there is only one DatabaseOutputs.
                return SaveExplorationToDatabaseFile(widExplorer, exploration);

            }
            catch (Exception e)
            {

                return DumpExceptionToConsole(e);

            }

        }
        static int ExplorationDescribe(JsonConsoleOutputs output, string folderPath, bool useDemoData)
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

                if (output == JsonConsoleOutputs.console)
                    return DumpExploratonToConsole(widExplorer, exploration);

                if (output == JsonConsoleOutputs.jsonfile)
                    return SaveExplorationToJson(widExplorer, exploration);

                if (output == JsonConsoleOutputs.both)
                    return DumpExplorationToConsoleAndSaveToJson(widExplorer, exploration);

                throw CreateOutputException<JsonConsoleOutputs>(output.ToString());

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
        private static JsonConsoleOutputs ConvertToJsonConsoleOutputs(string outputValue)
        {

            if (outputValue == nameof(JsonConsoleOutputs.jsonfile))
                return JsonConsoleOutputs.jsonfile;

            if (outputValue == nameof(JsonConsoleOutputs.console))
                return JsonConsoleOutputs.console;

            if (outputValue == nameof(JsonConsoleOutputs.both))
                return JsonConsoleOutputs.both;

            throw CreateOutputException<JsonConsoleOutputs>(outputValue);

        }
        private static Exception CreateOutputException<T>(string outputValue)
        {

            return new Exception(MessageCollection.Program_OutputValueCantBeConvertedToOutputs.Invoke(outputValue, typeof(T)));

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
        private static int DumpMetricCollectionToConsole(WIDExplorer widExplorer, MetricCollection metricCollection, bool numbersAsPercentages)
        {

            string json = widExplorer.ConvertToJson(metricCollection, numbersAsPercentages);
            DumpJsonToConsole(json);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            return ((int)ExitCodes.Success);

        }
        private static int SaveMetricCollectionToJson(WIDExplorer widExplorer, MetricCollection metricCollection, bool numbersAsPercentages)
        {

            IFileInfoAdapter fileInfoAdapter = widExplorer.SaveToJsonFile(metricCollection, numbersAsPercentages);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            if (!fileInfoAdapter.Exists)
                return ((int)ExitCodes.Failure);

            return ((int)ExitCodes.Success);

        }
        private static int DumpMetricCollectionToConsoleAndSaveToJson(WIDExplorer widExplorer, MetricCollection metricCollection, bool numbersAsPercentages)
        {

            DumpMetricCollectionToConsole(widExplorer, metricCollection, numbersAsPercentages);

            return SaveMetricCollectionToJson(widExplorer, metricCollection, numbersAsPercentages);

        }
        private static CommandOption CreateJsonPathOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_JsonPath_Template, Option_JsonPath_Description, CommandOptionType.SingleValue)
                    .IsRequired(false, Option_JsonPath_ErrorMessage)
                    .Accepts(validator => validator.ExistingFile());

        }
        private static CommandOption CreateJsonConsoleOutputOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_Output_Template, Option_Output_Description, CommandOptionType.SingleValue)
                    .IsRequired(false, Option_Output_ErrorMessage)
                    .Accepts(validator => validator.Enum<JsonConsoleOutputs>());

        }
        private static CommandOption CreateDatabaseOutputOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_Output_Template, Option_Output_Description, CommandOptionType.SingleValue)
                    .IsRequired(false, Option_Output_ErrorMessage)
                    .Accepts(validator => validator.Enum<DatabaseOutputs>());

        }
        private static CommandOption CreateOptionalFolderPathOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_FolderPath_Template, Option_FolderPath_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.ExistingDirectory());

        }
        private static CommandOption CreateRequiredFolderPathOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_FolderPath_Template, Option_FolderPath_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.ExistingDirectory())
                    .IsRequired(false, Option_FolderPath_ErrorMessage);

        }
        private static CommandOption CreateAsPercentagesOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_AsPercentages_Template, Option_AsPercentages_Description, CommandOptionType.NoValue);

        }
        private static CommandOption CreateDemoDataOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_UseDemoData_Template, Option_UseDemoData_Description, CommandOptionType.NoValue);

        }
        private static int SaveExplorationToDatabaseFile(WIDExplorer widExplorer, Exploration exploration)
        {

            IFileInfoAdapter fileInfoAdapter = widExplorer.SaveToSQLiteDatabase(exploration.JobPostingsExtended);

            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            if (fileInfoAdapter.Exists)
                return ((int)ExitCodes.Success);

            return ((int)ExitCodes.Failure);

        }
        private static DatabaseOutputs ConvertToDatabaseOutputs(string outputValue)
        {

            if (outputValue == nameof(DatabaseOutputs.databasefile))
                return DatabaseOutputs.databasefile;

            throw CreateOutputException<DatabaseOutputs>(outputValue);

        }

    }

}

/*
    Author: numbworks@gmail.com
    Last Update: 25.08.2021

    WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(MessageCollection.Program_PressAButtonToCloseTheWindow);
    Console.ReadLine();

*/