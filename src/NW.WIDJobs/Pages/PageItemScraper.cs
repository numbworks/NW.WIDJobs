using System;
using System.Collections.Generic;
using System.Globalization;
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

            ValidateXPathQueryResults
                (urls, titles, createDates, applicationDates, workAreas, workingHours, jobTypes, jobIds);

            List<PageItem> pageItems 
                = CreatePageItems(page, urls, titles, createDates, applicationDates, workAreas, workingHours, jobTypes, jobIds);

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
        private List<PageItem> CreatePageItems(
                    Page page,
                    List<string> urls,
                    List<string> titles,
                    List<DateTime> createDates,
                    List<DateTime> applicationDates,
                    List<string> workAreas,
                    List<string> workingHours,
                    List<string> jobTypes,
                    List<ulong> jobIds
                    )
        {

            List<PageItem> pageItems = new List<PageItem>();
            for (int i = 0; i < urls.Count; i++)
            {

                PageItem pageItem = new PageItem(

                        runId: page.RunId,
                        pageNumber: page.PageNumber,
                        url: urls[i],
                        title: titles[i],
                        createDate: createDates[i],
                        applicationDate: applicationDates[i],
                        workArea: workAreas[i],
                        workingHours: workingHours[i],
                        jobType: jobTypes[i],
                        jobId: jobIds[i],
                        pageItemNumber: CalculatePageItemNumber((ushort)i)

                    );

                pageItems.Add(pageItem);

            }

            return pageItems;

        }

        private void ValidateXPathQueryResults(
            List<string> urls,
            List<string> titles,
            List<DateTime> createDates,
            List<DateTime> applicationDates,
            List<string> workAreas,
            List<string> workingHours,
            List<string> jobTypes, 
            List<ulong> jobIds
            )
        {

            int[] counts = {
                    urls.Count,
                    titles.Count,
                    createDates.Count,
                    applicationDates.Count,
                    workAreas.Count,
                    workingHours.Count,
                    jobTypes.Count,
                    jobIds.Count
                };

            bool status = AreAllEqual(counts);

            if (status == false)
                throw new Exception($"At least one XPath pattern doesn't return the expected amount of {nameof(PageItem)} fields.");

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
        private bool AreAllEqual(int[] integers)
            => Array.TrueForAll(integers, val => (integers[0] == val));
        private ushort CalculatePageItemNumber(ushort i)
            => i++;

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.05.2021
*/