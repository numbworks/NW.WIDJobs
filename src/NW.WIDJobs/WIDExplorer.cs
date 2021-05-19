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
        public WIDResult Explore
            (string runId, ushort untilPageNumber, WIDCategories category, WIDStages stage)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfLessThanOne(untilPageNumber, nameof(untilPageNumber));

            LogInitialization(runId, DefaultInitialPageNumber, untilPageNumber, category, stage);

            (string content, uint totalResults) stage1 = ProcessStage1Category(DefaultInitialPageNumber, category);
            if (stage == WIDStages.Stage1_TotalResults)
                return CompleteExploration(runId, stage1.totalResults);

            ushort stage2TotalEstimatedPages = ProcessStage2(stage1.totalResults);
            if (stage == WIDStages.Stage2_TotalEstimatedPages)
                return CompleteExploration(runId, stage1.totalResults, stage2TotalEstimatedPages);

            List<Page> stage3Pages = ProcessStage3(runId, DefaultInitialPageNumber, stage1.content);
            if (untilPageNumber == 1 && stage == WIDStages.Stage3_Pages)
                return CompleteExploration(runId, stage1.totalResults, stage2TotalEstimatedPages, stage3Pages);

            List<PageItem> stage4aPageItems = ProcessStage4A(stage3Pages);
            if (untilPageNumber == 1 && stage == WIDStages.Stage4_PageItems)
                return CompleteExploration(runId, stage1.totalResults, stage2TotalEstimatedPages, stage3Pages, stage4aPageItems);

            (ushort finalPageNumber, List<Page> pages, List<PageItem> pageItems) stage4B
                = ProcessStage4B(runId, untilPageNumber, stage2TotalEstimatedPages, stage3Pages, stage4aPageItems);
            if (stage == WIDStages.Stage4_PageItems)
                return CompleteExploration(runId, stage1.totalResults, stage2TotalEstimatedPages, stage3Pages, stage4B.pageItems);

            List<PageItemExtended> stage5PageItemsExtended = ProcessStage5(stage4B.pageItems);

            return CompleteExploration
                (runId, stage1.totalResults, stage2TotalEstimatedPages, stage4B.pages, stage4B.pageItems, stage5PageItemsExtended);

        }
        public WIDResult Explore
            (ushort untilPageNumber, WIDCategories category, WIDStages stage)
        {

            ushort initialPageNumber = 1;
            string runId = _components.RunIdManager.Create(Now, initialPageNumber, untilPageNumber);

            return Explore(runId, untilPageNumber, category, stage);

        }

        public WIDResult Explore
            (string runId, DateTime untilDate, WIDCategories category, WIDStages stage)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            // Date validation

            ushort initialPageNumber = 1;
            // LogInitialization(runId, initialPageNumber, untilPageNumber, category, stage);

            (string content, uint totalResults) stage1 = ProcessStage1Category(initialPageNumber, category);
            ushort stage2TotalEstimatedPages = ProcessStage2(stage1.totalResults);
            List<Page> stage3Pages = ProcessStage3(runId, initialPageNumber, stage1.content);
            List<PageItem> stage4aPageItems = ProcessStage4A(stage3Pages);

            // check CreateDate < untilDate Condition
            // ... 

            return null;

        }
        public WIDResult Explore
            (DateTime untilDate, WIDCategories category, WIDStages stage)
        {

            string runId = _components.RunIdManager.Create(Now, untilDate);

            return Explore(runId, untilDate, category, stage);

        }

        public string ToJson(WIDResult result)
        {

            Validator.ValidateObject(result, nameof(result));

            WIDResult clean
                = new WIDResult(
                        result.RunId,
                        result.TotalResults,
                        result.TotalEstimatedPages,
                        result.Pages?.Select(page => new Page(page.RunId, page.PageNumber, DefaultNotSerialized)).ToList(),
                        result.PageItems,
                        result.PageItemsExtended
                        );

            JsonSerializerOptions jso = new JsonSerializerOptions();
            jso.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            return JsonSerializer.Serialize(clean, jso);

        }

        // Methods (private)
        private void LogInitialization
            (string runId, ushort initialPageNumber, ushort untilPageNumber, WIDCategories category, WIDStages stage)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationStarted);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RunIdIs(runId));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_InitialPageNumberIs(initialPageNumber));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_UntilPageNumberIs(untilPageNumber));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_CategoryIs(category));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationStageIs(stage));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(stage));

        }
        private (string content, uint totalResults) ProcessStage1Category
            (ushort initialPageNumber, WIDCategories category)
        {

            string url = _components.PageManager.CreateUrl(initialPageNumber, category);

            return ProcessStage1(url);

        }
        private (string content, uint totalResults) ProcessStage1All
            (ushort initialPageNumber)
        {

            string url = _components.PageManager.CreateUrl(initialPageNumber);

            return ProcessStage1(url);

        }
        private ushort ProcessStage2
            (uint totalResults)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(WIDStages.Stage2_TotalEstimatedPages));

            ushort totalEstimatedPages = _components.PageManager.GetTotalEstimatedPages(totalResults);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_TotalEstimatedPagesAre(totalEstimatedPages));

            return totalEstimatedPages;

        }
        private List<Page> ProcessStage3
            (string runId, ushort initialPageNumber, string content)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(WIDStages.Stage3_Pages));

            Page initialPage = new Page(runId, initialPageNumber, content);
            List<Page> pages = new List<Page>() { initialPage };
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_InitialPageCreated);

            return pages;

        }
        private List<PageItem> ProcessStage4A
            (List<Page> pages)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(WIDStages.Stage4_PageItems));

            List<PageItem> pageItems = _components.PageItemScraper.Do(pages[0]);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemScrapedInitial(pageItems));

            return pageItems;

        }
        private (ushort finalPageNumber, List<Page> pages, List<PageItem> pageItems) ProcessStage4B
            (string runId, ushort finalPageNumber, ushort totalEstimatedPages, List<Page> pages, List<PageItem> pageItems)
        {

            ushort stage4bFinalPageNumber = finalPageNumber;
            if (stage4bFinalPageNumber > totalEstimatedPages)
            {

                _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FinalPageNumberIsHigher(stage4bFinalPageNumber, totalEstimatedPages));
                _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FinalPageNumberWillBeNow(totalEstimatedPages));

                stage4bFinalPageNumber = totalEstimatedPages;

            }

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_AntiFloodingStrategy);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ParallelRequestsAre(_settings.ParallelRequests));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PauseBetweenRequestsIs(_settings.PauseBetweenRequestsMs));

            List<Page> stage4bPages = new List<Page>(pages);
            List<PageItem> stage4bPageItems = new List<PageItem>(pageItems);
            for (ushort i = 2; i <= stage4bFinalPageNumber; i++)
            {

                Page currentPage = _components.PageManager.GetPage(runId, i);
                List<PageItem> currentPageItems = _components.PageItemScraper.Do(currentPage);

                stage4bPages.Add(currentPage);
                stage4bPageItems.AddRange(currentPageItems);

                _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemObjectsScraped(i, currentPageItems));

                ConditionallySleep(i, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemObjectsScrapedTotal(stage4bPageItems));

            return (stage4bFinalPageNumber, stage4bPages, stage4bPageItems);

        }
        private List<PageItemExtended> ProcessStage5
            (List<PageItem> pageItems)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(WIDStages.Stage5_PageItemsExtended));

            List<PageItemExtended> pageItemsExtended = new List<PageItemExtended>();
            foreach (PageItem pageItem in pageItems)
            {

                PageItemExtended current = _components.PageItemExtendedManager.Get(pageItem);
                pageItemsExtended.Add(current);

                _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemExtendedScraped(pageItem));

                ConditionallySleep(pageItem.PageItemNumber, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_PageItemExtendedScrapedTotal(pageItemsExtended));
            
            return pageItemsExtended;
        
        }

        private void ConditionallySleep
            (ushort i, ushort parallelRequests, uint pauseBetweenRequestsMs)
        {

            // Do a pause of x each y requests
            // i != 0, because 0 % x = 0...
            if (i != 0 && i % parallelRequests == 0)
                Thread.Sleep((int)pauseBetweenRequestsMs);

        }
        private (string content, uint totalResults) ProcessStage1(string url)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_UrlCreated);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_UrlIs(url));

            string content = _components.PageManager.GetContent(url);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ContentSuccessfullyRetrieved);

            uint totalResults = _components.PageScraper.GetTotalResults(content);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_TotalResultsAre(totalResults));

            return (content, totalResults);

        }
        private WIDResult CompleteExploration(
            string runId,
            uint totalResults,
            ushort? totalEstimatedPages = null,
            List<Page> pages = null,
            List<PageItem> pageItems = null,
            List<PageItemExtended> pageItemsExtended = null)
        {

            _components.LoggingAction.Invoke($"Exploration has been completed.");

            return new WIDResult
                    (runId, totalResults, totalEstimatedPages, pages, pageItems, pageItemsExtended);

        }

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 18.05.2021
*/