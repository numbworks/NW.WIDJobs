using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace NW.WIDJobsClient
{
    /// <inheritdoc cref="IThresholdValueManager"/>
    public class ThresholdValueManager : IThresholdValueManager
    {

        #region Fields

        #endregion

        #region Properties

        public static uint MininumFinalPageNumber { get; } = 1;
        public static string ThresholdDateFormat { get; } = "yyyyMMdd";
        public static string JobPostingIdPattern = "[0-9]{1,}[a-zA-Z]{1,}";

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="ThresholdValueManager"/> instance.</summary>	
        public ThresholdValueManager() { }

        #endregion

        #region Methods_public

        public bool IsValid(string value)
        {

            // PageNumber: 1, 2, ...
            // Date: 20210722
            // JobPostingId: 5376524visgerrengringsassistenter

            if (IsValidFinalPageNumber(value))
                return true;

            if (IsValidThresholdDate(value))
                return true;

            if (IsValidJobPostingId(value))
                return true;

            return false;

        }
        public bool IsValidFinalPageNumber(string value)
        {

            try
            {
                ushort pageNumber = ParseFinalPageNumber(value);

                if (pageNumber < MininumFinalPageNumber)
                    return false;

                return true;

            }
            catch
            {

                return false;

            }

        }
        public bool IsValidThresholdDate(string value)
        {

            try
            {

                DateTime date = ParseThresholdDate(value);

                return true;

            }
            catch
            {

                return false;

            }

        }
        public bool IsValidJobPostingId(string value)
            => Regex.IsMatch(value, JobPostingIdPattern);
        public ushort ParseFinalPageNumber(string value)
            => ushort.Parse(value);
        public DateTime ParseThresholdDate(string value)
            => DateTime.ParseExact(value, ThresholdDateFormat, CultureInfo.InvariantCulture);

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 27.08.2021
*/