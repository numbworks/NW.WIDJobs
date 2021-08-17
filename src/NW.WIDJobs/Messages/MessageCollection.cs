using System;
using System.Collections.Generic;
using System.Linq;
using NW.WIDJobs.BulletPoints;
using NW.WIDJobs.Explorations;

namespace NW.WIDJobs
{
    ///<summary>Collects all the messages used for logging and exceptions.</summary>
    public static class MessageCollection
    {

        #region Validator
        
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
        public static Func<IFileInfoAdapter, string> Validator_ProvidedPathDoesntExist
            = (file) => $"The provided path doesn't exist: '{file.FullName}'.";

        #endregion

        #region WIDExplorer

        public static string WIDExplorer_ExplorationStarted = "The exploration has started...";
        public static Func<string, string> WIDExplorer_RunIdIs 
            = (runId) => $"RunId:'{runId}'.";
        public static Func<ushort, string> WIDExplorer_DefaultInitialPageNumberIs
            = (defaultInitialPageNumber) => $"DefaultInitialPageNumber:'{defaultInitialPageNumber}'.";
        public static Func<ushort, string> WIDExplorer_FinalPageNumberIs
            = (finalPageNumber) => $"FinalPageNumber:'{finalPageNumber}'.";
        public static string WIDExplorer_FinalPageNumberIsLastPage
            = "FinalPageNumber: The last available page on the website.";
        public static Func<DateTime, string> WIDExplorer_ThresholdDateIs
            = (thresholdDate) => $"ThresholdDate:'{thresholdDate.ToString(WIDExplorer.DefaultFormatDate)}'.";
        public static Func<Stages, string> WIDExplorer_StageIs
            = (stage) => $"Stage:'{stage}'.";
        public static Func<Stages, string> WIDExplorer_ExecutionStageStarted
            = (stage) => $"The execution of the '{stage}' has been started.";
        public static string WIDExplorer_ContentSuccessfullyRetrieved
            = "Content has been successfully retrieved for the provided url.";
        public static Func<uint, string> WIDExplorer_TotalResultCountIs
            = (totalResultCount) => $"TotalResultCount:'{totalResultCount}'.";
        public static Func<ushort, string> WIDExplorer_TotalJobPagesIs
            = (totalJobPages) => $"TotalJobPages:'{totalJobPages}'.";
        public static Func<List<JobPosting>, string> WIDExplorer_JobPostingScrapedInitial
            = (jobPostings) => $"'{jobPostings.Count}' '{nameof(JobPosting)}' objects have been scraped out of the initial page.";
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
        public static Func<ushort, List<JobPosting>, string> WIDExplorer_JobPostingObjectsScraped
            = (i, currentJobPostings) => $"Page '{i}' - '{currentJobPostings.Count}' '{nameof(JobPosting)}' objects have been scraped.";
        public static Func<List<JobPosting>, string> WIDExplorer_JobPostingObjectsScrapedTotal
            = (jobPostings) => $"'{jobPostings.Count}' '{nameof(JobPosting)}' objects have been scraped in total.";
        public static Func<JobPosting, string> WIDExplorer_JobPostingExtendedScraped
            = (jobPosting) => $"JobPage '{jobPosting.PageNumber}', PageItem '{jobPosting.JobPostingNumber}' - A '{nameof(JobPostingExtended)}' object has been scraped.";
        public static Func<List<JobPostingExtended>, string> WIDExplorer_JobPostingExtendedScrapedTotal
            = (jobPostingExtended) => $"'{jobPostingExtended.Count}' '{nameof(JobPostingExtended)}' objects have been scraped in total.";
        public static string WIDExplorer_ExplorationCompleted
            = "The exploration has been completed.";
        public static Func<DateTime, ushort, string> WIDExplorer_ThresholdDateFoundPageNr 
            = (thresholdDate, i) => $"'{thresholdDate}' has been found in page nr. '{i}'.";
        public static Func<List<JobPosting>, ushort, string> WIDExplorer_XJobPostingsRemovedPageNr
            = (jobPostings, i) => $"'{20 - jobPostings.Count}' has been removed from page nr. '{i}'.";
        public static Func<ushort, string> WIDExplorer_FinalPageNumberThresholdDate
            = (finalPageNumber) => $"The 'FinalPageNumber' for the provided 'ThresholdDate' is '{finalPageNumber}'.";

        public static string WIDExplorer_ExtractJobPostingsFromJson
            = $"Extracting {nameof(JobPosting)} objects from the provided Json file...";
        public static Func<List<JobPosting>, string> WIDExplorer_JobPostingsExtractedFromJson
            = (jobPostings) => $"'{jobPostings.Count}' {nameof(JobPosting)} objects have been successfully extracted from the provided Json file.";
        public static string WIDExplorer_SomeDefaultValuesUsedFromHTML
            = $"Some default values need to be used in order to perform this extraction directly out of a HTML file.";

        public static Func<IFileInfoAdapter, string> WIDExplorer_HTMLFileIs
            = (htmlFile) => $"HTMLFile: '{htmlFile}'.";
        public static Func<ushort, string> WIDExplorer_PageNumberIs
            = (pageNumber) => $"PageNumber:'{pageNumber}'.";
        public static Func<ushort, string> WIDExplorer_JobPostingNumberIs
            = (jobPostingNumber) => $"PageItemNumber:'{jobPostingNumber}'.";
        public static Func<JobPostingExtended, string> WIDExplorer_JobPostingExtendedIs
            = (jobPostingExtended) => $"PageItemExtended:'{jobPostingExtended}'.";

        public static string WIDExplorer_SavingJobPostingsExtendedAsSQLite
            =  $"Saving the provided {nameof(JobPostingExtended)} objects as SQLite database...";
        public static Func<List<JobPostingExtended>, string> WIDExplorer_JobPostingsExtendedAre
            = (jobPostingsExtended) => $"PJobPostingsExtended: '{jobPostingsExtended.Count}'.";
        public static Func<string, string> WIDExplorer_DatabaseFileIs
            = (databaseFile) => $"DatabaseFile: '{databaseFile}'.";
        public static Func<bool, string> WIDExplorer_DeleteAndRecreateDatabaseIs
            = (deleteAndRecreateDatabase) => $"DeleteAndRecreateDatabase: '{deleteAndRecreateDatabase}'.";
        public static Func<int, string> WIDExplorer_AffectedRowsAre
            = (affectedRows) => $"AffectedRows: '{affectedRows}'.";
        public static string WIDExplorer_ExplorationSavedAsSQLite
            = $"The provided {nameof(JobPostingExtended)} objects have been successfully saved as SQLite database.";

        public static string WIDExplorer_SavingExplorationAsJson
            = $"Saving the provided {nameof(Exploration)} object as JSON file...";
        public static Func<IFileInfoAdapter, string> WIDExplorer_JSONFileIs
            = (jsonFile) => $"JSONFile: '{jsonFile}'.";
        public static string WIDExplorer_ExplorationSavedAsJson
            = $"The provided {nameof(Exploration)} object has been successfully saved as JSON file.";

        public static string WIDExplorer_SavingMetricCollectionAsJson
            = $"Saving the provided {nameof(MetricCollection)} object as JSON file...";
        public static Func<bool, string> WIDExplorer_NumbersAsPercentagesIs
            = (numbersAsPercentages) => $"NumbersAsPercentages: '{numbersAsPercentages}'.";
        public static string WIDExplorer_MetricCollectionSavedAsJson
            = $"The provided {nameof(MetricCollection)} object has been successfully saved as JSON file.";

        public static Func<string, string> WIDExplorer_MethodCalledWithoutIFileInfoAdapter
            = (methodName) => $"'{methodName}' has been called without providing a '{nameof(IFileInfoAdapter)}' parameter.";
        public static string WIDExplorer_DefaultValuesCreateIFileInfoAdapter
            = $"Before proceeding, default values will be used to create a '{nameof(IFileInfoAdapter)}' object.";
        public static Func<string, string> WIDExplorer_FolderPathIs
            = (folderPath) => $"FolderPath: '{folderPath}'.";
        public static Func<DateTime, string> WIDExplorer_NowIs
            = (now) => $"Now:'{now.ToString(WIDExplorer.DefaultFormatDate)}'.";

        public static string WIDExplorer_ConvertingExplorationToMetrics
            = $"Converting the provided {nameof(Exploration)} object to a {nameof(MetricCollection)} object...";  
        public static string WIDExplorer_ExplorationConvertedToMetrics
            = $"The provided {nameof(Exploration)} object has been successfully converted to a {nameof(MetricCollection)} object.";

        public static string WIDExplorer_ConvertingExplorationToJsonString
            = $"Converting the provided {nameof(Exploration)} object to a JSON string...";
        public static Func<string, string> WIDExplorer_SerializationOptionIs
            = (serializationOption) => $"SerializationOption: '{serializationOption}'.";
        public static string WIDExplorer_SerializationOptionPageContent 
            = "Page content is not serialized.";
        public static string WIDExplorer_SerializationOptionPageItems 
            = $"If {nameof(Stages.Stage3_UpToAllJobPostingsExtended)}, {nameof(JobPosting)} objects are not serialized.";
        public static string WIDExplorer_ConvertedExplorationToJsonString
            = $"The provided {nameof(Exploration)} object has been successfully converted to a JSON string.";

        public static string WIDExplorer_ConvertingMetricCollectionToJsonString
            = $"Converting the provided {nameof(MetricCollection)} object to a JSON string...";
        public static string WIDExplorer_ConvertedMetricsCollectionToJsonString
            = $"The provided {nameof(MetricCollection)} object has been successfully converted to a JSON string.";

        public static string WIDExplorer_RetrievingPreLabeledBulletPoints
            = $"Retrieving pre-labeled {nameof(BulletPoint)} objects...";
        public static Func<List<BulletPoint>, string> WIDExplorer_PreLabeledBulletPointsRetrieved
            = (bulletPoints) => $"'{bulletPoints.Count}' {nameof(BulletPoint)} objects has been successfully retrieved.";

        #endregion

        #region FileManager

        public static Func<IFileInfoAdapter, Exception, string> FileManager_NotPossibleToRead
            = (file, e) => $"It hasn't been possible to read from the provided file: '{file.FullName}': '{e.Message}'.";
        public static Func<IFileInfoAdapter, Exception, string> FileManager_NotPossibleToWrite
            = (file, e) => $"It hasn't been possible to write to the provided file: '{file.FullName}': '{e.Message}'.";

        #endregion

        #region JobPageManager

        public static Func<string, string> JobPageManager_NotPossibleExtractOffset
            = (url) => $"It's not possible to extract offset from \"{url}\".";

        #endregion 

        #region Methods_private

        private static string RollOutCollection(List<double> coll)
            => RollOutCollection(coll.Cast<object>().ToList());
        private static string RollOutCollection(IEnumerable<object> coll)
        {

            List<string> list = new List<string>();

            foreach (object obj in coll)
                list.Add(obj.ToString());

            return $"[{string.Join(", ", list)}]";

        }

        #endregion

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 11.08.2021

*/