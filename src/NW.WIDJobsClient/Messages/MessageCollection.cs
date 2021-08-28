using System;
using NW.WIDJobs.Explorations;

namespace NW.WIDJobsClient.Messages
{
    ///<summary>Collects all the messages used for logging and exceptions.</summary>
    public static class MessageCollection
    {

        #region CommandLineManager

        public static string CommandLineManager_DumpingJsonToConsole = "Dumping Json to console:";
        public static string CommandLineManager_PressAButtonToCloseTheWindow = "Press a button to close the window.";
        public static string CommandLineManager_ApplicationAuthor = "Author: numbworks";
        public static string CommandLineManager_ApplicationEmail = "Email: numbworks [AT] gmail [DOT] com";
        public static string CommandLineManager_ApplicationUrl = @"Github: http://www.github.com/numbworks";
        public static string CommandLineManager_ApplicationLicense = "License: MIT License";
        public static Func<string, string> CommandLineManager_FormattedErrorMessage 
            = (message) => $"ERROR: {message}";
        public static Func<string, string> CommandLineManager_FileHasNotBeenCreated
            = (filePath) => $"ERROR: the file hasn't been created ('{filePath}').";
        public static Func<string, Type, string> CommandLineManager_OptionValueCantBeConvertedTo
            = (optionValue, type) => $"The provided option value ('{optionValue}') can't be converted to {type.Name}.";
        public static Func<Type, Type, string, string> CommandLineManager_FirstEnumCantBeMapped
            = (inputEnum, outputEnum, value) => $"The input enum ('{inputEnum}') can't be mapped to the output enum ('{outputEnum}') for the provided value: '{value}'.";

        #endregion

        #region ThresholdValueValidator

        public static Func<string, string> ThresholdValueValidator_ThresholdValueNotValidFormat
            = (optionValue) => $"The thresold value ('{optionValue}') is not in a valid format. It can be a number (1, 2, ...), a date (yyyyMMdd) or an id (5376524visgerrengringsassistenter, ...).";

        #endregion

        #region ParallelRequestsValidator

        public static Func<string, string> ParallelRequestsValidator_ValueNotInExpectedRange
            = (optionValue) => $"The value ('{optionValue}') is not within the expected range ('{nameof(ParallelRequestsManager.MininumParallelRequests)}':'{ParallelRequestsManager.MininumParallelRequests}', '{nameof(ParallelRequestsManager.MaximumParallelRequests)}':'{ParallelRequestsManager.MaximumParallelRequests}').";

        #endregion

        #region PauseBetweenRequestsValidator

        public static Func<string, string> PauseBetweenRequestsValidator_ValueNotValid
            = (optionValue) => $"The value ('{optionValue}') is not valid.";

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.08.2021
*/