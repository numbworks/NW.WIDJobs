using System;
using NW.WIDJobs.Explorations;

namespace NW.WIDJobsClient.Messages
{
    ///<summary>Collects all the messages used for logging and exceptions.</summary>
    public static class MessageCollection
    {

        public static string Program_DumpingExplorationToConsole = $"Dumping {nameof(Exploration)} object to console:";
        public static string Program_DumpingJsonToConsole = "Dumping Json to console:";
        public static string Program_PressAButtonToCloseTheWindow = "Press a button to close the window.";
        public static string Program_ApplicationAuthor = "Author: numbworks";
        public static string Program_ApplicationEmail = "Email: numbworks [AT] gmail [DOT] com";
        public static string Program_ApplicationUrl = @"Github: http://www.github.com/numbworks";
        public static string Program_ApplicationLicense = "License: MIT License";
        public static Func<string, string> Program_FormattedErrorMessage = (message) => $"ERROR: {message}";
        public static Func<string, string> Program_OutputValueCantBeConvertedDescribeOutputs
            = (outputValue) => $"The provided output value ('{outputValue}') can't be converted to {nameof(DescribeOutputs)}.";

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 25.08.2021
*/