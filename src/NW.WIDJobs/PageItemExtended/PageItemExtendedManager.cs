using System.Text;

namespace NW.WIDJobs
{
    public class PageItemExtendedManager : IPageItemExtendedManager
    {

        // Fields
        private IGetRequestManager _getRequestManager;
        private IPageItemExtendedScraper _pageItemExtendedScraper;

        // Properties
        // Constructors
        public PageItemExtendedManager
            (IGetRequestManager getRequestManager, IPageItemExtendedScraper pageItemExtendedScraper)
        {

            Validator.ValidateObject(getRequestManager, nameof(getRequestManager));
            Validator.ValidateObject(pageItemExtendedScraper, nameof(pageItemExtendedScraper));

            _getRequestManager = getRequestManager;
            _pageItemExtendedScraper = pageItemExtendedScraper;

        }
        public PageItemExtendedManager()
            : this(new GetRequestManager(), new PageItemExtendedScraper()) { }

        // Methods (public)
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

        // Methods (private)

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/