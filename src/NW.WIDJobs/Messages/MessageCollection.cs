using System;
using System.Collections.Generic;
using System.Linq;

namespace NW.WIDJobs
{
    public static class MessageCollection
    {

        private static string RollOutCollection(List<double> coll)
            => RollOutCollection(coll.Cast<object>().ToList());
        private static string RollOutCollection(IEnumerable<object> coll)
        {

            List<string> list = new List<string>();

            foreach (object obj in coll)
                list.Add(obj.ToString());

            return $"[{string.Join(", ", list)}]";

        }

        // Validator
        public static Func<string, string, string> Validator_FirstValueIsGreaterOrEqualThanSecondValue
            = (variableName1, variableName2) => $"The '{variableName1}''s value is greater or equal than '{variableName2}''s value.";
        public static Func<string, string, string> Validator_FirstValueIsGreaterThanSecondValue
            = (variableName1, variableName2) => $"The '{variableName1}''s value is greater than '{variableName2}''s value.";
        public static Func<string, string> Validator_VariableContainsZeroItems
            = (variableName) => $"'{variableName}' contains zero items.";
        public static Func<string, string> Validator_VariableCantBeLessThanOne
            = (variableName) => $"'{variableName}' can't be less than one.";
        public static Func<string, string, string> Validator_DividingMustReturnWholeNumber 
            = (variableName1, variableName2) => $"Dividing '{variableName1}' by '{variableName2}' must return a whole number.";
        public static Func<Dictionary<string, int>, string> Validator_AtLeastOneSubScraper =
                (subscrapers)
                    => {

                        /*
                            At least one sub-scraper didn't return the expected amount of results 
                            ('urls':'20','titles':'20','createDates':'20','applicationDates':'20','workAreas':'20',
                            'workAreasWithoutZones':'20','workingHours':'20','jobTypes':'20','jobIds':'20').
                        */

                        List<string> results = subscrapers.Select(item => $"'{item.Key}':'{item.Value}'").ToList();
                        string joined = string.Join(",", results);

                        return string.Concat(
                                "At least one sub-scraper didn't return the expected amount of results (",
                                joined,
                                ")."
                                );

                    };
        public static Func<string, string, string> Validator_FirstDateIsOlderOrEqual
            = (variableName1, variableName2) => $"'{variableName1}''s is older or equal than '{variableName2}'.";

        // PageItemScraper
        public static Func<string, string, string> PageItemScraper_NotPossibleToExtractJobId =
            (url, pattern) => $"Not possible to extract {nameof(PageItem.JobId)} from '{url}' with pattern: '{pattern}'.";

        // WIDExplorer
        public static string WIDExplorer_ExplorationStarted = "The exploration has started...";
        public static Func<string, string> WIDExplorer_RunIdIs 
            = (runId) => $"RunId:'{runId}'.";
        public static Func<ushort, string> WIDExplorer_InitialPageNumberIs
            = (initialPageNumber) => $"InitialPageNumber:'{initialPageNumber}'.";
        public static Func<ushort, string> WIDExplorer_UntilPageNumberIs
            = (finalPageNumber) => $"UntilPageNumber:'{finalPageNumber}'.";
        public static Func<WIDCategories, string> WIDExplorer_CategoryIs
            = (category) => $"Category:'{category}'.";
        public static Func<WIDStages, string> WIDExplorer_ExplorationStageIs
            = (stage) => $"ExplorationStage:'{stage}'.";
        public static Func<WIDStages, string> WIDExplorer_ExecutionStageStarted
            = (stage) => $"The execution of the '{stage}' has been started.";
        public static string WIDExplorer_UrlCreated = "Url has been created for the provided parameters.";
        public static Func<string, string> WIDExplorer_UrlIs
            = (url) => $"Url:'{url}'.";
        public static string WIDExplorer_ContentSuccessfullyRetrieved
            = "Content has been successfully retrieved for the provided url.";
        public static Func<uint, string> WIDExplorer_TotalResultsAre
            = (totalResults) => $"TotalResults:'{totalResults}'.";
        public static Func<ushort, string> WIDExplorer_TotalEstimatedPagesAre
            = (totalEstimatedPages) => $"TotalEstimatedPages:'{totalEstimatedPages}'.";
        public static Func<List<PageItem>, string> WIDExplorer_PageItemScrapedInitial
            = (pageItems) => $"'{pageItems.Count}' '{nameof(PageItem)}' objects have been scraped out of the initial page.";
        public static Func<ushort, ushort, string> WIDExplorer_FinalPageNumberIsHigher
            = (finalPageNumber, totalEstimatedPages) => $"'FinalPageNumber' ('{finalPageNumber}') is higher than 'TotalEstimatedPages' ('{totalEstimatedPages}').";
        public static Func<ushort, string> WIDExplorer_FinalPageNumberWillBeNow
            = (totalEstimatedPages) => $"'FinalPageNumber' will be now equal to '{totalEstimatedPages}'.";
        public static string WIDExplorer_AntiFloodingStrategy
            = "An anti-flooding strategy based on the provided settings is now in use.";
        public static Func<ushort, string> WIDExplorer_ParallelRequestsAre
            = (parallelRequests) => $"ParallelRequests:'{parallelRequests}'.";
        public static Func<uint, string> WIDExplorer_PauseBetweenRequestsIs
            = (pauseBetweenRequestsMs) => $"PauseBetweenRequestsMs:'{pauseBetweenRequestsMs}'.";
        public static Func<ushort, List<PageItem>, string> WIDExplorer_PageItemObjectsScraped
            = (i, currentPageItems) => $"Page '{i}' - '{currentPageItems.Count}' '{nameof(PageItem)}' objects have been scraped.";
        public static Func<List<PageItem>, string> WIDExplorer_PageItemObjectsScrapedTotal
            = (stage4bPageItems) => $"'{stage4bPageItems.Count}' '{nameof(PageItem)}' objects have been scraped in total.";
        public static Func<PageItem, string> WIDExplorer_PageItemExtendedScraped
            = (pageItem) => $"Page '{pageItem.PageNumber}', PageItem '{pageItem.PageItemNumber}' - A '{nameof(PageItemExtended)}' object has been scraped.";
        public static Func<List<PageItemExtended>, string> WIDExplorer_PageItemExtendedScrapedTotal
            = (pageItemsExtended) => $"'{pageItemsExtended.Count}' '{nameof(PageItemExtended)}' objects have been scraped in total.";
        public static string WIDExplorer_ExplorationCompleted
            = "The exploration has been completed.";


    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 18.05.2021

*/