using System;

namespace NW.WIDJobs
{
    /// <inheritdoc cref="IPageScraper"/>
    public class PageScraper : IPageScraper
    {

        #region Fields

        private IXPathManager _xpathManager;

        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="PageScraper"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public PageScraper(IXPathManager xpathManager)
        {

            Validator.ValidateObject(xpathManager, nameof(xpathManager));

            _xpathManager = xpathManager;

        }

        /// <summary>Initializes a <see cref="PageScraper"/> instance using default parameters.</summary>
        public PageScraper()
            : this(new XPathManager()) { }

        #endregion

        #region Methods_public

        public uint GetTotalResults(string content)
        {

            Validator.ValidateStringNullOrWhiteSpace(content, nameof(content));

            string xpath = "//div[@class='col-sm-6']//strong//strong";

            string totalResults = _xpathManager.GetInnerText(content, xpath);

            return uint.Parse(totalResults);

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/