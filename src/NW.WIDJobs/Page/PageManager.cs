using System;
using System.Text;

namespace NW.WIDJobs
{
    public class PageManager : IPageManager
    {

        // Fields
        private IGetRequestManager _getRequestManager;
        private IPageScraper _pageScraper;

        // Properties
        public static ushort PageItemsPerPage = 20;

        // Constructors
        public PageManager(IGetRequestManager getRequestManager, IPageScraper pageScraper)
        {

            Validator.ValidateObject(getRequestManager, nameof(getRequestManager));
            Validator.ValidateObject(pageScraper, nameof(pageScraper));

            _getRequestManager = getRequestManager;
            _pageScraper = pageScraper;

        }
        public PageManager()
            : this(new GetRequestManager(), new PageScraper()) { }

        // Methods (public)
        public string CreateUrl(ushort pageNumber)
        {

            Validator.ThrowIfLessThanOne(pageNumber, nameof(pageNumber));

            if (pageNumber == 1)
                return "https://www.workindenmark.dk/Search/Job-search?q=&orderBy=date";

            return $"https://www.workindenmark.dk/Search/Job-search?q=&orderBy=date&PageNum={pageNumber}&";

        }
        public Page GetPage(string runId, ushort pageNumber)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfLessThanOne(pageNumber, nameof(pageNumber));

            string url = CreateUrl(pageNumber);
            string content = GetContent(url);

            Page page = new Page(runId, pageNumber, content);

            return page;

        }
        public uint GetTotalResults(string content)
        {

            Validator.ValidateStringNullOrWhiteSpace(content, nameof(content));

            uint totalResults = _pageScraper.GetTotalResults(content);

            return totalResults;

        }
        public ushort GetTotalEstimatedPages(uint totalResults)
        {

            /*
             * 
             *  1243 total results / 20 results per page = 62.15.
             *  
             *  In the case above, 63 must be returned, because:
             *     a) 62 pages with 20 results each = 1240;
             *     b) 1 page with the 3 results left.
             *   
             */

            int reminder = 0;

            int totalEstimatedPages = Math.DivRem((int)totalResults, PageItemsPerPage, out reminder);
            if (reminder > 0)
                totalEstimatedPages++;

            return (ushort)totalEstimatedPages;

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
    Last Update: 15.05.2021
*/