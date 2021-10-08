using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using NW.WIDJobs.Database;
using NW.WIDJobs.Explorations;
using NW.WIDJobs.Files;
using NW.WIDJobs.JobPages;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.JobPostingsExtended;
using NW.WIDJobs.Metrics;
using NW.WIDJobs.JsonSerializerConverters;
using NW.NGramTextClassification.LabeledExamples;

namespace NW.WIDJobs
{
    /// <inheritdoc cref="IWIDExplorer"/>
    public class WIDExplorer : IWIDExplorer
    {

        #region Fields

        private WIDExplorerComponents _components;
        private WIDExplorerSettings _settings;

        #endregion

        #region Properties

        public static string DefaultFormatDateTime { get; } = "yyyyMMddHHmmssfff";
        public static string DefaultFormatDate { get; } = "yyyyMMdd";
        public static string DefaultNotSerialized { get; } = "This item has been exluded from the serialization.";
        public static ushort DefaultInitialPageNumber { get; } = 1;

        public string Version { get; }
        public string AsciiBanner { get; }

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="WIDExplorer"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public WIDExplorer
            (WIDExplorerComponents components, WIDExplorerSettings settings)
        {

            Validation.Validator.ValidateObject(components, nameof(components));
            Validation.Validator.ValidateObject(settings, nameof(settings));

            _components = components;
            _settings = settings;

            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            AsciiBanner = _components.AsciiBannerManager.Create(Version);

        }

        /// <summary>Initializes a <see cref="WIDExplorer"/> instance with default parameters.</summary>	
        public WIDExplorer()
            : this(new WIDExplorerComponents(), new WIDExplorerSettings()) { }

        #endregion

        #region Methods_public

        public void LogAsciiBanner()
            => _components.LoggingActionAsciiBanner.Invoke(AsciiBanner);
        public List<LabeledExample> GetPreLabeledExamplesForBulletPointType()
        {

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_RetrievingPreLabeledExamplesForBulletPointType);

            List<LabeledExample> labeledExamples = _components.ClassificationManager.GetPreLabeledExamplesForBulletPointType();

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_PreLabeledExamplesForBulletPointTypeRetrieved.Invoke(labeledExamples.Count));

            return labeledExamples;

        }

        public MetricCollection ConvertToMetricCollection(Exploration exploration)
        {

            Validation.Validator.ValidateObject(exploration, nameof(exploration));
            Validation.Validator.ValidateList(exploration.JobPostings, nameof(exploration.JobPostings));

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ConvertingExplorationToMetricCollection);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_RunIdIs.Invoke(exploration.RunId));

            MetricCollection metricCollection = _components.MetricCollectionManager.Calculate(exploration);

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ExplorationConvertedToMetricCollection);

            return metricCollection;

        }      
        public string ConvertToJson(Exploration exploration, bool verboseSerialization = false)
        {

            Validation.Validator.ValidateObject(exploration, nameof(exploration));

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ConvertingExplorationToJsonString);
            LogSharedSerializationOptions();
            LogExplorationVerboseSerializationOption(verboseSerialization);

            string json = SerializeSuccintly(exploration);
            if (verboseSerialization)
                json = SerializeVerbosely(exploration);

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ConvertedExplorationToJsonString);

            return json;

        }
        public string ConvertToJson(MetricCollection metricCollection, bool numbersAsPercentages)
        {

            Validation.Validator.ValidateObject(metricCollection, nameof(metricCollection));

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ConvertingMetricCollectionToJsonString);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_NumbersAsPercentagesIs.Invoke(numbersAsPercentages));
            LogSharedSerializationOptions();

            dynamic dyn = metricCollection;
            if (numbersAsPercentages)
                dyn = ConvertNumbersToPercentages(metricCollection);

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ConvertedMetricsCollectionToJsonString);

            return JsonSerializer.Serialize(dyn, CreateJsonSerializerOptions());

        }
        public string ConvertToJson(List<LabeledExample> labeledExamples)
        {

            Validation.Validator.ValidateList(labeledExamples, nameof(labeledExamples));

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ConvertingLabeledExamplesToJsonString);
            LogSharedSerializationOptions();

            string json = JsonSerializer.Serialize(labeledExamples, CreateJsonSerializerOptions());

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ConvertedLabeledExamplesToJsonString);

            return json;

        }
        public List<JobPosting> LoadJobPostingsFromJsonFile(IFileInfoAdapter jsonFile)
        {

            Validation.Validator.ValidateObject(jsonFile, nameof(jsonFile));
            Validation.Validator.ValidateFileExistance(jsonFile);

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_LoadingJobPostingsFromJsonFile);

            DateTime now = _components.NowFunction.Invoke();
            string runId = _components.RunIdManager.Create(now);
            ushort pageNumber = 1;

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_SomeDefaultValuesUsedJsonFile);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_RunIdIs.Invoke(runId));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_PageNumberIs.Invoke(pageNumber));

            string content = _components.FileManager.ReadAllText(jsonFile);
            JobPage jobPage = new JobPage(runId, pageNumber, content);
            List<JobPosting> jobPostings = _components.JobPostingDeserializer.Do(jobPage);

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_JobPostingsExtractedFromJsonFile.Invoke(jobPostings));

            return jobPostings;

        }
        public List<JobPosting> LoadJobPostingsFromJsonFile(string filePath)
            => LoadJobPostingsFromJsonFile(_components.FileManager.Create(filePath));
        public Exploration LoadExplorationFromJsonFile(IFileInfoAdapter jsonFile)
        {

            Validation.Validator.ValidateObject(jsonFile, nameof(jsonFile));
            Validation.Validator.ValidateFileExistance(jsonFile);

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_LoadingExplorationFromJsonFile);

            string json = _components.FileManager.ReadAllText(jsonFile);
            Exploration exploration = JsonSerializer.Deserialize<Exploration>(json, CreateJsonSerializerOptions());

            return exploration;

        }
        public Exploration LoadExplorationFromJsonFile(string filePath)
            => LoadExplorationFromJsonFile(_components.FileManager.Create(filePath));
        public IFileInfoAdapter SaveToJsonFile(MetricCollection metricCollection, bool numbersAsPercentages, IFileInfoAdapter jsonFile)
        {

            Validation.Validator.ValidateObject(metricCollection, nameof(metricCollection));
            Validation.Validator.ValidateObject(jsonFile, nameof(jsonFile));

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_SavingMetricCollectionToJsonFile);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_RunIdIs.Invoke(metricCollection.RunId));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_NumbersAsPercentagesIs.Invoke(numbersAsPercentages));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_JSONFileIs.Invoke(jsonFile));

            string json = ConvertToJson(metricCollection, numbersAsPercentages);
            _components.FileManager.WriteAllText(jsonFile, json);

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_MetricCollectionSavedToJsonFile);

            return jsonFile;

        }
        public IFileInfoAdapter SaveToJsonFile(MetricCollection metricCollection, bool numbersAsPercentages)
        {

            DateTime now = _components.NowFunction.Invoke();
            string fullName = _components.FilenameFactory.CreateForMetricCollectionJson(_settings.FolderPath, now, numbersAsPercentages);
            IFileInfoAdapter jsonFile = new FileInfoAdapter(fullName);

            LogSharedSaveTo(nameof(SaveToJsonFile), now);

            return SaveToJsonFile(metricCollection, numbersAsPercentages, jsonFile);

        }
        public IFileInfoAdapter SaveToJsonFile(Exploration exploration, IFileInfoAdapter jsonFile, bool verboseSerialization = false)
        {

            Validation.Validator.ValidateObject(exploration, nameof(exploration));
            Validation.Validator.ValidateObject(jsonFile, nameof(jsonFile));

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_SavingExplorationToJsonFile);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_RunIdIs.Invoke(exploration.RunId));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_JSONFileIs.Invoke(jsonFile));

            string json = ConvertToJson(exploration, verboseSerialization);
            _components.FileManager.WriteAllText(jsonFile, json);

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ExplorationSavedToJsonFile);

            return jsonFile;

        }
        public IFileInfoAdapter SaveToJsonFile(Exploration exploration, bool verboseSerialization = false)
        {

            DateTime now = _components.NowFunction.Invoke();
            string fullName = _components.FilenameFactory.CreateForExplorationJson(_settings.FolderPath, now);
            IFileInfoAdapter jsonFile = new FileInfoAdapter(fullName);

            LogSharedSaveTo(nameof(SaveToJsonFile), now);

            return SaveToJsonFile(exploration, jsonFile, verboseSerialization);

        }
        public IFileInfoAdapter SaveToJsonFile(List<LabeledExample> labeledExamples, IFileInfoAdapter jsonFile)
        {

            Validation.Validator.ValidateList(labeledExamples, nameof(labeledExamples));
            Validation.Validator.ValidateObject(jsonFile, nameof(jsonFile));

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_SavingLabeledExamplesToJsonFile);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_LabeledExamplesAre.Invoke(labeledExamples.Count));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_JSONFileIs.Invoke(jsonFile));

            string json = ConvertToJson(labeledExamples);
            _components.FileManager.WriteAllText(jsonFile, json);

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_LabeledExamplesSavedToJsonFile);

            return jsonFile;

        }
        public IFileInfoAdapter SaveToJsonFile(List<LabeledExample> labeledExamples)
        {

            DateTime now = _components.NowFunction.Invoke();
            string fullName = _components.FilenameFactory.CreateForBulletPointTypesJson(_settings.FolderPath, now);
            IFileInfoAdapter jsonFile = new FileInfoAdapter(fullName);

            LogSharedSaveTo(nameof(SaveToJsonFile), now);

            return SaveToJsonFile(labeledExamples, jsonFile);

        }
        public IFileInfoAdapter SaveToSQLiteDatabase(Exploration exploration, IFileInfoAdapter databaseFile, bool deleteAndRecreateDatabase)
        {

            Validation.Validator.ValidateObject(exploration, nameof(exploration));
            Validation.Validator.ValidateObject(exploration.JobPostings, nameof(exploration.JobPostings));
            Validation.Validator.ValidateObject(databaseFile, nameof(databaseFile));

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_SavingExplorationToSQLiteDatabase);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ExplorationIs.Invoke(exploration));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_DatabaseFileIs.Invoke(databaseFile.FullName));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_DeleteAndRecreateDatabaseIs.Invoke(deleteAndRecreateDatabase));

            IRepository repository =
                _components.RepositoryFactory
                    .Create(databaseFile.DirectoryName, databaseFile.Name, _settings.DeleteAndRecreateDatabase);

            int affectedRows = 0;
            if (exploration.JobPostingsExtended != null)
                affectedRows = repository.ConditionallyInsert(exploration.JobPostingsExtended);
            else
                affectedRows = repository.ConditionallyInsert(exploration.JobPostings);

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_AffectedRowsAre.Invoke(affectedRows));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ExplorationSavedToSQLiteDatabase);

            return databaseFile;

        }
        public IFileInfoAdapter SaveToSQLiteDatabase(Exploration exploration)
        {

            DateTime now = _components.NowFunction.Invoke();
            string fullName = _components.FilenameFactory.CreateForDatabase(_settings.FolderPath, now);
            IFileInfoAdapter databaseFile = new FileInfoAdapter(fullName);

            LogSharedSaveTo(nameof(SaveToSQLiteDatabase), now);

            return SaveToSQLiteDatabase(exploration, databaseFile, _settings.DeleteAndRecreateDatabase);

        }

        public Exploration Explore(ushort finalPageNumber, Stages stage)
        {

            DateTime now = _components.NowFunction.Invoke();
            string runId = _components.RunIdManager.Create(now, DefaultInitialPageNumber, finalPageNumber);

            return Explore(runId, finalPageNumber, stage);

        }
        public Exploration Explore(string runId, ushort finalPageNumber, Stages stage)
        {

            Validation.Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validation.Validator.ThrowIfLessThanOne(finalPageNumber, nameof(finalPageNumber));

            LogInitializationMessage(runId, finalPageNumber, stage);

            Exploration exploration = ProcessStage1(runId, DefaultInitialPageNumber, stage);
            if (exploration.IsCompleted)
                return LogCompletionMessageAndReturn(exploration);

            finalPageNumber = EstablishFinalPageNumber(finalPageNumber, exploration.TotalJobPages);

            exploration = ProcessStage2(exploration, finalPageNumber, stage);
            if (exploration.IsCompleted)
                return LogCompletionMessageAndReturn(exploration);

            exploration = ProcessStage3(exploration, stage);

            return LogCompletionMessageAndReturn(exploration);

        }
        public Exploration Explore(DateTime thresholdDate, Stages stage)
        {

            DateTime now = _components.NowFunction.Invoke();
            string runId = _components.RunIdManager.Create(now, thresholdDate);

            return Explore(runId, thresholdDate, stage);

        }
        public Exploration Explore(string runId, DateTime thresholdDate, Stages stage)
        {

            Validation.Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));

            LogInitializationMessage(runId, thresholdDate, stage);

            Exploration exploration = ProcessStage1(runId, DefaultInitialPageNumber, stage);
            if (exploration.IsCompleted)
                return LogCompletionMessageAndReturn(exploration);

            exploration = ProcessStage2WhenThresholdDate(exploration, stage, thresholdDate);
            if (exploration.IsCompleted)
                return LogCompletionMessageAndReturn(exploration);

            exploration = ProcessStage3(exploration, stage);

            return LogCompletionMessageAndReturn(exploration);

        }
        public Exploration Explore(string jobPostingId, Stages stage)
        {

            DateTime now = _components.NowFunction.Invoke();
            string runId = _components.RunIdManager.Create(now, jobPostingId);

            return Explore(runId, jobPostingId, stage);

        }
        public Exploration Explore(string runId, string jobPostingId, Stages stage)
        {

            Validation.Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validation.Validator.ValidateStringNullOrWhiteSpace(jobPostingId, nameof(jobPostingId));

            LogInitializationMessage(runId, jobPostingId, stage);

            Exploration exploration = ProcessStage1(runId, DefaultInitialPageNumber, stage);
            if (exploration.IsCompleted)
                return LogCompletionMessageAndReturn(exploration);

            exploration = ProcessStage2WhenJobPostingId(exploration, stage, jobPostingId);
            if (exploration.IsCompleted)
                return LogCompletionMessageAndReturn(exploration);

            exploration = ProcessStage3(exploration, stage);

            return LogCompletionMessageAndReturn(exploration);

        }

        public Exploration ExploreAll(Stages stage)
        {

            DateTime now = _components.NowFunction.Invoke();
            string runId = _components.RunIdManager.Create(now);

            return ExploreAll(runId, stage);

        }
        public Exploration ExploreAll(string runId, Stages stage)
        {

            Validation.Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));

            LogInitializationMessage(runId, stage);

            Exploration exploration = ProcessStage1(runId, DefaultInitialPageNumber, stage);
            if (exploration.IsCompleted)
                return LogCompletionMessageAndReturn(exploration);

            ushort finalPageNumber = exploration.TotalJobPages;

            exploration = ProcessStage2(exploration, finalPageNumber, stage);
            if (exploration.IsCompleted)
                return LogCompletionMessageAndReturn(exploration);

            exploration = ProcessStage3(exploration, stage);

            return LogCompletionMessageAndReturn(exploration);

        }

        #endregion

        #region Methods_private

        private JsonSerializerOptions CreateJsonSerializerOptions()
        {

            JsonSerializerOptions options = new JsonSerializerOptions();

            options.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            options.Converters.Add(new JsonStringEnumConverter());
            options.Converters.Add(new DateTimeToDateConverter());
            options.WriteIndented = true;

            return options;

        }
        private void ConditionallySleep(ushort i, ushort parallelRequests, uint pauseBetweenRequestsMs)
        {

            // Do a pause of x each y requests
            // i != 0, because 0 % x = 0...
            if (i != 0 && i % parallelRequests == 0)
                Thread.Sleep((int)pauseBetweenRequestsMs);

        }
        private dynamic ConvertNumbersToPercentages(MetricCollection metricCollection)
        {

            dynamic dyn = new ExpandoObject();

            dyn.RunId = metricCollection.RunId;
            dyn.TotalJobPages = metricCollection.TotalJobPages;
            dyn.TotalJobPostings = metricCollection.TotalJobPostings;

            dyn.JobPostingsByHiringOrgName = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByHiringOrgName);
            dyn.JobPostingsByWorkPlaceAddress = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByWorkPlaceAddress);
            dyn.JobPostingsByWorkPlacePostalCode = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByWorkPlacePostalCode);
            dyn.JobPostingsByWorkPlaceCity = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByWorkPlaceCity);
            dyn.JobPostingsByPostingCreated = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByPostingCreated);
            dyn.JobPostingsByLastDateApplication = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByLastDateApplication);
            dyn.JobPostingsByRegion = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByRegion);
            dyn.JobPostingsByMunicipality = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByMunicipality);
            dyn.JobPostingsByCountry = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByCountry);
            dyn.JobPostingsByEmploymentType = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByEmploymentType);
            dyn.JobPostingsByWorkHours = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByWorkHours);
            dyn.JobPostingsByOccupation = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByOccupation);
            dyn.JobPostingsByWorkplaceId = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByWorkplaceId);
            dyn.JobPostingsByOrganisationId = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByOrganisationId);
            dyn.JobPostingsByHiringOrgCVR = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByHiringOrgCVR);
            dyn.JobPostingsByWorkPlaceCityWithoutZone = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByWorkPlaceCityWithoutZone);
            dyn.JobPostingsByLanguage = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByLanguage);
            dyn.ResponseLengthByJobPostingId = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.ResponseLengthByJobPostingId);
            dyn.PresentationLengthByJobPostingId = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.PresentationLengthByJobPostingId);

            dyn.JobPostingsByPublicationStartDate = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByPublicationStartDate);
            dyn.JobPostingsByPublicationEndDate = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByPublicationEndDate);
            dyn.JobPostingsByNumberToFill = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByNumberToFill);
            dyn.JobPostingsByContactEmail = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByContactEmail);
            dyn.JobPostingsByContactPersonName = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByContactPersonName);
            dyn.JobPostingsByEmploymentDate = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByEmploymentDate);
            dyn.JobPostingsByApplicationDeadlineDate = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByApplicationDeadlineDate);
            dyn.JobPostingsByBulletPointScenario = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.JobPostingsByBulletPointScenario);
            dyn.ExtendedResponseLengthByJobPostingId = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.ExtendedResponseLengthByJobPostingId);
            dyn.HiringOrgDescriptionLengthByJobPostingId = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.HiringOrgDescriptionLengthByJobPostingId);
            dyn.PurposeLengthByJobPostingId = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.PurposeLengthByJobPostingId);
            dyn.BulletPointsByJobPostingId = _components.MetricCollectionManager.TryConvertToPercentages(metricCollection.BulletPointsByJobPostingId);
            dyn.TotalBulletPoints = metricCollection.TotalBulletPoints;

            return dyn;

        }

        private void LogInitializationMessage(string runId, ushort finalPageNumber, Stages stage)
        {

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ExplorationStarted);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_RunIdIs(runId));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_DefaultInitialPageNumberIs(DefaultInitialPageNumber));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_FinalPageNumberIs(finalPageNumber));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_StageIs(stage));

        }
        private void LogInitializationMessage(string runId, DateTime thresholdDate, Stages stage)
        {

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ExplorationStarted);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_RunIdIs(runId));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_DefaultInitialPageNumberIs(DefaultInitialPageNumber));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ThresholdDateIs(thresholdDate));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_StageIs(stage));

        }
        private void LogInitializationMessage(string runId, string jobPostingId, Stages stage)
        {

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ExplorationStarted);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_RunIdIs(runId));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_DefaultInitialPageNumberIs(DefaultInitialPageNumber));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_JobPostingIdIs(jobPostingId));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_StageIs(stage));

        }
        private void LogInitializationMessage(string runId, Stages stage)
        {

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ExplorationStarted);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_RunIdIs(runId));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_DefaultInitialPageNumberIs(DefaultInitialPageNumber));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_FinalPageNumberIsLastPage);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_StageIs(stage));

        }
        private void LogSharedSerializationOptions()
        {

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(JavaScriptEncoder.UnsafeRelaxedJsonEscaping)));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(DateTimeToDateConverter)));

        }
        private void LogExplorationVerboseSerializationOption(bool verboseSerialization)
        {

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_VerboseSerializationIs.Invoke(verboseSerialization));

        }
        private Exploration LogCompletionMessageAndReturn(Exploration exploration)
        {

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ExplorationCompleted);

            return exploration;

        }
        private void LogSharedSaveTo(string methodName, DateTime now)
        {

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_MethodCalledWithoutIFileInfoAdapter.Invoke(methodName));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_DefaultValuesCreateIFileInfoAdapter);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_FolderPathIs.Invoke(_settings.FolderPath));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_NowIs.Invoke(now));

        }
        private void LogJobPostings(List<JobPosting> jobPostings)
            => jobPostings.ForEach((jobPosting) => _components.LoggingAction.Invoke(_components.Formatter.Format(jobPosting)));

        private JobPage OptimizeJobPageForSerialization(JobPage jobPage)
        {

            JobPage optimized
                = new JobPage(jobPage.RunId, jobPage.PageNumber, DefaultNotSerialized);

            return optimized;

        }
        private List<JobPage> OptimizeJobPagesForSerialization(List<JobPage> jobPages)
        {

            List<JobPage> optimized
                = jobPages.Select(jobPage => OptimizeJobPageForSerialization(jobPage)).ToList();

            return optimized;

        }
        private JobPosting OptimizeJobPostingForSerialization(JobPosting jobPosting)
        {

            JobPosting optimized
                = new JobPosting(
                        runId: jobPosting.RunId,
                        pageNumber: jobPosting.PageNumber,
                        response: DefaultNotSerialized,
                        title: jobPosting.Title,
                        presentation: DefaultNotSerialized,
                        hiringOrgName: jobPosting.HiringOrgName,
                        workPlaceAddress: jobPosting.WorkPlaceAddress,
                        workPlacePostalCode: jobPosting.WorkPlacePostalCode,
                        workPlaceCity: jobPosting.WorkPlaceCity,
                        postingCreated: jobPosting.PostingCreated,
                        lastDateApplication: jobPosting.LastDateApplication,
                        url: jobPosting.Url,
                        region: jobPosting.Region,
                        municipality: jobPosting.Municipality,
                        country: jobPosting.Country,
                        employmentType: jobPosting.EmploymentType,
                        workHours: jobPosting.WorkHours,
                        occupation: jobPosting.Occupation,
                        workplaceId: jobPosting.WorkplaceId,
                        organisationId: jobPosting.OrganisationId,
                        hiringOrgCVR: jobPosting.HiringOrgCVR,
                        id: jobPosting.Id,
                        workPlaceCityWithoutZone: jobPosting.WorkPlaceCityWithoutZone,
                        jobPostingNumber: jobPosting.JobPostingNumber,
                        jobPostingId: jobPosting.JobPostingId,
                        language: jobPosting.Language
                    );

            return optimized;

        }
        private List<JobPosting> OptimizeJobPostingsForSerialization(List<JobPosting> jobPostings)
        {

            List<JobPosting> optimized
                = jobPostings.Select(jobPosting => OptimizeJobPostingForSerialization(jobPosting)).ToList();

            return optimized;

        }
        private JobPostingExtended OptimizeJobPostingExtendedForSerialization(JobPostingExtended jobPostingExtended)
        {

            JobPostingExtended optimized
                = new JobPostingExtended(
                    jobPosting: OptimizeJobPostingForSerialization(jobPostingExtended.JobPosting),
                    response: DefaultNotSerialized,
                    hiringOrgDescription: jobPostingExtended.HiringOrgDescription,
                    publicationStartDate: jobPostingExtended.PublicationStartDate,
                    publicationEndDate: jobPostingExtended.PublicationEndDate,
                    purpose: DefaultNotSerialized,
                    numberToFill: jobPostingExtended.NumberToFill,
                    contactEmail: jobPostingExtended.ContactEmail,
                    contactPersonName: jobPostingExtended.ContactPersonName,
                    employmentDate: jobPostingExtended.EmploymentDate,
                    applicationDeadlineDate: jobPostingExtended.ApplicationDeadlineDate,
                    bulletPoints: jobPostingExtended.BulletPoints,
                    bulletPointScenario: jobPostingExtended.BulletPointScenario
                    );

            return optimized;

        }
        private List<JobPostingExtended> OptimizeJobPostingsExtendedForSerialization(List<JobPostingExtended> jobPostingsExtended)
        {

            List<JobPostingExtended> optimized
                = jobPostingsExtended.Select(jobPostingExtended => OptimizeJobPostingExtendedForSerialization(jobPostingExtended)).ToList();

            return optimized;

        }
        
        private string SerializeSuccintly(Exploration exploration)
        {

            dynamic dyn = new ExpandoObject();

            dyn.RunId = exploration.RunId;
            dyn.TotalResultCount = exploration.TotalResultCount;
            dyn.TotalJobPages = exploration.TotalJobPages;
            dyn.Stage = exploration.Stage;
            dyn.IsCompleted = exploration.IsCompleted;

            if (exploration.JobPages != null)
                dyn.JobPages = OptimizeJobPagesForSerialization(exploration.JobPages);

            if (exploration.JobPostings != null)
                dyn.JobPostings = OptimizeJobPostingsForSerialization(exploration.JobPostings);

            if (exploration.JobPostingsExtended != null)
                dyn.JobPostingsExtended = OptimizeJobPostingsExtendedForSerialization(exploration.JobPostingsExtended);

            string json = JsonSerializer.Serialize(dyn, CreateJsonSerializerOptions());

            return json;

        }
        private string SerializeVerbosely(Exploration exploration)
        {

            dynamic dyn = new ExpandoObject();

            dyn.RunId = exploration.RunId;
            dyn.TotalResultCount = exploration.TotalResultCount;
            dyn.TotalJobPages = exploration.TotalJobPages;
            dyn.Stage = exploration.Stage;
            dyn.IsCompleted = exploration.IsCompleted;

            if (exploration.JobPages != null)
                dyn.JobPages = exploration.JobPages;

            if (exploration.JobPostings != null)
                dyn.JobPostings = exploration.JobPostings;

            if (exploration.JobPostingsExtended != null)
                dyn.JobPostingsExtended = exploration.JobPostingsExtended;

            string json = JsonSerializer.Serialize(dyn, CreateJsonSerializerOptions());

            return json;

        }

        private Exploration ProcessStage1(string runId, ushort initialPageNumber, Stages stage)
        {

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ExecutionStageStarted(Stages.Stage1_OnlyMetrics));

            JobPage jobPage = _components.JobPageManager.GetJobPage(runId, initialPageNumber);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_JobPageSuccessfullyRetrieved.Invoke(jobPage.PageNumber));

            ushort totalResultCount = _components.JobPageDeserializer.GetTotalResultCount(jobPage.Response);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_TotalResultCountIs(totalResultCount));

            ushort totalJobPages = _components.JobPageManager.GetTotalJobPages(totalResultCount);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_TotalJobPagesIs(totalJobPages));

            bool isCompleted = false;
            if (stage == Stages.Stage1_OnlyMetrics)
                isCompleted = true;

            List<JobPage> jobPages = new List<JobPage>() { jobPage };

            return
                new Exploration(
                        runId,
                        totalResultCount,
                        totalJobPages,
                        stage,
                        isCompleted,
                        jobPages);

        }
        private ushort EstablishFinalPageNumber(ushort finalPageNumber, ushort totalJobPages)
        {

            if (finalPageNumber > totalJobPages)
            {

                _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_FinalPageNumberIsHigher(finalPageNumber, totalJobPages));
                _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_FinalPageNumberWillBeNow(totalJobPages));

                return totalJobPages;

            }

            return finalPageNumber;

        }
        private Exploration ProcessStage2(Exploration exploration, ushort finalPageNumber, Stages stage)
        {

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ExecutionStageStarted(Stages.Stage2_UpToAllJobPostings));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_AntiFloodingStrategy);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ParallelRequestsAre(_settings.ParallelRequests));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_PauseBetweenRequestsIs(_settings.PauseBetweenRequestsMs));

            List<JobPosting> jobPostings = _components.JobPostingDeserializer.Do(exploration.JobPages[0]);
            
            LogJobPostings(jobPostings);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_JobPageProcessed(DefaultInitialPageNumber, finalPageNumber, jobPostings));

            List<JobPage> stage2JobPages = new List<JobPage>(exploration.JobPages);
            for (ushort currentPageNumber = 2; currentPageNumber <= finalPageNumber; currentPageNumber++)
            {

                JobPage currentJobPage = _components.JobPageManager.GetJobPage(exploration.RunId, currentPageNumber);
                List<JobPosting> currentJobPostings = _components.JobPostingDeserializer.Do(currentJobPage);

                stage2JobPages.Add(currentJobPage);
                jobPostings.AddRange(currentJobPostings);

                LogJobPostings(currentJobPostings);
                _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_JobPageProcessed(currentPageNumber, finalPageNumber, currentJobPostings));

                ConditionallySleep(currentPageNumber, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_JobPostingObjectsCreatedTotal(jobPostings));

            bool isCompleted = false;
            if (stage == Stages.Stage2_UpToAllJobPostings)
                isCompleted = true;

            return
                new Exploration(
                        exploration.RunId,
                        exploration.TotalResultCount,
                        exploration.TotalJobPages,
                        stage,
                        isCompleted,
                        stage2JobPages,
                        jobPostings);

        }
        private Exploration ProcessStage2WhenThresholdDate(Exploration exploration, Stages stage, DateTime thresholdDate)
        {

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ExecutionStageStarted(Stages.Stage2_UpToAllJobPostings));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_AntiFloodingStrategy);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ParallelRequestsAre(_settings.ParallelRequests));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_PauseBetweenRequestsIs(_settings.PauseBetweenRequestsMs));

            List<JobPage> stage2JobPages = new List<JobPage>() { exploration.JobPages[0] };
            List<JobPosting> stage2JobPostings = new List<JobPosting>();

            ushort finalPageNumber = exploration.TotalJobPages;
            for (ushort currentPageNumber = 1; currentPageNumber <= exploration.TotalJobPages; currentPageNumber++)
            {

                List<JobPosting> currentJobPostings = new List<JobPosting>();

                if (currentPageNumber == 1)
                {

                    currentJobPostings = _components.JobPostingDeserializer.Do(exploration.JobPages[0]);

                    LogJobPostings(currentJobPostings);
                    _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_JobPageProcessed(DefaultInitialPageNumber, finalPageNumber, currentJobPostings));

                }
                else
                {

                    JobPage currentJobPage = _components.JobPageManager.GetJobPage(exploration.RunId, currentPageNumber);
                    currentJobPostings = _components.JobPostingDeserializer.Do(currentJobPage);

                    stage2JobPages.Add(currentJobPage);

                    LogJobPostings(currentJobPostings);
                    _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_JobPageProcessed(currentPageNumber, finalPageNumber, currentJobPostings));

                }

                List<DateTime> postingCreatedCollection = currentJobPostings.Select(jobPosting => jobPosting.PostingCreated).ToList();
                bool isThresholdConditionMet = _components.JobPostingManager.IsThresholdConditionMet(thresholdDate, postingCreatedCollection);

                if (isThresholdConditionMet)
                {

                    _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ThresholdDateFoundJobPageNr(thresholdDate, currentPageNumber));

                    currentJobPostings = _components.JobPostingManager.RemoveUnsuitable(thresholdDate, currentJobPostings);
                    _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_XJobPostingsRemovedJobPageNr(currentJobPostings.Count, currentPageNumber));

                    stage2JobPostings.AddRange(currentJobPostings);
                    finalPageNumber = currentPageNumber;

                    LogJobPostings(currentJobPostings);

                    break;

                }
                else
                    stage2JobPostings.AddRange(currentJobPostings);

                ConditionallySleep(currentPageNumber, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_FinalPageNumberThresholdDate(finalPageNumber));

            bool isCompleted = false;
            if (stage == Stages.Stage2_UpToAllJobPostings)
                isCompleted = true;

            return
                new Exploration(
                        exploration.RunId,
                        exploration.TotalResultCount,
                        exploration.TotalJobPages,
                        exploration.Stage,
                        isCompleted,
                        stage2JobPages,
                        stage2JobPostings);

        }
        private Exploration ProcessStage2WhenJobPostingId(Exploration exploration, Stages stage, string jobPostingId)
        {

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ExecutionStageStarted(Stages.Stage2_UpToAllJobPostings));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_AntiFloodingStrategy);
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ParallelRequestsAre(_settings.ParallelRequests));
            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_PauseBetweenRequestsIs(_settings.PauseBetweenRequestsMs));

            List<JobPage> stage2JobPages = new List<JobPage>() { exploration.JobPages[0] };
            List<JobPosting> stage2JobPostings = new List<JobPosting>();

            ushort finalPageNumber = exploration.TotalJobPages;
            for (ushort currentPageNumber = 1; currentPageNumber <= exploration.TotalJobPages; currentPageNumber++)
            {

                List<JobPosting> currentJobPostings = new List<JobPosting>();

                if (currentPageNumber == 1)
                {

                    currentJobPostings = _components.JobPostingDeserializer.Do(exploration.JobPages[0]);

                    LogJobPostings(currentJobPostings);
                    _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_JobPageProcessed(DefaultInitialPageNumber, finalPageNumber, currentJobPostings));

                }
                else
                {

                    JobPage currentJobPage = _components.JobPageManager.GetJobPage(exploration.RunId, currentPageNumber);
                    currentJobPostings = _components.JobPostingDeserializer.Do(currentJobPage);

                    stage2JobPages.Add(currentJobPage);

                    LogJobPostings(currentJobPostings);
                    _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_JobPageProcessed(DefaultInitialPageNumber, finalPageNumber, currentJobPostings));

                }

                bool isThresholdConditionMet = _components.JobPostingManager.IsThresholdConditionMet(jobPostingId, currentJobPostings);

                if (isThresholdConditionMet)
                {

                    _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_JobPostingIdFoundJobPageNr(jobPostingId, currentPageNumber));

                    currentJobPostings = _components.JobPostingManager.RemoveUnsuitable(jobPostingId, currentJobPostings);
                    _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_XJobPostingsRemovedJobPageNr(currentJobPostings.Count, currentPageNumber));

                    stage2JobPostings.AddRange(currentJobPostings);
                    finalPageNumber = currentPageNumber;

                    LogJobPostings(currentJobPostings);

                    break;

                }
                else
                    stage2JobPostings.AddRange(currentJobPostings);

                ConditionallySleep(currentPageNumber, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_FinalPageNumberJobPostingId(finalPageNumber));

            bool isCompleted = false;
            if (stage == Stages.Stage2_UpToAllJobPostings)
                isCompleted = true;

            return
                new Exploration(
                        exploration.RunId,
                        exploration.TotalResultCount,
                        exploration.TotalJobPages,
                        exploration.Stage,
                        isCompleted,
                        stage2JobPages,
                        stage2JobPostings);

        }
        private Exploration ProcessStage3(Exploration exploration, Stages stage)
        {

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_ExecutionStageStarted(Stages.Stage3_UpToAllJobPostingsExtended));

            List<JobPostingExtended> jobPostingsExtended = new List<JobPostingExtended>();
            foreach (JobPosting jobPosting in exploration.JobPostings)
            {

                JobPostingExtended current = _components.JobPostingExtendedManager.GetJobPostingExtended(jobPosting);
                jobPostingsExtended.Add(current);

                _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_JobPostingProcessed(jobPosting));
                _components.LoggingAction.Invoke(_components.Formatter.Format(current));

                ConditionallySleep(jobPosting.JobPostingNumber, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }

            _components.LoggingAction.Invoke(Messages.MessageCollection.WIDExplorer_JobPostingExtendedCreatedTotal(jobPostingsExtended));

            bool isCompleted = true;

            return
                new Exploration(
                        exploration.RunId,
                        exploration.TotalResultCount,
                        exploration.TotalJobPages,
                        stage,
                        isCompleted,
                        exploration.JobPages,
                        exploration.JobPostings,
                        jobPostingsExtended);

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 15.09.2021
*/