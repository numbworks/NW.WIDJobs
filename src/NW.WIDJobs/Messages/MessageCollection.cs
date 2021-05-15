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
        public static Func<string, string, string> Validator_DividingMustReturnWholeNumber { get; }
            = (variableName1, variableName2) => $"Dividing '{variableName1}' by '{variableName2}' must return a whole number.";
        public static Func<Dictionary<string, int>, string> Validator_AtLeastOneSubScraper { get; } =
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
    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 10.05.2021

*/