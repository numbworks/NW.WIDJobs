using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Text.RegularExpressions;

namespace NW.WIDJobs
{
    public class PageItemScraper
    {

        // Fields
        private IXPathManager _xpathManager;

        // Properties
        // Constructors
        public PageItemScraper(IXPathManager xpathManager)
        {

            Validator.ValidateObject(xpathManager, nameof(xpathManager));

            _xpathManager = xpathManager;

        }
        public PageItemScraper()
            : this(new XPathManager()) { }

        // Methods (public)
        public List<PageItem> Do(Page page)
        {

            Validator.ValidateObject(page, nameof(page));

            List<string> urls = ExtractAndFixUrls(page.Content);
            List<string> titles = ExtractTitles(page.Content);
            List<DateTime> createDates = ExtractAndParseCreateDates(page.Content);
            List<DateTime> applicationDates = ExtractAndParseApplicationDates(page.Content);
            List<string> workAreas = ExtractAndCleanWorkAreas(page.Content);
            List<string> workingHours = ExtractAndCleanWorkingHours(page.Content);
            List<string> jobTypes = ExtractAndCleanJobTypes(page.Content);
            List<ulong> jobIds = ExtractAndParseJobIds(urls);

            List <PageItem> pageItems = new List<PageItem>();

            /* ... */

            return pageItems;

        }

        // Methods (private)
        private List<string> ExtractAndFixUrls(string content)
        {

            throw new NotImplementedException();

        }
        private List<string> ExtractTitles(string content)
        {

            throw new NotImplementedException();

        }
        private List<DateTime> ExtractAndParseCreateDates(string content)
        {

            throw new NotImplementedException();

        }
        private List<DateTime> ExtractAndParseApplicationDates(string content)
        {

            throw new NotImplementedException();

        }
        private List<string> ExtractAndCleanWorkAreas(string content)
        {

            throw new NotImplementedException();

        }
        private List<string> ExtractAndCleanWorkingHours(string content)
        {

            throw new NotImplementedException();

        }
        private List<string> ExtractAndCleanJobTypes(string content)
        {

            throw new NotImplementedException();

        }
        private List<ulong> ExtractAndParseJobIds(List<string> urls)
        {

            throw new NotImplementedException();

        }

        private string ConvertToAbsoluteUrl(string relativeUrl)
        {
            /*
                /job/8148174/Technology-Finance-Business-Partner
                => https://www.workindenmark.dk/job/8148174/Technology-Finance-Business-Partner
            */

            return string.Concat("https://www.workindenmark.dk", relativeUrl);

        }
        private DateTime ParseDate(string date)
            => DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        private string CleanWorkArea(string workArea)
            => CleanField(workArea, "Work area: ");
        private string CleanWorkingHours(string workingHours)
            => CleanField(workingHours, "Working hours: ");
        private string CleanJobType(string jobType)
            => CleanField(jobType, "Job type: ");
        private string CleanField(string field, string toRemove)
            => field.Replace(toRemove, string.Empty);
        private string ExtractJobId(string url)
        {

            /*
                https://www.workindenmark.dk/job/8148174/Technology-Finance-Business-Partner
                    => 8148174
            */

            string pattern = "(?<=/job/)[0-9]{5,}";

            if (!Regex.IsMatch(url, pattern))
                throw new Exception($"Not possible to extract JobId from '{url}' with pattern: '{pattern}'.");

            return Regex.Match(url, pattern).ToString();

        }
        private ushort CalculatePageItemNumber(int i)
        {

            throw new NotImplementedException();

        }

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.05.2021
*/