using System;

namespace NW.WIDJobs
{
    public class PageScraper : IPageScraper
    {

        // Fields
        private IXPathManager _xpathManager;

        // Properties
        public static ushort PageItemsPerPage = 20;

        // Constructors
        public PageScraper(IXPathManager xpathManager)
        {

            Validator.ValidateObject(xpathManager, nameof(xpathManager));

            _xpathManager = xpathManager;

        }
        public PageScraper() { }

        // Methods (public)
        public uint GetTotalResults(string content)
        {

            string xpath = "//div[@class='col-sm-6']//strong//strong";

            string totalResults = _xpathManager.GetInnerText(content, xpath);

            return uint.Parse(totalResults);

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

        // Methods (private)

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/