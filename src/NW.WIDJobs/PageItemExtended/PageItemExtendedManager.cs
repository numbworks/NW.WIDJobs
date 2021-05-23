using System;
using System.Text;

namespace NW.WIDJobs
{
    /// <inheritdoc cref="IPageItemExtendedManager"/>
    public class PageItemExtendedManager : IPageItemExtendedManager
    {

        #region Fields

        private IGetRequestManager _getRequestManager;
        private IPageItemExtendedScraper _pageItemExtendedScraper;

        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="PageItemExtendedManager"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public PageItemExtendedManager
            (IGetRequestManager getRequestManager, IPageItemExtendedScraper pageItemExtendedScraper)
        {

            Validator.ValidateObject(getRequestManager, nameof(getRequestManager));
            Validator.ValidateObject(pageItemExtendedScraper, nameof(pageItemExtendedScraper));

            _getRequestManager = getRequestManager;
            _pageItemExtendedScraper = pageItemExtendedScraper;

        }

        /// <summary>Initializes a <see cref="PageItemExtendedManager"/> instance using default parameters.</summary>
        public PageItemExtendedManager()
            : this(new GetRequestManager(), new PageItemExtendedScraper()) { }

        #endregion

        #region Methods_public

        public PageItemExtended Get(PageItem pageItem)
        {

            Validator.ValidateObject(pageItem, nameof(pageItem));

            string content = GetContent(pageItem.Url);
            PageItemExtended pageItemExtended = _pageItemExtendedScraper.Do(pageItem, content);

            return pageItemExtended;

        }
        public string GetContent(string url)
        {

            Validator.ValidateStringNullOrWhiteSpace(url, nameof(url));

            return _getRequestManager.Send(url, Encoding.UTF8);

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/