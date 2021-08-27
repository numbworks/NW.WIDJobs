﻿using System;
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
        static string SubCommand_Explore_Name = "explore";
        static string SubCommand_Explore_Description = $"Fetches data from WorkInDenmark.dk.";

        static string Option_JsonPath_Template = "--jsonpath";
        static string Option_JsonPath_Description = $"The file path to the required JSON file.";
        static string Option_JsonPath_ErrorMessage = $"{Option_JsonPath_Template} is mandatory.";
        static string Option_FolderPath_Template = "--folderpath";
        static string Option_FolderPath_Description = $"A valid folder path.";
        static string Option_FolderPath_ErrorMessage = $"{Option_FolderPath_Template} is mandatory.";
        static string Option_Output_Template = "--output";
        static string Option_Output_Description = "The output(s) of the operation.";
        static string Option_Output_ErrorMessage = $"{Option_Output_Template} is mandatory.";
        static string Option_AsPercentages_Template = "--aspercentages";
        static string Option_AsPercentages_Description = "Shows metrics as percentages instead of numbers.";
        static string Option_UseDemoData_Template = "--usedemodata";
        static string Option_UseDemoData_Description = $"Use demo data instead of real data. This options doesn't require internet connection.";

        static string Option_Stage_Template = "--stage";
        static string Option_Stage_Description = $"The depth of an {nameof(Exploration)}.";
        static string Option_Stage_ErrorMessage = $"{Option_Stage_Template} is mandatory.";
        static string Option_ThresholdType_Template = "--thresholdtype";
        static string Option_ThresholdType_Description = "The exploration proceeds until this criteria is met.";
        static string Option_ThresholdType_ErrorMessage = $"{Option_ThresholdType_Template} is mandatory.";
        static string Option_ThresholdValue_Template = "--thresholdvalue";
        static string Option_ThresholdValue_Description = $"The value for the provided threshold type. Date must be provided in the 'yyyyMMdd' format.";
        static string Option_ThresholdValue_ErrorMessage = $"{Option_ThresholdValue_Template} is mandatory.";
        static string Option_Metrics_Template = "--metrics";
        static string Option_Metrics_Description = "Enables the metric calculation.";
        static string Option_MetricsOutput_Template = "--metricsoutput";
        static string Option_MetricsOutput_Description = "The output(s) for the metric calculation.";
        static string Option_ParallelRequests_Template = "--parallelrequests";
        static string Option_ParallelRequests_Description = $"The number of HTTP requests to send to WorkInDenmark.dk before pausing. If not specified, '{WIDExplorerSettings.DefaultParallelRequests}' will be used.";
        static string Option_PauseBetweenRequestsMs_Template = "--pausebetweenrequestsms";
        static string Option_PauseBetweenRequestsMs_Description = $"The duration of the pause after x HTTP requests in milliseconds. If not specified, '{WIDExplorerSettings.DefaultPauseBetweenRequestsMs}' will be used.";

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
                CommandOption useDemoDataOption = CreateUseDemoDataOption(describeSubCommand);

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
        private static CommandLineApplication AddExplorationExplore(CommandLineApplication explorationCommand)
        {

            explorationCommand.Command(SubCommand_Explore_Name, exploreSubCommand =>
            {

                exploreSubCommand.Description = SubCommand_Explore_Description;

                CommandOption stageFromInputOption = CreateStageFromInputOption(exploreSubCommand);
                CommandOption thresholdTypeOption = CreateThresholdTypeOption(exploreSubCommand);
                CommandOption thresholdValueOption = CreateThresholdValueOption(exploreSubCommand);
                CommandOption outputOption = CreateDatabaseJsonConsoleOutputOption(exploreSubCommand);
                CommandOption folderPathOption = CreateOptionalFolderPathOption(exploreSubCommand);
                CommandOption metricsOption = CreateMetricsOption(exploreSubCommand);
                CommandOption metricsOutputOption = CreateMetricsOutputOption(exploreSubCommand);
                CommandOption asPercentagesOption = CreateAsPercentagesOption(exploreSubCommand);
                CommandOption parallelRequestsOption = CreateParallelRequestsOption(exploreSubCommand);
                CommandOption pauseBetweenRequestsMsOption = CreatePauseBetweenRequestsMsOption(exploreSubCommand);
                CommandOption useDemoDataOption = CreateUseDemoDataOption(exploreSubCommand);

                exploreSubCommand.OnExecute(() =>
                {

                    return ExplorationExplore(
                                ConvertToStagesFromInput(stageFromInputOption.Value()),
                                ConvertToThresholdTypes(thresholdTypeOption.Value()),
                                ParseThresholdValue(thresholdValueOption.Value()),
                                ConvertToDatabaseJsonConsoleOutputs(outputOption.Value()),
                                folderPathOption.Value(),
                                metricsOption.HasValue(),
                                ConvertToJsonConsoleOutputs(metricsOutputOption.Value()),
                                asPercentagesOption.HasValue(),
                                parallelRequestsOption.Value(),
                                pauseBetweenRequestsMsOption.Value(),
                                useDemoDataOption.HasValue()
                                );

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

                WIDExplorerComponents components = CreateComponents(useDemoData: false);
                WIDExplorerSettings settings = CreateSettings(folderPath: folderPath);

                WIDExplorer widExplorer = new WIDExplorer(components, settings);
                Exploration exploration = widExplorer.LoadExplorationFromJsonFile(filePath);
                MetricCollection metricCollection = widExplorer.ConvertToMetricCollection(exploration);

                if (output == JsonConsoleOutputs.console)
                    return DumpMetricCollectionToConsole(widExplorer, metricCollection, numbersAsPercentages);

                if (output == JsonConsoleOutputs.jsonfile)
                    return SaveMetricCollectionToJson(widExplorer, metricCollection, numbersAsPercentages);

                if (output == JsonConsoleOutputs.both)
                    return DumpMetricCollectionToConsoleAndSaveToJson(widExplorer, metricCollection, numbersAsPercentages);

                throw CreateOptionValueException<JsonConsoleOutputs>(output.ToString());

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

                WIDExplorerComponents components = CreateComponents(useDemoData: false);
                WIDExplorerSettings settings = CreateSettings(folderPath: folderPath);

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

                WIDExplorerComponents components = CreateComponents(useDemoData);
                WIDExplorerSettings settings = CreateSettings(folderPath: folderPath);

                WIDExplorer widExplorer = new WIDExplorer(components, settings);
                Exploration exploration = widExplorer.Explore(1, Stages.Stage1_OnlyMetrics);

                if (output == JsonConsoleOutputs.console)
                    return DumpExploratonToConsole(widExplorer, exploration);

                if (output == JsonConsoleOutputs.jsonfile)
                    return SaveExplorationToJson(widExplorer, exploration);

                if (output == JsonConsoleOutputs.both)
                    return DumpExplorationToConsoleAndSaveToJson(widExplorer, exploration);

                throw CreateOptionValueException<JsonConsoleOutputs>(output.ToString());

            }
            catch (Exception e)
            {

                return DumpExceptionToConsole(e);

            }

        }

        static int ExplorationExplore(
                        StagesFromInput stageFromInput, 
                        ThresholdTypes thresholdType,
                        ThresholdValue thresholdValue,
                        DatabaseJsonConsoleOutputs databaseJsonConsoleOutputs,
                        string folderPath,
                        bool enableMetrics,
                        JsonConsoleOutputs jsonConsoleOutputs,
                        bool numbersAsPercentages,
                        string parallelRequests,
                        string pauseBetweenRequestsMs,
                        bool useDemoData)
        {

            WIDExplorerComponents components = CreateComponents(useDemoData: useDemoData);
            WIDExplorerSettings settings = CreateSettings(parallelRequests: parallelRequests, pauseBetweenRequestsMs: pauseBetweenRequestsMs, folderPath: folderPath);


            Stages stage = ConvertToStages(stageFromInput);



        }
        static int ExplorationExplore(WIDExplorerComponents components, WIDExplorerSettings settings, ushort finalPageNumber, Stages stage)
        {


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
        private static JsonConsoleOutputs ConvertToJsonConsoleOutputs(string optionValue)
        {

            if (optionValue == nameof(JsonConsoleOutputs.jsonfile))
                return JsonConsoleOutputs.jsonfile;

            if (optionValue == nameof(JsonConsoleOutputs.console))
                return JsonConsoleOutputs.console;

            if (optionValue == nameof(JsonConsoleOutputs.both))
                return JsonConsoleOutputs.both;

            throw CreateOptionValueException<JsonConsoleOutputs>(optionValue);

        }
        private static Exception CreateOptionValueException<T>(string optionValue)
        {

            return new Exception(MessageCollection.Program_OptionValueCantBeConvertedTo.Invoke(optionValue, typeof(T)));

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
        private static WIDExplorerComponents CreateComponents(bool useDemoData)
        {

            if (useDemoData)
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
                        nowFunction: WIDExplorerComponents.DefaultNowFunction
                      );
            
            return new WIDExplorerComponents();

        }
        private static WIDExplorerSettings CreateSettings
            (string parallelRequests = null, string pauseBetweenRequestsMs = null, string folderPath = null, bool? deleteAndRecreateDatabase = null)
        {

            return new WIDExplorerSettings(
                            parallelRequests: TryParseParallelRequests(parallelRequests) ?? WIDExplorerSettings.DefaultParallelRequests,
                            pauseBetweenRequestsMs: TryParsePauseBetweenRequestsMs(pauseBetweenRequestsMs) ?? WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                            folderPath: folderPath ?? WIDExplorerSettings.DefaultFolderPath,
                            deleteAndRecreateDatabase: deleteAndRecreateDatabase ?? WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                        );

        }
        private static ushort? TryParseParallelRequests(string parallelRequests)
        {

            if (parallelRequests == null)
                return null;

            return ushort.Parse(parallelRequests);

        }
        private static uint? TryParsePauseBetweenRequestsMs(string pauseBetweenRequestsMs)
        {

            if (pauseBetweenRequestsMs == null)
                return null;

            return uint.Parse(pauseBetweenRequestsMs);

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
                    .Accepts(validator => validator.ExistingFile())
                    .IsRequired(false, Option_JsonPath_ErrorMessage);

        }
        private static CommandOption CreateJsonConsoleOutputOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_Output_Template, Option_Output_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Enum<JsonConsoleOutputs>())
                    .IsRequired(false, Option_Output_ErrorMessage);

        }
        private static CommandOption CreateDatabaseOutputOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_Output_Template, Option_Output_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Enum<DatabaseOutputs>())
                    .IsRequired(false, Option_Output_ErrorMessage);

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
        private static CommandOption CreateUseDemoDataOption(CommandLineApplication subCommand)
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
        private static DatabaseOutputs ConvertToDatabaseOutputs(string optionValue)
        {

            if (optionValue == nameof(DatabaseOutputs.databasefile))
                return DatabaseOutputs.databasefile;

            throw CreateOptionValueException<DatabaseOutputs>(optionValue);

        }

        private static CommandOption CreateStageFromInputOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_Stage_Template, Option_Stage_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Enum<StagesFromInput>())
                    .IsRequired(false, Option_Stage_ErrorMessage);

        }
        private static CommandOption CreateThresholdTypeOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_ThresholdType_Template, Option_ThresholdType_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Enum<ThresholdTypes>())
                    .IsRequired(false, Option_ThresholdType_ErrorMessage);

        }
        private static CommandOption CreateThresholdValueOption(CommandLineApplication subCommand)
        {

            CommandOption result 
                = subCommand
                    .Option(Option_ThresholdValue_Template, Option_ThresholdValue_Description, CommandOptionType.SingleValue)
                    .IsRequired(false, Option_ThresholdValue_ErrorMessage);
            result.Validators.Add(new ThresholdValidator());

            return result;

        }
        private static CommandOption CreateDatabaseJsonConsoleOutputOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_Output_Template, Option_Output_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Enum<DatabaseJsonConsoleOutputs>())
                    .IsRequired(false, Option_Output_ErrorMessage);

        }
        private static CommandOption CreateMetricsOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_Metrics_Template, Option_Metrics_Description, CommandOptionType.SingleValue);

        }
        private static CommandOption CreateMetricsOutputOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_MetricsOutput_Template, Option_MetricsOutput_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Enum<JsonConsoleOutputs>());

        }
        private static CommandOption CreateParallelRequestsOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_ParallelRequests_Template, Option_ParallelRequests_Description, CommandOptionType.SingleValue);

        }
        private static CommandOption CreatePauseBetweenRequestsMsOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_PauseBetweenRequestsMs_Template, Option_PauseBetweenRequestsMs_Description, CommandOptionType.SingleValue);

        }
        private static DatabaseJsonConsoleOutputs ConvertToDatabaseJsonConsoleOutputs(string optionValue)
        {

            if (optionValue == nameof(DatabaseJsonConsoleOutputs.databasefile))
                return DatabaseJsonConsoleOutputs.databasefile;

            if (optionValue == nameof(DatabaseJsonConsoleOutputs.jsonfile))
                return DatabaseJsonConsoleOutputs.jsonfile;

            if (optionValue == nameof(DatabaseJsonConsoleOutputs.console))
                return DatabaseJsonConsoleOutputs.console;

            if (optionValue == nameof(DatabaseJsonConsoleOutputs.all))
                return DatabaseJsonConsoleOutputs.all;

            throw CreateOptionValueException<DatabaseJsonConsoleOutputs>(optionValue);

        }
        private static StagesFromInput ConvertToStagesFromInput(string optionValue)
        {

            if (optionValue == nameof(StagesFromInput.S2))
                return StagesFromInput.S2;

            if (optionValue == nameof(StagesFromInput.S3))
                return StagesFromInput.S3;

            throw CreateOptionValueException<StagesFromInput>(optionValue);

        }
        private static ThresholdTypes ConvertToThresholdTypes(string optionValue)
        {

            if (optionValue == nameof(ThresholdTypes.pagenumber))
                return ThresholdTypes.pagenumber;

            if (optionValue == nameof(ThresholdTypes.date))
                return ThresholdTypes.date;

            if (optionValue == nameof(ThresholdTypes.jobpostingid))
                return ThresholdTypes.jobpostingid;

            throw CreateOptionValueException<ThresholdTypes>(optionValue);

        }
        private static ThresholdValue ParseThresholdValue(string optionValue)
        {

            throw new Exception();

        }
        private static Stages ConvertToStages(StagesFromInput stageFromInput)
        {

            if (stageFromInput == StagesFromInput.S2)
                return Stages.Stage2_UpToAllJobPostings;

            if (stageFromInput == StagesFromInput.S3)
                return Stages.Stage3_UpToAllJobPostingsExtended;

            throw CreateOptionValueException<Stages>(nameof(stageFromInput));

        }



    }

}

/*
    Author: numbworks@gmail.com
    Last Update: 25.08.2021

    WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(MessageCollection.Program_PressAButtonToCloseTheWindow);
    Console.ReadLine();

*/