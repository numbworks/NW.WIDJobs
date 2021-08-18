using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading;
using NW.WIDJobs.BulletPoints;
using NW.WIDJobs.Database;
using NW.WIDJobs.Explorations;
using NW.WIDJobs.Files;
using NW.WIDJobs.JobPages;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.JobPostingsExtended;
using NW.WIDJobs.Messages;
using NW.WIDJobs.Metrics;
using NW.WIDJobs.Miscellaneous;
using NW.WIDJobs.Validation;

namespace NW.WIDJobs
{
    public class WIDExplorer
    {

        #region Fields

        private WIDExplorerComponents _components;
        private WIDExplorerSettings _settings;

        #endregion

        #region Properties

        public static Func<DateTime> DefaultNowFunction { get; } = () => DateTime.Now;
        public static string DefaultFormatDateTime { get; } = "yyyyMMddHHmmssfff";
        public static string DefaultFormatDate { get; } = "yyyyMMdd";
        public static string DefaultNotSerialized { get; } = "This item has been exluded from the serializazion.";
        public static ushort DefaultInitialPageNumber { get; } = 1;

        public Func<DateTime> NowFunction { get; }
        public string Version { get; }
        public string AsciiBanner { get; }

        #endregion

        #region Constructors

        public WIDExplorer
            (WIDExplorerComponents components, WIDExplorerSettings settings, Func<DateTime> nowFunction)
        {

            Validator.ValidateObject(components, nameof(components));
            Validator.ValidateObject(settings, nameof(settings));

            _components = components;
            _settings = settings;
            NowFunction = nowFunction;

            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            AsciiBanner = _components.AsciiBannerManager.Create(Version);

        }
        
        public WIDExplorer()
            : this(new WIDExplorerComponents(), new WIDExplorerSettings(), DefaultNowFunction) { }

        #endregion

        #region Methods_public

        public void LogAsciiBanner()
            => _components.LoggingActionAsciiBanner.Invoke(AsciiBanner);
        public List<BulletPoint> GetPreLabeledBulletPoints()
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RetrievingPreLabeledBulletPoints);

            List<BulletPoint> bulletPoints = _components.BulletPointManager.GetPreLabeledExamples();

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PreLabeledBulletPointsRetrieved.Invoke(bulletPoints));

            return bulletPoints;

        }
        public MetricCollection ConvertToMetricCollection(Exploration exploration)
        {

            Validator.ValidateObject(exploration, nameof(exploration));
            Validator.ValidateList(exploration.JobPostings, nameof(exploration.JobPostings));
            Validator.ValidateList(exploration.JobPostingsExtended, nameof(exploration.JobPostingsExtended));

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ConvertingExplorationToMetricCollection);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RunIdIs.Invoke(exploration.RunId));

            MetricCollection metricCollection = _components.MetricCollectionManager.Calculate(exploration);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationConvertedToMetricCollection);

            return metricCollection;

        }
        public string ConvertToJson(Exploration exploration)
        {

            Validator.ValidateObject(exploration, nameof(exploration));

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ConvertingExplorationToJsonString);
            LogSharedSerializationOptions();
            LogExplorationSerializationOptions();

            dynamic dyn = OptimizeExplorationForSerialization(exploration);
            string json = JsonSerializer.Serialize(dyn, CreateJsonSerializerOptions());

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ConvertedExplorationToJsonString);

            return json;

        }
        public string ConvertToJson(MetricCollection metricCollection, bool numbersAsPercentages)
        {

            Validator.ValidateObject(metricCollection, nameof(metricCollection));

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ConvertingMetricCollectionToJsonString);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_NumbersAsPercentagesIs.Invoke(numbersAsPercentages));
            LogSharedSerializationOptions();

            dynamic dyn = metricCollection;
            if (numbersAsPercentages)
                dyn = ConvertNumbersToPercentages(metricCollection);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ConvertedMetricsCollectionToJsonString);

            return JsonSerializer.Serialize(dyn, CreateJsonSerializerOptions());

        }
        public List<JobPosting> LoadFromJsonFile(IFileInfoAdapter jsonFile)
        {

            Validator.ValidateObject(jsonFile, nameof(jsonFile));
            Validator.ValidateFileExistance(jsonFile);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_LoadingJobPostingsFromJsonFile);

            DateTime now = NowFunction.Invoke();
            string runId = _components.RunIdManager.Create(now);
            ushort pageNumber = 1;

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SomeDefaultValuesUsedJsonFile);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RunIdIs.Invoke(runId));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageNumberIs.Invoke(pageNumber));

            string content = _components.FileManager.ReadAllText(jsonFile);
            JobPage jobPage = new JobPage(runId, pageNumber, content);
            List<JobPosting> jobPostings = _components.JobPostingDeserializer.Do(jobPage);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_JobPostingsExtractedFromJsonFile.Invoke(jobPostings));

            return jobPostings;

        }
        public List<JobPosting> LoadFromJsonFile(string filePath)
            => LoadFromJsonFile(_components.FileManager.Create(filePath));
        public IFileInfoAdapter SaveToJsonFile(MetricCollection metricCollection, bool numbersAsPercentages, IFileInfoAdapter jsonFile)
        {

            Validator.ValidateObject(metricCollection, nameof(metricCollection));
            Validator.ValidateObject(jsonFile, nameof(jsonFile));

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SavingMetricCollectionToJsonFile);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RunIdIs.Invoke(metricCollection.RunId));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_NumbersAsPercentagesIs.Invoke(numbersAsPercentages));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_JSONFileIs.Invoke(jsonFile));

            string json = ConvertToJson(metricCollection, numbersAsPercentages);
            _components.FileManager.WriteAllText(jsonFile, json);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_MetricCollectionSavedToJsonFile);

            return jsonFile;

        }
        public IFileInfoAdapter SaveToJsonFile(MetricCollection metricCollection, bool numbersAsPercentages)
        {

            DateTime now = NowFunction.Invoke();
            string fullName = _components.FilenameFactory.CreateForMetricCollectionJson(_settings.FolderPath, now, numbersAsPercentages);
            IFileInfoAdapter jsonFile = new FileInfoAdapter(fullName);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_MethodCalledWithoutIFileInfoAdapter.Invoke(nameof(SaveToJsonFile)));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_DefaultValuesCreateIFileInfoAdapter);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FolderPathIs.Invoke(_settings.FolderPath));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_NowIs.Invoke(now));

            return SaveToJsonFile(metricCollection, numbersAsPercentages, jsonFile);

        }
        public IFileInfoAdapter SaveToJsonFile(Exploration exploration, IFileInfoAdapter jsonFile)
        {

            Validator.ValidateObject(exploration, nameof(exploration));
            Validator.ValidateObject(jsonFile, nameof(jsonFile));

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SavingExplorationToJsonFile);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RunIdIs.Invoke(exploration.RunId));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_JSONFileIs.Invoke(jsonFile));

            string json = ConvertToJson(exploration);
            _components.FileManager.WriteAllText(jsonFile, json);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationSavedToJsonFile);

            return jsonFile;

        }
        public IFileInfoAdapter SaveToJsonFile(Exploration exploration)
        {

            DateTime now = NowFunction.Invoke();
            string fullName = _components.FilenameFactory.CreateForExplorationJson(_settings.FolderPath, now);
            IFileInfoAdapter jsonFile = new FileInfoAdapter(fullName);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_MethodCalledWithoutIFileInfoAdapter.Invoke(nameof(SaveToJsonFile)));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_DefaultValuesCreateIFileInfoAdapter);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FolderPathIs.Invoke(_settings.FolderPath));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_NowIs.Invoke(now));

            return SaveToJsonFile(exploration, jsonFile);

        }
        public IFileInfoAdapter SaveToSQLiteDatabase(List<JobPostingExtended> jobPostingsExtended, IFileInfoAdapter databaseFile, bool deleteAndRecreateDatabase)
        {

            Validator.ValidateList(jobPostingsExtended, nameof(jobPostingsExtended));
            Validator.ValidateObject(databaseFile, nameof(databaseFile));

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SavingJobPostingsExtendedToSQLiteDatabase);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_JobPostingsExtendedAre.Invoke(jobPostingsExtended));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_DatabaseFileIs.Invoke(databaseFile.FullName));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_DeleteAndRecreateDatabaseIs.Invoke(deleteAndRecreateDatabase));

            IRepository repository =
                _components.RepositoryFactory
                    .Create(databaseFile.DirectoryName, databaseFile.Name, _settings.DeleteAndRecreateDatabase);

            int affectedRows = repository.ConditionallyInsert(jobPostingsExtended);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_AffectedRowsAre.Invoke(affectedRows));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationSavedToSQLiteDatabase);

            return databaseFile;

        }
        public IFileInfoAdapter SaveToSQLiteDatabase(List<JobPostingExtended> jobPostingsExtended)
        {

            DateTime now = NowFunction.Invoke();
            string fullName = _components.FilenameFactory.CreateForDatabase(_settings.FolderPath, now);
            IFileInfoAdapter databaseFile = new FileInfoAdapter(fullName);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_MethodCalledWithoutIFileInfoAdapter.Invoke(nameof(SaveToJsonFile)));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_DefaultValuesCreateIFileInfoAdapter);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FolderPathIs.Invoke(_settings.FolderPath));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_NowIs.Invoke(now));

            return SaveToSQLiteDatabase(jobPostingsExtended, databaseFile, _settings.DeleteAndRecreateDatabase);

        }

        public Exploration Explore(ushort finalPageNumber, Stages stage)
        {

            DateTime now = NowFunction.Invoke();
            string runId = _components.RunIdManager.Create(now, DefaultInitialPageNumber, finalPageNumber);

            return Explore(runId, finalPageNumber, stage);

        }
        public Exploration Explore(string runId, ushort finalPageNumber, Stages stage)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfLessThanOne(finalPageNumber, nameof(finalPageNumber));

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

            DateTime now = NowFunction.Invoke();
            string runId = _components.RunIdManager.Create(now, thresholdDate);

            return Explore(runId, thresholdDate, stage);

        }
        public Exploration Explore(string runId, DateTime thresholdDate, Stages stage)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));

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

        public Exploration ExploreAll(Stages stage)
        {

            DateTime now = NowFunction.Invoke();
            string runId = _components.RunIdManager.Create(now);

            return ExploreAll(runId, stage);

        }
        public Exploration ExploreAll(string runId, Stages stage)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));

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

            dyn.JobPostingsByHiringOrgName = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByHiringOrgName);
            dyn.JobPostingsByWorkPlaceAddress = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByWorkPlaceAddress);
            dyn.JobPostingsByWorkPlacePostalCode = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByWorkPlacePostalCode);
            dyn.JobPostingsByWorkPlaceCity = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByWorkPlaceCity);
            dyn.JobPostingsByPostingCreated = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByPostingCreated);
            dyn.JobPostingsByLastDateApplication = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByLastDateApplication);
            dyn.JobPostingsByRegion = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByRegion);
            dyn.JobPostingsByMunicipality = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByMunicipality);
            dyn.JobPostingsByCountry = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByCountry);
            dyn.JobPostingsByEmploymentType = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByEmploymentType);
            dyn.JobPostingsByWorkHours = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByWorkHours);
            dyn.JobPostingsByOccupation = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByOccupation);
            dyn.JobPostingsByWorkplaceId = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByWorkplaceId);
            dyn.JobPostingsByOrganisationId = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByOrganisationId);
            dyn.JobPostingsByHiringOrgCVR = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByHiringOrgCVR);
            dyn.JobPostingsByWorkPlaceCityWithoutZone = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByWorkPlaceCityWithoutZone);

            dyn.JobPostingsByPublicationStartDate = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByPublicationStartDate);
            dyn.JobPostingsByPublicationEndDate = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByPublicationEndDate);
            dyn.JobPostingsByNumberToFill = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByNumberToFill);
            dyn.JobPostingsByContactEmail = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByContactEmail);
            dyn.JobPostingsByContactPersonName = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByContactPersonName);
            dyn.JobPostingsByEmploymentDate = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByEmploymentDate);
            dyn.JobPostingsByApplicationDeadlineDate = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByApplicationDeadlineDate);
            dyn.JobPostingsByBulletPointScenario = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.JobPostingsByBulletPointScenario);

            dyn.ResponseLengthByJobPostingId = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.ResponseLengthByJobPostingId);
            dyn.PresentationLengthByJobPostingId = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.PresentationLengthByJobPostingId);
            dyn.ExtendedResponseLengthByJobPostingId = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.ExtendedResponseLengthByJobPostingId);
            dyn.HiringOrgDescriptionLengthByJobPostingId = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.HiringOrgDescriptionLengthByJobPostingId);
            dyn.PurposeLengthByJobPostingId = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.PurposeLengthByJobPostingId);
            dyn.BulletPointsByJobPostingId = _components.MetricCollectionManager.ConvertToPercentages(metricCollection.BulletPointsByJobPostingId);

            dyn.TotalBulletPoints = metricCollection.TotalBulletPoints;

            return dyn;

        }

        private void LogInitializationMessage(string runId, ushort finalPageNumber, Stages stage)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationStarted);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RunIdIs(runId));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_DefaultInitialPageNumberIs(DefaultInitialPageNumber));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FinalPageNumberIs(finalPageNumber));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_StageIs(stage));

        }
        private void LogInitializationMessage(string runId, DateTime thresholdDate, Stages stage)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationStarted);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RunIdIs(runId));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_DefaultInitialPageNumberIs(DefaultInitialPageNumber));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ThresholdDateIs(thresholdDate));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_StageIs(stage));

        }
        private void LogInitializationMessage(string runId, Stages stage)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationStarted);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RunIdIs(runId));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_DefaultInitialPageNumberIs(DefaultInitialPageNumber));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FinalPageNumberIsLastPage);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_StageIs(stage));

        }
        private void LogSharedSerializationOptions()
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(JavaScriptEncoder.UnsafeRelaxedJsonEscaping)));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(DateTimeToDateConverter)));

        }
        private void LogExplorationSerializationOptions()
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(MessageCollection.WIDExplorer_NotSerializedJobPageContent));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(MessageCollection.WIDExplorer_NotSerializedJobPostings));

        }
        private Exploration LogCompletionMessageAndReturn(Exploration exploration)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationCompleted);

            return exploration;

        }

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
                =  new JobPosting(
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
                        jobPostingId: jobPosting.JobPostingId
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
        private dynamic OptimizeExplorationForSerialization(Exploration exploration)
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
            {

                dyn.JobPostingsExtended = OptimizeJobPostingsExtendedForSerialization(exploration.JobPostingsExtended);

                if (exploration.Stage == Stages.Stage3_UpToAllJobPostingsExtended)
                    dyn.JobPostings = DefaultNotSerialized;

            }

            return dyn;

        }

        private Exploration ProcessStage1(string runId, ushort initialPageNumber, Stages stage)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(stage));

            JobPage jobPage = _components.JobPageManager.GetJobPage(runId, initialPageNumber);

            // To-Do: "Page n.X retrieved" 

            ushort totalResultCount = _components.JobPageDeserializer.GetTotalResultCount(jobPage.Response);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_TotalResultCountIs(totalResultCount));

            ushort totalJobPages = _components.JobPageManager.GetTotalJobPages(totalResultCount);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_TotalJobPagesIs(totalJobPages));

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

                _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FinalPageNumberIsHigher(finalPageNumber, totalJobPages));
                _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FinalPageNumberWillBeNow(totalJobPages));

                return totalJobPages;

            }

            return finalPageNumber;

        }
        private Exploration ProcessStage2(Exploration exploration, ushort finalPageNumber, Stages stage)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(stage));

            List<JobPosting> jobPostings = _components.JobPostingDeserializer.Do(exploration.JobPages[0]);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_JobPostingScrapedInitial(jobPostings));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_AntiFloodingStrategy);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ParallelRequestsAre(_settings.ParallelRequests));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PauseBetweenRequestsIs(_settings.PauseBetweenRequestsMs));

            List<JobPage> stage2JobPages = new List<JobPage>(exploration.JobPages);
            for (ushort i = 2; i <= finalPageNumber; i++)
            {

                JobPage currentJobPage = _components.JobPageManager.GetJobPage(exploration.RunId, i);
                List<JobPosting> currentJobPostings = _components.JobPostingDeserializer.Do(currentJobPage);

                stage2JobPages.Add(currentJobPage);
                jobPostings.AddRange(currentJobPostings);

                _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_JobPostingObjectsScraped(i, currentJobPostings));

                ConditionallySleep(i, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_JobPostingObjectsScrapedTotal(jobPostings));

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

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(stage));

            List<JobPage> stage2JobPages = new List<JobPage>() { exploration.JobPages[0] };
            List<JobPosting> stage2JobPostings = new List<JobPosting>();

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_AntiFloodingStrategy);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ParallelRequestsAre(_settings.ParallelRequests));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PauseBetweenRequestsIs(_settings.PauseBetweenRequestsMs));

            ushort finalPageNumber = exploration.TotalJobPages;
            for (ushort i = 1; i <= exploration.TotalJobPages; i++)
            {

                List<JobPosting> currentJobPostings = new List<JobPosting>();

                if (i == 1)
                {

                    currentJobPostings = _components.JobPostingDeserializer.Do(exploration.JobPages[0]);
                    _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_JobPostingScrapedInitial(currentJobPostings));

                }
                else
                {

                    JobPage currentJobPage = _components.JobPageManager.GetJobPage(exploration.RunId, i);
                    currentJobPostings = _components.JobPostingDeserializer.Do(currentJobPage);

                    stage2JobPages.Add(currentJobPage);
                    _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_JobPostingObjectsScraped(i, currentJobPostings));

                }

                List<DateTime> postingCreatedCollection = currentJobPostings.Select(jobPosting => jobPosting.PostingCreated).ToList();
                bool isThresholdConditionMet = _components.JobPostingManager.IsThresholdConditionMet(thresholdDate, postingCreatedCollection);

                if (isThresholdConditionMet)
                {

                    _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ThresholdDateFoundPageNr(thresholdDate, i));

                    currentJobPostings = _components.JobPostingManager.RemoveUnsuitable(thresholdDate, currentJobPostings);
                    _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_XJobPostingsRemovedPageNr(currentJobPostings, i));

                    stage2JobPostings.AddRange(currentJobPostings);
                    finalPageNumber = i;

                    break;

                }
                else
                    stage2JobPostings.AddRange(currentJobPostings);

                ConditionallySleep(i, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FinalPageNumberThresholdDate(finalPageNumber));

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

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(stage));

            List<JobPostingExtended> pageItemsExtended = new List<JobPostingExtended>();
            foreach (JobPosting jobPosting in exploration.JobPostings)
            {

                JobPostingExtended current = _components.JobPostingExtendedManager.GetJobPostingExtended(jobPosting);
                pageItemsExtended.Add(current);

                _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_JobPostingExtendedScraped(jobPosting));

                ConditionallySleep(jobPosting.JobPostingNumber, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_JobPostingExtendedScrapedTotal(pageItemsExtended));

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
                        pageItemsExtended);

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 17.08.2021
*/