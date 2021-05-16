using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;

namespace NW.WIDJobs
{

    public class WIDExplorer
    {

        // Fields
        private WIDExplorerComponents _components;
        private WIDExplorerSettings _settings;

        // Properties
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
        public ExplorationResult Explore(
            string runId, ushort initialPageNumber, ushort finalPageNumber, Categories category, ExplorationStages stage)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfLessThanOne(initialPageNumber, nameof(initialPageNumber));
            Validator.ThrowIfLessThanOne(finalPageNumber, nameof(finalPageNumber));

            _components.LoggingAction.Invoke("Exploration started...");
            _components.LoggingAction.Invoke($"{nameof(runId)}:'{runId}'.");
            _components.LoggingAction.Invoke($"{nameof(initialPageNumber)}:'{initialPageNumber}'.");
            _components.LoggingAction.Invoke($"{nameof(finalPageNumber)}:'{finalPageNumber}'.");
            _components.LoggingAction.Invoke($"{nameof(category)}:'{category}'.");
            _components.LoggingAction.Invoke($"{nameof(stage)}:'{stage}'.");

            string url = _components.PageManager.CreateUrl(initialPageNumber, category);
            _components.LoggingAction.Invoke($"Url has been created for the provided parameters ('{url}').");

            string content = _components.PageManager.GetContent(url);
            _components.LoggingAction.Invoke($"Content has been successfully retrieved for url:'{url}'.");

            uint totalResults = _components.PageScraper.GetTotalResults(content);
            _components.LoggingAction.Invoke($"{nameof(totalResults)}:'{totalResults}'.");

            if (stage == ExplorationStages.Stage1_TotalResults)
                LogAndReturn(new ExplorationResult(runId, totalResults));

            ushort totalExpectedPages = _components.PageManager.GetTotalEstimatedPages(totalResults);
            _components.LoggingAction.Invoke($"{nameof(totalExpectedPages)}:'{totalExpectedPages}'.");

            if (stage == ExplorationStages.Stage2_TotalEstimatedPages)
                LogAndReturn(
                    new ExplorationResult(runId, totalResults, totalExpectedPages));

            Page initialPage = new Page(runId, initialPageNumber, content);
            List<Page> pages = new List<Page>() { initialPage };
            _components.LoggingAction.Invoke($"Initial '{nameof(Page)}' object has been created for the provided parameters.");

            if (finalPageNumber == 1 && stage == ExplorationStages.Stage3_Pages)
                LogAndReturn(
                    new ExplorationResult(runId, totalResults, totalExpectedPages, pages));

            List<PageItem> pageItems = _components.PageItemScraper.Do(initialPage);
            if (finalPageNumber == 1 && stage == ExplorationStages.Stage4_PageItems)
                LogAndReturn(
                    new ExplorationResult(runId, totalResults, totalExpectedPages, pages, pageItems));

            if (finalPageNumber > totalExpectedPages)
                finalPageNumber = totalExpectedPages;

            for (ushort i = 2; i <= finalPageNumber; i++)
            {

                Page currentPage = _components.PageManager.GetPage(runId, i);
                List<PageItem> currentPageItems = _components.PageItemScraper.Do(currentPage);

                pages.Add(currentPage);
                pageItems.AddRange(currentPageItems);

                ConditionallySleep(i, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }
            if (stage == ExplorationStages.Stage4_PageItems)
                LogAndReturn(
                    new ExplorationResult(runId, totalResults, totalExpectedPages, pages, pageItems));

            List<PageItemExtended> pageItemsExtended = new List<PageItemExtended>();
            foreach (PageItem pageItem in pageItems)
            {

                PageItemExtended current = _components.PageItemExtendedManager.Get(pageItem);
                pageItemsExtended.Add(current);

                ConditionallySleep(pageItem.PageItemNumber, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }

            return LogAndReturn(
                    new ExplorationResult
                        (runId, totalResults, totalExpectedPages, pages, pageItems, pageItemsExtended));

        }
        public ExplorationResult Explore(
            DateTime now, ushort initialPageNumber, ushort finalPageNumber, Categories category, ExplorationStages stage)
        {

            string runId = _components.RunIdManager.Create(now, initialPageNumber, finalPageNumber);

            return Explore(runId, initialPageNumber, finalPageNumber, category, stage);

        }
        public ExplorationResult Explore(
            ushort initialPageNumber, ushort finalPageNumber, Categories category, ExplorationStages stage)
                => Explore(DateTime.Now, initialPageNumber, finalPageNumber, category, stage);

        // Methods (private)
        private void ConditionallySleep
            (ushort i, ushort parallelRequests, uint pauseBetweenRequestsMs)
        {

            // Do a pause of x each y requests
            // i != 0, because 0 % x = 0...
            if (i != 0 && i % parallelRequests == 0)
                Thread.Sleep((int)pauseBetweenRequestsMs);

        }
        private ExplorationResult LogAndReturn(ExplorationResult explorationAndResult)
        {

            _components.LoggingAction.Invoke($"Exploration has been completed.");

            return explorationAndResult;

        }

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 16.05.2021
*/