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
    /// <inheritdoc cref="ICommandLineManager"/>
    public class CommandLineManager
    {

        #region Fields

        private IThresholdValueManager _thresholdValueManager;

        #endregion

        #region Properties

        public static string Application_Name { get; } = "NW.WIDJobsClient.exe";
        public static string Application_Description { get; } = "Unofficial command-line client for WorkInDenmark.dk.";

        public static string Command_About_Name { get; } = "about";
        public static string Command_About_Description { get; } = "About this application.";
        public static string Command_Session_Name { get; } = "session";
        public static string Command_Session_Description { get; } = "Groups all the features related to a single WorkInDenmark.dk exploration session.";
        public static string Command_Service_Name { get; } = "service";
        public static string Command_Service_Description { get; } = "Groups all the features related to a continuous WorkInDenmark.dk exploration.";

        public static string SubCommand_Calculate_Name { get; } = "calculate";
        public static string SubCommand_Calculate_Description { get; } = $"Loads an {nameof(Exploration)} from a JSON file and calculates the metrics.";
        public static string SubCommand_Convert_Name { get; } = "convert";
        public static string SubCommand_Convert_Description { get; } = $"Loads an {nameof(Exploration)} from a JSON file and convert it to a SQLite database.";
        public static string SubCommand_Describe_Name { get; } = "describe";
        public static string SubCommand_Describe_Description { get; } = $"Describes the current state of WorkInDenmark.dk. It requires internet connection to work.";
        public static string SubCommand_Explore_Name { get; } = "explore";
        public static string SubCommand_Explore_Description { get; } = $"Fetches data from WorkInDenmark.dk. It requires internet connection to work.";

        public static string Option_JsonPath_Template { get; } = "--jsonpath";
        public static string Option_JsonPath_Description { get; } = $"The file path to the required JSON file.";
        public static string Option_JsonPath_ErrorMessage { get; } = $"{Option_JsonPath_Template} is mandatory.";
        public static string Option_FolderPath_Template { get; } = "--folderpath";
        public static string Option_FolderPath_Description { get; } = $"A valid folder path. If not specified, '{WIDExplorerSettings.DefaultFolderPath}' will be used.";
        public static string Option_FolderPath_ErrorMessage { get; } = $"{Option_FolderPath_Template} is mandatory.";
        public static string Option_Output_Template { get; } = "--output";
        public static string Option_Output_Description { get; } = "The output(s) of the operation.";
        public static string Option_Output_ErrorMessage { get; } = $"{Option_Output_Template} is mandatory.";
        public static string Option_AsPercentages_Template { get; } = "--aspercentages";
        public static string Option_AsPercentages_Description { get; } = "Shows the metrics as percentages instead of numbers.";
        public static string Option_UseDemoData_Template { get; } = "--usedemodata";
        public static string Option_UseDemoData_Description { get; } = $"Use demo data instead of real data. It doesn't require internet connection to work.";
        public static string Option_Stage_Template { get; } = "--stage";
        public static string Option_Stage_Description { get; } = $"The depth of an {nameof(Exploration)}.";
        public static string Option_Stage_ErrorMessage { get; } = $"{Option_Stage_Template} is mandatory.";
        public static string Option_ThresholdType_Template { get; } = "--thresholdtype";
        public static string Option_ThresholdType_Description { get; } = "The exploration proceeds until this criteria is met.";
        public static string Option_ThresholdType_ErrorMessage { get; } = $"{Option_ThresholdType_Template} is mandatory.";
        public static string Option_ThresholdValue_Template { get; } = "--thresholdvalue";
        public static string Option_ThresholdValue_Description { get; } = $"The value for the provided threshold type. Date must be provided in the 'yyyyMMdd' format.";
        public static string Option_ThresholdValue_ErrorMessage { get; } = $"{Option_ThresholdValue_Template} is mandatory.";
        public static string Option_Metrics_Template { get; } = "--metrics";
        public static string Option_Metrics_Description { get; } = "Enables the metric calculation.";
        public static string Option_ExplorationOutput_Template { get; } = "--explorationoutput";
        public static string Option_ExplorationOutput_Description { get; } = "The output(s) for the exploration.";
        public static string Option_ExplorationOutput_ErrorMessage { get; } = $"{Option_ExplorationOutput_Template} is mandatory.";
        public static string Option_MetricsOutput_Template { get; } = "--metricsoutput";
        public static string Option_MetricsOutput_Description { get; } = "The output(s) for the metric calculation.";
        public static string Option_ParallelRequests_Template { get; } = "--parallelrequests";
        public static string Option_ParallelRequests_Description { get; } = $"The number of HTTP requests to send to WorkInDenmark.dk before pausing. If not specified, '{WIDExplorerSettings.DefaultParallelRequests}' will be used.";
        public static string Option_PauseBetweenRequestsMs_Template { get; } = "--pausebetweenrequestsms";
        public static string Option_PauseBetweenRequestsMs_Description { get; } = $"The duration of the pause after x HTTP requests in milliseconds. If not specified, '{WIDExplorerSettings.DefaultPauseBetweenRequestsMs}' will be used.";

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="CommandLineManager"/> instance.</summary>	
        public CommandLineManager(IThresholdValueManager thresholdValueManager) 
        {

            // To-Do: validation

            _thresholdValueManager = thresholdValueManager;

        }

        /// <summary>Initializes a <see cref="CommandLineManager"/> instance using default parameters.</summary>	
        public CommandLineManager()
            :this(new ThresholdValueManager()) { }

        #endregion

        #region Methods_public

        public int Execute(params string[] args)
        {

            CommandLineApplication app = CreateApplication();

            return app.Execute(args);

        }

        #endregion

        #region Methods_private

        private CommandLineApplication CreateApplication()
        {

            CommandLineApplication app = new CommandLineApplication
            {

                Name = Application_Name,
                Description = Application_Description

            };

            AddRoot(app);
            AddAbout(app);
            AddSession(app);
            AddService(app);

            app.HelpOption(inherited: true);

            return app;

        }
        private CommandLineApplication AddRoot(CommandLineApplication app)
        {

            app.OnExecute(() =>
            {

                int exitCode = GenericCommand();
                app.ShowHelp();

                return exitCode;

            });

            return app;

        }
        private CommandLineApplication AddAbout(CommandLineApplication app)
        {

            app.Command(Command_About_Name, aboutCommand =>
            {

                aboutCommand = AddAboutMain(aboutCommand);

            });

            return app;

        }
        private CommandLineApplication AddAboutMain(CommandLineApplication aboutCommand)
        {

            aboutCommand.Description = Command_About_Description;
            aboutCommand.OnExecute(() =>
            {

                return About();

            });

            return aboutCommand;

        }

        private CommandLineApplication AddSession(CommandLineApplication app)
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
        private CommandLineApplication AddSessionMain(CommandLineApplication sessionCommand)
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
        private CommandLineApplication AddSessionCalculate(CommandLineApplication sessionCommand)
        {

            sessionCommand.Command(SubCommand_Calculate_Name, calculateSubCommand =>
            {

                calculateSubCommand.Description = SubCommand_Calculate_Description;

                CommandOption jsonPathOption = CreateRequiredJsonPathOption(calculateSubCommand);
                CommandOption outputOption = CreateRequiredCalculateOutputOption(calculateSubCommand);
                CommandOption folderPathOption = CreateOptionalFolderPathOption(calculateSubCommand);
                CommandOption asPercentagesOption = CreateOptionalAsPercentagesOption(calculateSubCommand);

                calculateSubCommand.OnExecute(() =>
                {

                    return SessionCalculate(
                                jsonPathOption.Value(),
                                ConvertToCalculateOutputs(outputOption.Value()),
                                folderPathOption.Value(),
                                asPercentagesOption.HasValue());

                });

            });

            return sessionCommand;

        }
        private CommandLineApplication AddSessionConvert(CommandLineApplication sessionCommand)
        {

            sessionCommand.Command(SubCommand_Convert_Name, convertSubCommand =>
            {

                convertSubCommand.Description = SubCommand_Convert_Description;

                CommandOption jsonPathOption = CreateRequiredJsonPathOption(convertSubCommand);
                CommandOption outputOption = CreateRequiredConvertOutputOption(convertSubCommand);
                CommandOption folderPathOption = CreateOptionalFolderPathOption(convertSubCommand);

                convertSubCommand.OnExecute(() =>
                {

                    return SessionConvert(
                                jsonPathOption.Value(),
                                ConvertToConvertOutputs(outputOption.Value()),
                                folderPathOption.Value());

                });

            });

            return sessionCommand;

        }
        private CommandLineApplication AddSessionDescribe(CommandLineApplication sessionCommand)
        {

            sessionCommand.Command(SubCommand_Describe_Name, describeSubCommand =>
            {

                describeSubCommand.Description = SubCommand_Describe_Description;

                CommandOption outputOption = CreateRequiredDescribeOutputOption(describeSubCommand);
                CommandOption folderPathOption = CreateOptionalFolderPathOption(describeSubCommand);
                CommandOption useDemoDataOption = CreateOptionalUseDemoDataOption(describeSubCommand);

                describeSubCommand.OnExecute(() =>
                {

                    return SessionDescribe(
                                ConvertToDescribeOutputs(outputOption.Value()),
                                folderPathOption.Value(),
                                useDemoDataOption.HasValue());

                });

            });

            return sessionCommand;

        }
        private CommandLineApplication AddSessionExplore(CommandLineApplication sessionCommand)
        {

            sessionCommand.Command(SubCommand_Explore_Name, exploreSubCommand =>
            {

                exploreSubCommand.Description = SubCommand_Explore_Description;

                CommandOption stageFromInputOption = CreateRequiredExploreStageOption(exploreSubCommand);
                CommandOption thresholdTypeOption = CreateRequiredThresholdTypeOption(exploreSubCommand);
                CommandOption thresholdValueOption = CreateRequiredThresholdValueOption(exploreSubCommand);
                CommandOption explorationOutputOption = CreateRequiredExplorationOutputOption(exploreSubCommand);
                CommandOption folderPathOption = CreateOptionalFolderPathOption(exploreSubCommand);
                CommandOption metricsOption = CreateOptionalMetricsOption(exploreSubCommand);
                CommandOption metricsOutputOption = CreateMetricsOutputOption(exploreSubCommand);
                CommandOption asPercentagesOption = CreateOptionalAsPercentagesOption(exploreSubCommand);
                CommandOption parallelRequestsOption = CreateOptionalParallelRequestsOption(exploreSubCommand);
                CommandOption pauseBetweenRequestsMsOption = CreateOptionalPauseBetweenRequestsMsOption(exploreSubCommand);
                CommandOption useDemoDataOption = CreateOptionalUseDemoDataOption(exploreSubCommand);

                exploreSubCommand.OnExecute(() =>
                {

                    return SessionExplore(
                                useDemoData: useDemoDataOption.HasValue(),
                                parallelRequests: parallelRequestsOption.Value(),
                                pauseBetweenRequestsMs: pauseBetweenRequestsMsOption.Value(),
                                folderPath: folderPathOption.Value(),
                                thresholdType: ConvertToThresholdTypes(thresholdTypeOption.Value()),
                                thresholdValue: thresholdValueOption.Value(),
                                exploreStage: ConvertToExploreStages(stageFromInputOption.Value()),
                                explorationOutput: ConvertToExploreOutputs(explorationOutputOption.Value()),
                                enableMetrics: metricsOption.HasValue(),
                                metricsOutput: ConvertToMetricsOutputs(metricsOutputOption.Value()),
                                numbersAsPercentages: asPercentagesOption.HasValue()
                                );

                });

            });

            return sessionCommand;

        }

        private CommandLineApplication AddService(CommandLineApplication app)
        {

            app.Command(Command_Service_Name, serviceCommand =>
            {

                serviceCommand = AddServiceMain(serviceCommand);

            });

            return app;

        }
        private CommandLineApplication AddServiceMain(CommandLineApplication serviceCommand)
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

        private void LogAsciiBanner()
        {

            WIDExplorer widExplorer = new WIDExplorer();

            WIDExplorerComponents.DefaultLoggingActionAsciiBanner(string.Empty);
            widExplorer.LogAsciiBanner();

        }
        private int GenericCommand()
        {

            LogAsciiBanner();

            return ((int)ExitCodes.Success);

        }
        private int About()
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
        private int SessionCalculate(string filePath, CalculateOutputs output, string folderPath, bool numbersAsPercentages)
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
        private int SessionConvert(string filePath, ConvertOutputs output, string folderPath)
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
        private int SessionDescribe(DescribeOutputs output, string folderPath, bool useDemoData)
        {

            try
            {

                LogAsciiBanner();

                WIDExplorerComponents components = CreateComponents(useDemoData);
                WIDExplorerSettings settings = CreateSettings(folderPath: folderPath);
                WIDExplorer widExplorer = new WIDExplorer(components, settings);
                Exploration exploration = widExplorer.Explore(1, Stages.Stage1_OnlyMetrics);

                if (output == DescribeOutputs.console)
                    return DumpExplorationToConsole(widExplorer, exploration);

                else if (output == DescribeOutputs.jsonfile)
                    return SaveExplorationToJson(widExplorer, exploration);

                else if (output == DescribeOutputs.both)
                    return DumpExplorationToConsoleAndSaveToJson(widExplorer, exploration);

                else
                    throw CreateOptionValueException<DescribeOutputs>(output.ToString());

            }
            catch (Exception e)
            {

                return DumpExceptionToConsole(e);

            }

        }
        private int SessionExplore(
            bool useDemoData, 
            string parallelRequests, 
            string pauseBetweenRequestsMs, 
            string folderPath,
            ThresholdTypes thresholdType, 
            string thresholdValue, 
            ExploreStages exploreStage, 
            ExploreOutputs explorationOutput,
            bool enableMetrics, 
            MetricsOutputs metricsOutput, 
            bool numbersAsPercentages)
        {

            try
            {

                LogAsciiBanner();

                WIDExplorerComponents components = CreateComponents(useDemoData: useDemoData);
                WIDExplorerSettings settings = CreateSettings(parallelRequests: parallelRequests, pauseBetweenRequestsMs: pauseBetweenRequestsMs, folderPath: folderPath);
                Stages stage = ConvertToStages(exploreStage);
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

        private ushort? TryParseParallelRequests(string parallelRequests)
        {

            if (parallelRequests == null)
                return null;

            return ushort.Parse(parallelRequests);

        }
        private uint? TryParsePauseBetweenRequestsMs(string pauseBetweenRequestsMs)
        {

            if (pauseBetweenRequestsMs == null)
                return null;

            return uint.Parse(pauseBetweenRequestsMs);

        }
        private WIDExplorerComponents CreateComponents(bool useDemoData)
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
        private WIDExplorerSettings CreateSettings
            (string parallelRequests = null, string pauseBetweenRequestsMs = null, string folderPath = null, bool? deleteAndRecreateDatabase = null)
        {

            return new WIDExplorerSettings(
                            parallelRequests: TryParseParallelRequests(parallelRequests) ?? WIDExplorerSettings.DefaultParallelRequests,
                            pauseBetweenRequestsMs: TryParsePauseBetweenRequestsMs(pauseBetweenRequestsMs) ?? WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                            folderPath: folderPath ?? WIDExplorerSettings.DefaultFolderPath,
                            deleteAndRecreateDatabase: deleteAndRecreateDatabase ?? WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                        );

        }

        private Exception CreateOptionValueException<T>(string optionValue)
           => new Exception(MessageCollection.Program_OptionValueCantBeConvertedTo.Invoke(optionValue, typeof(T)));
        private CalculateOutputs ConvertToCalculateOutputs(string optionValue)
        {

            if (optionValue == nameof(CalculateOutputs.jsonfile))
                return CalculateOutputs.jsonfile;

            if (optionValue == nameof(CalculateOutputs.console))
                return CalculateOutputs.console;

            if (optionValue == nameof(CalculateOutputs.both))
                return CalculateOutputs.both;

            throw CreateOptionValueException<CalculateOutputs>(optionValue);

        }
        private DescribeOutputs ConvertToDescribeOutputs(string optionValue)
        {

            if (optionValue == nameof(DescribeOutputs.jsonfile))
                return DescribeOutputs.jsonfile;

            if (optionValue == nameof(DescribeOutputs.console))
                return DescribeOutputs.console;

            if (optionValue == nameof(DescribeOutputs.both))
                return DescribeOutputs.both;

            throw CreateOptionValueException<DescribeOutputs>(optionValue);

        }
        private MetricsOutputs ConvertToMetricsOutputs(string optionValue)
        {

            if (optionValue == nameof(MetricsOutputs.jsonfile))
                return MetricsOutputs.jsonfile;

            if (optionValue == nameof(MetricsOutputs.console))
                return MetricsOutputs.console;

            if (optionValue == nameof(MetricsOutputs.both))
                return MetricsOutputs.both;

            throw CreateOptionValueException<MetricsOutputs>(optionValue);

        }
        private ConvertOutputs ConvertToConvertOutputs(string optionValue)
        {

            if (optionValue == nameof(ConvertOutputs.databasefile))
                return ConvertOutputs.databasefile;

            throw CreateOptionValueException<ConvertOutputs>(optionValue);

        }
        private ExploreOutputs ConvertToExploreOutputs(string optionValue)
        {

            if (optionValue == nameof(ExploreOutputs.databasefile))
                return ExploreOutputs.databasefile;

            if (optionValue == nameof(ExploreOutputs.jsonfile))
                return ExploreOutputs.jsonfile;

            if (optionValue == nameof(ExploreOutputs.console))
                return ExploreOutputs.console;

            if (optionValue == nameof(ExploreOutputs.all))
                return ExploreOutputs.all;

            throw CreateOptionValueException<ExploreOutputs>(optionValue);

        }
        private ExploreStages ConvertToExploreStages(string optionValue)
        {

            if (optionValue == nameof(ExploreStages.S2))
                return ExploreStages.S2;

            if (optionValue == nameof(ExploreStages.S3))
                return ExploreStages.S3;

            throw CreateOptionValueException<ExploreStages>(optionValue);

        }
        private ThresholdTypes ConvertToThresholdTypes(string optionValue)
        {

            if (optionValue == nameof(ThresholdTypes.finalpagenumber))
                return ThresholdTypes.finalpagenumber;

            if (optionValue == nameof(ThresholdTypes.thresholddate))
                return ThresholdTypes.thresholddate;

            if (optionValue == nameof(ThresholdTypes.jobpostingid))
                return ThresholdTypes.jobpostingid;

            throw CreateOptionValueException<ThresholdTypes>(optionValue);

        }
        private Stages ConvertToStages(ExploreStages exploreStage)
        {

            if (exploreStage == ExploreStages.S2)
                return Stages.Stage2_UpToAllJobPostings;

            if (exploreStage == ExploreStages.S3)
                return Stages.Stage3_UpToAllJobPostingsExtended;

            throw CreateOptionValueException<Stages>(exploreStage.ToString());

        }

        private Exception CreateMappingException<TInput, TOutput>(string value)
           => new Exception(MessageCollection.Program_FirstEnumCantBeMapped.Invoke(typeof(TInput), typeof(TOutput), value));
        private MetricsOutputs Map(CalculateOutputs output)
        {

            if (output.ToString() == nameof(CalculateOutputs.jsonfile))
                return MetricsOutputs.jsonfile;

            if (output.ToString() == nameof(CalculateOutputs.console))
                return MetricsOutputs.console;

            if (output.ToString() == nameof(CalculateOutputs.both))
                return MetricsOutputs.both;

            throw CreateMappingException<CalculateOutputs, MetricsOutputs>(output.ToString());

        }

        private void DumpJsonToConsole(string json)
        {

            WIDExplorerComponents.DefaultLoggingAction.Invoke(MessageCollection.Program_DumpingJsonToConsole);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(json);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

        }
        private int DumpExceptionToConsole(Exception e)
        {

            WIDExplorerComponents.DefaultLoggingAction.Invoke(MessageCollection.Program_FormattedErrorMessage.Invoke(e.Message));
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            return ((int)ExitCodes.Failure);

        }
        private int DumpExplorationToConsole(WIDExplorer widExplorer, Exploration exploration)
        {

            string json = widExplorer.ConvertToJson(exploration);
            DumpJsonToConsole(json);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            return ((int)ExitCodes.Success);

        }
        private int DumpExplorationToConsoleAndSaveToJson(WIDExplorer widExplorer, Exploration exploration)
        {

            DumpExplorationToConsole(widExplorer, exploration);

            return SaveExplorationToJson(widExplorer, exploration);

        }
        private int DumpExplorationToConsoleAndSaveToJsonDatabase(WIDExplorer widExplorer, Exploration exploration)
        {

            DumpExplorationToConsole(widExplorer, exploration);

            int exitCode1 = SaveExplorationToJson(widExplorer, exploration);
            int exitCode2 = SaveExplorationToDatabaseFile(widExplorer, exploration);

            if (exitCode1 == ((int)ExitCodes.Success) && exitCode2 == ((int)ExitCodes.Success))
                return ((int)ExitCodes.Success);

            return ((int)ExitCodes.Failure);

        }
        private int DumpMetricCollectionToConsole(WIDExplorer widExplorer, MetricCollection metricCollection, bool numbersAsPercentages)
        {

            string json = widExplorer.ConvertToJson(metricCollection, numbersAsPercentages);
            DumpJsonToConsole(json);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            return ((int)ExitCodes.Success);

        }
        private int DumpMetricCollectionToConsoleAndSaveToJson(WIDExplorer widExplorer, MetricCollection metricCollection, bool numbersAsPercentages)
        {

            DumpMetricCollectionToConsole(widExplorer, metricCollection, numbersAsPercentages);

            return SaveMetricCollectionToJson(widExplorer, metricCollection, numbersAsPercentages);

        }
        private int SaveExplorationToJson(WIDExplorer widExplorer, Exploration exploration)
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
        private int SaveExplorationToDatabaseFile(WIDExplorer widExplorer, Exploration exploration)
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
        private int SaveMetricCollectionToJson(WIDExplorer widExplorer, MetricCollection metricCollection, bool numbersAsPercentages)
        {

            IFileInfoAdapter fileInfoAdapter = widExplorer.SaveToJsonFile(metricCollection, numbersAsPercentages);
            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            if (!fileInfoAdapter.Exists)
            {

                WIDExplorerComponents.DefaultLoggingAction.Invoke(MessageCollection.Program_FileHasNotBeenCreated.Invoke(fileInfoAdapter.FullName));
                WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

                return ((int)ExitCodes.Failure);

            }

            WIDExplorerComponents.DefaultLoggingActionAsciiBanner.Invoke(string.Empty);

            return ((int)ExitCodes.Success);

        }

        private CommandOption CreateRequiredCalculateOutputOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_Output_Template, Option_Output_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Enum<CalculateOutputs>())
                    .IsRequired(false, Option_Output_ErrorMessage);

        }
        private CommandOption CreateRequiredConvertOutputOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_Output_Template, Option_Output_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Enum<ConvertOutputs>())
                    .IsRequired(false, Option_Output_ErrorMessage);

        }
        private CommandOption CreateRequiredDescribeOutputOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_Output_Template, Option_Output_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Enum<DescribeOutputs>())
                    .IsRequired(false, Option_Output_ErrorMessage);

        }
        private CommandOption CreateRequiredExplorationOutputOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_ExplorationOutput_Template, Option_ExplorationOutput_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Enum<ExploreOutputs>())
                    .IsRequired(false, Option_ExplorationOutput_ErrorMessage);

        }
        private CommandOption CreateMetricsOutputOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_MetricsOutput_Template, Option_MetricsOutput_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Enum<MetricsOutputs>());

        }

        private CommandOption CreateRequiredJsonPathOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_JsonPath_Template, Option_JsonPath_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.ExistingFile())
                    .IsRequired(false, Option_JsonPath_ErrorMessage);

        }
        private CommandOption CreateOptionalFolderPathOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_FolderPath_Template, Option_FolderPath_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.ExistingDirectory());

        }
        private CommandOption CreateOptionalAsPercentagesOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_AsPercentages_Template, Option_AsPercentages_Description, CommandOptionType.NoValue);

        }
        private CommandOption CreateOptionalUseDemoDataOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_UseDemoData_Template, Option_UseDemoData_Description, CommandOptionType.NoValue);

        }
        private CommandOption CreateRequiredExploreStageOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_Stage_Template, Option_Stage_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Enum<ExploreStages>())
                    .IsRequired(false, Option_Stage_ErrorMessage);

        }
        private CommandOption CreateRequiredThresholdTypeOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_ThresholdType_Template, Option_ThresholdType_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Enum<ThresholdTypes>())
                    .IsRequired(false, Option_ThresholdType_ErrorMessage);

        }
        private CommandOption CreateRequiredThresholdValueOption(CommandLineApplication subCommand)
        {

            CommandOption result
                = subCommand
                    .Option(Option_ThresholdValue_Template, Option_ThresholdValue_Description, CommandOptionType.SingleValue)
                    .IsRequired(false, Option_ThresholdValue_ErrorMessage)
                    .Accepts(validator => validator.Use(new ThresholdValueValidator()));

            return result;

        }
        private CommandOption CreateOptionalMetricsOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_Metrics_Template, Option_Metrics_Description, CommandOptionType.SingleValue);

        }
        private CommandOption CreateOptionalParallelRequestsOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_ParallelRequests_Template, Option_ParallelRequests_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Use(new ParallelRequestsValidator()));

        }
        private CommandOption CreateOptionalPauseBetweenRequestsMsOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_PauseBetweenRequestsMs_Template, Option_PauseBetweenRequestsMs_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Use(new PauseBetweenRequestsValidator()));

        }

        private int OrchestrateMetricCollection(WIDExplorer widExplorer, Exploration exploration, MetricsOutputs output, bool numbersAsPercentages)
        {

            MetricCollection metricCollection = widExplorer.ConvertToMetricCollection(exploration);

            if (output == MetricsOutputs.console)
                return DumpMetricCollectionToConsole(widExplorer, metricCollection, numbersAsPercentages);

            if (output == MetricsOutputs.jsonfile)
                return SaveMetricCollectionToJson(widExplorer, metricCollection, numbersAsPercentages);

            if (output == MetricsOutputs.both)
                return DumpMetricCollectionToConsoleAndSaveToJson(widExplorer, metricCollection, numbersAsPercentages);

            throw CreateOptionValueException<MetricsOutputs>(output.ToString());

        }
        private int OrchestrateMetricCollection(WIDExplorer widExplorer, Exploration exploration, CalculateOutputs output, bool numbersAsPercentages)
            => OrchestrateMetricCollection(widExplorer, exploration, Map(output), numbersAsPercentages);
        private int OrchestrateExploration(
            WIDExplorer widExplorer, 
            Exploration exploration, 
            ExploreOutputs explorationOutput,
            bool enableMetrics, 
            MetricsOutputs metricsOutput, 
            bool numbersAsPercentages)
        {

            if (explorationOutput == ExploreOutputs.console)
                return DumpExplorationToConsole(widExplorer, exploration);

            else if (explorationOutput == ExploreOutputs.jsonfile)
                return SaveExplorationToJson(widExplorer, exploration);

            else if (explorationOutput == ExploreOutputs.databasefile)
                return SaveExplorationToDatabaseFile(widExplorer, exploration);

            else if (explorationOutput == ExploreOutputs.all)
                return DumpExplorationToConsoleAndSaveToJsonDatabase(widExplorer, exploration);

            else
                throw CreateOptionValueException<ExploreOutputs>(explorationOutput.ToString());

            if (!enableMetrics)
                return ((int)ExitCodes.Success);

            return OrchestrateMetricCollection(widExplorer, exploration, metricsOutput, numbersAsPercentages);

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.08.2021
*/