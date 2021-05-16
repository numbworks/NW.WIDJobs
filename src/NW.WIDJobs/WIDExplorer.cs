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

            string url = _components.PageManager.CreateUrl(initialPageNumber, category);
            string content = _components.PageManager.GetContent(url);
            uint totalResults = _components.PageScraper.GetTotalResults(content);

            if (stage == ExplorationStages.Stage1_TotalResults)
                return new ExplorationResult(runId, totalResults);

            ushort totalExpectedPages = _components.PageManager.GetTotalEstimatedPages(totalResults);

            if (stage == ExplorationStages.Stage2_TotalEstimatedPages)
                return new ExplorationResult(runId, totalResults, totalExpectedPages);

            Page initialPage = new Page(runId, initialPageNumber, content);
            List<Page> pages = new List<Page>() { initialPage };            
            if (finalPageNumber == 1 && stage == ExplorationStages.Stage3_Pages)
                return new ExplorationResult(runId, totalResults, totalExpectedPages, pages);

            List<PageItem> pageItems = _components.PageItemScraper.Do(initialPage);
            if (finalPageNumber == 1 && stage == ExplorationStages.Stage4_PageItems)
                return new ExplorationResult(runId, totalResults, totalExpectedPages, pages, pageItems);

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
                return new ExplorationResult(runId, totalResults, totalExpectedPages, pages, pageItems);

            List<PageItemExtended> pageItemsExtended = new List<PageItemExtended>();
            foreach (PageItem pageItem in pageItems)
            {

                PageItemExtended current = _components.PageItemExtendedManager.Get(pageItem);
                pageItemsExtended.Add(current);

                ConditionallySleep(pageItem.PageItemNumber, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }

            return new ExplorationResult(runId, totalResults, totalExpectedPages, pages, pageItems, pageItemsExtended);

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

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 16.05.2021
*/