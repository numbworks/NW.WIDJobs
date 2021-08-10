using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading;

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
        public Exploration Explore(ushort finalPageNumber, Stages stage)
        {

            DateTime now = NowFunction.Invoke();
            ushort initialPageNumber = 1;

            string runId = _components.RunIdManager.Create(now, initialPageNumber, finalPageNumber);

            return Explore(runId, finalPageNumber, stage);

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
        public Exploration Explore(DateTime thresholdDate, Stages stage)
        {

            DateTime now = NowFunction.Invoke();

            string runId = _components.RunIdManager.Create(now, thresholdDate);

            return Explore(runId, thresholdDate, stage);

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
        public Exploration ExploreAll(Stages stage)
        {

            DateTime now = NowFunction.Invoke();
            string runId = _components.RunIdManager.Create(now);

            return ExploreAll(runId, stage);

        }

        public List<JobPosting> ExtractFromJson(IFileInfoAdapter jsonFile)
        {

            Validator.ValidateObject(jsonFile, nameof(jsonFile));
            Validator.ValidateFileExistance(jsonFile);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExtractJobPostingsFromJson);

            DateTime now = NowFunction.Invoke();
            string runId = _components.RunIdManager.Create(now);
            ushort pageNumber = 1;

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SomeDefaultValuesUsedFromHTML);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RunIdIs.Invoke(runId));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageNumberIs.Invoke(pageNumber));

            string content = _components.FileManager.ReadAllText(jsonFile);
            JobPage jobPage = new JobPage(runId, pageNumber, content);
            List<JobPosting> jobPostings = _components.JobPostingDeserializer.Do(jobPage);
            
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_JobPostingsExtractedFromJson.Invoke(jobPostings));

            return jobPostings;

        }
        public List<JobPosting> ExtractFromJson(string filePath)
            => ExtractFromJson(_components.FileManager.Create(filePath));

        public PageItemExtended TryExtractFromHtml(IFileInfoAdapter htmlFile)
        {

            Validator.ValidateObject(htmlFile, nameof(htmlFile));
            Validator.ValidateFileExistance(htmlFile);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExtractPageItemExtendedFromHTML);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_HTMLFileIs.Invoke(htmlFile));

            DateTime now = NowFunction.Invoke();
            string runId = _components.RunIdManager.Create(now);
            ushort pageNumber = PageItemExtendedScraper.DummyPageNumber;
            ushort pageItemNumber = PageItemExtendedScraper.DummyPageItemNumber;

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SomeDefaultValuesUsedFromHTML);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RunIdIs.Invoke(runId));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageNumberIs.Invoke(pageNumber));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemNumberIs.Invoke(pageItemNumber));

            string content = _components.FileManager.ReadAllText(htmlFile);
            PageItem pageItem = _components.JobPostingExtendedDeserializer.TryExtractPageItem(runId, pageNumber, pageItemNumber, content);
            if (pageItem == null)
            {
                _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ItHasNotBeenPossibleFromHTML);               
                return null;      
            }
            
            PageItemExtended pageItemExtended = _components.JobPostingExtendedDeserializer.Do(pageItem, content);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemExtendedIs.Invoke(pageItemExtended));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemExtendedExtractedFromHTML);

            return pageItemExtended;

        }
        public PageItemExtended TryExtractFromHtml(string filePath)
            => TryExtractFromHtml(_components.FileManager.Create(filePath));

        public IFileInfoAdapter SaveAsSQLite
            (List<PageItemExtended> pageItemsExtended, IFileInfoAdapter databaseFile, bool deleteAndRecreateDatabase)
        {

            Validator.ValidateList(pageItemsExtended, nameof(pageItemsExtended));
            Validator.ValidateObject(databaseFile, nameof(databaseFile));

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SavingPageItemsExtendedAsSQLite);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemsExtendedAre.Invoke(pageItemsExtended));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_DatabaseFileIs.Invoke(databaseFile.FullName));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_DeleteAndRecreateDatabaseIs.Invoke(deleteAndRecreateDatabase));

            IRepository repository = 
                _components.RepositoryFactory
                    .Create(databaseFile.DirectoryName, databaseFile.Name, _settings.DeleteAndRecreateDatabase);

            // int affectedRows = repository.ConditionallyInsert(pageItemsExtended);

            // _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_AffectedRowsAre.Invoke(affectedRows));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationSavedAsSQLite);

            return databaseFile;

        }
        public IFileInfoAdapter SaveAsSQLite(List<PageItemExtended> pageItemsExtended)
        {

            DateTime now = NowFunction.Invoke();
            string fullName = _components.FilenameFactory.CreateForDatabase(_settings.FolderPath, now);
            IFileInfoAdapter databaseFile = new FileInfoAdapter(fullName);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_MethodCalledWithoutIFileInfoAdapter.Invoke(nameof(SaveAsJson)));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_DefaultValuesCreateIFileInfoAdapter);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FolderPathIs.Invoke(_settings.FolderPath));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_NowIs.Invoke(now));

            return SaveAsSQLite(pageItemsExtended, databaseFile, _settings.DeleteAndRecreateDatabase);

        }

        public IFileInfoAdapter SaveAsJson(Exploration exploration, IFileInfoAdapter jsonFile)
        {

            Validator.ValidateObject(exploration, nameof(exploration));
            Validator.ValidateObject(jsonFile, nameof(jsonFile));

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SavingExplorationAsJson);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RunIdIs.Invoke(exploration.RunId));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_JSONFileIs.Invoke(jsonFile));

            string json = ConvertToJson(exploration);
            _components.FileManager.WriteAllText(jsonFile, json);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationSavedAsJson);

            return jsonFile;

        }
        public IFileInfoAdapter SaveAsJson(Exploration exploration)
        {

            DateTime now = NowFunction.Invoke();
            string fullName = _components.FilenameFactory.CreateForExplorationJson(_settings.FolderPath, now);
            IFileInfoAdapter jsonFile = new FileInfoAdapter(fullName);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_MethodCalledWithoutIFileInfoAdapter.Invoke(nameof(SaveAsJson)));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_DefaultValuesCreateIFileInfoAdapter);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FolderPathIs.Invoke(_settings.FolderPath));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_NowIs.Invoke(now));

            return SaveAsJson(exploration, jsonFile);

        }

        public IFileInfoAdapter SaveAsJson(MetricCollection metricCollection, bool numbersAsPercentages, IFileInfoAdapter jsonFile)
        {

            Validator.ValidateObject(metricCollection, nameof(metricCollection));
            Validator.ValidateObject(jsonFile, nameof(jsonFile));

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SavingMetricCollectionAsJson);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RunIdIs.Invoke(metricCollection.RunId));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_NumbersAsPercentagesIs.Invoke(numbersAsPercentages));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_JSONFileIs.Invoke(jsonFile));

            string json = ConvertToJson(metricCollection, numbersAsPercentages);
            _components.FileManager.WriteAllText(jsonFile, json);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_MetricsSavedAsJson);

            return jsonFile;

        }
        public IFileInfoAdapter SaveAsJson(MetricCollection metricCollection, bool numbersAsPercentages)
        {

            DateTime now = NowFunction.Invoke();           
            string fullName = _components.FilenameFactory.CreateForMetricsJson(_settings.FolderPath, now, numbersAsPercentages);       
            IFileInfoAdapter jsonFile = new FileInfoAdapter(fullName);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_MethodCalledWithoutIFileInfoAdapter.Invoke(nameof(SaveAsJson)));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_DefaultValuesCreateIFileInfoAdapter);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FolderPathIs.Invoke(_settings.FolderPath));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_NowIs.Invoke(now));

            return SaveAsJson(metricCollection, numbersAsPercentages, jsonFile);

        }

        public string ConvertToJson(Exploration exploration)
        {

            Validator.ValidateObject(exploration, nameof(exploration));

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ConvertingExplorationToJsonString);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(JavaScriptEncoder.UnsafeRelaxedJsonEscaping)));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(DateTimeToDateConverter)));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(MessageCollection.WIDExplorer_SerializationOptionPageContent));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(MessageCollection.WIDExplorer_SerializationOptionPageItems));

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            options.Converters.Add(new DateTimeToDateConverter());

            dynamic dyn = OptimizeForSerialization(exploration);
            string json = JsonSerializer.Serialize(dyn, options);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ConvertedExplorationToJsonString);

            return json;

        }
        public string ConvertToJson(MetricCollection metricCollection, bool numbersAsPercentages)
        {

            Validator.ValidateObject(metricCollection, nameof(metricCollection));

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ConvertingMetricCollectionToJsonString);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_NumbersAsPercentagesIs.Invoke(numbersAsPercentages));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(JavaScriptEncoder.UnsafeRelaxedJsonEscaping)));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SerializationOptionIs.Invoke(nameof(DateTimeToDateConverter)));

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            options.Converters.Add(new DateTimeToDateConverter());

            dynamic dyn = metricCollection;
            if (numbersAsPercentages)
                dyn = ConvertNumbersToPercentages(metricCollection);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ConvertedMetricsCollectionToJsonString);

            return JsonSerializer.Serialize(dyn, options);

        }
        public MetricCollection ConvertToMetricCollection(Exploration exploration)
        {

            Validator.ValidateObject(exploration, nameof(exploration));
            Validator.ValidateList(exploration.JobPostings, nameof(exploration.JobPostings));
            Validator.ValidateList(exploration.JobPostingsExtended, nameof(exploration.JobPostingsExtended));

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ConvertingExplorationToMetrics);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RunIdIs.Invoke(exploration.RunId));

            MetricCollection metrics = _components.MetricCollectionManager.Calculate(exploration);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationConvertedToMetrics);

            return metrics;

        }

        public List<BulletPoint> GetPreLabeledBulletPoints()
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RetrievingPreLabeledBulletPoints);

            List<BulletPoint> bulletPoints = _components.BulletPointManager.GetPreLabeledExamples();

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PreLabeledBulletPointsRetrieved.Invoke(bulletPoints));

            return bulletPoints;

        }
        public void LogAsciiBanner()
            => _components.LoggingActionAsciiBanner.Invoke(AsciiBanner);

        #endregion

        #region Methods_private

        private void ConditionallySleep(ushort i, ushort parallelRequests, uint pauseBetweenRequestsMs)
        {

            // Do a pause of x each y requests
            // i != 0, because 0 % x = 0...
            if (i != 0 && i % parallelRequests == 0)
                Thread.Sleep((int)pauseBetweenRequestsMs);

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
        private Exploration LogCompletionMessageAndReturn(Exploration exploration)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationCompleted);

            return exploration;

        }
        private dynamic OptimizeForSerialization(Exploration exploration)
        {

            dynamic dyn = new ExpandoObject();

            dyn.RunId = exploration.RunId;
            dyn.TotalResultCount = exploration.TotalResultCount;
            dyn.TotalJobPages = exploration.TotalJobPages;
            dyn.Stage = exploration.Stage;
            dyn.IsCompleted = exploration.IsCompleted;

            dyn.JobPages =
                exploration.JobPages?.Select(jobPage => new JobPage(jobPage.RunId, jobPage.PageNumber, DefaultNotSerialized)).ToList();

            if (exploration.Stage == Stages.Stage3_UpToAllJobPostingsExtended)
                dyn.JobPostings = DefaultNotSerialized;

            dyn.JobPostingsExtended = exploration.JobPostingsExtended;

            return dyn;

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

        private Exploration ProcessStage1
            (string runId, ushort initialPageNumber, Stages stage)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(stage));

            string url = _components.JobPageManager.CreateUrl(initialPageNumber, category);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_UrlCreated);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_UrlIs(url));

            string content = _components.JobPageManager.GetContent(url);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ContentSuccessfullyRetrieved);

            uint totalResults = _components.JobPageDeserializer.GetTotalResults(content);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_TotalResultsAre(totalResults));

            ushort totalEstimatedPages = _components.JobPageManager.GetTotalEstimatedPages(totalResults);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_TotalEstimatedPagesAre(totalEstimatedPages));

            bool isCompleted = false;
            if (stage == Stages.Stage1_OnlyMetrics)
                isCompleted = true;

            Page page = new Page(runId, initialPageNumber, content);
            List<Page> pages = new List<Page>() { page };

            return
                new WIDExploration(
                        runId,
                        totalResults,
                        totalEstimatedPages,
                        category,
                        stage,
                        isCompleted,
                        pages);

        }
        private ushort EstablishFinalPageNumber
            (ushort finalPageNumber, ushort totalEstimatedPages)
        {

            if (finalPageNumber > totalEstimatedPages)
            {

                _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FinalPageNumberIsHigher(finalPageNumber, totalEstimatedPages));
                _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FinalPageNumberWillBeNow(totalEstimatedPages));

                return totalEstimatedPages;

            }

            return finalPageNumber;

        }
        private Exploration ProcessStage2
            (Exploration exploration, ushort finalPageNumber, Stages stage)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(stage));

            List<PageItem> pageItems = _components.JobPostingDeserializer.Do(exploration.JobPages[0]);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemScrapedInitial(pageItems));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_AntiFloodingStrategy);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ParallelRequestsAre(_settings.ParallelRequests));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PauseBetweenRequestsIs(_settings.PauseBetweenRequestsMs));

            List<Page> stage2Pages = new List<Page>(exploration.JobPages);
            for (ushort i = 2; i <= finalPageNumber; i++)
            {

                Page currentPage = _components.JobPageManager.GetPage(exploration.RunId, i, exploration.Category);
                List<PageItem> currentPageItems = _components.JobPostingDeserializer.Do(currentPage);

                stage2Pages.Add(currentPage);
                pageItems.AddRange(currentPageItems);

                _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemObjectsScraped(i, currentPageItems));

                ConditionallySleep(i, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemObjectsScrapedTotal(pageItems));

            bool isCompleted = false;
            if (stage == Stages.Stage2_UpToAllJobPostings)
                isCompleted = true;

            return
                new WIDExploration(
                        exploration.RunId,
                        exploration.TotalResultCount,
                        exploration.TotalJobPages,
                        exploration.Category,
                        stage,
                        isCompleted,
                        stage2Pages,
                        pageItems);

        }
        private Exploration ProcessStage2WhenThresholdDate
            (Exploration exploration, Stages stage, DateTime thresholdDate)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(stage));

            List<Page> stage2Pages = new List<Page>() { exploration.JobPages[0] };
            List<PageItem> stage2PageItems = new List<PageItem>();

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_AntiFloodingStrategy);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ParallelRequestsAre(_settings.ParallelRequests));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PauseBetweenRequestsIs(_settings.PauseBetweenRequestsMs));

            ushort finalPageNumber = exploration.TotalJobPages;
            for (ushort i = 1; i <= exploration.TotalJobPages; i++)
            {

                List<PageItem> currentPageItems = new List<PageItem>();

                if (i == 1)
                {

                    currentPageItems = _components.JobPostingDeserializer.Do(exploration.JobPages[0]);
                    _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemScrapedInitial(currentPageItems));

                }
                else
                {

                    Page currentPage = _components.JobPageManager.GetPage(exploration.RunId, i, exploration.Category);
                    currentPageItems = _components.JobPostingDeserializer.Do(currentPage);

                    stage2Pages.Add(currentPage);
                    _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemObjectsScraped(i, currentPageItems));

                }

                List<DateTime> createDates = currentPageItems.Select(pageItem => pageItem.CreateDate).ToList();
                bool isThresholdConditionMet = _components.JobPostingDeserializer.IsThresholdConditionMet(thresholdDate, createDates);

                if (isThresholdConditionMet)
                {

                    _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ThresholdDateFoundPageNr(thresholdDate, i));

                    currentPageItems = _components.JobPostingDeserializer.RemoveUnsuitable(thresholdDate, currentPageItems);
                    _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_XPageItemsRemovedPageNr(currentPageItems, i));

                    stage2PageItems.AddRange(currentPageItems);
                    finalPageNumber = i;

                    break;

                }
                else
                    stage2PageItems.AddRange(currentPageItems);

                ConditionallySleep(i, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FinalPageNumberThresholdDate(finalPageNumber));

            bool isCompleted = false;
            if (stage == Stages.Stage2_UpToAllJobPostings)
                isCompleted = true;

            return
                new WIDExploration(
                        exploration.RunId,
                        exploration.TotalResultCount,
                        exploration.TotalJobPages,
                        exploration.Category,
                        exploration.Stage,
                        isCompleted,
                        stage2Pages,
                        stage2PageItems);

        }
        private Exploration ProcessStage3
            (Exploration exploration, Stages stage)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(stage));

            List<PageItemExtended> pageItemsExtended = new List<PageItemExtended>();
            foreach (PageItem pageItem in exploration.JobPostings)
            {

                PageItemExtended current = _components.JobPostingExtendedManager.Get(pageItem);
                pageItemsExtended.Add(current);

                _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemExtendedScraped(pageItem));

                ConditionallySleep(pageItem.PageItemNumber, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemExtendedScrapedTotal(pageItemsExtended));

            bool isCompleted = true;

            return
                new WIDExploration(
                        exploration.RunId,
                        exploration.TotalResultCount,
                        exploration.TotalJobPages,
                        exploration.Category,
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
    Last Update: 10.06.2021
*/