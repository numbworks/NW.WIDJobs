using System;

namespace NW.WIDJobsClient
{
    /// <summary>Groups all the utility methods related to <see cref="CommandLineManager.Option_ThresholdValue_Template"/>.</summary>
    public interface IThresholdValueManager
    {

        /// <summary>Establishes if the value for <see cref="CommandLineManager.Option_ThresholdValue_Template"/> is valid or not.</summary>
        bool IsValid(string value);

        /// <summary>Establishes if the value for <see cref="CommandLineManager.Option_ThresholdValue_Template"/> is a valid <see cref="ThresholdTypes.finalpagenumber"/> or not.</summary>
        bool IsValidFinalPageNumber(string value);

        /// <summary>Establishes if the value for <see cref="CommandLineManager.Option_ThresholdValue_Template"/> is a valid <see cref="ThresholdTypes.jobpostingid"/> or not.</summary>
        bool IsValidJobPostingId(string value);

        /// <summary>Establishes if the value for <see cref="CommandLineManager.Option_ThresholdValue_Template"/> is a valid <see cref="ThresholdTypes.thresholddate"/> or not.</summary>
        bool IsValidThresholdDate(string value);

        /// <summary>Parses the value for <see cref="ThresholdTypes.finalpagenumber"/>.</summary>
        ushort ParseFinalPageNumber(string value);

        /// <summary>Parses the value for <see cref="ThresholdTypes.thresholddate"/>.</summary>
        DateTime ParseThresholdDate(string value);
    
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 29.08.2021
*/