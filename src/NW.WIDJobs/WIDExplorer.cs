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
            _components.LoggingAction.Invoke($"RunId:'{runId}'.");
            _components.LoggingAction.Invoke($"InitialPageNumber:'{initialPageNumber}'.");
            _components.LoggingAction.Invoke($"FinalPageNumber:'{finalPageNumber}'.");
            _components.LoggingAction.Invoke($"Category:'{category}'.");
            _components.LoggingAction.Invoke($"ExplorationStage:'{stage}'.");
            _components.LoggingAction.Invoke($"The execution of the '{ExplorationStages.Stage1_TotalResults}' has been started.");

            string url = _components.PageManager.CreateUrl(initialPageNumber, category);
            _components.LoggingAction.Invoke($"Url has been created for the provided parameters");
            _components.LoggingAction.Invoke($"Url:'{url}'.");

            string content = _components.PageManager.GetContent(url);
            _components.LoggingAction.Invoke($"Content has been successfully retrieved for the provided url.");

            uint totalResults = _components.PageScraper.GetTotalResults(content);
            _components.LoggingAction.Invoke($"TotalResults:'{totalResults}'.");

            if (stage == ExplorationStages.Stage1_TotalResults)
                return CompleteExploration(runId, totalResults);

            _components.LoggingAction.Invoke($"The execution of the '{ExplorationStages.Stage2_TotalEstimatedPages}' has been started.");

            ushort totalEstimatedPages = _components.PageManager.GetTotalEstimatedPages(totalResults);
            _components.LoggingAction.Invoke($"TotalEstimatedPages:'{totalEstimatedPages}'.");

            if (stage == ExplorationStages.Stage2_TotalEstimatedPages)
                return CompleteExploration(runId, totalResults, totalEstimatedPages);

            _components.LoggingAction.Invoke($"The execution of the '{ExplorationStages.Stage3_Pages}' has been started.");

            Page initialPage = new Page(runId, initialPageNumber, content);
            List<Page> pages = new List<Page>() { initialPage };
            _components.LoggingAction.Invoke($"Initial '{nameof(Page)}' object has been created for the provided parameters.");

            if (finalPageNumber == 1 && stage == ExplorationStages.Stage3_Pages)
                return CompleteExploration(runId, totalResults, totalEstimatedPages, pages);

            _components.LoggingAction.Invoke($"The execution of the '{ExplorationStages.Stage4_PageItems}' has been started.");

            List<PageItem> pageItems = _components.PageItemScraper.Do(initialPage);
            _components.LoggingAction.Invoke($"'{pageItems.Count}' '{nameof(PageItem)}' objects have been scraped out of the initial page.");

            if (finalPageNumber == 1 && stage == ExplorationStages.Stage4_PageItems)
                return CompleteExploration(runId, totalResults, totalEstimatedPages, pages, pageItems);

            if (finalPageNumber > totalEstimatedPages)
            {

                _components.LoggingAction.Invoke($"'FinalPageNumber' ('{finalPageNumber}') is higher than 'TotalEstimatedPages' ('{totalEstimatedPages}').");
                _components.LoggingAction.Invoke($"'FinalPageNumber' will be now equal to '{totalEstimatedPages}'.");

                finalPageNumber = totalEstimatedPages;

            }

            _components.LoggingAction.Invoke("An anti-flooding strategy based on the provided settings is now in use.");
            _components.LoggingAction.Invoke($"{nameof(_settings.ParallelRequests)}:'{_settings.ParallelRequests}'.");
            _components.LoggingAction.Invoke($"{nameof(_settings.ParallelRequests)}:'{_settings.PauseBetweenRequestsMs}'.");

            for (ushort i = 2; i <= finalPageNumber; i++)
            {

                Page currentPage = _components.PageManager.GetPage(runId, i);
                List<PageItem> currentPageItems = _components.PageItemScraper.Do(currentPage);

                pages.Add(currentPage);
                pageItems.AddRange(currentPageItems);

                _components.LoggingAction.Invoke($"Page '{i}' - '{currentPageItems.Count}' '{nameof(PageItem)}' objects have been scraped.");

                ConditionallySleep(i, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }
            
            _components.LoggingAction.Invoke($"'{pageItems.Count}' '{nameof(PageItem)}' objects have been scraped in total.");

            if (stage == ExplorationStages.Stage4_PageItems)
                return CompleteExploration(runId, totalResults, totalEstimatedPages, pages, pageItems);

            _components.LoggingAction.Invoke($"The execution of the '{ExplorationStages.Stage5_PageItemsExtended}' has been started.");

            List<PageItemExtended> pageItemsExtended = new List<PageItemExtended>();
            foreach (PageItem pageItem in pageItems)
            {

                PageItemExtended current = _components.PageItemExtendedManager.Get(pageItem);
                pageItemsExtended.Add(current);

                _components.LoggingAction.Invoke($"Page '{pageItem.PageNumber}', PageItem '{pageItem.PageItemNumber}' - A '{nameof(PageItemExtended)}' object has been scraped.");

                ConditionallySleep(pageItem.PageItemNumber, _settings.ParallelRequests, _settings.PauseBetweenRequestsMs);

            }

            _components.LoggingAction.Invoke($"'{pageItemsExtended.Count}' '{nameof(PageItemExtended)}' objects have been scraped in total.");

            return CompleteExploration
                        (runId, totalResults, totalEstimatedPages, pages, pageItems, pageItemsExtended);

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

        public string Serialize(ExplorationResult explorationResult)
        {

            // Validation?

            ExplorationResult clean
                = new ExplorationResult(
                        explorationResult.RunId,
                        explorationResult.TotalResults,
                        explorationResult.TotalEstimatedPages,
                        explorationResult.Pages?.Select(page => new Page(page.RunId, page.PageNumber, "<skipped>")).ToList(),
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

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 16.05.2021
*/