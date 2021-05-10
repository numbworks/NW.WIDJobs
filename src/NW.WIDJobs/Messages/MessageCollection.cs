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

        // PageItemScraper
        public static Func<List<string>, List<string>, List<DateTime>, List<DateTime?>, List<string>, List<string>, List<string>, List<ulong>, string>
            PageItemScraper_AtLeastOneSubScraper =
                (urls, titles, createDates, applicationDates, workAreas, workingHours, jobTypes, jobIds)
                    => {

                        return string.Concat(
                                "At least one sub-scraper didn't return the expected amount of results (",
                                $"'{nameof(urls)}':'{urls.Count}', ",
                                $"'{nameof(titles)}':'{titles.Count}', ",
                                $"'{nameof(createDates)}':'{createDates.Count}', ",
                                $"'{nameof(applicationDates)}':'{applicationDates.Count}', ",
                                $"'{nameof(workAreas)}':'{workAreas.Count}', ",
                                $"'{nameof(workingHours)}':'{workingHours.Count}', ",
                                $"'{nameof(jobTypes)}':'{jobTypes.Count}', ",
                                $"'{nameof(jobIds)}':'{jobIds.Count}'",
                                $")."
                                );

                    };

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 10.05.2021

*/