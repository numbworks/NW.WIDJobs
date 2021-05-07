using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;

namespace NW.WIDJobs
{

    /// <summary>
    /// It performs an regressive search on WorkInDenmark.dk that returns a ResultsExploration object. 
    /// The latter contains all the *Items that haven't been imported in the database yet, split by *Pages of ResultsPerPage items each. 
    /// At this stage, the *Items contain only the information that are available on the search results pages (AbsoluteUrl, ItemId, WorkArea).
    /// </summary>
    public class WIDExplorer : IWIDExplorer
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
        public ExplorationSummary Explore()
        {

            PageBundle pageBundle = GetPage(1);
            ExplorationSummary explorationSummary = InitializeExploration(pageBundle.Response);

            List<Page> pages = new List<Page>();
            pages.Add(pageBundle.Page);

            if (pageBundle.Page.IsLastForCurrentExploration == false)
            {

                List<Page> morePages = GetPages(2, explorationSummary.TotalPagesExpected);
                pages.AddRange(morePages);

            }

            return new ExplorationSummary(explorationSummary.TotalResults, explorationSummary.TotalPagesExpected, pages);

        }

        // Methods (private)
        private ExplorationSummary InitializeExploration(string response)
        {

            uint totalResults = GetTotalResults(response);
            ushort estimatedTotalPages = EstimateTotalPages(totalResults);

            return new ExplorationSummary(totalResults, estimatedTotalPages, null);

        }
        private List<Page> GetPages(ushort startPage, ushort endPage)
        {

            List<Page> pages = new List<Page>();
            for (ushort i = startPage; i <= endPage; i++)
            {

                PageBundle pageBundle = GetPage(i);
                Page page = pageBundle.Page;
                pages.Add(page);

                if (page.IsLastForCurrentExploration == true)
                    break;

                ConditionallySleep(i, _settings.ParallelRequests, (int)_settings.PauseBetweenRequestsMs);

            }

            return pages;

        }

        private PageBundle GetPage(ushort pageNumber)
        {

            string absoluteUrl = CreatePageAbsoluteUrl(pageNumber);
            string response = _components.GetRequestManager.Send(absoluteUrl, Encoding.UTF8);
            List<PageItem> listItems = GetItems(response);

            Page page = new Page();
            page.PageNumber = pageNumber;
            page.AbsoluteUrl = absoluteUrl;
            page.Items = listItems;

            PageBundle pageBundle = new PageBundle();
            pageBundle.Response = response;
            pageBundle.Page = page;

            return pageBundle;

        }
        private List<PageItem> GetItems(string response)
        {

            // Should this "nulls" be Exceptions instead?

            List<string> titles = GetTitles(response);
            if (titles == null)
                return null;

            List<string> relativeUrls = GetRelativeUrls(response);
            if (relativeUrls == null)
                return null;

            List<string> workAreas = GetWorkAreas(response);
            if (workAreas == null)
                return null;

            if (!CompareIntegers(new int[] { titles.Count, relativeUrls.Count, workAreas.Count }))
                return null;

            List<PageItem> pageItems = new List<PageItem>();
            for (int i = 0; i < relativeUrls.Count; i++)
                pageItems.Add(
                    new PageItem()
                    {
                        Title = titles[i],
                        AbsoluteUrl = CreateItemAbsoluteUrl(relativeUrls[i]),
                        ItemId = CreateItemId(relativeUrls[i]),
                        WorkArea = workAreas[i]
                    });

            return pageItems;

        }
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
            totalResults = TrimOrNull(totalResults);

            return uint.Parse(totalResults);

        }
        private List<string> GetTitles(string response)
        {

            /*
             * ...
             * <div class="col-sm-9 ">
             *    <h2><a class="search-link underline visited" href="/job/6765129/Logistics-Specialist">Logistics Specialist<small class="visited-text"> &nbsp;</small></a></h2>
             * ...
             * 
             * Expected: 
             *  
             *      Application Specialist
             *      Test Engineer
             *      Test Engineer
             *      ...
             * 
             */

            string xpath = "//div[@class='col-sm-9 ']//h2";

            List<string> titles = _components.XPathManager.GetInnerTexts(response, xpath);
            if (titles != null)
                return CleanTitles(titles);

            return null;

        }
        private List<string> GetRelativeUrls(string response)
        {

            /*
             * ...
             * <div class="col-sm-9 ">
             *    <h2><a class="search-link underline visited" href="/job/6765129/Logistics-Specialist">Logistics Specialist<small class="visited-text"> &nbsp;</small></a></h2>
             * ...
             * 
             * Expected: 
             *  
             *      /job/6765088/Application-Specialist
             *      /job/6765087/Test-Engineer
             *      /job/6765085/Test-Engineer
             *      ...
             * 
             */

            string xpath = "//div[@class='col-sm-9 ']//h2//a//@href";
            uint attributeNr = 1;

            List<string> relativeUrls = _components.XPathManager.GetAttributeValues(response, xpath, attributeNr);

            return relativeUrls;

        }
        private List<string> GetWorkAreas(string strResponse)
        {

            /*
             * ...
             *	<div class="col-sm-12">
             *		<ul class="list-inline">
             *			<li>Work area: Kolding</li>
             *			<li>Working hours: Full time (37 hours)</li>
             *			<li>Job type: Regular position</li>
             * ...
             * 
             * Expected: 
             *  
             *      Work area: Nordborg                     <=
             *      Working hours: Full time (37 hours)
             *      Job type: Regular position
             *      Work area: Gråsten                      <=
             *      Working hours: Full time (37 hours)
             *      Job type: Limited period
             *      ...
             * 
             */

            string xpath = "//div[@class='col-sm-12']//ul[@class='list-inline']";

            List<string> workAreas = _components.XPathManager.GetInnerTexts(strResponse, xpath);
            if (workAreas != null)
                return ExtractWorkAreas(workAreas);

            return null;

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
        private string CreateItemAbsoluteUrl(string relativeUrl)
        {

            /*
             * 
             * /job/6755866/COUNTRY-SALES-PRODUCT-RESPONSIBLE 
             *      => https://www.workindenmark.dk/job/6755866/COUNTRY-SALES-PRODUCT-RESPONSIBLE
             *      
             */

            return string.Concat("https://www.workindenmark.dk", relativeUrl);

        }
        private string CreateItemId(string relativeUrl)
        {

            /*
             * 
             * /job/6755866/COUNTRY-SALES-PRODUCT-RESPONSIBLE 
             *          => 6755866COUNTRY-SALES-PRODUCT-RESPONSIBLE 
             *      
             */

            return relativeUrl.Replace("/job/", string.Empty).Replace("/", string.Empty);

        }

        private void ConditionallySleep
            (ushort i, ushort parallelRequests, int pauseBetweenRequestsMs)
        {

            // Do a pause of x each y requests
            // i != 0, because 0 % x = 0...
            if (i != 0 && i % parallelRequests == 0)
                Thread.Sleep(pauseBetweenRequestsMs);

        }
        private bool CompareIntegers(int[] arr)
        {

            if (arr.Length < 2)
                return false;

            return Array.TrueForAll(arr, val => (arr[0] == val));

        }
        private List<string> CleanTitles(List<string> list)
        {

            // "Application Specialist &nbsp;" => "Application Specialist"

            for (int i = 0; i < list.Count; i++)
                list[i] = list[i].Replace("&nbsp;", string.Empty).Trim();

            return list;

        }
        private List<string> ExtractWorkAreas(List<string> list)
        {

            /*
             * It expects something like:
             * 
             *  [0]
             *  Work area: Odense S
             *  Working hours: Full time (37 hours)
             *  Job type: Regular position
             * 
             *  [1]
             *  Work area: Glostrup
             *  Working hours: Full time (37 hours)
             *  Job type: Regular position
             * 	 
             *  [2]
             *  		  
             *  Working hours: Full time (37 hours)
             *  Job type: Limited period
             * 
             *  [3]
             *  	  
             *  Working hours: Full time (37 hours)
             *  Job type: Limited period
             * 
             *  ...
             * 
             */

            List<string> workAreas = new List<string>();
            for (int i = 0; i < list.Count; i++)
                workAreas.Add(ExtractWorkArea(list[i]));

            return workAreas;

        }
        private string ExtractWorkArea(string strText)
        {

            /*
             * If the provided text is:
             * 
             *      Work area: Odense S
             *      Working hours: Full time (37 hours)
             *      Job type: Regular position
             * 
             * it returns: "Odense S".
             * 
             * If the provided text is:
             * 
             *      Work area: Kgs. Lyngby
             *      Working hours: Full time (37 hours)
             *      Job type: Regular position
             * 
             * it returns: "Kgs. Lyngby".
             * 
             * If the provided text is:
             * 
             *      Working hours: Full time (37 hours)
             *      Job type: Limited period
             * 
             * it returns "null".
             * 
             */

            // \w in .NET matches all Unicode characters, Danish vowels included.
            string strPattern = @"(?<=Work area: )[\w. ]*(?!Working hours:|Job type:)";

            string strWorkArea = null;
            if (Regex.IsMatch(strText.Trim(), strPattern))
                strWorkArea = Regex.Match(strText, strPattern).ToString();

            return strWorkArea;

        }
        private string TrimOrNull(string str)
        {

            if (str == null)
                return null;

            return str.Trim();

        }

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.05.2021
*/