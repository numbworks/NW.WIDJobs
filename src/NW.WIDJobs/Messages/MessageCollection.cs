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

        // PageItemScraper
        public static Func<string, string, string> PageItemScraper_NotPossibleToExtractJobId =
            (url, pattern) => $"Not possible to extract {nameof(PageItem.JobId)} from '{url}' with pattern: '{pattern}'.";

        // WIDExplorer
        public static string WIDExplorer_ExplorationStarted = "Exploration started...";
        public static Func<string, string> WIDExplorer_RunIdIs 
            = (runId) => $"RunId:'{runId}'.";
        public static Func<ushort, string> WIDExplorer_InitialPageNumberIs
            = (initialPageNumber) => $"InitialPageNumber:'{initialPageNumber}'.";
        public static Func<ushort, string> WIDExplorer_FinalPageNumberIs
            = (finalPageNumber) => $"FinalPageNumber:'{finalPageNumber}'.";
        public static Func<Categories, string> WIDExplorer_CategoryIs
            = (category) => $"Category:'{category}'.";
        public static Func<ExplorationStages, string> WIDExplorer_ExplorationStageIs
            = (stage) => $"ExplorationStage:'{stage}'.";
        public static Func<ExplorationStages, string> WIDExplorer_ExecutionStageStarted
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

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 18.05.2021

*/