using System;
using System.Collections.Generic;
using System.Linq;
using NW.WIDJobs.BulletPoints;
using NW.WIDJobs.Explorations;
using NW.WIDJobs.Files;
using NW.WIDJobs.Formatting;
using NW.WIDJobs.JobPages;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.JobPostingsExtended;
using NW.WIDJobs.Metrics;

namespace NW.WIDJobs.Messages
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
        public static Func<ushort, string> WIDExplorer_PageNumberIs
            = (pageNumber) => $"PageNumber:'{pageNumber}'.";
        public static Func<ushort, string> WIDExplorer_DefaultInitialPageNumberIs
            = (defaultInitialPageNumber) => $"DefaultInitialPageNumber:'{defaultInitialPageNumber}'.";
        public static Func<ushort, string> WIDExplorer_FinalPageNumberIs
            = (finalPageNumber) => $"FinalPageNumber:'{finalPageNumber}'.";
        public static string WIDExplorer_FinalPageNumberIsLastPage
            = "FinalPageNumber: The last available page on the website.";
        public static Func<DateTime, string> WIDExplorer_ThresholdDateIs
            = (thresholdDate) => $"ThresholdDate:'{thresholdDate.ToString(WIDExplorer.DefaultFormatDate)}'.";
        public static Func<string, string> WIDExplorer_JobPostingIdIs
            = (jobPostingId) => $"JobPostingId:'{jobPostingId}'.";
        public static Func<Stages, string> WIDExplorer_StageIs
            = (stage) => $"Stage:'{stage}'.";
        public static Func<int, string> WIDExplorer_BulletPointsAre
            = (bulletPoints) => $"BulletPoints:'{bulletPoints}'.";
        public static Func<Stages, string> WIDExplorer_ExecutionStageStarted
            = (stage) => $"The execution of the '{stage}' has been started.";
        public static Func<ushort, string> WIDExplorer_JobPageSuccessfullyRetrieved
            = (pageNumber) => $"The '{nameof(JobPage)}' object with '{nameof(JobPage.PageNumber)}'='{pageNumber}' has been successfully retrieved";       
        public static Func<uint, string> WIDExplorer_TotalResultCountIs
            = (totalResultCount) => $"TotalResultCount:'{totalResultCount}'.";
        public static Func<ushort, string> WIDExplorer_TotalJobPagesIs
            = (totalJobPages) => $"TotalJobPages:'{totalJobPages}'.";
        public static Func<List<JobPosting>, string> WIDExplorer_JobPostingCreatedInitial
            = (jobPostings) => $"'{jobPostings.Count}' '{nameof(JobPosting)}' objects have been created out of the initial page.";
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
        public static Func<ushort, List<JobPosting>, string> WIDExplorer_JobPostingObjectsCreated
            = (i, currentJobPostings) => $"Page '{i}' - '{currentJobPostings.Count}' '{nameof(JobPosting)}' objects have been created.";
        public static Func<List<JobPosting>, string> WIDExplorer_JobPostingObjectsCreatedTotal
            = (jobPostings) => $"'{jobPostings.Count}' '{nameof(JobPosting)}' objects have been created in total.";
        public static Func<JobPosting, string> WIDExplorer_JobPostingExtendedCreated
            = (jobPosting) => $"JobPosting {Format(jobPosting.PageNumber)}/{Format(jobPosting.JobPostingNumber)} processed. The corresponding '{nameof(JobPostingExtended)}' object has been created.";
        public static Func<List<JobPostingExtended>, string> WIDExplorer_JobPostingExtendedCreatedTotal
            = (jobPostingExtended) => $"'{jobPostingExtended.Count}' '{nameof(JobPostingExtended)}' objects have been created in total.";
        public static string WIDExplorer_ExplorationCompleted
            = "The exploration has been completed.";
        public static Func<DateTime, ushort, string> WIDExplorer_ThresholdDateFoundJobPageNr 
            = (thresholdDate, i) => $"'{thresholdDate}' has been found in {nameof(JobPage)} nr. '{i}'.";
        public static Func<string, ushort, string> WIDExplorer_JobPostingIdFoundJobPageNr
            = (jobPostingId, i) => $"'{jobPostingId}' has been found in {nameof(JobPage)} nr. '{i}'.";
        public static Func<int, ushort, string> WIDExplorer_XJobPostingsRemovedJobPageNr
            = (jobPostings, i) => $"'{20 - jobPostings}' has been removed from {nameof(JobPage)} nr. '{i}'.";
        public static Func<ushort, string> WIDExplorer_FinalPageNumberThresholdDate
            = (finalPageNumber) => $"The 'FinalPageNumber' for the provided 'ThresholdDate' is '{finalPageNumber}'.";
        public static Func<ushort, string> WIDExplorer_FinalPageNumberJobPostingId
            = (finalPageNumber) => $"The 'FinalPageNumber' for the provided 'JobPosting' is '{finalPageNumber}'.";

        public static string WIDExplorer_LoadingJobPostingsFromJsonFile
            = $"Loading {nameof(JobPosting)} objects from the provided Json file...";
        public static string WIDExplorer_LoadingExplorationFromJsonFile
            = $"Loading an {nameof(Exploration)} object from the provided Json file...";
        public static Func<List<JobPosting>, string> WIDExplorer_JobPostingsExtractedFromJsonFile
            = (jobPostings) => $"'{jobPostings.Count}' {nameof(JobPosting)} objects have been successfully extracted from the provided Json file.";
        public static string WIDExplorer_SomeDefaultValuesUsedJsonFile
            = $"Some default values need to be used in order to perform this extraction directly from a Json file.";

        public static string WIDExplorer_SavingExplorationToSQLiteDatabase
            =  $"Saving the provided {nameof(Exploration)} object to a SQLite database...";
        public static Func<Exploration, string> WIDExplorer_ExplorationIs
            = (exploration) => $"Exploration: '{exploration}'.";
        public static Func<string, string> WIDExplorer_DatabaseFileIs
            = (databaseFile) => $"DatabaseFile: '{databaseFile}'.";
        public static Func<bool, string> WIDExplorer_DeleteAndRecreateDatabaseIs
            = (deleteAndRecreateDatabase) => $"DeleteAndRecreateDatabase: '{deleteAndRecreateDatabase}'.";
        public static Func<int, string> WIDExplorer_AffectedRowsAre
            = (affectedRows) => $"AffectedRows: '{affectedRows}'.";
        public static string WIDExplorer_ExplorationSavedToSQLiteDatabase
            = $"The provided {nameof(JobPostingExtended)} objects have been successfully saved to a SQLite database.";

        public static string WIDExplorer_SavingExplorationToJsonFile
            = $"Saving the provided {nameof(Exploration)} object to a JSON file...";
        public static string WIDExplorer_ExplorationSavedToJsonFile
            = $"The provided {nameof(Exploration)} object has been successfully saved to a JSON file.";
        public static Func<IFileInfoAdapter, string> WIDExplorer_JSONFileIs
            = (jsonFile) => $"JSONFile: '{jsonFile.FullName}'.";
        public static string WIDExplorer_SavingBulletPointsToJsonFile
            = $"Saving the provided {nameof(BulletPoint)} objects to a JSON file...";
        public static string WIDExplorer_BulletPointsSavedToJsonFile
            = $"The provided {nameof(BulletPoint)} objects have been successfully saved to a JSON file.";

        public static string WIDExplorer_SavingMetricCollectionToJsonFile
            = $"Saving the provided {nameof(MetricCollection)} object to a JSON file...";
        public static Func<bool, string> WIDExplorer_NumbersAsPercentagesIs
            = (numbersAsPercentages) => $"NumbersAsPercentages: '{numbersAsPercentages}'.";
        public static string WIDExplorer_MetricCollectionSavedToJsonFile
            = $"The provided {nameof(MetricCollection)} object has been successfully saved to a JSON file.";

        public static Func<string, string> WIDExplorer_MethodCalledWithoutIFileInfoAdapter
            = (methodName) => $"'{methodName}' has been called without providing a '{nameof(IFileInfoAdapter)}' parameter.";
        public static string WIDExplorer_DefaultValuesCreateIFileInfoAdapter
            = $"Before proceeding, default values will be used to create a '{nameof(IFileInfoAdapter)}' object.";
        public static Func<string, string> WIDExplorer_FolderPathIs
            = (folderPath) => $"FolderPath: '{folderPath}'.";
        public static Func<DateTime, string> WIDExplorer_NowIs
            = (now) => $"Now:'{now.ToString(WIDExplorer.DefaultFormatDate)}'.";

        public static string WIDExplorer_ConvertingExplorationToMetricCollection
            = $"Converting the provided {nameof(Exploration)} object to a {nameof(MetricCollection)} object...";  
        public static string WIDExplorer_ExplorationConvertedToMetricCollection
            = $"The provided {nameof(Exploration)} object has been successfully converted to a {nameof(MetricCollection)} object.";

        public static string WIDExplorer_ConvertingExplorationToJsonString
            = $"Converting the provided {nameof(Exploration)} object to a JSON string...";
        public static Func<string, string> WIDExplorer_SerializationOptionIs
            = (serializationOption) => $"SerializationOption: '{serializationOption}'.";
        public static Func<bool, string> WIDExplorer_VerboseSerializationIs 
            = (verboseSerialization) => $"VerboseSerialization: '{verboseSerialization}'.";
        public static string WIDExplorer_ConvertedExplorationToJsonString
            = $"The provided {nameof(Exploration)} object has been successfully converted to a JSON string.";

        public static string WIDExplorer_ConvertingBulletPointsToJsonString
            = $"Converting the provided {nameof(BulletPoint)} objects to a JSON string...";
        public static string WIDExplorer_ConvertedBulletPointsToJsonString
            = $"The provided {nameof(BulletPoint)} objects have been successfully converted to a JSON string.";

        public static string WIDExplorer_ConvertingMetricCollectionToJsonString
            = $"Converting the provided {nameof(MetricCollection)} object to a JSON string...";
        public static string WIDExplorer_ConvertedMetricsCollectionToJsonString
            = $"The provided {nameof(MetricCollection)} object has been successfully converted to a JSON string.";

        public static string WIDExplorer_RetrievingPreLabeledBulletPoints
            = $"Retrieving pre-labeled {nameof(BulletPoint)} objects...";
        public static Func<int, string> WIDExplorer_PreLabeledBulletPointsRetrieved
            = (bulletPoints) => $"'{bulletPoints}' {nameof(BulletPoint)} objects has been successfully retrieved.";

        #endregion

        #region FileManager

        public static Func<IFileInfoAdapter, Exception, string> FileManager_NotPossibleToRead
            = (file, e) => $"It hasn't been possible to read from the provided file: '{file.FullName}': '{e.Message}'.";
        public static Func<IFileInfoAdapter, Exception, string> FileManager_NotPossibleToWrite
            = (file, e) => $"It hasn't been possible to write to the provided file: '{file.FullName}': '{e.Message}'.";

        #endregion

        #region Formatter

        public static Func<string, string> Formatter_NoFormattingStrategyAvailableFor
            = (value) => $"No formatting strategy available for ('{value}').";

        #endregion

        #region Methods_private
        private static string Format(uint value)
            => new Formatter().Format(value);
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
    Last Update: 05.09.2021
*/