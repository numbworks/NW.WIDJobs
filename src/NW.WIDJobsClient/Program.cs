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
        static string Command_Session_Name = "session";
        static string Command_Session_Description = "Groups all the features related to a single WorkInDenmark.dk exploration session.";
        static string Command_Service_Name = "service";
        static string Command_Service_Description = "Groups all the features related to a continuous WorkInDenmark.dk exploration.";

        static string SubCommand_Calculate_Name = "calculate";
        static string SubCommand_Calculate_Description = $"Loads an {nameof(Exploration)} from a JSON file and calculates the metrics.";
        static string SubCommand_Convert_Name = "convert";
        static string SubCommand_Convert_Description = $"Loads an {nameof(Exploration)} from a JSON file and convert it to a SQLite database.";
        static string SubCommand_Describe_Name = "describe";
        static string SubCommand_Describe_Description = $"Describes the current state of WorkInDenmark.dk. It requires internet connection to work.";
        static string SubCommand_Explore_Name = "explore";
        static string SubCommand_Explore_Description = $"Fetches data from WorkInDenmark.dk. It requires internet connection to work.";

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
        static string Option_AsPercentages_Description = "Shows the metrics as percentages instead of numbers.";
        static string Option_UseDemoData_Template = "--usedemodata";
        static string Option_UseDemoData_Description = $"Use demo data instead of real data. It doesn't require internet connection to work.";
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
        static string Option_ExplorationOutput_Template = "--explorationoutput";
        static string Option_ExplorationOutput_Description = "The output(s) for the exploration.";
        static string Option_ExplorationOutput_ErrorMessage = $"{Option_ExplorationOutput_Template} is mandatory.";
        static string Option_MetricsOutput_Template = "--metricsoutput";
        static string Option_MetricsOutput_Description = "The output(s) for the metric calculation.";
        static string Option_ParallelRequests_Template = "--parallelrequests";
        static string Option_ParallelRequests_Description = $"The number of HTTP requests to send to WorkInDenmark.dk before pausing. If not specified, '{WIDExplorerSettings.DefaultParallelRequests}' will be used.";
        static string Option_PauseBetweenRequestsMs_Template = "--pausebetweenrequestsms";
        static string Option_PauseBetweenRequestsMs_Description = $"The duration of the pause after x HTTP requests in milliseconds. If not specified, '{WIDExplorerSettings.DefaultPauseBetweenRequestsMs}' will be used.";

        #endregion

        static IThresholdValueManager _thresholdValueManager = new ThresholdValueManager();

        // Methods_Public
        static int Main(string[] args)
        {

            CommandLineApplication app = CreateApplication();

            return app.Execute(args);

        }

        // Methods_Private
        private static CommandLineApplication CreateApplication()
        {

            CommandLineApplication app = new CommandLineApplication
            {

                Name = Application_Name,
                Description = Application_Description

            };

            AddRoot(app);
            AddAbout(app);
            AddSession(app);

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

        private static CommandLineApplication AddSession(CommandLineApplication app)
        {

            app.Command(Command_Session_Name, sessionCommand =>
            {

                sessionCommand = AddSessionMain(sessionCommand);
                sessionCommand = AddSessionCalculate(sessionCommand);
                sessionCommand = AddSessionConvert(sessionCommand);
                sessionCommand = AddSessionDescribe(sessionCommand);
                sessionCommand = AddSessionExplore(sessionCommand);

            });

            return app;

        }
        private static CommandLineApplication AddSessionMain(CommandLineApplication sessionCommand)
        {

            sessionCommand.Description = Command_Session_Description;
            sessionCommand.OnExecute(() =>
            {

                int exitCode = GenericCommand();
                sessionCommand.ShowHelp();

                return exitCode;

            });

            return sessionCommand;

        }
        private static CommandLineApplication AddSessionCalculate(CommandLineApplication sessionCommand)
        {

            sessionCommand.Command(SubCommand_Calculate_Name, calculateSubCommand =>
            {

                calculateSubCommand.Description = SubCommand_Calculate_Description;

                CommandOption jsonPathOption = CreateJsonPathOption(calculateSubCommand);
                CommandOption outputOption = CreateJsonConsoleOutputOption(calculateSubCommand);
                CommandOption folderPathOption = CreateOptionalFolderPathOption(calculateSubCommand);
                CommandOption asPercentagesOption = CreateAsPercentagesOption(calculateSubCommand);

                calculateSubCommand.OnExecute(() =>
                {

                    return SessionCalculate(
                                jsonPathOption.Value(),
                                ConvertToJsonConsoleOutputs(outputOption.Value()),
                                folderPathOption.Value(),
                                asPercentagesOption.HasValue());

                });

            });

            return sessionCommand;

        }
        private static CommandLineApplication AddSessionConvert(CommandLineApplication sessionCommand)
        {

            sessionCommand.Command(SubCommand_Convert_Name, convertSubCommand =>
            {

                convertSubCommand.Description = SubCommand_Convert_Description;

                CommandOption jsonPathOption = CreateJsonPathOption(convertSubCommand);
                CommandOption outputOption = CreateDatabaseOutputOption(convertSubCommand);
                CommandOption folderPathOption = CreateRequiredFolderPathOption(convertSubCommand);

                convertSubCommand.OnExecute(() =>
                {

                    return SessionConvert(
                                jsonPathOption.Value(), 
                                ConvertToDatabaseOutputs(outputOption.Value()),
                                folderPathOption.Value());

                });

            });

            return sessionCommand;

        }
        private static CommandLineApplication AddSessionDescribe(CommandLineApplication sessionCommand)
        {

            sessionCommand.Command(SubCommand_Describe_Name, describeSubCommand =>
            {

                describeSubCommand.Description = SubCommand_Describe_Description;

                CommandOption outputOption = CreateJsonConsoleOutputOption(describeSubCommand);
                CommandOption folderPathOption = CreateOptionalFolderPathOption(describeSubCommand);
                CommandOption useDemoDataOption = CreateUseDemoDataOption(describeSubCommand);

                describeSubCommand.OnExecute(() =>
                {

                    return SessionDescribe(
                                ConvertToJsonConsoleOutputs(outputOption.Value()), 
                                folderPathOption.Value(), 
                                useDemoDataOption.HasValue());

                });

            });

            return sessionCommand;

        }
        private static CommandLineApplication AddSessionExplore(CommandLineApplication sessionCommand)
        {

            sessionCommand.Command(SubCommand_Explore_Name, exploreSubCommand =>
            {

                exploreSubCommand.Description = SubCommand_Explore_Description;

                CommandOption stageFromInputOption = CreateStageFromInputOption(exploreSubCommand);
                CommandOption thresholdTypeOption = CreateThresholdTypeOption(exploreSubCommand);
                CommandOption thresholdValueOption = CreateThresholdValueOption(exploreSubCommand);
                CommandOption explorationOutputOption = CreateExplorationOutputOption(exploreSubCommand);
                CommandOption folderPathOption = CreateOptionalFolderPathOption(exploreSubCommand);
                CommandOption metricsOption = CreateMetricsOption(exploreSubCommand);
                CommandOption metricsOutputOption = CreateMetricsOutputOption(exploreSubCommand);
                CommandOption asPercentagesOption = CreateAsPercentagesOption(exploreSubCommand);
                CommandOption parallelRequestsOption = CreateParallelRequestsOption(exploreSubCommand);
                CommandOption pauseBetweenRequestsMsOption = CreatePauseBetweenRequestsMsOption(exploreSubCommand);
                CommandOption useDemoDataOption = CreateUseDemoDataOption(exploreSubCommand);

                exploreSubCommand.OnExecute(() =>
                {

                    return SessionExplore(
                                useDemoData: useDemoDataOption.HasValue(),
                                parallelRequests: parallelRequestsOption.Value(),
                                pauseBetweenRequestsMs: pauseBetweenRequestsMsOption.Value(),
                                folderPath: folderPathOption.Value(),
                                thresholdType: ConvertToThresholdTypes(thresholdTypeOption.Value()),
                                thresholdValue: thresholdValueOption.Value(),
                                stageFromInput: ConvertToStagesFromInput(stageFromInputOption.Value()),
                                explorationOutput: ConvertToDatabaseJsonConsoleOutputs(explorationOutputOption.Value()),
                                enableMetrics: metricsOption.HasValue(),
                                metricsOutput: ConvertToJsonConsoleOutputs(metricsOutputOption.Value()),
                                numbersAsPercentages: asPercentagesOption.HasValue()
                                );

                });

            });

            return sessionCommand;

        }

        private static CommandLineApplication AddService(CommandLineApplication app)
        {

            app.Command(Command_Service_Name, serviceCommand =>
            {

                serviceCommand = AddSessionMain(serviceCommand);

            });

            return app;

        }
        private static CommandLineApplication AddServiceMain(CommandLineApplication serviceCommand)
        {

            serviceCommand.Description = Command_Service_Description;
            serviceCommand.OnExecute(() =>
            {

                int exitCode = GenericCommand();
                serviceCommand.ShowHelp();

                return exitCode;

            });

            return serviceCommand;

        }

        private static void LogAsciiBanner()
        {

            WIDExplorer widExplorer = new WIDExplorer();

            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(string.Empty);
            widExplorer.LogAsciiBanner();

        }
        private static int GenericCommand()
        {

            LogAsciiBanner();

            return ((int)ExitCodes.Success);

        }
        private static int About()
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
        private static int SessionCalculate(string filePath, JsonConsoleOutputs output, string folderPath, bool numbersAsPercentages)
        {

            try
            {

                LogAsciiBanner();

                WIDExplorerComponents components = CreateComponents(useDemoData: false);
                WIDExplorerSettings settings = CreateSettings(folderPath: folderPath);
                WIDExplorer widExplorer = new WIDExplorer(components, settings);
                Exploration exploration = widExplorer.LoadExplorationFromJsonFile(filePath);

                return OrchestrateMetricCollection(widExplorer, exploration, output, numbersAsPercentages);

            }
            catch (Exception e)
            {

                return DumpExceptionToConsole(e);

            }

        }
        private static int SessionConvert(string filePath, DatabaseOutputs output, string folderPath)
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
        private static int SessionDescribe(JsonConsoleOutputs output, string folderPath, bool useDemoData)
        {

            try
            {

                LogAsciiBanner();

                WIDExplorerComponents components = CreateComponents(useDemoData);
                WIDExplorerSettings settings = CreateSettings(folderPath: folderPath);
                WIDExplorer widExplorer = new WIDExplorer(components, settings);
                Exploration exploration = widExplorer.Explore(1, Stages.Stage1_OnlyMetrics);

                if (output == JsonConsoleOutputs.console)
                    return DumpExplorationToConsole(widExplorer, exploration);

                else if (output == JsonConsoleOutputs.jsonfile)
                    return SaveExplorationToJson(widExplorer, exploration);

                else if (output == JsonConsoleOutputs.both)
                    return DumpExplorationToConsoleAndSaveToJson(widExplorer, exploration);
                
                else
                    throw CreateOptionValueException<JsonConsoleOutputs>(output.ToString());

            }
            catch (Exception e)
            {

                return DumpExceptionToConsole(e);

            }

        }
        private static int SessionExplore
            (bool useDemoData, string parallelRequests, string pauseBetweenRequestsMs, string folderPath,
            ThresholdTypes thresholdType, string thresholdValue, StagesFromInput stageFromInput, DatabaseJsonConsoleOutputs explorationOutput,
            bool enableMetrics, JsonConsoleOutputs metricsOutput, bool numbersAsPercentages)
        {

            try 
            {

                LogAsciiBanner();

                WIDExplorerComponents components = CreateComponents(useDemoData: useDemoData);
                WIDExplorerSettings settings = CreateSettings(parallelRequests: parallelRequests, pauseBetweenRequestsMs: pauseBetweenRequestsMs, folderPath: folderPath);
                Stages stage = ConvertToStages(stageFromInput);
                WIDExplorer widExplorer = new WIDExplorer(components, settings);                            
                Exploration exploration;
                
                if (thresholdType == ThresholdTypes.finalpagenumber)
                    exploration = widExplorer.Explore(_thresholdValueManager.ParseFinalPageNumber(thresholdValue), stage);

                else if (thresholdType == ThresholdTypes.thresholddate)
                    exploration = widExplorer.Explore(_thresholdValueManager.ParseThresholdDate(thresholdValue), stage);

                else if (thresholdType == ThresholdTypes.jobpostingid)
                    exploration = widExplorer.Explore(thresholdValue, stage);

                else
                    throw CreateOptionValueException<ThresholdTypes>(thresholdType.ToString());

                return OrchestrateExploration(widExplorer, exploration, explorationOutput, enableMetrics, metricsOutput, numbersAsPercentages);

            }
            catch (Exception e)
            {

                return DumpExceptionToConsole(e);

            }

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

        private static Exception CreateOptionValueException<T>(string optionValue)
           => new Exception(MessageCollection.Program_OptionValueCantBeConvertedTo.Invoke(optionValue, typeof(T)));
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
        private static DatabaseOutputs ConvertToDatabaseOutputs(string optionValue)
        {

            if (optionValue == nameof(DatabaseOutputs.databasefile))
                return DatabaseOutputs.databasefile;

            throw CreateOptionValueException<DatabaseOutputs>(optionValue);

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

            if (optionValue == nameof(ThresholdTypes.finalpagenumber))
                return ThresholdTypes.finalpagenumber;

            if (optionValue == nameof(ThresholdTypes.thresholddate))
                return ThresholdTypes.thresholddate;

            if (optionValue == nameof(ThresholdTypes.jobpostingid))
                return ThresholdTypes.jobpostingid;

            throw CreateOptionValueException<ThresholdTypes>(optionValue);

        }
        private static Stages ConvertToStages(StagesFromInput stageFromInput)
        {

            if (stageFromInput == StagesFromInput.S2)
                return Stages.Stage2_UpToAllJobPostings;

            if (stageFromInput == StagesFromInput.S3)
                return Stages.Stage3_UpToAllJobPostingsExtended;

            throw CreateOptionValueException<Stages>(stageFromInput.ToString());

        }

        private static void DumpJsonToConsole(string json)
        {

            WIDExplorerComponents.DefaultLoggingAction.Invoke(MessageCollection.Program_DumpingJsonToConsole);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(json);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

        }
        private static int DumpExceptionToConsole(Exception e)
        {

            WIDExplorerComponents.DefaultLoggingAction.Invoke(MessageCollection.Program_FormattedErrorMessage.Invoke(e.Message));
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            return ((int)ExitCodes.Failure);

        }
        private static int DumpExplorationToConsole(WIDExplorer widExplorer, Exploration exploration)
        {

            string json = widExplorer.ConvertToJson(exploration);
            DumpJsonToConsole(json);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            return ((int)ExitCodes.Success);

        }
        private static int DumpExplorationToConsoleAndSaveToJson(WIDExplorer widExplorer, Exploration exploration)
        {

            DumpExplorationToConsole(widExplorer, exploration);

            return SaveExplorationToJson(widExplorer, exploration);

        }
        private static int DumpExplorationToConsoleAndSaveToJsonDatabase(WIDExplorer widExplorer, Exploration exploration)
        {

            DumpExplorationToConsole(widExplorer, exploration);

            int exitCode1 = SaveExplorationToJson(widExplorer, exploration);
            int exitCode2 = SaveExplorationToDatabaseFile(widExplorer, exploration);

            if (exitCode1 == ((int)ExitCodes.Success) && exitCode2 == ((int)ExitCodes.Success))
                return ((int)ExitCodes.Success);

            return ((int)ExitCodes.Failure);

        }
        private static int DumpMetricCollectionToConsole(WIDExplorer widExplorer, MetricCollection metricCollection, bool numbersAsPercentages)
        {

            string json = widExplorer.ConvertToJson(metricCollection, numbersAsPercentages);
            DumpJsonToConsole(json);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            return ((int)ExitCodes.Success);

        }
        private static int DumpMetricCollectionToConsoleAndSaveToJson(WIDExplorer widExplorer, MetricCollection metricCollection, bool numbersAsPercentages)
        {

            DumpMetricCollectionToConsole(widExplorer, metricCollection, numbersAsPercentages);

            return SaveMetricCollectionToJson(widExplorer, metricCollection, numbersAsPercentages);

        }
        private static int SaveExplorationToJson(WIDExplorer widExplorer, Exploration exploration)
        {

            IFileInfoAdapter fileInfoAdapter = widExplorer.SaveToJsonFile(exploration);

            if (!fileInfoAdapter.Exists)
            {

                WIDExplorerComponents.DefaultLoggingAction.Invoke(MessageCollection.Program_FileHasNotBeenCreated.Invoke(fileInfoAdapter.FullName));
                WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

                return ((int)ExitCodes.Failure);

            }

            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            return ((int)ExitCodes.Success);

        }
        private static int SaveExplorationToDatabaseFile(WIDExplorer widExplorer, Exploration exploration)
        {

            IFileInfoAdapter fileInfoAdapter = widExplorer.SaveToSQLiteDatabase(exploration.JobPostingsExtended);

            if (!fileInfoAdapter.Exists)
            {

                WIDExplorerComponents.DefaultLoggingAction.Invoke(MessageCollection.Program_FileHasNotBeenCreated.Invoke(fileInfoAdapter.FullName));
                WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

                return ((int)ExitCodes.Failure);

            }

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
                    .IsRequired(false, Option_ThresholdValue_ErrorMessage)
                    .Accepts(validator => validator.Use(new ThresholdValueValidator()));

            return result;

        }
        private static CommandOption CreateExplorationOutputOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_ExplorationOutput_Template, Option_ExplorationOutput_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Enum<DatabaseJsonConsoleOutputs>())
                    .IsRequired(false, Option_ExplorationOutput_ErrorMessage);

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
                    .Option(Option_ParallelRequests_Template, Option_ParallelRequests_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Use(new ParallelRequestsValidator()));

        }
        private static CommandOption CreatePauseBetweenRequestsMsOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_PauseBetweenRequestsMs_Template, Option_PauseBetweenRequestsMs_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Use(new PauseBetweenRequestsValidator()));

        }

        private static int OrchestrateMetricCollection(WIDExplorer widExplorer, Exploration exploration, JsonConsoleOutputs output, bool numbersAsPercentages)
        {

            MetricCollection metricCollection = widExplorer.ConvertToMetricCollection(exploration);

            if (output == JsonConsoleOutputs.console)
                return DumpMetricCollectionToConsole(widExplorer, metricCollection, numbersAsPercentages);

            if (output == JsonConsoleOutputs.jsonfile)
                return SaveMetricCollectionToJson(widExplorer, metricCollection, numbersAsPercentages);

            if (output == JsonConsoleOutputs.both)
                return DumpMetricCollectionToConsoleAndSaveToJson(widExplorer, metricCollection, numbersAsPercentages);

            throw CreateOptionValueException<JsonConsoleOutputs>(output.ToString());

        }
        private static int OrchestrateExploration
            (WIDExplorer widExplorer, Exploration exploration, DatabaseJsonConsoleOutputs explorationOutput,
            bool enableMetrics, JsonConsoleOutputs metricsOutput, bool numbersAsPercentages)
        {

            if (explorationOutput == DatabaseJsonConsoleOutputs.console)
                return DumpExplorationToConsole(widExplorer, exploration);

            else if (explorationOutput == DatabaseJsonConsoleOutputs.jsonfile)
                return SaveExplorationToJson(widExplorer, exploration);

            else if (explorationOutput == DatabaseJsonConsoleOutputs.databasefile)
                return SaveExplorationToDatabaseFile(widExplorer, exploration);

            else if (explorationOutput == DatabaseJsonConsoleOutputs.all)
                return DumpExplorationToConsoleAndSaveToJsonDatabase(widExplorer, exploration);

            else
                throw CreateOptionValueException<DatabaseJsonConsoleOutputs>(explorationOutput.ToString());

            if (!enableMetrics)
                return ((int)ExitCodes.Success);

            return OrchestrateMetricCollection(widExplorer, exploration, metricsOutput, numbersAsPercentages);

        }

    }

}

/*
    Author: numbworks@gmail.com
    Last Update: 2.08.2021

    WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(MessageCollection.Program_PressAButtonToCloseTheWindow);
    Console.ReadLine();

*/