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

        public static string DefaultNotSerialized { get; } = "This item has been exluded from the serializazion.";
        public static ushort DefaultInitialPageNumber { get; } = 1;
        public DateTime Now { get; }
        public string Version { get; }
        public string AsciiBanner { get; }

        #endregion

        #region Constructors

        public WIDExplorer
            (WIDExplorerComponents components, WIDExplorerSettings settings, DateTime now)
        {

            Validator.ValidateObject(components, nameof(components));
            Validator.ValidateObject(settings, nameof(settings));

            _components = components;
            _settings = settings;
            Now = now;

            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            AsciiBanner = _components.AsciiBannerManager.Create(Version);

        }
        
        public WIDExplorer()
            : this(new WIDExplorerComponents(), new WIDExplorerSettings(), DateTime.Now) { }

        #endregion

        #region Methods_public

        public WIDExploration Explore
            (string runId, ushort finalPageNumber, WIDCategories category, WIDStages stage)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfLessThanOne(finalPageNumber, nameof(finalPageNumber));

            LogAsciiBanner();
            LogInitializationMessage(runId, finalPageNumber, category, stage);

            WIDExploration exploration = ProcessStage1(runId, DefaultInitialPageNumber, category, stage);
            if (exploration.IsCompleted)
                return LogCompletionMessageAndReturn(exploration);

            finalPageNumber = EstablishFinalPageNumber(finalPageNumber, exploration.TotalEstimatedPages);

            exploration = ProcessStage2(exploration, finalPageNumber, stage);
            if (exploration.IsCompleted)
                return LogCompletionMessageAndReturn(exploration);

            exploration = ProcessStage3(exploration, stage);

            return LogCompletionMessageAndReturn(exploration);

        }
        public WIDExploration Explore
            (ushort finalPageNumber, WIDCategories category, WIDStages stage)
        {

            ushort initialPageNumber = 1;
            string runId = _components.RunIdManager.Create(Now, initialPageNumber, finalPageNumber);

            return Explore(runId, finalPageNumber, category, stage);

        }

        public WIDExploration Explore
            (string runId, DateTime thresholdDate, WIDCategories category, WIDStages stage)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));

            LogAsciiBanner();
            LogInitializationMessage(runId, thresholdDate, category, stage);

            WIDExploration exploration = ProcessStage1(runId, DefaultInitialPageNumber, category, stage);
            if (exploration.IsCompleted)
                return LogCompletionMessageAndReturn(exploration);

            exploration = ProcessStage2WhenThresholdDate(exploration, stage, thresholdDate);
            if (exploration.IsCompleted)
                return LogCompletionMessageAndReturn(exploration);

            exploration = ProcessStage3(exploration, stage);

            return LogCompletionMessageAndReturn(exploration);

        }
        public WIDExploration Explore
            (DateTime thresholdDate, WIDCategories category, WIDStages stage)
        {

            string runId = _components.RunIdManager.Create(Now, thresholdDate);

            return Explore(runId, thresholdDate, category, stage);

        }

        public WIDExploration ExploreAll
            (string runId, WIDCategories category, WIDStages stage)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));

            LogAsciiBanner();
            LogInitializationMessage(runId, category, stage);

            WIDExploration exploration = ProcessStage1(runId, DefaultInitialPageNumber, category, stage);
            if (exploration.IsCompleted)
                return LogCompletionMessageAndReturn(exploration);

            ushort finalPageNumber = exploration.TotalEstimatedPages;

            exploration = ProcessStage2(exploration, finalPageNumber, stage);
            if (exploration.IsCompleted)
                return LogCompletionMessageAndReturn(exploration);

            exploration = ProcessStage3(exploration, stage);

            return LogCompletionMessageAndReturn(exploration);

        }
        public WIDExploration ExploreAll
            (WIDCategories category, WIDStages stage)
        {

            string runId = _components.RunIdManager.Create(Now);

            return ExploreAll(runId, category, stage);

        }

        public List<PageItem> GetPageItemsFromHtml(IFileInfoAdapter fileInfoAdapter)
        {

            Validator.ValidateObject(fileInfoAdapter, nameof(fileInfoAdapter));
            Validator.ValidateFileExistance(fileInfoAdapter);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExploringProvidedFile.Invoke(fileInfoAdapter));

            string runId = _components.RunIdManager.Create(Now);
            ushort pageNumber = 1;

            string content = _components.FileManager.ReadAllText(fileInfoAdapter);
            Page page = new Page(runId, pageNumber, content);
            List<PageItem> pageItems = _components.PageItemScraper.Do(page);
            
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemObjectsScrapedTotal.Invoke(pageItems));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ProvidedFileSuccessfullyExplored);

            return pageItems;

        }
        public List<PageItem> GetPageItemsFromHtml(string filePath)
            => GetPageItemsFromHtml(_components.FileManager.Create(filePath));

        public PageItemExtended TryGetPageItemExtendedFromHtml(IFileInfoAdapter fileInfoAdapter)
        {

            Validator.ValidateObject(fileInfoAdapter, nameof(fileInfoAdapter));
            Validator.ValidateFileExistance(fileInfoAdapter);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExploringProvidedFile.Invoke(fileInfoAdapter));

            string runId = _components.RunIdManager.Create(Now);
            ushort pageNumber = PageItemExtendedScraper.DummyPageNumber;
            ushort pageItemNumber = PageItemExtendedScraper.DummyPageItemNumber;

            string content = _components.FileManager.ReadAllText(fileInfoAdapter);
            PageItem pageItem = _components.PageItemExtendedScraper.TryExtractPageItem(runId, pageNumber, pageItemNumber, content);
            PageItemExtended pageItemExtended = _components.PageItemExtendedScraper.Do(pageItem, content);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ProvidedFileSuccessfullyExplored);

            return pageItemExtended;

        }
        public PageItemExtended TryGetPageItemExtendedFromHtml(string filePath)
            => TryGetPageItemExtendedFromHtml(_components.FileManager.Create(filePath));

        public WIDMetrics CalculateMetrics(WIDExploration exploration)
            => _components.MetricsManager.Calculate(exploration);

        public string ConvertToJson(WIDExploration exploration)
        {

            Validator.ValidateObject(exploration, nameof(exploration));

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            options.Converters.Add(new DateTimeToDateConverter());

            dynamic dyn = new ExpandoObject();
            dyn.RunId = exploration.RunId;
            dyn.TotalResults = exploration.TotalResults;
            dyn.TotalEstimatedPages = exploration.TotalEstimatedPages;
            dyn.Category = exploration.Category;
            dyn.Stage = exploration.Stage;
            dyn.IsCompleted = exploration.IsCompleted;
            dyn.Pages = exploration.Pages?.Select(page => new Page(page.RunId, page.PageNumber, DefaultNotSerialized)).ToList();

            if (exploration.Stage == WIDStages.Stage3_UpToAllPageItemsExtended)
                dyn.PageItems = DefaultNotSerialized;

            dyn.PageItemsExtended = exploration.PageItemsExtended;

            return JsonSerializer.Serialize(dyn, options);

        }
        public string ConvertToJson(WIDMetrics metrics, bool numbersAsPercentages)
        {

            Validator.ValidateObject(metrics, nameof(metrics));

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            options.Converters.Add(new DateTimeToDateConverter());

            if(numbersAsPercentages)
            {

                dynamic dyn = ConvertNumbersToPercentages(metrics);

                return JsonSerializer.Serialize(dyn, options);
            
            }

            return JsonSerializer.Serialize(metrics, options);

        }

        public IFileInfoAdapter SaveAsSQLite
            (List<PageItemExtended> pageItemsExtended, IFileInfoAdapter databaseFile, bool deleteAndRecreateDatabase)
        {

            Validator.ValidateList(pageItemsExtended, nameof(pageItemsExtended));
            Validator.ValidateFileExistance(databaseFile);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExportingToSQLite.Invoke(pageItemsExtended));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_DatabaseFileIs.Invoke(databaseFile.FullName));

            IRepository repository = 
                _components.RepositoryFactory
                    .Create(databaseFile.DirectoryName, databaseFile.Name, _settings.DeleteAndRecreateDatabase);
            
            int affectedRows = repository.Insert(pageItemsExtended);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_AffectedRowsAre.Invoke(affectedRows));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_SQLiteDatabaseSuccessfullyCreated);

            return new FileInfoAdapter(databaseFile.FullName);

        }
        public IFileInfoAdapter SaveAsSQLite(List<PageItemExtended> pageItemsExtended)
        {

            string fullName = Path.Combine(_settings.DatabasePath, _settings.DatabaseName);
            IFileInfoAdapter databaseFile = new FileInfoAdapter(fullName);

            return SaveAsSQLite(pageItemsExtended, databaseFile, _settings.DeleteAndRecreateDatabase);

        }

        #endregion

        #region Methods_private

        private void ConditionallySleep
            (ushort i, ushort parallelRequests, uint pauseBetweenRequestsMs)
        {

            // Do a pause of x each y requests
            // i != 0, because 0 % x = 0...
            if (i != 0 && i % parallelRequests == 0)
                Thread.Sleep((int)pauseBetweenRequestsMs);

        }
        private void LogAsciiBanner()
            => _components.LoggingActionAsciiBanner.Invoke(AsciiBanner);
        private void LogInitializationMessage
            (string runId, ushort finalPageNumber, WIDCategories category, WIDStages stage)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationStarted);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RunIdIs(runId));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_NowIs(Now));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_DefaultInitialPageNumberIs(DefaultInitialPageNumber));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FinalPageNumberIs(finalPageNumber));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_CategoryIs(category));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_StageIs(stage));

        }
        private void LogInitializationMessage
            (string runId, DateTime thresholdDate, WIDCategories category, WIDStages stage)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationStarted);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RunIdIs(runId));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_NowIs(Now));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_DefaultInitialPageNumberIs(DefaultInitialPageNumber));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ThresholdDateIs(thresholdDate));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_CategoryIs(category));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_StageIs(stage));

        }
        private void LogInitializationMessage
            (string runId, WIDCategories category, WIDStages stage)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationStarted);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RunIdIs(runId));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_NowIs(Now));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_DefaultInitialPageNumberIs(DefaultInitialPageNumber));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FinalPageNumberIsLastPage);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_CategoryIs(category));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_StageIs(stage));

        }
        private WIDExploration LogCompletionMessageAndReturn(WIDExploration exploration)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationCompleted);

            return exploration;

        }
        private dynamic ConvertNumbersToPercentages(WIDMetrics metrics)
        {

            dynamic dyn = new ExpandoObject();

            dyn.RunId = metrics.RunId;
            dyn.TotalPages = metrics.TotalPages;
            dyn.TotalItems = metrics.TotalItems;

            dyn.ItemsByWorkAreaWithoutZone =
                _components.MetricsManager.ConvertToPercentages(metrics.ItemsByWorkAreaWithoutZone);
            dyn.ItemsByCreateDate =
                _components.MetricsManager.ConvertToPercentages(metrics.ItemsByCreateDate);
            dyn.ItemsByApplicationDate =
                _components.MetricsManager.ConvertToPercentages(metrics.ItemsByApplicationDate);
            dyn.ItemsByEmployerName =
                _components.MetricsManager.ConvertToPercentages(metrics.ItemsByEmployerName);
            dyn.ItemsByNumberOfOpenings =
                _components.MetricsManager.ConvertToPercentages(metrics.ItemsByNumberOfOpenings);
            dyn.ItemsByAdvertisementPublishDate =
                _components.MetricsManager.ConvertToPercentages(metrics.ItemsByAdvertisementPublishDate);
            dyn.ItemsByApplicationDeadline =
                _components.MetricsManager.ConvertToPercentages(metrics.ItemsByApplicationDeadline);
            dyn.ItemsByStartDateOfEmployment =
                _components.MetricsManager.ConvertToPercentages(metrics.ItemsByStartDateOfEmployment);
            dyn.ItemsByReference =
                _components.MetricsManager.ConvertToPercentages(metrics.ItemsByReference);
            dyn.ItemsByPosition =
                _components.MetricsManager.ConvertToPercentages(metrics.ItemsByPosition);
            dyn.ItemsByTypeOfEmployment =
                _components.MetricsManager.ConvertToPercentages(metrics.ItemsByTypeOfEmployment);
            dyn.ItemsByContact =
                _components.MetricsManager.ConvertToPercentages(metrics.ItemsByContact);
            dyn.ItemsByEmployerAddress =
                _components.MetricsManager.ConvertToPercentages(metrics.ItemsByEmployerAddress);
            dyn.ItemsByHowToApply =
                _components.MetricsManager.ConvertToPercentages(metrics.ItemsByHowToApply);
            dyn.DescriptionLengthByPageItemId =
                _components.MetricsManager.ConvertToPercentages(metrics.DescriptionLengthByPageItemId);
            dyn.BulletPointsByPageItemId =
                _components.MetricsManager.ConvertToPercentages(metrics.BulletPointsByPageItemId);

            dyn.TotalBulletPoints = metrics.TotalBulletPoints;

            return dyn;

        }

        private WIDExploration ProcessStage1
            (string runId, ushort initialPageNumber, WIDCategories category, WIDStages stage)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(stage));

            string url = _components.PageManager.CreateUrl(initialPageNumber, category);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_UrlCreated);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_UrlIs(url));

            string content = _components.PageManager.GetContent(url);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ContentSuccessfullyRetrieved);

            uint totalResults = _components.PageScraper.GetTotalResults(content);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_TotalResultsAre(totalResults));

            ushort totalEstimatedPages = _components.PageManager.GetTotalEstimatedPages(totalResults);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_TotalEstimatedPagesAre(totalEstimatedPages));

            bool isCompleted = false;
            if (stage == WIDStages.Stage1_OnlyMetrics)
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
        private WIDExploration ProcessStage2
            (WIDExploration exploration, ushort finalPageNumber, WIDStages stage)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(stage));

            List<PageItem> pageItems = _components.PageItemScraper.Do(exploration.Pages[0]);

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemScrapedInitial(pageItems));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_AntiFloodingStrategy);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ParallelRequestsAre(_settings.ParallelRequests));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PauseBetweenRequestsIs(_settings.PauseBetweenRequestsMs));

            List<Page> stage2Pages = new List<Page>(exploration.Pages);
            for (ushort i = 2; i <= finalPageNumber; i++)
            {

                Page currentPage = _components.PageManager.GetPage(exploration.RunId, i, exploration.Category);
                List<PageItem> currentPageItems = _components.PageItemScraper.Do(currentPage);

                stage2Pages.Add(currentPage);
                pageItems.AddRange(currentPageItems);

                _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemObjectsScraped(i, currentPageItems));

                ConditionallySleep(i, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemObjectsScrapedTotal(pageItems));

            bool isCompleted = false;
            if (stage == WIDStages.Stage2_UpToAllPageItems)
                isCompleted = true;

            return
                new WIDExploration(
                        exploration.RunId,
                        exploration.TotalResults,
                        exploration.TotalEstimatedPages,
                        exploration.Category,
                        stage,
                        isCompleted,
                        stage2Pages,
                        pageItems);

        }
        private WIDExploration ProcessStage2WhenThresholdDate
            (WIDExploration exploration, WIDStages stage, DateTime thresholdDate)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(stage));

            List<Page> stage2Pages = new List<Page>() { exploration.Pages[0] };
            List<PageItem> stage2PageItems = new List<PageItem>();

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_AntiFloodingStrategy);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ParallelRequestsAre(_settings.ParallelRequests));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PauseBetweenRequestsIs(_settings.PauseBetweenRequestsMs));

            ushort finalPageNumber = exploration.TotalEstimatedPages;
            for (ushort i = 1; i <= exploration.TotalEstimatedPages; i++)
            {

                List<PageItem> currentPageItems = new List<PageItem>();

                if (i == 1)
                {

                    currentPageItems = _components.PageItemScraper.Do(exploration.Pages[0]);
                    _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemScrapedInitial(currentPageItems));

                }
                else
                {

                    Page currentPage = _components.PageManager.GetPage(exploration.RunId, i, exploration.Category);
                    currentPageItems = _components.PageItemScraper.Do(currentPage);

                    stage2Pages.Add(currentPage);
                    _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemObjectsScraped(i, currentPageItems));

                }

                List<DateTime> createDates = currentPageItems.Select(pageItem => pageItem.CreateDate).ToList();
                bool isThresholdConditionMet = _components.PageItemScraper.IsThresholdConditionMet(thresholdDate, createDates);

                if (isThresholdConditionMet)
                {

                    _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ThresholdDateFoundPageNr(thresholdDate, i));

                    currentPageItems = _components.PageItemScraper.RemoveUnsuitable(thresholdDate, currentPageItems);
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
            if (stage == WIDStages.Stage2_UpToAllPageItems)
                isCompleted = true;

            return
                new WIDExploration(
                        exploration.RunId,
                        exploration.TotalResults,
                        exploration.TotalEstimatedPages,
                        exploration.Category,
                        exploration.Stage,
                        isCompleted,
                        stage2Pages,
                        stage2PageItems);

        }
        private WIDExploration ProcessStage3
            (WIDExploration exploration, WIDStages stage)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(stage));

            List<PageItemExtended> pageItemsExtended = new List<PageItemExtended>();
            foreach (PageItem pageItem in exploration.PageItems)
            {

                PageItemExtended current = _components.PageItemExtendedManager.Get(pageItem);
                pageItemsExtended.Add(current);

                _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemExtendedScraped(pageItem));

                ConditionallySleep(pageItem.PageItemNumber, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemExtendedScrapedTotal(pageItemsExtended));

            bool isCompleted = true;

            return
                new WIDExploration(
                        exploration.RunId,
                        exploration.TotalResults,
                        exploration.TotalEstimatedPages,
                        exploration.Category,
                        stage,
                        isCompleted,
                        exploration.Pages,
                        exploration.PageItems,
                        pageItemsExtended);

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 10.06.2021
*/