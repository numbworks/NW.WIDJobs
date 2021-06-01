using System;

namespace NW.WIDJobs
{
    /// <inheritdoc cref="IPageItemScraperHelper"/>
    public class PageItemScraperHelper : IPageItemScraperHelper
    {

        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="PageItemScraperHelper"/> instance.</summary>
        public PageItemScraperHelper() { }

        #endregion

        #region Methods_public

        public string ConvertToAbsoluteUrl(string relativeUrl)
        {

            /*
                /job/8148174/Technology-Finance-Business-Partner
                => https://www.workindenmark.dk/job/8148174/Technology-Finance-Business-Partner
            */

            Validator.ValidateStringNullOrWhiteSpace(relativeUrl, nameof(relativeUrl));

            return string.Concat("https://www.workindenmark.dk", relativeUrl);

        }
        public string CleanWorkArea(string workArea)
        {

            Validator.ValidateStringNullOrWhiteSpace(workArea, nameof(workArea));

            return workArea.Replace("Work area: ", string.Empty);

        }
        public string CleanWorkingHours(string workingHours)
        {

            Validator.ValidateStringNullOrWhiteSpace(workingHours, nameof(workingHours));

            return workingHours.Replace("Working hours: ", string.Empty);

        }
        public string CleanJobType(string jobType)
        {

            Validator.ValidateStringNullOrWhiteSpace(jobType, nameof(jobType));

            return jobType.Replace("Job type: ", string.Empty);

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 01.06.2021
*/