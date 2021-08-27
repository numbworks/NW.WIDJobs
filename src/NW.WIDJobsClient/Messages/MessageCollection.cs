using System;
using NW.WIDJobs.Explorations;

namespace NW.WIDJobsClient.Messages
{
    ///<summary>Collects all the messages used for logging and exceptions.</summary>
    public static class MessageCollection
    {

        #region Program

        public static string Program_DumpingExplorationToConsole = $"Dumping {nameof(Exploration)} object to console:";
        public static string Program_DumpingJsonToConsole = "Dumping Json to console:";
        public static string Program_PressAButtonToCloseTheWindow = "Press a button to close the window.";
        public static string Program_ApplicationAuthor = "Author: numbworks";
        public static string Program_ApplicationEmail = "Email: numbworks [AT] gmail [DOT] com";
        public static string Program_ApplicationUrl = @"Github: http://www.github.com/numbworks";
        public static string Program_ApplicationLicense = "License: MIT License";
        public static Func<string, string> Program_FormattedErrorMessage 
            = (message) => $"ERROR: {message}";
        public static Func<string, string> Program_FileHasNotBeenCreated
            = (filePath) => $"ERROR: the file hasn't been created ('{filePath}').";
        public static Func<string, Type, string> Program_OptionValueCantBeConvertedTo
            = (optionValue, type) => $"The provided option value ('{optionValue}') can't be converted to {type.Name}.";

        #endregion

        #region ThresholdValidator

        public static Func<string, string> ThresholdValidator_ThresholdValueNotValidFormat
            = (optionValue) => $"The thresold value ('{optionValue}') is not in a valid format.";

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 26.08.2021
*/