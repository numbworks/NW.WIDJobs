using System;
using NW.WIDJobs;
using NW.WIDJobs.Explorations;
using NW.WIDJobs.Metrics;
using NW.WIDJobs.Files;
using NW.WIDJobsClient.CommandLineAccepts;
using NW.WIDJobsClient.CommandLineValidators;
using McMaster.Extensions.CommandLineUtils;
using System.Collections.Generic;
using NW.NGramTextClassification.LabeledExamples;
using NW.WIDJobs.Validation;

namespace NW.WIDJobsClient.CommandLine
{
    /// <inheritdoc cref="ICommandLineManager"/>
    public class CommandLineManager : ICommandLineManager
    {

        #region Fields

        private IThresholdValueManager _thresholdValueManager;
        private IWIDExplorerComponentsFactory _componentsFactory;
        private IWIDExplorerSettingsFactory _settingsFactory;
        private WIDExplorerComponents _defaultComponents;
        private WIDExplorerComponents _demodataComponents;

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
        public static string Command_Extra_Name { get; } = "extra";
        public static string Command_Extra_Description { get; } = "All the extra features that don't fit in the two main groups.";

        public static string SubCommand_Calculate_Name { get; } = "calculate";
        public static string SubCommand_Calculate_Description { get; } = $"Loads an {nameof(Exploration)} from a JSON file and calculates the metrics.";
        public static string SubCommand_Convert_Name { get; } = "convert";
        public static string SubCommand_Convert_Description { get; } = $"Loads an {nameof(Exploration)} from a JSON file and convert it to a SQLite database.";
        public static string SubCommand_Describe_Name { get; } = "describe";
        public static string SubCommand_Describe_Description { get; } = "Describes the current state of WorkInDenmark.dk. It requires internet connection to work.";
        public static string SubCommand_Explore_Name { get; } = "explore";
        public static string SubCommand_Explore_Description { get; } = "Fetches data from WorkInDenmark.dk. It requires internet connection to work.";
        public static string SubCommand_PreLabeledBulletPoints_Name { get; } = "prelabeledbulletpoints";
        public static string SubCommand_PreLabeledBulletPoints_Description { get; } = "Pre-labeled examples that can be helpful to automatically categorize new bullet points via additional software.";

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
        public static string Option_ThresholdValue_Description { get; } = $"The value for the provided threshold type. It can be a number (1, 2, ...), a date (yyyyMMdd) or an id (5376524visgerrengringsassistenter, ...).";
        public static string Option_ThresholdValue_ErrorMessage { get; } = $"{Option_ThresholdValue_Template} is mandatory.";
        public static string Option_ExplorationOutput_Template { get; } = "--explorationoutput";
        public static string Option_ExplorationOutput_Description { get; } = "The output(s) for the exploration.";
        public static string Option_ExplorationOutput_ErrorMessage { get; } = $"{Option_ExplorationOutput_Template} is mandatory.";
        public static string Option_VerboseSerialization_Template { get; } = "--verboseserialization";
        public static string Option_VerboseSerialization_Description { get; } = $"By default, some fields in the {nameof(Exploration)} JSONs are replaced with '{WIDExplorer.DefaultNotSerialized}' to increase readability. Use it option to disable the default behaviour.";
        public static string Option_MetricsOutput_Template { get; } = "--metricsoutput";
        public static string Option_MetricsOutput_Description { get; } = "The output(s) for the metric calculation.";
        public static string Option_ParallelRequests_Template { get; } = "--parallelrequests";
        public static string Option_ParallelRequests_Description { get; } = $"The number of HTTP requests to send to WorkInDenmark.dk before pausing. If not specified, '{WIDExplorerSettings.DefaultParallelRequests}' will be used.";
        public static string Option_PauseBetweenRequestsMs_Template { get; } = "--pausebetweenrequestsms";
        public static string Option_PauseBetweenRequestsMs_Description { get; } = $"The duration of the pause after x HTTP requests in milliseconds. If not specified, '{WIDExplorerSettings.DefaultPauseBetweenRequestsMs}' will be used.";

        public static int Success { get; } = ((int)ExitCodes.Success);
        public static int Failure { get; } = ((int)ExitCodes.Failure);

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="CommandLineManager"/> instance.</summary>	
        public CommandLineManager
            (IThresholdValueManager thresholdValueManager, IWIDExplorerComponentsFactory componentsFactory, IWIDExplorerSettingsFactory settingsFactory)
        {

            Validator.ValidateObject(thresholdValueManager, nameof(thresholdValueManager));
            Validator.ValidateObject(componentsFactory, nameof(componentsFactory));
            Validator.ValidateObject(settingsFactory, nameof(settingsFactory));

            _thresholdValueManager = thresholdValueManager;
            _componentsFactory = componentsFactory;
            _settingsFactory = settingsFactory;

            _defaultComponents = _componentsFactory.Create(settingsFactory.Create());
            _demodataComponents = _componentsFactory.CreateForDemoData();

        }

        /// <summary>Initializes a <see cref="CommandLineManager"/> instance using default parameters.</summary>	
        public CommandLineManager()
            : this(new ThresholdValueManager(), new WIDExplorerComponentsFactory(), new WIDExplorerSettingsFactory()) { }

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
            AddExtra(app);

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
                CommandOption verboseSerialization = CreateOptionalVerboseSerializationOption(describeSubCommand);
                CommandOption useDemoDataOption = CreateOptionalUseDemoDataOption(describeSubCommand);

                describeSubCommand.OnExecute(() =>
                {

                    return SessionDescribe(
                                ConvertToDescribeOutputs(outputOption.Value()),
                                folderPathOption.Value(),
                                useDemoDataOption.HasValue(),
                                verboseSerialization: verboseSerialization.HasValue()
                                );

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
                CommandOption verboseSerialization = CreateOptionalVerboseSerializationOption(exploreSubCommand);
                CommandOption metricsOutputOption = CreateRequiredMetricsOutputOption(exploreSubCommand);
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
                                metricsOutput: ConvertToMetricsOutputs(metricsOutputOption.Value()),
                                numbersAsPercentages: asPercentagesOption.HasValue(),
                                verboseSerialization: verboseSerialization.HasValue()
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
        private CommandLineApplication AddExtra(CommandLineApplication app)
        {

            app.Command(Command_Extra_Name, extraCommand =>
            {

                extraCommand = AddExtraMain(extraCommand);
                extraCommand = AddExtraPreLabeledBulletPoints(extraCommand);

            });

            return app;

        }
        private CommandLineApplication AddExtraMain(CommandLineApplication extraCommand)
        {

            extraCommand.Description = Command_Extra_Description;
            extraCommand.OnExecute(() =>
            {

                int exitCode = GenericCommand();
                extraCommand.ShowHelp();

                return exitCode;

            });

            return extraCommand;

        }
        private CommandLineApplication AddExtraPreLabeledBulletPoints(CommandLineApplication extraCommand)
        {

            extraCommand.Command(SubCommand_PreLabeledBulletPoints_Name, preLabeledBulletPointsSubCommand =>
            {

                preLabeledBulletPointsSubCommand.Description = SubCommand_PreLabeledBulletPoints_Description;

                CommandOption outputOption = CreateRequiredPreLabeledBulletPointsOutputOption(preLabeledBulletPointsSubCommand);
                CommandOption folderPathOption = CreateOptionalFolderPathOption(preLabeledBulletPointsSubCommand);

                preLabeledBulletPointsSubCommand.OnExecute(() =>
                {

                    return ExtraPreLabeledBulletPoints(
                                ConvertToPreLabeledBulletPointsOutputs(outputOption.Value()),
                                folderPathOption.Value());

                });

            });

            return extraCommand;

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
        private CommandOption CreateRequiredMetricsOutputOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_MetricsOutput_Template, Option_MetricsOutput_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Enum<MetricsOutputs>())
                    .IsRequired(false, Option_ExplorationOutput_ErrorMessage);

        }
        private CommandOption CreateRequiredPreLabeledBulletPointsOutputOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_Output_Template, Option_Output_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.Enum<PreLabeledBulletPointsOutputs>())
                    .IsRequired(false, Option_Output_ErrorMessage);

        }
        private CommandOption CreateRequiredJsonPathOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_JsonPath_Template, Option_JsonPath_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.ExistingFile())
                    .IsRequired(false, Option_JsonPath_ErrorMessage);

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
        private CommandOption CreateOptionalFolderPathOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_FolderPath_Template, Option_FolderPath_Description, CommandOptionType.SingleValue)
                    .Accepts(validator => validator.ExistingDirectory());

        }
        private CommandOption CreateOptionalVerboseSerializationOption(CommandLineApplication subCommand)
        {

            return subCommand
                    .Option(Option_VerboseSerialization_Template, Option_VerboseSerialization_Description, CommandOptionType.NoValue);

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

        private Exception CreateOptionValueException<T>(string optionValue)
           => new Exception(Messages.MessageCollection.CommandLineManager_OptionValueCantBeConvertedTo.Invoke(optionValue, typeof(T)));
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

            if (optionValue == nameof(MetricsOutputs.none))
                return MetricsOutputs.none;

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

            if (optionValue == nameof(ExploreOutputs.onlyfiles))
                return ExploreOutputs.onlyfiles;

            if (optionValue == nameof(ExploreOutputs.all))
                return ExploreOutputs.all;

            throw CreateOptionValueException<ExploreOutputs>(optionValue);

        }
        private PreLabeledBulletPointsOutputs ConvertToPreLabeledBulletPointsOutputs(string optionValue)
        {

            if (optionValue == nameof(PreLabeledBulletPointsOutputs.jsonfile))
                return PreLabeledBulletPointsOutputs.jsonfile;

            if (optionValue == nameof(PreLabeledBulletPointsOutputs.console))
                return PreLabeledBulletPointsOutputs.console;

            if (optionValue == nameof(PreLabeledBulletPointsOutputs.both))
                return PreLabeledBulletPointsOutputs.both;

            throw CreateOptionValueException<PreLabeledBulletPointsOutputs>(optionValue);

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
           => new Exception(Messages.MessageCollection.CommandLineManager_FirstEnumCantBeMapped.Invoke(typeof(TInput), typeof(TOutput), value));
        private MetricsOutputs MapCalculateToMetrics(CalculateOutputs output)
        {

            if (output.ToString() == nameof(CalculateOutputs.jsonfile))
                return MetricsOutputs.jsonfile;

            if (output.ToString() == nameof(CalculateOutputs.console))
                return MetricsOutputs.console;

            if (output.ToString() == nameof(CalculateOutputs.both))
                return MetricsOutputs.both;

            throw CreateMappingException<CalculateOutputs, MetricsOutputs>(output.ToString());

        }
        private WIDExplorerComponents ChooseComponents(bool useDemoData)
        {

            if (useDemoData)
                return _demodataComponents;

            return _defaultComponents;

        }
        private WIDExplorer Create()
            => new WIDExplorer();
        private WIDExplorer Create(WIDExplorerComponents components, WIDExplorerSettings settings)
            => new WIDExplorer(components, settings);
        private int HandleFileExistance(IFileInfoAdapter fileInfoAdapter)
        {

            _defaultComponents.LoggingActionAsciiBanner.Invoke(string.Empty);

            if (!fileInfoAdapter.Exists)
            {

                _defaultComponents.LoggingAction.Invoke(Messages.MessageCollection.CommandLineManager_FileHasNotBeenCreated.Invoke(fileInfoAdapter.FullName));
                _defaultComponents.LoggingActionAsciiBanner.Invoke(string.Empty);

                return Failure;

            }

            _defaultComponents.LoggingActionAsciiBanner.Invoke(string.Empty);

            return Success;

        }

        private void DumpJsonToConsole(string json)
        {

            _defaultComponents.LoggingAction.Invoke(Messages.MessageCollection.CommandLineManager_DumpingJsonToConsole);
            _defaultComponents.LoggingActionAsciiBanner.Invoke(string.Empty);
            _defaultComponents.LoggingActionAsciiBanner.Invoke(json);
            _defaultComponents.LoggingActionAsciiBanner.Invoke(string.Empty);

        }
        private int DumpExceptionToConsole(Exception e)
        {

            _defaultComponents.LoggingAction.Invoke(Messages.MessageCollection.CommandLineManager_FormattedErrorMessage.Invoke(e.Message));
            _defaultComponents.LoggingActionAsciiBanner.Invoke(string.Empty);

            return Failure;

        }
        private int DumpExplorationToConsole(WIDExplorer widExplorer, Exploration exploration, bool verboseSerialization)
        {

            string json = widExplorer.ConvertToJson(exploration, verboseSerialization);
            DumpJsonToConsole(json);
            _defaultComponents.LoggingActionAsciiBanner.Invoke(string.Empty);

            return Success;

        }
        private int DumpLabeledExamplesToConsole(WIDExplorer widExplorer, List<LabeledExample> labeledExamples)
        {

            string json = widExplorer.ConvertToJson(labeledExamples);
            DumpJsonToConsole(json);
            _defaultComponents.LoggingActionAsciiBanner.Invoke(string.Empty);

            return Success;

        }
        private int DumpExplorationToConsoleAndSaveToJsonFile(WIDExplorer widExplorer, Exploration exploration, bool verboseSerialization)
        {

            DumpExplorationToConsole(widExplorer, exploration, verboseSerialization);

            return SaveExplorationToJsonFile(widExplorer, exploration, verboseSerialization);

        }
        private int DumpExplorationToConsoleAndSaveToJsonDatabaseFiles(WIDExplorer widExplorer, Exploration exploration, bool verboseSerialization)
        {

            DumpExplorationToConsole(widExplorer, exploration, verboseSerialization);

            int exitCode1 = SaveExplorationToJsonFile(widExplorer, exploration, verboseSerialization);
            int exitCode2 = SaveExplorationToDatabaseFile(widExplorer, exploration);

            return OrchestrateExitCodes(exitCode1, exitCode2);

        }
        private int DumpMetricCollectionToConsole(WIDExplorer widExplorer, MetricCollection metricCollection, bool numbersAsPercentages)
        {

            string json = widExplorer.ConvertToJson(metricCollection, numbersAsPercentages);
            DumpJsonToConsole(json);
            _defaultComponents.LoggingActionAsciiBanner.Invoke(string.Empty);

            return Success;

        }
        private int DumpMetricCollectionToConsoleAndSaveToJsonFile(WIDExplorer widExplorer, MetricCollection metricCollection, bool numbersAsPercentages)
        {

            DumpMetricCollectionToConsole(widExplorer, metricCollection, numbersAsPercentages);

            return SaveMetricCollectionToJsonFile(widExplorer, metricCollection, numbersAsPercentages);

        }
        private int DumpBulletPointsToConsoleAndSaveToJsonFile(WIDExplorer widExplorer, List<LabeledExample> labeledExamples)
        {

            DumpLabeledExamplesToConsole(widExplorer, labeledExamples);

            return SaveBulletPointsToJsonFile(widExplorer, labeledExamples);

        }
        private int SaveExplorationToJsonFile(WIDExplorer widExplorer, Exploration exploration, bool verboseSerialization)
        {

            IFileInfoAdapter fileInfoAdapter = widExplorer.SaveToJsonFile(exploration, verboseSerialization);

            return HandleFileExistance(fileInfoAdapter);

        }
        private int SaveExplorationToDatabaseFile(WIDExplorer widExplorer, Exploration exploration)
        {

            IFileInfoAdapter fileInfoAdapter = widExplorer.SaveToSQLiteDatabase(exploration);

            return HandleFileExistance(fileInfoAdapter);

        }
        private int SaveExplorationToJsonDatabaseFiles(WIDExplorer widExplorer, Exploration exploration, bool verboseSerialization)
        {

            int exitCode1 = SaveExplorationToJsonFile(widExplorer, exploration, verboseSerialization);
            int exitCode2 = SaveExplorationToDatabaseFile(widExplorer, exploration);

            return OrchestrateExitCodes(exitCode1, exitCode2);

        }
        private int SaveMetricCollectionToJsonFile(WIDExplorer widExplorer, MetricCollection metricCollection, bool numbersAsPercentages)
        {

            IFileInfoAdapter fileInfoAdapter = widExplorer.SaveToJsonFile(metricCollection, numbersAsPercentages);

            return HandleFileExistance(fileInfoAdapter);

        }
        private int SaveBulletPointsToJsonFile(WIDExplorer widExplorer, List<LabeledExample> labeledExamples)
        {

            IFileInfoAdapter fileInfoAdapter = widExplorer.SaveToJsonFile(labeledExamples);

            return HandleFileExistance(fileInfoAdapter);

        }

        private int OrchestrateExitCodes(int exitCode1, int exitCode2)
        {

            if (exitCode1 == Success && exitCode2 == Success)
                return Success;

            return Failure;

        }
        private int OrchestrateMetricCollection(WIDExplorer widExplorer, Exploration exploration, MetricsOutputs output, bool numbersAsPercentages)
        {

            MetricCollection metricCollection = widExplorer.ConvertToMetricCollection(exploration);

            if (output == MetricsOutputs.console)
                return DumpMetricCollectionToConsole(widExplorer, metricCollection, numbersAsPercentages);

            if (output == MetricsOutputs.jsonfile)
                return SaveMetricCollectionToJsonFile(widExplorer, metricCollection, numbersAsPercentages);

            if (output == MetricsOutputs.both)
                return DumpMetricCollectionToConsoleAndSaveToJsonFile(widExplorer, metricCollection, numbersAsPercentages);

            throw CreateOptionValueException<MetricsOutputs>(output.ToString());

        }
        private int OrchestrateMetricCollection(WIDExplorer widExplorer, Exploration exploration, CalculateOutputs output, bool numbersAsPercentages)
            => OrchestrateMetricCollection(widExplorer, exploration, MapCalculateToMetrics(output), numbersAsPercentages);
        private int OrchestrateExploration
            (WIDExplorer widExplorer, Exploration exploration, ExploreOutputs explorationOutput, MetricsOutputs metricsOutput, bool numbersAsPercentages, bool verboseSerialization)
        {

            if (explorationOutput == ExploreOutputs.console)
            {

                int exitCode1 = DumpExplorationToConsole(widExplorer, exploration, verboseSerialization);

                int exitCode2 = ((int)ExitCodes.Success);
                if (metricsOutput != MetricsOutputs.none)
                    exitCode2 = OrchestrateMetricCollection(widExplorer, exploration, metricsOutput, numbersAsPercentages);

                return OrchestrateExitCodes(exitCode1, exitCode2);

            }
            if (explorationOutput == ExploreOutputs.jsonfile)
            {

                int exitCode1 = SaveExplorationToJsonFile(widExplorer, exploration, verboseSerialization);

                int exitCode2 = ((int)ExitCodes.Success);
                if (metricsOutput != MetricsOutputs.none)
                    exitCode2 = OrchestrateMetricCollection(widExplorer, exploration, metricsOutput, numbersAsPercentages);

                return OrchestrateExitCodes(exitCode1, exitCode2);

            }
            if (explorationOutput == ExploreOutputs.databasefile)
            {

                int exitCode1 = SaveExplorationToDatabaseFile(widExplorer, exploration);

                int exitCode2 = ((int)ExitCodes.Success);
                if (metricsOutput != MetricsOutputs.none)
                    exitCode2 = OrchestrateMetricCollection(widExplorer, exploration, metricsOutput, numbersAsPercentages);

                return OrchestrateExitCodes(exitCode1, exitCode2);

            }
            if (explorationOutput == ExploreOutputs.onlyfiles)
            {

                int exitCode1 = SaveExplorationToJsonDatabaseFiles(widExplorer, exploration, verboseSerialization);

                int exitCode2 = ((int)ExitCodes.Success);
                if (metricsOutput != MetricsOutputs.none)
                    exitCode2 = OrchestrateMetricCollection(widExplorer, exploration, metricsOutput, numbersAsPercentages);

                return OrchestrateExitCodes(exitCode1, exitCode2);

            }
            if (explorationOutput == ExploreOutputs.all)
            {

                int exitCode1 = DumpExplorationToConsoleAndSaveToJsonDatabaseFiles(widExplorer, exploration, verboseSerialization);

                int exitCode2 = ((int)ExitCodes.Success);
                if (metricsOutput != MetricsOutputs.none)
                    exitCode2 = OrchestrateMetricCollection(widExplorer, exploration, metricsOutput, numbersAsPercentages);

                return OrchestrateExitCodes(exitCode1, exitCode2);

            }

            throw CreateOptionValueException<ExploreOutputs>(explorationOutput.ToString());

        }
        private int OrchestrateBulletPoints(WIDExplorer widExplorer, PreLabeledBulletPointsOutputs output, List<LabeledExample> labeledExamples)
        {

            if (output == PreLabeledBulletPointsOutputs.console)
                return DumpLabeledExamplesToConsole(widExplorer, labeledExamples);

            if (output == PreLabeledBulletPointsOutputs.jsonfile)
                return SaveBulletPointsToJsonFile(widExplorer, labeledExamples);

            if (output == PreLabeledBulletPointsOutputs.both)
                return DumpBulletPointsToConsoleAndSaveToJsonFile(widExplorer, labeledExamples);

            throw CreateOptionValueException<PreLabeledBulletPointsOutputs>(output.ToString());

        }

        private void LogAsciiBanner()
        {

            _defaultComponents.LoggingActionAsciiBanner(string.Empty);

            WIDExplorer widExplorer = Create();
            widExplorer.LogAsciiBanner();

        }
        private int GenericCommand()
        {

            LogAsciiBanner();

            return Success;

        }
        private int About()
        {

            LogAsciiBanner();

            _defaultComponents.LoggingActionAsciiBanner(Application_Description);
            _defaultComponents.LoggingActionAsciiBanner(string.Empty);
            _defaultComponents.LoggingActionAsciiBanner(Messages.MessageCollection.CommandLineManager_ApplicationAuthor);
            _defaultComponents.LoggingActionAsciiBanner(Messages.MessageCollection.CommandLineManager_ApplicationEmail);
            _defaultComponents.LoggingActionAsciiBanner(Messages.MessageCollection.CommandLineManager_ApplicationUrl);
            _defaultComponents.LoggingActionAsciiBanner(Messages.MessageCollection.CommandLineManager_ApplicationLicense);

            _defaultComponents.LoggingActionAsciiBanner(string.Empty);

            return Success;

        }
        private int SessionCalculate(string filePath, CalculateOutputs output, string folderPath, bool numbersAsPercentages)
        {

            try
            {

                LogAsciiBanner();

                WIDExplorerSettings settings = _settingsFactory.Create(folderPath: folderPath);
                WIDExplorer widExplorer = Create(_defaultComponents, settings);
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

                WIDExplorerSettings settings = _settingsFactory.Create(folderPath: folderPath);
                WIDExplorer widExplorer = Create(_defaultComponents, settings);
                Exploration exploration = widExplorer.LoadExplorationFromJsonFile(filePath);

                // At the moment there is only one DatabaseOutputs.
                return SaveExplorationToDatabaseFile(widExplorer, exploration);

            }
            catch (Exception e)
            {

                return DumpExceptionToConsole(e);

            }

        }
        private int SessionDescribe(DescribeOutputs output, string folderPath, bool useDemoData, bool verboseSerialization)
        {

            try
            {

                LogAsciiBanner();

                WIDExplorerComponents components = ChooseComponents(useDemoData);
                WIDExplorerSettings settings = _settingsFactory.Create(folderPath: folderPath);
                WIDExplorer widExplorer = Create(components, settings);
                Exploration exploration = widExplorer.Explore(1, Stages.Stage1_OnlyMetrics);

                if (output == DescribeOutputs.console)
                    return DumpExplorationToConsole(widExplorer, exploration, verboseSerialization);

                else if (output == DescribeOutputs.jsonfile)
                    return SaveExplorationToJsonFile(widExplorer, exploration, verboseSerialization);

                else if (output == DescribeOutputs.both)
                    return DumpExplorationToConsoleAndSaveToJsonFile(widExplorer, exploration, verboseSerialization);

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
            MetricsOutputs metricsOutput,
            bool numbersAsPercentages,
            bool verboseSerialization
            )
        {

            try
            {

                LogAsciiBanner();

                WIDExplorerComponents components = ChooseComponents(useDemoData);
                WIDExplorerSettings settings = _settingsFactory.Create(parallelRequests: parallelRequests, pauseBetweenRequestsMs: pauseBetweenRequestsMs, folderPath: folderPath);
                Stages stage = ConvertToStages(exploreStage);
                WIDExplorer widExplorer = Create(components, settings);

                Exploration exploration;
                if (thresholdType == ThresholdTypes.finalpagenumber)
                    exploration = widExplorer.Explore(_thresholdValueManager.ParseFinalPageNumber(thresholdValue), stage);

                else if (thresholdType == ThresholdTypes.thresholddate)
                    exploration = widExplorer.Explore(_thresholdValueManager.ParseThresholdDate(thresholdValue), stage);

                else if (thresholdType == ThresholdTypes.jobpostingid)
                    exploration = widExplorer.Explore(thresholdValue, stage);

                else
                    throw CreateOptionValueException<ThresholdTypes>(thresholdType.ToString());

                return OrchestrateExploration(widExplorer, exploration, explorationOutput, metricsOutput, numbersAsPercentages, verboseSerialization);

            }
            catch (Exception e)
            {

                return DumpExceptionToConsole(e);

            }

        }
        private int ExtraPreLabeledBulletPoints(PreLabeledBulletPointsOutputs output, string folderPath)
        {

            try
            {

                LogAsciiBanner();

                WIDExplorerSettings settings = _settingsFactory.Create(folderPath: folderPath);
                WIDExplorer widExplorer = Create(_defaultComponents, settings);
                List<LabeledExample> labeledExamples = widExplorer.GetPreLabeledExamplesForBulletPointType();

                return OrchestrateBulletPoints(widExplorer, output, labeledExamples);

            }
            catch (Exception e)
            {

                return DumpExceptionToConsole(e);

            }

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.10.2021
*/