using System;
using System.Text;

namespace NW.WIDJobs
{
    /// <summary><inheritdoc cref="IPageManager"/></summary>
    public class PageManager : IPageManager
    {

        #region Fields

        private IGetRequestManager _getRequestManager;
        private IPageScraper _pageScraper;
        private IWIDCategoryManager _categoryManager;

        #endregion

        #region Properties

        public static ushort PageItemsPerPage = 20;
        public static string UrlAllCategoriesFirstPage 
            = "https://www.workindenmark.dk/Search/Job-search?q=&orderBy=date";
        public static Func<ushort, string> UrlAllCategoriesOtherPages
            = (pageNumber) => $"https://www.workindenmark.dk/Search/Job-search?q=&orderBy=date&PageNum={pageNumber}&";
        public static Func<string, string> UrlCategoryFirstPage
            = (token) => $"https://www.workindenmark.dk/search/Job-search?q=&categories={token}&orderBy=date";
        public static Func<string, ushort, string> UrlCategoryOtherPages
            = (token, pageNumber) => $"https://www.workindenmark.dk/search/Job-search?q=&categories={token}&orderBy=date&PageNum={pageNumber}";

        #endregion

            #region Constructors

            /// <summary>Initializes a <see cref="PageManager"/> instance.</summary>
            /// <exception cref="ArgumentNullException"/>
        public PageManager(
           IGetRequestManager getRequestManager, IPageScraper pageScraper, IWIDCategoryManager categoryManager)
        {

            Validator.ValidateObject(getRequestManager, nameof(getRequestManager));
            Validator.ValidateObject(pageScraper, nameof(pageScraper));
            Validator.ValidateObject(categoryManager, nameof(categoryManager));

            _getRequestManager = getRequestManager;
            _pageScraper = pageScraper;
            _categoryManager = categoryManager;

        }

        /// <summary>Initializes a <see cref="PageManager"/> instance using default parameters.</summary>
        public PageManager()
            : this(new GetRequestManager(), new PageScraper(), new WIDCategoryManager()) { }

        #endregion

        #region Methods_public

        public string CreateUrl(ushort pageNumber, WIDCategories category)
        {

            Validator.ThrowIfLessThanOne(pageNumber, nameof(pageNumber));

            if (category == WIDCategories.AllCategories && pageNumber == 1)
                return UrlAllCategoriesFirstPage;

            if (category == WIDCategories.AllCategories && pageNumber > 1)
                return UrlAllCategoriesOtherPages(pageNumber);

            string token = _categoryManager.GetCategoryToken(category);

            if (pageNumber == 1)
                return UrlCategoryFirstPage(token);

            return UrlCategoryOtherPages(token, pageNumber);

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
        public Page GetPage(string runId, ushort pageNumber, WIDCategories category)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfLessThanOne(pageNumber, nameof(pageNumber));

            string url = CreateUrl(pageNumber, category);
            string content = GetContent(url);

            Page page = new Page(runId, pageNumber, content);

            return page;

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 15.05.2021
*/