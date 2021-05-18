﻿using System;
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
        public static string NotSerialized { get; } = "<not_serialized>";

        // Constructors
        public WIDExplorer
            (WIDExplorerComponents components, WIDExplorerSettings settings)
        {

            Validator.ValidateObject(components, nameof(components));
            Validator.ValidateObject(settings, nameof(settings));

            _components = components;
            _settings = settings;

        }
        public WIDExplorer()
            : this(new WIDExplorerComponents(), new WIDExplorerSettings()) { }

        // Methods (public)
        public ExplorationResult Explore
            (string runId, ushort initialPageNumber, ushort finalPageNumber, Categories category, ExplorationStages stage)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfLessThanOne(initialPageNumber, nameof(initialPageNumber));
            Validator.ThrowIfLessThanOne(finalPageNumber, nameof(finalPageNumber));

            (string content, uint totalResults) stage1 =
                ProcessStage1(runId, initialPageNumber, finalPageNumber, category, stage);
            if (stage == ExplorationStages.Stage1_TotalResults)
                return CompleteExploration(runId, stage1.totalResults);

            ushort stage2TotalEstimatedPages = ProcessStage2(stage1.totalResults);
            if (stage == ExplorationStages.Stage2_TotalEstimatedPages)
                return CompleteExploration(runId, stage1.totalResults, stage2TotalEstimatedPages);

            List<Page> stage3Pages = ProcessStage3(runId, initialPageNumber, stage1.content, stage1.totalResults);
            if (finalPageNumber == 1 && stage == ExplorationStages.Stage3_Pages)
                return CompleteExploration(runId, stage1.totalResults, stage2TotalEstimatedPages, stage3Pages);

            List<PageItem> stage4aPageItems = ProcessStage4A(stage3Pages);
            if (finalPageNumber == 1 && stage == ExplorationStages.Stage4_PageItems)
                return CompleteExploration(runId, stage1.totalResults, stage2TotalEstimatedPages, stage3Pages, stage4aPageItems);

            (ushort finalPageNumber, List<Page> pages, List<PageItem> pageItems) stage4B
                = ProcessStage4B(runId, finalPageNumber, stage2TotalEstimatedPages, stage3Pages, stage4aPageItems);
            if (stage == ExplorationStages.Stage4_PageItems)
                return CompleteExploration(runId, stage1.totalResults, stage2TotalEstimatedPages, stage3Pages, stage4B.pageItems);

            List<PageItemExtended> stage5PageItemsExtended = ProcessStage5(stage4B.pageItems);

            return CompleteExploration
                (runId, stage1.totalResults, stage2TotalEstimatedPages, stage4B.pages, stage4B.pageItems, stage5PageItemsExtended);

        }
        public ExplorationResult Explore
            (DateTime now, ushort initialPageNumber, ushort finalPageNumber, Categories category, ExplorationStages stage)
        {

            string runId = _components.RunIdManager.Create(now, initialPageNumber, finalPageNumber);

            return Explore(runId, initialPageNumber, finalPageNumber, category, stage);

        }
        public ExplorationResult Explore(
            ushort initialPageNumber, ushort finalPageNumber, Categories category, ExplorationStages stage)
                => Explore(DateTime.Now, initialPageNumber, finalPageNumber, category, stage);

        public string ToJson(ExplorationResult explorationResult)
        {

            Validator.ValidateObject(explorationResult, nameof(explorationResult));

            ExplorationResult clean
                = new ExplorationResult(
                        explorationResult.RunId,
                        explorationResult.TotalResults,
                        explorationResult.TotalEstimatedPages,
                        explorationResult.Pages?.Select(page => new Page(page.RunId, page.PageNumber, NotSerialized)).ToList(),
                        explorationResult.PageItems,
                        explorationResult.PageItemsExtended
                        );

            JsonSerializerOptions jso = new JsonSerializerOptions();
            jso.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            return JsonSerializer.Serialize(clean, jso);

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
        private ExplorationResult CompleteExploration(
            string runId, 
            uint totalResults, 
            ushort? totalEstimatedPages = null,
            List<Page> pages = null, 
            List<PageItem> pageItems = null, 
            List<PageItemExtended> pageItemsExtended = null)
        {

            _components.LoggingAction.Invoke($"Exploration has been completed.");

            return new ExplorationResult
                        (runId, totalResults, totalEstimatedPages, pages, pageItems, pageItemsExtended);

        }

        private (string content, uint totalResults) ProcessStage1
            (string runId, ushort initialPageNumber, ushort finalPageNumber, Categories category, ExplorationStages stage)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationStarted);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_RunIdIs(runId));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_InitialPageNumberIs(initialPageNumber));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_FinalPageNumberIs(finalPageNumber));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_CategoryIs(category));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExplorationStageIs(stage));
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(stage));

            string url = _components.PageManager.CreateUrl(initialPageNumber, category);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_UrlCreated);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_UrlIs(url));

            string content = _components.PageManager.GetContent(url);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ContentSuccessfullyRetrieved);

            uint totalResults = _components.PageScraper.GetTotalResults(content);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_TotalResultsAre(totalResults));

            return (content, totalResults);

        }
        private ushort ProcessStage2
            (uint totalResults)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(ExplorationStages.Stage2_TotalEstimatedPages));

            ushort totalEstimatedPages = _components.PageManager.GetTotalEstimatedPages(totalResults);
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_TotalEstimatedPagesAre(totalEstimatedPages));

            return totalEstimatedPages;

        }
        private List<Page> ProcessStage3
            (string runId, ushort initialPageNumber, string content, uint totalResults)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(ExplorationStages.Stage3_Pages));

            Page initialPage = new Page(runId, initialPageNumber, content);
            List<Page> pages = new List<Page>() { initialPage };
            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_InitialPageCreated);

            return pages;

        }
        private List<PageItem> ProcessStage4A
            (List<Page> pages)
        {

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(ExplorationStages.Stage4_PageItems));

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

            _components.LoggingAction.Invoke(MessageCollection.WIDExplorer_ExecutionStageStarted(ExplorationStages.Stage5_PageItemsExtended));

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

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 18.05.2021
*/