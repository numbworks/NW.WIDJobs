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

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 01.06.2021
*/