using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Threading;
using System.Linq;

namespace NW.WIDJobs
{

    public class WIDExplorer
    {

        // Fields
        private WIDExplorerComponents _components;
        private WIDExplorerSettings _settings;

        // Properties
        public static string DefaultNotSerialized { get; } = "<not_serialized>";
        public static ushort DefaultInitialPageNumber { get; } = 1;
        public DateTime Now { get; }
        public string RunId { get; }

        // Constructors
        public WIDExplorer
            (WIDExplorerComponents components, WIDExplorerSettings settings, DateTime now)
        {

            Validator.ValidateObject(components, nameof(components));
            Validator.ValidateObject(settings, nameof(settings));

            _components = components;
            _settings = settings;
            Now = now;

        }
        public WIDExplorer()
            : this(new WIDExplorerComponents(), new WIDExplorerSettings(), DateTime.Now) { }

        // Methods (public)
        public string ToJson(WIDExploration exploration)
        {

            Validator.ValidateObject(exploration, nameof(exploration));

            WIDExploration clean
                = new WIDExploration(
                        exploration.RunId,
                        exploration.TotalResults,
                        exploration.TotalEstimatedPages,
                        exploration.Category,
                        exploration.Stage,
                        exploration.IsCompleted,
                        exploration.Pages?.Select(page => new Page(page.RunId, page.PageNumber, DefaultNotSerialized)).ToList(),
                        exploration.PageItems,
                        exploration.PageItemsExtended
                        );

            JsonSerializerOptions jso = new JsonSerializerOptions();
            jso.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            return JsonSerializer.Serialize(clean, jso);

        }

        public WIDExploration Explore
            (string runId, ushort untilPageNumber, WIDCategories category, WIDStages stage)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfLessThanOne(untilPageNumber, nameof(untilPageNumber));

            LogInitializationMessage(runId, untilPageNumber, category, stage);

            WIDExploration exploration = ProcessStage1(runId, DefaultInitialPageNumber, category, stage);
            if (exploration.IsCompleted)
                return LogCompletionMessageAndReturn(exploration);

            exploration = ProcessStage2(exploration, untilPageNumber, stage);
            if (exploration.IsCompleted)
                return LogCompletionMessageAndReturn(exploration);

            exploration = ProcessStage3(exploration, stage);

            return LogCompletionMessageAndReturn(exploration);

        }
        public WIDExploration Explore
            (ushort untilPageNumber, WIDCategories category, WIDStages stage)
        {

            ushort initialPageNumber = 1;
            string runId = _components.RunIdManager.Create(Now, initialPageNumber, untilPageNumber);

            return Explore(runId, untilPageNumber, category, stage);

        }

        public WIDExploration Explore
            (string runId, DateTime untilDate, WIDCategories category, WIDStages stage)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfFirstIsOlderOrEqual(Now, nameof(Now), untilDate, nameof(untilDate));

            LogInitializationMessage(runId, untilDate, category, stage);

            WIDExploration exploration 
                = ProcessStage1WhenUntilDate(runId, DefaultInitialPageNumber, category, stage, untilDate);
            if (exploration.IsCompleted)
                return LogCompletionMessageAndReturn(exploration);

            foreach (ushort i in Enumerable.Range(DefaultInitialPageNumber, exploration.TotalEstimatedPages))
            {


            }

            return null;

        }


        // Methods (private)
        private void ConditionallySleep
            (ushort i, ushort parallelRequests, uint pauseBetweenRequestsMs)
        {

            // Do a pause of x each y requests
            // i != 0, because 0 % x = 0...
            if (i != 0 && i % parallelRequests == 0)
                Thread.Sleep((int)pauseBetweenRequestsMs);

        }
        private void LogInitializationMessage
            (string runId, ushort untilPageNumber, WIDCategories category, WIDStages stage)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationStarted);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RunIdIs(runId));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_NowIs(Now));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_DefaultInitialPageNumberIs(DefaultInitialPageNumber));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_UntilPageNumberIs(untilPageNumber));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_CategoryIs(category));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_StageIs(stage));

        }
        private void LogInitializationMessage
            (string runId, DateTime untilDate, WIDCategories category, WIDStages stage)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationStarted);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RunIdIs(runId));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_NowIs(Now));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_DefaultInitialPageNumberIs(DefaultInitialPageNumber));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_UntilDateIs(untilDate));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_CategoryIs(category));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_StageIs(stage));

        }
        private WIDExploration LogCompletionMessageAndReturn(WIDExploration exploration)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationCompleted);

            return exploration;

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
        private WIDExploration ProcessStage2
            (WIDExploration exploration, ushort untilPageNumber, WIDStages stage)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(stage));

            List<PageItem> stage2PageItems = _components.PageItemScraper.Do(exploration.Pages[0]);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemScrapedInitial(stage2PageItems));

            ushort stage2UntilPageNumber = untilPageNumber;
            if (stage2UntilPageNumber > exploration.TotalEstimatedPages)
            {

                _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FinalPageNumberIsHigher(stage2UntilPageNumber, exploration.TotalEstimatedPages));
                _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FinalPageNumberWillBeNow(exploration.TotalEstimatedPages));

                stage2UntilPageNumber = exploration.TotalEstimatedPages;

            }

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_AntiFloodingStrategy);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ParallelRequestsAre(_settings.ParallelRequests));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PauseBetweenRequestsIs(_settings.PauseBetweenRequestsMs));

            List<Page> stage2Pages = new List<Page>(exploration.Pages);
            for (ushort i = 2; i <= stage2UntilPageNumber; i++)
            {

                Page currentPage = _components.PageManager.GetPage(exploration.RunId, i, exploration.Category);
                List<PageItem> currentPageItems = _components.PageItemScraper.Do(currentPage);

                stage2Pages.Add(currentPage);
                stage2PageItems.AddRange(currentPageItems);

                _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemObjectsScraped(i, currentPageItems));

                ConditionallySleep(i, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemObjectsScrapedTotal(stage2PageItems));

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

            bool isCompleted =  true;

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

        private WIDExploration ProcessStage1WhenUntilDate
            (string runId, ushort initialPageNumber, WIDCategories category, WIDStages stage, DateTime untilDate)
        {

            WIDExploration exploration = ProcessStage1(runId, DefaultInitialPageNumber, category, stage);

            // Log message

            List<DateTime> createDates = _components.PageItemScraper.ExtractAndParseCreateDates(exploration.Pages[0].Content);
            bool isWithinRange = _components.PageItemScraper.IsWithinRange(untilDate, createDates);

            // Log message

            bool isCompleted = false;
            if (isWithinRange == true && stage == WIDStages.Stage1_OnlyMetrics)
                isCompleted = true;

            return
                new WIDExploration(
                        exploration.RunId,
                        exploration.TotalResults,
                        exploration.TotalEstimatedPages,
                        exploration.Category,
                        exploration.Stage,
                        isCompleted,
                        exploration.Pages);

        }

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.05.2021
*/