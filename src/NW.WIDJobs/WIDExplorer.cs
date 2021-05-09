using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;

namespace NW.WIDJobs
{

    public class WIDExplorer
    {

        // Fields
        private WIDExplorerComponents _components;
        private WIDExplorerSettings _settings;

        // Properties
        // Constructors
        public WIDExplorer
            (WIDExplorerComponents components, WIDExplorerSettings settings)
        {

            Validator.ValidateObject(components, nameof(components));
            Validator.ValidateObject(settings, nameof(settings));

            _components = components;
            _settings = settings;

        }
        public WIDExplorer()
            : this(new WIDExplorerComponents(), new WIDExplorerSettings()) { }

        // Methods (public)

        // Methods (private)

 
        private uint GetTotalResults(string response)
        {

            /*
             * ...
             * 	<div class="row" style="padding:15px 0;">
             * 		<div class="col-sm-6">
             * 				<strong><strong>1243</strong> results</strong>
             * 		</div>
             * ...
             * 
             */

            string xpath = "//div[@class='col-sm-6']//strong//strong";

            string totalResults = _components.XPathManager.GetInnerText(response, xpath);

            return uint.Parse(totalResults);

        }

        private ushort EstimateTotalPages(uint totalResults)
        {

            /*
             *  Since ResultsPerPage is a read-only value, we assume it will always be > 0.
             * 
             *  Example:
             *  
             *  1243 total results / 20 results per page = 62.15.
             *  
             *  In the case above, 63 must be returned, because:
             *     a) 62 pages with 20 results each = 1240;
             *     b) 1 page with the 3 results left.
             *   
             */

            int reminder = 0;

            int estimatedTotalPages = Math.DivRem((int)totalResults, _settings.ResultsPerPage, out reminder);
            if (reminder > 0)
                estimatedTotalPages++;

            return (ushort)estimatedTotalPages;

        }
        private string CreatePageAbsoluteUrl(ushort pageNumber)
        {

            if (pageNumber == 1)
                return "https://www.workindenmark.dk/Search/Job-search?q=";

            return $"https://www.workindenmark.dk/Search/Job-search?q=&PageNum={pageNumber}";

        }
        private void ConditionallySleep
            (ushort i, ushort parallelRequests, int pauseBetweenRequestsMs)
        {

            // Do a pause of x each y requests
            // i != 0, because 0 % x = 0...
            if (i != 0 && i % parallelRequests == 0)
                Thread.Sleep(pauseBetweenRequestsMs);

        }

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/